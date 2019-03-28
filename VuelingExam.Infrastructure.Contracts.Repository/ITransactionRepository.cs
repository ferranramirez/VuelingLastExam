using System;
using System.Collections.Generic;
using System.Text;
using VuelingExam.Infrastructure.DataModel;

namespace VuelingExam.Infrastructure.Contracts.Repository
{
    public interface ITransactionRepository : ICreate<TransactionDM>,
        IReadBySku<TransactionDM>, IReadAll<TransactionDM>
    {

    }
}
