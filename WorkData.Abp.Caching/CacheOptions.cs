﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Distributed;

namespace WorkData.Abp.Caching
{
    public class CacheOptions
    {
        /// <summary>
        /// Cache key prefix.
        /// </summary>
        public string KeyPrefix { get; set; }

        /// <summary>
        /// Global Cache entry options.
        /// </summary>
        public DistributedCacheEntryOptions GlobalCacheEntryOptions { get; set; }

        /// <summary>
        /// List of all cache configurators.
        /// (func argument:Name of cache)
        /// </summary>
        public List<Func<string, DistributedCacheEntryOptions>> CacheConfigurators { get; set; } //TODO  list item use a configurator interface instead?

        public CacheOptions()
        {
            CacheConfigurators = new List<Func<string, DistributedCacheEntryOptions>>();
            GlobalCacheEntryOptions = new DistributedCacheEntryOptions();
            KeyPrefix = "";
        }
    }
}