using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.CacheService
{
    public interface ICacheService
    {
        Task SetCacheResponseAsync(String key, object response, TimeSpan timetolive);
        Task<String> GetCacheResponseAsync(string key);
    }
}
