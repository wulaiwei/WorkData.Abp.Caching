using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Caching;

namespace WorkData.Abp.Caching
{
    public static class WorkDataCachingExtension
    {
        public static IServiceCollection ConfigureCachingServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IJsonSerializer, NewtonsoftJsonSerializer>();
            serviceCollection.AddTransient<IDistributedCacheSerializer, Utf8JsonDistributedCacheSerializer>();
            serviceCollection.AddMemoryCache();
            serviceCollection.AddDistributedMemoryCache();

            serviceCollection.AddSingleton(typeof(IDistributedCache<>), typeof(DistributedCache<>));
            serviceCollection.Configure<CacheOptions>(cacheOptions =>
            {
                cacheOptions.GlobalCacheEntryOptions.SlidingExpiration = TimeSpan.FromMinutes(20);
            });
            return serviceCollection;
        }
    }
}
