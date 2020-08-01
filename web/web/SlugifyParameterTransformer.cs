namespace tbd.web
{
    using System;
    using System.Text.RegularExpressions;
    using Microsoft.AspNetCore.Routing;

    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            if (value == null)
            {
                return null;
            }

            // Slugify value
            return Regex.Replace(
                value.ToString() ?? string.Empty,
                "([a-z])([A-Z])",
                "$1-$2",
                RegexOptions.CultureInvariant,
                TimeSpan.FromMilliseconds(100)
            ).ToLower();
        }
    }
}