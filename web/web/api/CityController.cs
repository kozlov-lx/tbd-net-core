namespace tbd.web.api
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public sealed class CityController : ApiController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Create()
        {
            throw new NotImplementedException();
        }

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