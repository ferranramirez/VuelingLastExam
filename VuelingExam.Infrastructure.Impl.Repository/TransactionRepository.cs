using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using VuelingExam.Common.Logic.Helpers;
using VuelingExam.Infrastructure.Contracts.Repository;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository.Exceptions;
using VuelingExam.Infrastructure.Impl.Repository.Resource;

namespace VuelingExam.Infrastructure.Impl.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string connectionString = ConfigHelper.AppSettings["ConnectionString"];

        public List<TransactionDM> ReadAll()
        {
            List<TransactionDM> result = new List<TransactionDM>();
            try
            {
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
            }
            #region Exceptions
            catch (InvalidCastException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (IOException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (ObjectDisposedException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (InvalidOperationException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (SqlException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (ArgumentNullException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (FormatException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (OverflowException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            #endregion
            return result;
        }
        public List<TransactionDM> CreateAll(List<TransactionDM> modelList)
        {
            List<TransactionDM> result;
            try
            {
                for (int i = 0; i < modelList.Count; i++)
                {
                    Create(modelList[i]);
                }
                result = ReadAll();
            }
            #region Exceptions
            catch (InvalidCastException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (IOException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (ObjectDisposedException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (InvalidOperationException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (SqlException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (ArgumentNullException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (FormatException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (OverflowException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            #endregion
            return result;
        }
        public TransactionDM Create(TransactionDM model)
        {
            TransactionDM result;
            int id;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string queryString = DatabaseResources.InsertTransaction;

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@Sku", model.Sku);
                        command.Parameters.AddWithValue("@Amount", model.Amount);
                        command.Parameters.AddWithValue("@Currency", model.Currency);
                        id = (int)command.ExecuteScalar();
                    }
                }
                result = ReadById(id);
            }
            #region Exceptions
            catch (InvalidCastException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (IOException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (ObjectDisposedException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (InvalidOperationException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (SqlException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (ArgumentNullException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (FormatException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (OverflowException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            #endregion
            return result;
        }
        public List<TransactionDM> ReadBySku(string id)
        {
            List<TransactionDM> result = new List<TransactionDM>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string queryString = DatabaseResources.SelectTransactionsBySku;
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@Sku", id);
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
            }
            #region Exceptions
            catch (InvalidCastException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (IOException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (ObjectDisposedException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (InvalidOperationException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (SqlException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (ArgumentNullException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (FormatException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (OverflowException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            #endregion
            return result;
        }

        public TransactionDM ReadById(int id)
        {
            TransactionDM result = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string queryString = DatabaseResources.SelectTransactionById;
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionId", id);
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
            }
            #region Exceptions
            catch (InvalidCastException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (IOException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (ObjectDisposedException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (InvalidOperationException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (SqlException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (ArgumentNullException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (FormatException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            catch (OverflowException e)
            {
                throw new VuelingExamInfrastructureException(e.Message, e.InnerException);
            }
            #endregion
            return result;
        }
    }
}
