using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Runtime.Serialization;
using System.IO;

namespace MyCaching
{
    public class RedisCaching : ICaching
    {
        private readonly ConnectionMultiplexer redis; 
        
        public RedisCaching(string hostName)
        {
            var options = new ConfigurationOptions()
            {
                AbortOnConnectFail = false,
                EndPoints = { hostName },
                AllowAdmin = true
            };
                        redis = ConnectionMultiplexer.Connect(options);         

           

        }

        public object GetFromCache(string key)
        {
            var db = redis.GetDatabase();
            byte[] dd =  db.StringGet(key);
            return dd;
        }

        public void PutToCache(string key, object item)
        {
            using (var stream = new MemoryStream())
            {
                var db = redis.GetDatabase();
                db.StringSet(key, stream.ToArray());
            }          
        }
    }
}
