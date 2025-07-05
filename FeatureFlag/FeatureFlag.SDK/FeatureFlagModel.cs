namespace FeatureFlag.SDK
{
    public class FeatureFlagModel : FeatureFlagLogin
    {
        public string ProjectName { get; set; }
        public string FlagName { get; set; }
        public bool isActive { get; set; }
    }
}
