using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using VuelingExam.Common.Logic.Helpers;
using VuelingExam.Infrastructure.Contracts.Repository;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository.Resource;

namespace VuelingExam.Infrastructure.Impl.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string connectionString = ConfigHelper.AppSettings["ConnectionString"];

        public List<TransactionDM> ReadAll()
        {
            List<TransactionDM> result = new List<TransactionDM>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryString = DatabaseResources.SelectTransactions;
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string sku = reader["Sku"].ToString();
                            decimal amount = Decimal.Parse(reader["Amount"].ToString());
                            string currency = reader["Currency"].ToString();
                            TransactionDM model = new TransactionDM(sku, amount, currency);
                            result.Add(model);
                        }
                    }
                }
            }
            return result;
        }
        public List<TransactionDM> CreateAll(List<TransactionDM> modelList)
        {
            for (int i = 0; i < modelList.Count; i++)
            {
                Create(modelList[i]);
            }
            return ReadAll();
        }
        public TransactionDM Create(TransactionDM model)
        {
            string id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryString = DatabaseResources.InsertTransaction;

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@Sku", model.Sku);
                    command.Parameters.AddWithValue("@Amount", model.Amount);
                    command.Parameters.AddWithValue("@Currency", model.Currency);
                    command.ExecuteNonQuery();
                    id = model.Sku;
                }
            }
            return ReadBySku(id);
        }

        public TransactionDM ReadBySku(string id)
        {
            TransactionDM result = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryString = DatabaseResources.SelectTransactionsBySku;
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@Sku", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string sku = reader["Sku"].ToString();
                            decimal amount = Decimal.Parse(reader["Amount"].ToString());
                            string currency = reader["Currency"].ToString();
                            result = new TransactionDM(sku, amount, currency);
                        }
                    }
                }
            }
            return result;
        }
    }
}
