using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Product.Services.CacheService;
using System.Text;

namespace WebAPI
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        public int _timeToLiveInSeconds;
        public CacheAttribute(int timeToLiveSeconds) { 
        _timeToLiveInSeconds=timeToLiveSeconds;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _cacheServices = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
            var cachekey = Generate(context.HttpContext.Request);
                var CachedResponse = await _cacheServices.GetCacheResponseAsync(cachekey);
            if (CachedResponse != null)
            {
                var contentResult = new ContentResult
                {
                    Content = CachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200

                };
                context.Result=contentResult;
                return;
            }
            var excutedcontext = await next();
            if(excutedcontext.Result is OkObjectResult response)
            {
                await _cacheServices.SetCacheResponseAsync(cachekey, response.Value, TimeSpan.FromSeconds(_timeToLiveInSeconds));
            }


        }
        private String Generate(HttpRequest request)
        {
            StringBuilder cachekey=new StringBuilder();
            cachekey.Append($"{request.Path}");
            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
                cachekey.Append($"|{key}-{value}");
            return cachekey.ToString();
        }

    }
}
