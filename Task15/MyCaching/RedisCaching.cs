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
    public class RedisCaching<T> : ICaching<T>
    {
        private readonly ConnectionMultiplexer redis;
        private readonly DataContractSerializer serializer = new DataContractSerializer(typeof(T));
        public RedisCaching(string hostName)
        {
            redis = ConnectionMultiplexer.Connect(hostName);
        }

        public T GetFromCache(string key)
        {
            IDatabase db = redis.GetDatabase();
            byte[] data =  db.StringGet(key);

            if (data == null)
            {
                return default;
            }          

            return (T)serializer.ReadObject(new MemoryStream(data));
        }

        public void PutToCache(string key, T item)
        {
            using (var stream = new MemoryStream())
            {
                var db = redis.GetDatabase();

                serializer.WriteObject(stream, item);

                db.StringSet(key, stream.ToArray());
            }          
        }
    }
}
