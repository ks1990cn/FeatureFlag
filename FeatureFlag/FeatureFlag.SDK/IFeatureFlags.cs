namespace FeatureFlag.SDK
{
    public interface IFeatureFlags
    {
        void AddFeatureFlag(AddFeatureFlagModel addFeatureFlagModel);
        bool IsFlagEnabled(string featureFlagName);
    }
}