using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;


namespace MyCaching
{
    public class InProcessCaching : ICaching
    {
        private readonly ObjectCache cache = MemoryCache.Default;

        public object GetFromCache(string key)
        {
            return cache[key];
        }

        public void PutToCache(string key, object item)
        {
            cache.Set(key, item, ObjectCache.InfiniteAbsoluteExpiration);
        }
    }
}
