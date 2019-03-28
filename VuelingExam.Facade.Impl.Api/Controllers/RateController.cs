using Microsoft.AspNetCore.Mvc;
using VuelingExam.Application.Business.Contract.ServiceLibrary;
using VuelingExam.Application.DTO;

namespace VuelingExam.Facade.Impl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        public IApplication<RateDTO> RateApplication;
        public RateController(IApplication<RateDTO> rateApplication)
        {
            RateApplication = rateApplication;
        }

        // GET: api/Rate
        [HttpGet]
        public ActionResult<TransactionDTO> Get()
        {
            return Ok(RateApplication.GetAll());
        }
    }
}
