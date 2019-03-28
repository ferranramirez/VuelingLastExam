using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuelingExam.Common.Logic.Helpers;
using VuelingExam.Infrastructure.Contracts.Repository;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository.Resource;

namespace VuelingExam.Infrastructure.Impl.Repository
{
    public class RateRepository : IRepository<RateDM>
    {
        private readonly string connectionString = ConfigHelper.AppSettings["ConnectionString"];

        public List<RateDM> ReadAll()
        {
            List<RateDM> result = new List<RateDM>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryString = DatabaseResources.SelectRates;
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = (IDataRecord)reader;
                            string from = row["from"].ToString();
                            string to = row["to"].ToString();
                            decimal rate = Decimal.Parse(row["rate"].ToString());
                            RateDM model = new RateDM(from, to, rate);
                            result.Add(model);
                        }
                    }
                }
            }
            return result;
        }

        public RateDM Create(RateDM model)
        {
            int id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryString = "INSERT INTO Rates VALUES(@From, @To, @Rate);" +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@From", model.From);
                    command.Parameters.AddWithValue("@To", model.To);
                    command.Parameters.AddWithValue("@Rate", model.Rate);
                    id = (int)command.ExecuteScalar();
                }
            }
            return ReadById(id);
        }

        private RateDM ReadById(int id)
        {
            RateDM result = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryString = DatabaseResources.SelectRatesById;
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string from = reader["From"].ToString();
                            string to = reader["To"].ToString();
                            decimal rate = Decimal.Parse(reader["Rate"].ToString());
                            result = new RateDM(from, to, rate);
                        }
                    }
                }
            }
            return result;
        }
    }
}
