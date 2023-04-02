using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace CleanArchMVC.WebUI.Helpers
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var controllerDoErro = String.Join("-",context.Request.RouteValues.Values);
 
                Console.WriteLine("Chamando Middleware global" + controllerDoErro);
            }
        }
    }
}
