using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebTest
{
    public static class RequestSetOptionExtensions
    {
        public static IApplicationBuilder UseRequestSetOption(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestSetOptionMiddleware>();
        }

    }
}
