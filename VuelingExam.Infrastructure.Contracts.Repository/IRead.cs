using System.Collections.Generic;

namespace VuelingExam.Infrastructure.Contracts.Repository
{
    public interface IRead<T>
    {
        List<T> ReadAll();
        T ReadById(int id);
    }
}