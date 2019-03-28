using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuelingExam.Application.Business.Contract.ServiceLibrary;
using VuelingExam.Application.DTO;
using VuelingExam.Facade.Impl.Api.Models;

namespace VuelingExam.Facade.Impl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipController : ControllerBase
    {
        public ITipCalculatorServiceApplication TipCalculatorServiceApplication;
        public TipController(ITipCalculatorServiceApplication tipCalculatorServiceApplication)
        {
            TipCalculatorServiceApplication = tipCalculatorServiceApplication;
        }

        // GET: api/Tip
        [HttpGet]
        public ActionResult<BillDTO> Get(BillValues values)
        {
            return Ok(TipCalculatorServiceApplication.GetTipConversion(values.Sku, values.Currency));
        }
    }
}
