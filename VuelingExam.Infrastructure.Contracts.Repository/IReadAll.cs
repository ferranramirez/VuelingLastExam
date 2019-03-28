using System.Collections.Generic;

namespace VuelingExam.Infrastructure.Contracts.Repository
{
    public interface IReadAll<T>
    {
        List<T> ReadAll();
    }
}