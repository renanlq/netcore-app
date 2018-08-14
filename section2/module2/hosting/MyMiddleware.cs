using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace hosting
{
    public class MyMiddleware
    {
        private RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Request
            var start = DateTime.Now;

            await _next(context);
        
            await Task.Delay(100); // xgh

            // Response
            var finish = DateTime.Now;

            var diff = finish.Subtract(start);

            await context.Response.WriteAsync($"A diferenca e de {diff.Milliseconds}");
        }
    }
}