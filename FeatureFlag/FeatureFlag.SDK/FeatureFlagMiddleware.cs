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
        private readonly FeatureFlagLogin _featureFlagLogin;
        public FeatureFlagMiddleware(RequestDelegate next, FeatureFlagLogin featureFlagLogin, string password)
        {
            _next = next;
            _featureFlagLogin = featureFlagLogin;
            _password = password;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (_password != null && _password == "abc")
            {
                _featureFlagLogin.IsFlagLoggedIn = true;

                await _next(context);
            }
            else
            {
                throw new Exception("Unable to connect with feature flag system. Check Password.");
            }
             
        }
    }
}
