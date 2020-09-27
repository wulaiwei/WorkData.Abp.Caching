using System;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace WorkData.Abp.Caching.Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigureCachingServices();
            serviceCollection.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "119.27.185.32:6379, password=workdata123!@#, defaultDatabase=0";
            });
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var distributedCache = serviceProvider.GetService<IDistributedCache<string>>();
            var distributedCacheA = serviceProvider.GetService<IDistributedCache<A>>();
            distributedCacheA.Set("123123",new A
            {
                Name = "123123"
            });
            var ss= distributedCacheA.Get("123123");
            
            distributedCache.Set("132","345345");
            var data = distributedCache.Get("132");
            Console.WriteLine("Hello World!");
        }
    }
}