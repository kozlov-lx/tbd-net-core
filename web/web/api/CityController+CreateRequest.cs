namespace tbd.web.api
{
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
            public string Name { get; set; }
        }
    }
}