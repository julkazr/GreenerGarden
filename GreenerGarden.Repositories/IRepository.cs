using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenerGarden.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Delete(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task<T> Insert(T obj);
        Task<T> Update(T obj, int id);
        void Save();
    }
}
