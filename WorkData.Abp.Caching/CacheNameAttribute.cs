using System;
using System.Linq;
using JetBrains.Annotations;

namespace WorkData.Abp.Caching
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct)]
    public class CacheNameAttribute : Attribute
    {
        public string Name { get; }

        public CacheNameAttribute([NotNull] string name)
        {
            Name = name;
        }

        public static string GetCacheName(Type cacheItemType)
        {
            var cacheNameAttribute = cacheItemType
                .GetCustomAttributes(true)
                .OfType<CacheNameAttribute>()
                .FirstOrDefault();

            return cacheNameAttribute != null ? cacheNameAttribute.Name : string.Empty;
        }
    }
}