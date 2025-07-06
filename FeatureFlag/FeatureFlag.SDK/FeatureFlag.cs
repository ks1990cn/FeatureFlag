using System.Runtime.Caching;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;

namespace FeatureFlag.SDK
{
    public class FeatureFlags : IFeatureFlags
    {
        FeatureFlagLoginDetails _featureFlagLoginDetails;
        IMemoryCache _memoryCache;

        public FeatureFlags(FeatureFlagLoginDetails featureFlagLoginDetails, IMemoryCache memoryCache)
        {
            _featureFlagLoginDetails = featureFlagLoginDetails;
            _memoryCache = memoryCache;
        }
        public bool IsFlagEnabled(string featureFlagName)
        {
            if (!_memoryCache.TryGetValue(_featureFlagLoginDetails.Org_Id, out List<string> flagList))
            {
                flagList = new List<string>();
            }

            return flagList.Contains(featureFlagName);
        }

        public void AddFeatureFlag(AddFeatureFlagModel addFeatureFlagModel)
        {
            // Insert query with explicit Flag_Id
            string insertQuery = @"
            INSERT INTO FeatureFlags (Flag_Id, Flag_Name, Org_Id, CreatedBy_User_Id)
            VALUES (@FlagId, @FlagName, @OrgId, @CreatedByUserId)";

            // Sample data to insert
            int flagId = 1002;
            string flagName = "EnableReport1";
            int orgId = 1;
            int createdByUserId = 1;

            SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "FeatureFlag",
                TrustServerCertificate = true,
                UserID = "sa",
                Password = "1234"
            };

            SqlConnection connection = new SqlConnection(sConnB.ConnectionString);
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@FlagId", flagId);
                command.Parameters.AddWithValue("@FlagName", flagName);
                command.Parameters.AddWithValue("@OrgId", orgId);
                command.Parameters.AddWithValue("@CreatedByUserId", createdByUserId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("Inserted rows: " + rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting data: " + ex.Message);
                }
            }
        }
    }
}
