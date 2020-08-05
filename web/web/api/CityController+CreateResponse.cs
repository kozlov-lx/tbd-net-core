namespace tbd.web.api
{
    using System.ComponentModel.DataAnnotations;
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
            [Required]
            public string Id { get; set; }
        }
    }
}