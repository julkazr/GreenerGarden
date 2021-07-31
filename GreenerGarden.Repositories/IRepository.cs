using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenerGarden.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Delete(int id);
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        T Insert(T obj);
        T Update(T obj);
        void Save();
    }
}
