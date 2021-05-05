using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Service.Interface
{
    public interface IGeneric<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> Add(T obj);
        Task<bool> Update(T obj);
        Task<bool> Delete(int id);

    }
}
