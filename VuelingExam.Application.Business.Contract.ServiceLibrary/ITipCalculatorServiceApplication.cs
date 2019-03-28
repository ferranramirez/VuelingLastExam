using System;
using System.Collections.Generic;
using System.Text;
using VuelingExam.Application.DTO;

namespace VuelingExam.Application.Business.Contract.ServiceLibrary
{
    public interface ITipCalculatorServiceApplication
    {
        BillDTO GetTipConversion(string sku, string currency);
    }
}
