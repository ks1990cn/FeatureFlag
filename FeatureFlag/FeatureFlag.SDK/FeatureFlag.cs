using System.Runtime.Caching;

namespace FeatureFlag.SDK
{
    public class FeatureFlags
    {
        MemoryCache cache = MemoryCache.Default;
        public FeatureFlags()
        {
                
        }
        public bool IsFeatureFlagEnabled(FeatureFlagModel featureFlagModel)
        {
            return (bool)cache[featureFlagModel.FlagName];
        }

        public void AddFeatureFlag(FeatureFlagModel featureFlagModel)
        {

            string key = "myKey";
            cache.Add(new CacheItem(key) { Value = true}, new CacheItemPolicy() { });

            //if (value == null)
            //{
            //    value = true;
            //    cache.Set(key, value, DateTimeOffset.Now.AddMinutes(5));
            //}

        }
        public void UpdateFeatureFlag(FeatureFlagModel featureFlagModel)
        {

        }
        public void DeleteFeatureFlag(FeatureFlagModel featureFlagModel)
        {

        }
    }
}
