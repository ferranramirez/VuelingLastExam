using System.Collections.Generic;

namespace VuelingExam.Infrastructure.Contracts.Repository
{
    public interface ICreate<T>
    {
        List<T> CreateAll(List<T> modelList);
        T Create(T model);
    }
}