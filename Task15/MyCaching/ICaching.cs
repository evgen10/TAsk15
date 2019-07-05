using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCaching
{
    public interface ICaching
    {
        void PutToCache(string key, object item);
        object GetFromCache(string key);
    }
}
