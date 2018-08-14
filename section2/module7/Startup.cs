using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace module7
{
    public class Startup
    {
        public void configure(IApplicationBuilder app)
        {
            app.Run(context => context.Response.WriteAsync("Olá mundo 2."));
        }
    }
}