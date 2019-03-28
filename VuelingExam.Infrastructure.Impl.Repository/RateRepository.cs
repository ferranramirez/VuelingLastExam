using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using VuelingExam.Common.Logic.Helpers;
using VuelingExam.Infrastructure.Contracts.Repository;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository.Exceptions;
using VuelingExam.Infrastructure.Impl.Repository.Resource;

namespace VuelingExam.Infrastructure.Impl.Repository
{
    public class RateRepository : IRateRepository
    {
        private readonly string connectionString = ConfigHelper.AppSettings["ConnectionString"];

        public List<RateDM> ReadAll()
        {
            List<RateDM> result = new List<RateDM>();
            try
            {
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
        public List<RateDM> CreateAll(List<RateDM> modelList)
        {
            List<RateDM> result;
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
        public RateDM Create(RateDM model)
        {
            RateDM result;
            int id;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string queryString = DatabaseResources.InsertRate;

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@From", model.From);
                        command.Parameters.AddWithValue("@To", model.To);
                        command.Parameters.AddWithValue("@Rate", model.Rate);
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
        public RateDM ReadById(int id)
        {
            RateDM result = null;
            try
            {
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
