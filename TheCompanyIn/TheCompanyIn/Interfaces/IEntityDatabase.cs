using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCompanyIn.Interfaces
{
    public interface IEntityDatabase<T>
    {
        Task<T> Get(string id);
        Task<List<T>> Get();
        Task<bool> Insert(T obj);
        Task<bool> Delete(T obj);
    }
}
