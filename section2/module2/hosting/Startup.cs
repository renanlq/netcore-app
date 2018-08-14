using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace hosting
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // app.Use(async (context, next) => {
            //     context.Response.Headers.Add("Middleware", "MiddlewareNetCore");
            //     await next.Invoke();
            // });

            app.UseMiddleware<MyMiddleware>();

            app.Run(context => context.Response.WriteAsync("Ola mundo 2 | "));
        }
    }
}