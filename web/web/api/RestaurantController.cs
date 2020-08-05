namespace tbd.web.api
{
    using System.Net;
    using database;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public sealed partial class RestaurantController : ApiController
    {
        private readonly TbdDbContext _dbContext;

        public RestaurantController(TbdDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        ///     Creates a restaurant.
        /// </summary>
        /// <remarks>
        ///     Sample request:
        ///     POST
        ///     {
        ///         "name": "Restaurant",
        ///         "city": "1"
        ///     }
        /// </remarks>
        /// <returns>The id of the newly created restaurant.</returns>
        /// <response code="201">Returns the id of the newly created restaurant.</response>
        /// <response code="400">If the name or city is empty or the restaurant already exists.</response>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CreateResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreateRequest request)
        {
            int cityId;
            try
            {
                cityId = JsonConvert.DeserializeObject<int>(request.City);
            }
            catch (JsonReaderException)
            {
                this.ModelState.AddModelError(
                    nameof(CreateRequest.City),
                    "Invalid city id."
                );
                return this.BadRequest(this.ModelState);
            }
            
            var restaurant = new Restaurant
            {
                Name = request.Name?.Trim(),
                CityId = cityId,
            };

            this._dbContext.Set<Restaurant>().Add(restaurant);
            try
            {
                this._dbContext.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                var error = new TdbDbError(exception);
                if (error.IsUniqueViolation())
                {
                    this.ModelState.AddModelError(
                        nameof(CreateRequest.Name),
                        "The restaurant already exists."
                    );
                    return this.BadRequest(this.ModelState);
                }

                throw;
            }

            return new ObjectResult(new CreateResponse(restaurant))
            {
                StatusCode = (int) HttpStatusCode.Created,
            };
        }
    }
}