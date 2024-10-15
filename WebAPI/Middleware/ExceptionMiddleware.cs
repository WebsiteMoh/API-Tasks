using Product.Services.Response_Handler;
using System.Net;

namespace WebAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _envrioment;
        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment envrioment)
        {
            _next = next;
            _envrioment = envrioment;
        }
        public async void Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = _envrioment.IsDevelopment() ?
                    new CustomException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace) : new CustomException((int)HttpStatusCode.InternalServerError);
            }

        }
    }
}
