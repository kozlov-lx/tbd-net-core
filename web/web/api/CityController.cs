namespace tbd.web.api
{
    using System.Linq;
    using System.Net;
    using database;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

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
        [ProducesResponseType(typeof(CreateResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreateRequest request)
        {
            var city = new City
            {
                Name = request.Name?.Trim(),
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
                    this.ModelState.AddModelError(
                        nameof(CreateRequest.Name),
                        "The city already exists."
                    );
                    return this.BadRequest(this.ModelState);
                }

                throw;
            }

            return new ObjectResult(new CreateResponse(city))
            {
                StatusCode = (int) HttpStatusCode.Created,
            };
        }

        /// <summary>
        ///     Retrieves a list of restaurants in the city.
        /// </summary>
        /// <param name="city">the id of the city</param>
        /// <param name="pageIndex">the index of the page (starts from 0)</param>
        /// <param name="pageSize">the size of the page</param>
        [HttpGet]
        [Route("{city}/restaurants")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetRestaurantsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRestaurants(
            string city,
            [FromQuery] int? pageIndex,
            [FromQuery] int? pageSize)
        {
            int cityId;
            try
            {
                cityId = JsonConvert.DeserializeObject<int>(city);
            }
            catch (JsonReaderException)
            {
                this.ModelState.AddModelError(
                    nameof(city),
                    "Invalid city id."
                );
                return this.BadRequest(this.ModelState);
            }
            
            var response = new GetRestaurantsResponse
            {
                PageIndex = pageIndex ?? 0,
                PageSize = pageSize ?? 25,
            };

            if (response.PageIndex < 0)
            {
                this.ModelState.AddModelError(
                    nameof(pageIndex),
                    "Invalid page index."
                );
                return this.BadRequest(this.ModelState);
            }

            if (response.PageSize <= 0)
            {
                this.ModelState.AddModelError(
                    nameof(pageSize),
                    "Invalid page size."
                );
                return this.BadRequest(this.ModelState);
            }

            const int maxPageSize = 100;
            if (response.PageSize > maxPageSize)
            {
                this.ModelState.AddModelError(
                    nameof(pageSize),
                    "The max value of page size is 100."
                );
                return this.BadRequest(this.ModelState);
            }

            response.Restaurants = this._dbContext.Set<Restaurant>()
                .Where(p => p.CityId == cityId)
                .Skip(response.PageIndex * response.PageSize)
                .Take(response.PageSize)
                .Select(p => new CityRestaurant
                {
                    Id = JsonConvert.SerializeObject(p.Id),
                    Name = p.Name,
                }).ToList();

            return this.Ok(response);
        }
    }
}