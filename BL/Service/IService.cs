using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Service
{
    public interface IService<T>
    {
        T Get(int id);
        IEnumerable<T> Get();
        void Post(T item);
        void Delete(int id);
        void Put(T item);
    }

}
