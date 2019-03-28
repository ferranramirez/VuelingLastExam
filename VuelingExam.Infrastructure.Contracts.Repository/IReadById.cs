using System;
using System.Collections.Generic;
using System.Text;

namespace VuelingExam.Infrastructure.Contracts.Repository
{
    public interface IReadById<T>
    {
        T ReadById(int id);
    }
}
