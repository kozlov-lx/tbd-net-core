namespace tbd.web.api
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public sealed class CityController : ApiController
    {
        /// <summary>
        ///     Creates a city.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Create()
        {
            throw new NotImplementedException();
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