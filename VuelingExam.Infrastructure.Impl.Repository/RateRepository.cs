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
                            int rateId = Int16.Parse(row["RateId"].ToString());
                            string from = row["from"].ToString();
                            string to = row["to"].ToString();
                            decimal rate = Decimal.Parse(row["rate"].ToString());
                            RateDM model = new RateDM(rateId, from, to, rate);
                            result.Add(model);
                        }
                    }
                }
            }
            return result;
        }
    }
}
