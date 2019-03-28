using System.Collections.Generic;

namespace VuelingExam.Infrastructure.Contracts.Repository
{
    public interface IReadBySku<T>
    {
        List<T> ReadBySku(string id);
    }
}