using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using VuelingExam.Common.Logic.Resources;

namespace VuelingExam.Common.Logic.Helpers
{
    public static class ConfigHelper
    {
        public static IConfiguration AppSettings
        {
            get
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                return builder.Build();
            }
        }

        public static void CleanDatabase()
        {
            string connectionString = ConfigHelper.AppSettings["ConnectionString"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryString = DatabaseResources.DeleteTables;
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
