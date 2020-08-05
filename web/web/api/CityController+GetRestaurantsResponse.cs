namespace tbd.web.api
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public sealed partial class CityController
    {
        public sealed class GetRestaurantsResponse
        {
            [Required]
            public int PageIndex { get; set; }

            [Required]
            public int PageSize { get; set; }

            [Required]
            public List<CityRestaurant> Restaurants { get; set; }
        }

        public sealed class CityRestaurant
        {
            [Required]
            public string Id { get; set; }

            [Required]
            public string Name { get; set; }
        }
    }
}