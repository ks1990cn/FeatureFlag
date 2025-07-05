using System.Runtime.Caching;

namespace FeatureFlag.SDK
{
    public class FeatureFlags : IFeatureFlags
    {
        FeatureFlagLoginDetails _featureFlagLoginDetails;

        public FeatureFlags(FeatureFlagLoginDetails featureFlagLoginDetails)
        {
            _featureFlagLoginDetails = featureFlagLoginDetails;
        }
        public void IsFlagEnabled()
        {

        }

        public void AddFeatureFlag(AddFeatureFlagModel addFeatureFlagModel)
        {
          
        }
    }
}
