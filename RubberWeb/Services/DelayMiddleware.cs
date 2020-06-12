using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace RubberWeb.Services
{
    public class DelayMiddleware
    {
        private RequestDelegate Next { get; }

        public DelayMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var delay = context.Request.Headers["delay"].ToString();

            if(int.TryParse(delay, out int delayValue))
            {
                await Task.Delay(TimeSpan.FromMilliseconds(delayValue));
            }

            await Next(context);
        }
    }
}
