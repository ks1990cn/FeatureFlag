using FeatureFlag.SDK;
public class Program
{
    private static void Main(string[] args)
    {
        var featureFlag = new FeatureFlags();
        featureFlag.AddFeatureFlag(new FeatureFlagModel());
        if (featureFlag.IsFeatureFlagEnabled(new FeatureFlag.SDK.FeatureFlagModel() { FlagName = "myKey" }))
        {

        }
    }
}