namespace tbd.web.api
{
    using System.ComponentModel.DataAnnotations;

    public sealed partial class CityController
    {
        /// <summary>
        ///     A payload to create a new city.
        /// </summary>
        public sealed class CreateRequest
        {
            /// <summary>
            ///     The name of the city.
            /// </summary>
            [Required]
            public string Name { get; set; }
        }
    }
}