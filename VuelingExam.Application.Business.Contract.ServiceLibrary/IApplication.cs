using System;
using System.Collections.Generic;
using System.Text;

namespace VuelingExam.Application.Business.Contract.ServiceLibrary
{
    public interface IApplication<T>
    {
        List<T> GetAll();
    }
}
