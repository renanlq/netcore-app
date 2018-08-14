using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace hosting
{
    public class Startup
    {
        private IConfigurationRoot _configuration;

        public Startup (IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("application.json");

            builder.AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app)
        {
            // 1
            // app.Use(async (context, next) => {
            //     context.Response.Headers.Add("Middleware", "MiddlewareNetCore");
            //     await next.Invoke();
            // });

            // 2
            // app.UseMiddleware<MyMiddleware>();

            // 3
            var applicationName = _configuration.GetValue<string>("ApplicationName");
            
            app.Run(context => context.Response.WriteAsync($"Ola mundo, modulo 2: {applicationName}."));
        }
    }
}