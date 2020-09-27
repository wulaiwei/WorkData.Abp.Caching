using System;
using Newtonsoft.Json;
using WorkData.Abp.Caching;

namespace Volo.Abp.Caching
{
    public class NewtonsoftJsonSerializer : IJsonSerializer
    {
        public string Serialize(object obj, bool camelCase = true, bool indented = false)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T Deserialize<T>(string jsonString, bool camelCase = true)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public object Deserialize(Type type, string jsonString, bool camelCase = true)
        {
            return JsonConvert.DeserializeObject(jsonString, type);
        }
    }
}