namespace tbd.web.api
{
    using System.ComponentModel.DataAnnotations;
    using database;
    using Newtonsoft.Json;

    public sealed partial class RestaurantController
    {
        /// <summary>
        ///     A newly created restaurant.
        /// </summary>
        public sealed class CreateResponse
        {
            public CreateResponse(Restaurant restaurant)
            {
                this.Id = JsonConvert.SerializeObject(restaurant.Id);
            }

            /// <summary>
            ///     The id of the restaurant.
            /// </summary>
            [Required]
            public string Id { get; set; }
        }
    }
}