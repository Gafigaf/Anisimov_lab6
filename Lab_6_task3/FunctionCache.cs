using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Lab_6_task3
{

    public class FunctionCache<TKey, TResult>
    {
        public FunctionCache(Func<int, string> expensiveFunction)
        {
            throw new NotImplementedException();
        }

        public class CacheFunction<TKey, TResult>
        {
            private Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();
            private Func<TKey, TResult> func;

            public CacheFunction(Func<TKey, TResult> func)
            {
                this.func = func;
            }

            public TResult GetResult(TKey key, TimeSpan cacheDuration)
            {
                if (cache.ContainsKey(key) && !IsCacheExpired(key, cacheDuration))
                {
                    return cache[key].Result;
                }

                TResult result = func(key);
                cache[key] = new CacheItem(result, DateTime.Now);

                return result;
            }

            private bool IsCacheExpired(TKey key, TimeSpan cacheDuration)
            {
                DateTime currentTime = DateTime.Now;
                DateTime cacheTime = cache[key].Timestamp;
                return currentTime - cacheTime > cacheDuration;
            }

            private class CacheItem
            {
                public TResult Result { get; }
                public DateTime Timestamp { get; }

                public CacheItem(TResult result, DateTime timestamp)
                {
                    Result = result;
                    Timestamp = timestamp;
                }
            }

        }

        public string GetResult(int p0, TimeSpan fromSeconds)
        {
            throw new NotImplementedException();
        }
    }
}