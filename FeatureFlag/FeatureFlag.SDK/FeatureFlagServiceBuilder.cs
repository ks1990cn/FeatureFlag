using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureFlag.SDK
{
    public static class FeatureFlagServiceBuilder
    {

        public static void FeatureFlagBuilder(this IServiceCollection services)
        {
            services.AddSingleton<FeatureFlagLoginDetails>();
            services.AddTransient<IFeatureFlags, FeatureFlags>();
        }
    }
}
