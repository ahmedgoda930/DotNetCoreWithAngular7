using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Abstracts
{
    public interface IRepository<T>
    {
        Task<bool> Create(T Entity);
        Task<bool> Update(T Entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<T>> ReadAll();
        Task<T> ReadById(int id);
    }
}
