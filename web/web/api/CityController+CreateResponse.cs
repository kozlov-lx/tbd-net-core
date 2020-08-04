namespace tbd.web.api
{
    using database;
    using Newtonsoft.Json;

    public sealed partial class CityController
    {
        /// <summary>
        ///     A newly created city.
        /// </summary>
        public sealed class CreateResponse
        {
            public CreateResponse(City city)
            {
                this.Id = JsonConvert.SerializeObject(city.Id);
            }

            /// <summary>
            ///     The id of the city.
            /// </summary>
            public string Id { get; set; }
        }
    }
}