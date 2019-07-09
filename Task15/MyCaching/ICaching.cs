using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCaching
{
    public interface ICaching<T>
    {
        void PutToCache(string key, T item);
        T GetFromCache(string key);
    }
}
