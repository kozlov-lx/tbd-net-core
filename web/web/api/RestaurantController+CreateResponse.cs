namespace tbd.web.api
{
    using database;
    using Newtonsoft.Json;

    public sealed partial class RestaurantController
    {
        /// <summary>
        ///     A newly created city.
        /// </summary>
        public sealed class CreateResponse
        {
            public CreateResponse(Restaurant restaurant)
            {
                this.Id = JsonConvert.SerializeObject(restaurant.Id);
            }

            /// <summary>
            ///     The id of the city.
            /// </summary>
            public string Id { get; set; }
        }
    }
}