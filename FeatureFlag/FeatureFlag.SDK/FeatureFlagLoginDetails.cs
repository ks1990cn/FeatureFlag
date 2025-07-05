using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlag.SDK
{
    public class FeatureFlagLoginDetails 
    {
        public bool IsFlagLoggedIn { get; set; }

        public int Org_Id { get; set; }
    }
}
