using LP.University.API.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LP.University.API.Extensions
{
    public static class StringExtensions
    {
        public static LinkDto GetLink(this string self, Controller context, object routeData)
        {
            var url = context.Url.RouteUrl(self, routeData);
            return new LinkDto { Href = url };
        }
    }
}
