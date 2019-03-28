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
        public TransactionApplication(ITransactionRepository transactionRepository, Mapper mapper)
        {
            TransactionRepository = transactionRepository;
            Mapper = mapper;
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
                throw new VuelingExamApplicationException(e.Message, e.InnerException);
            }
            #endregion
            return result;
        }
    }
}
