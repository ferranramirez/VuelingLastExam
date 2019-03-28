using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuelingExam.Application.Business.Contract.ServiceLibrary;
using VuelingExam.Application.DTO;

namespace VuelingExam.Facade.Impl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public IApplication<TransactionDTO> TransactionApplication;
        public TransactionController(IApplication<TransactionDTO> transactionApplication)
        {
            TransactionApplication = transactionApplication;
        }
        
        // GET: api/Transaction
        [HttpGet]
        public ActionResult<TransactionDTO> Get()
        {
            return Ok(TransactionApplication.GetAll());
        }
    }
}
