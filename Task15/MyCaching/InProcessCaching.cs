using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;


namespace MyCaching
{
    public class InProcessCaching<T> : ICaching<T>
    {
        private readonly ObjectCache cache;

        public InProcessCaching()
        {
            cache = MemoryCache.Default;
        }

        public T GetFromCache(string key)
        {
            return (T)cache[key];
        }

        public void PutToCache(string key, T item)
        {
            cache.Set(key, item, ObjectCache.InfiniteAbsoluteExpiration);
        }
    }
}
