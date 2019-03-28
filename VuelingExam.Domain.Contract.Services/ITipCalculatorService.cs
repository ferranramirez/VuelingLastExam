using System.Collections.Generic;
using VuelingExam.Domain.BusinessEntities;

namespace VuelingExam.Domain.Contract.Services
{
    public interface ITipCalculatorService
    {
        decimal RecursiveDFS(string start, string end);

        decimal GetTip(List<RateBE> rateList, TransactionBE transaction, string currency);

        void GenerateGraph(List<RateBE> rateList);
    }
}
