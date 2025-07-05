using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FeatureFlag.SDK
{
    public class FeatureFlagMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _password;
        private readonly FeatureFlagLoginDetails _featureFlagLoginDetails;
        public FeatureFlagMiddleware(RequestDelegate next, FeatureFlagLoginDetails featureFlagLogin, string password)
        {
            _next = next;
            _featureFlagLoginDetails = featureFlagLogin;
            _password = password;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (_password != null && _password == "abc")
            {
                _featureFlagLoginDetails.IsFlagLoggedIn = true;
                _featureFlagLoginDetails.Org_Id = 1;
                await _next(context);
            }
            else
            {
                throw new Exception("Unable to connect with feature flag system. Check Password.");
            }
             
        }
    }
}
