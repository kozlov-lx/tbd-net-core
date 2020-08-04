namespace tbd.web.api
{
    using System;
    using System.Net;
    using database;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public sealed partial class CityController : ApiController
    {
        private readonly TbdDbContext _dbContext;

        public CityController(TbdDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        ///     Creates a city.
        /// </summary>
        /// <remarks>
        ///     Sample request:
        ///     POST
        ///     {
        ///         "name": "City"
        ///     }
        /// </remarks>
        /// <returns>The id of the newly created city.</returns>
        /// <response code="201">Returns the id of the newly created city.</response>
        /// <response code="400">If the name is empty or the city already exists.</response>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreateRequest request)
        {
            request.Name = request.Name?.Trim();
            if (string.IsNullOrEmpty(request.Name))
            {
                return this.BadRequest("The name is empty");
            }

            var city = new City
            {
                Name = request.Name,
            };

            this._dbContext.Set<City>().Add(city);
            try
            {
                this._dbContext.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                var error = new TdbDbError(exception);
                if (error.IsUniqueViolation())
                {
                    return this.BadRequest("The city already exists.");
                }
            }

            return new ObjectResult(new CreateResponse(city))
            {
                StatusCode = (int) HttpStatusCode.Created,
            };
        }

        /// <summary>
        ///     Retrieves a list of restaurants in the city.
        /// </summary>
        /// <param name="cityId">the id of the city</param>
        [HttpGet]
        [Route("{cityId}/restaurants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void GetRestaurants(string cityId)
        {
            throw new NotImplementedException();
        }
    }
}