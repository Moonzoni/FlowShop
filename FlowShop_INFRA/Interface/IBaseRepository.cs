using System;
using System.Collections.Generic;
using System.Text;

namespace FlowShop_INFRA.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T Entity);
        T Update(T Entity);
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
