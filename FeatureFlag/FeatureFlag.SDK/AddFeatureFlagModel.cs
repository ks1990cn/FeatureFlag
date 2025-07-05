using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlag.SDK
{
    public class AddFeatureFlagModel : FeatureFlagLogin
    {
        public int FlagId { get; set; }
        public string FlagName { get; set; }
        public bool IsEnabled { get; set; }
        public int Org_Id { get; set; }
        public int Created_By_User_Id { get; set; }
    }
}
