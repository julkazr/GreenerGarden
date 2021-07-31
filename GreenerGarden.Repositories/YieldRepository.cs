using GreenerGarden.Data;
using GreenerGarden.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenerGarden.Repositories
{
    public interface IYieldRepository : IRepository<Yield>
    {

    }
    public class YieldRepository
    {
        private readonly ApplicationDbContext _appContext;
        public YieldRepository(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }
        public Yield GetById(int id)
        {
            var yield = _appContext.Yields.Find(id);
            return yield;
        }

        public Yield Delete(int id)
        {
            Yield existing = _appContext.Yields.Find(id);
            var result = _appContext.Yields.Remove(existing).Entity;
            return result;
        }

        public async Task<IEnumerable<Yield>> GetAllAsync()
        {
            var data = await _appContext.Yields.ToListAsync();
            return data;
        }

        public Yield Insert(Yield obj)
        {
            var data = _appContext.Yields.Add(obj).Entity;
            return data;
        }

        public void Save()
        {
            _appContext.SaveChanges();
        }

        public Yield Update(Yield obj)
        {
            var updatedEntry = _appContext.Yields.Attach(obj).Entity;
            _appContext.Entry(obj).State = EntityState.Modified;
            return updatedEntry;
        }
    }
}
