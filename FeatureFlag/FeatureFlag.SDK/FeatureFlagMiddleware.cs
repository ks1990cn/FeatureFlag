using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;

namespace FeatureFlag.SDK
{
    public class FeatureFlagMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _password;
        private readonly FeatureFlagLoginDetails _featureFlagLoginDetails;
        private readonly IMemoryCache _memoryCache;
        public FeatureFlagMiddleware(RequestDelegate next, IMemoryCache memoryCache, FeatureFlagLoginDetails featureFlagLogin, string password)
        {
            _next = next;
            _featureFlagLoginDetails = featureFlagLogin;
            _password = password;
            _memoryCache = memoryCache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (_password != null && _password == "abc")
            {
                _featureFlagLoginDetails.IsFlagLoggedIn = true;
                _featureFlagLoginDetails.Org_Id = 1;
                CacheFeatureFlagAndState(1);
                await _next(context);
            }
            else
            {
                throw new Exception("Unable to connect with feature flag system. Check Password.");
            }

        }

        private void CacheFeatureFlagAndState(int org_id)
        {
            string selectQuery = "SELECT Org_Id, Flag_Name FROM FeatureFlags WHERE Is_Enabled = 1";

            Dictionary<string, bool> featureFlags = new Dictionary<string, bool>();
            SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "FeatureFlag",
                TrustServerCertificate = true,
                UserID = "sa",
                Password = "1234"
            };
            string query = "SELECT Org_Id, Flag_Name FROM FeatureFlags WHERE Is_Enabled = 1";

            using (SqlConnection connection = new SqlConnection(sConnB.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int orgId = Convert.ToInt32(reader["Org_Id"]);
                            string flagName = reader["Flag_Name"].ToString();

                            // Get existing from cache or initialize
                            if (!_memoryCache.TryGetValue(orgId, out List<string> flagList))
                            {
                                flagList = new List<string>();
                            }
                            if (!flagList.Contains(flagName))
                            {
                                flagList.Add(flagName);

                                // Set (or update) the list for this org
                                _memoryCache.Set(orgId, flagList, TimeSpan.FromMinutes(10));
                            }
                           
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching data: " + ex.Message);
                }
            }

        }
    }
}
              
