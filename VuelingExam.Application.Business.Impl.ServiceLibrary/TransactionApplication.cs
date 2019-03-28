using Serilog;
using System.Collections.Generic;
using VuelingExam.Application.Business.Contract.ServiceLibrary;
using VuelingExam.Application.Business.Impl.ServiceLibrary.Exceptions;
using VuelingExam.Application.DTO;
using VuelingExam.Common.Mapper;
using VuelingExam.Infrastructure.Contracts.Repository;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository.Exceptions;

namespace VuelingExam.Application.Business.Impl.ServiceLibrary
{
    public class TransactionApplication : IApplication<TransactionDTO>
    {
        ITransactionRepository TransactionRepository;
        Mapper Mapper;
        ILogger Log;
        public TransactionApplication(ITransactionRepository transactionRepository, Mapper mapper, ILogger logger)
        {
            TransactionRepository = transactionRepository;
            Mapper = mapper;
            Log = logger;
        }

        public List<TransactionDTO> GetAll()
        {
            List<TransactionDTO> result;
            try
            {
                List<TransactionDM> readRates = TransactionRepository.ReadAll();
                result = Mapper.MapList<TransactionDM, TransactionDTO>(readRates);
            }
            #region Exceptions
            catch (VuelingExamInfrastructureException e)
            {
                Log.Error(e.Message);
                Log.Warning(e.StackTrace);
                throw new VuelingExamApplicationException(e.Message, e.InnerException);
            }
            #endregion
            return result;
        }
    }
}
