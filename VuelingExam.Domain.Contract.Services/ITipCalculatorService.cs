using System.Collections.Generic;
using VuelingExam.Domain.BusinessEntities;

namespace VuelingExam.Domain.Contract.Services
{
    public interface ITipCalculatorService
    {
        decimal RecursiveDFS(string start, string end);

        BillBE GetBill(List<RateBE> rateList, List<TransactionBE> transactionList, string currency);
        decimal GetTransactionAmount(TransactionBE transaction, string currency);

        void GenerateGraph(List<RateBE> rateList);
    }
}
