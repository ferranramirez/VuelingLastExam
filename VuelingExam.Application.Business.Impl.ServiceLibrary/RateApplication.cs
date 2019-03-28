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
    public class RateApplication : IApplication<RateDTO>
    {
        IRateRepository RateRepository;
        Mapper Mapper;
        ILogger Log;
        public RateApplication(IRateRepository rateRepository, Mapper mapper, ILogger logger)
        {
            RateRepository = rateRepository;
            Mapper = mapper;
            Log = logger;
        }

        public List<RateDTO> GetAll()
        {
            List<RateDTO> result;
            try
            {
                List<RateDM> readRates = RateRepository.ReadAll();
                result = Mapper.MapList<RateDM, RateDTO>(readRates);
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
