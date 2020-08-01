namespace tbd.web.api
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public sealed class RestaurantController : ApiController
    {
        /// <summary>
        ///     Creates a restaurant.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Create()
        {
            throw new NotImplementedException();
        }
    }
}