using System.Collections.Generic;
using VuelingExam.Application.Business.Contract.ServiceLibrary;
using VuelingExam.Application.Business.Impl.ServiceLibrary.Exceptions;
using VuelingExam.Common.Mapper;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Domain.Contract.Services;
using VuelingExam.Domain.Impl.Services.Exceptions;
using VuelingExam.Infrastructure.Contracts.Repository;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository.Exceptions;

namespace VuelingExam.Application.Business.Impl.ServiceLibrary
{
    public class FetchServiceApplication : IFetchServiceApplication
    {
        IFetchService FetchService;
        IRateRepository RateRepository;
        ITransactionRepository TransactionRepository;
        Mapper Mapper;
        public FetchServiceApplication(IFetchService fetchService,
            IRateRepository rateRepository, ITransactionRepository transactionRepository,
            Mapper mapper)
        {
            FetchService = fetchService;
            RateRepository = rateRepository;
            TransactionRepository = transactionRepository;
            Mapper = mapper;
        }

        public bool FetchAndStore()
        {
            bool result = false;
            try
            {
                List<RateBE> fetchedRates = FetchService.FetchRates();
                List<RateDM> ratesToStore = Mapper.MapList<RateBE, RateDM>(fetchedRates);
                RateRepository.CreateAll(ratesToStore);

                List<TransactionBE> fetchedTransactions = FetchService.FetchTransactions();
                List<TransactionDM> transactionsToStore = 
                    Mapper.MapList<TransactionBE, TransactionDM>(fetchedTransactions);
                TransactionRepository.CreateAll(transactionsToStore);

                result = true;
            }
            #region Exceptions
            catch (VuelingExamDomainException e)
            {
                throw new VuelingExamApplicationException(e.Message, e.InnerException);
            }
            catch (VuelingExamInfrastructureException e)
            {
                throw new VuelingExamApplicationException(e.Message, e.InnerException);
            }
            #endregion
            return result;
        }
    }
}
