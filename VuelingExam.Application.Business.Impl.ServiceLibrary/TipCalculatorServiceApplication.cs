using System.Collections.Generic;
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
    public class TipCalculatorServiceApplication
    {
        ITipCalculatorService TipCalculatorService;
        ITransactionRepository TransactionRepository;
        IRateRepository RateRepository;
        Mapper Mapper;
        public TipCalculatorServiceApplication(ITipCalculatorService tipCalculatorService,
            ITransactionRepository transactionRepository, IRateRepository rateRepository,
            Mapper mapper)
        {
            TipCalculatorService = tipCalculatorService;
            TransactionRepository = transactionRepository;
            RateRepository = rateRepository;
            Mapper = mapper;
        }

        public void GetTipConversion(string sku, string currency)
        {
            //BillDTO result;
            
            try
            {
                List<RateDM> readRates = RateRepository.ReadAll();
                List<RateBE> ratesBusiness = Mapper.MapList<RateDM, RateBE>(readRates);

                List<TransactionDM> readTransactions = TransactionRepository.ReadBySku(sku);
                List<TransactionBE> transactionsBusiness = Mapper.MapList<TransactionDM,
                    TransactionBE>(readTransactions);

                
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
            //return result;
        }
    }
}
