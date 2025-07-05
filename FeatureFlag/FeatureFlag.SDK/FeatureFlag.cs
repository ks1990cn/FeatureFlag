using System.Runtime.Caching;

namespace FeatureFlag.SDK
{
    public class FeatureFlags : IFeatureFlags
    {
        FeatureFlagLogin _featureFlagLogin;
        public FeatureFlags(FeatureFlagLogin featureFlagLogin)
        {
            _featureFlagLogin = featureFlagLogin;
        }
        public void IsFlagEnabled()
        {

        }
    }
}
