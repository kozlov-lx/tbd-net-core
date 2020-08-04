namespace tbd.web.api
{
    using System.ComponentModel.DataAnnotations;

    public sealed partial class RestaurantController
    {
        /// <summary>
        ///     A payload to create a new restaurant.
        /// </summary>
        public sealed class CreateRequest
        {
            /// <summary>
            ///     The name of the city.
            /// </summary>
            [Required]
            public string Name { get; set; }

            /// <summary>
            ///     The id of the city.
            /// </summary>
            [Required]
            public string City { get; set; }
        }
    }
}