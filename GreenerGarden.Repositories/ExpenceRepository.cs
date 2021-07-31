using GreenerGarden.Data;
using GreenerGarden.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenerGarden.Repositories
{
    public interface IExpenceRepository : IRepository<Expence>
    {

    }

    public class ExpenceRepository : IExpenceRepository
    {
        private readonly ApplicationDbContext _appContext;
        public ExpenceRepository(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }
        public Expence GetById(int id)
        {
            var expence = _appContext.Expences.Find(id);
            return expence;
        }

        public Expence Delete(int id)
        {
            Expence existing = _appContext.Expences.Find(id);
            var result = _appContext.Expences.Remove(existing).Entity;
            return result;
        }

        public async Task<IEnumerable<Expence>> GetAllAsync()
        {
            var data = await _appContext.Expences.ToListAsync();
            return data;
        }

        public Expence Insert(Expence obj)
        {
            var data = _appContext.Expences.Add(obj).Entity;
            return data;
        }

        public void Save()
        {
            _appContext.SaveChanges();
        }

        public Expence Update(Expence obj)
        {
            var updatedEntry = _appContext.Expences.Attach(obj).Entity;
            _appContext.Entry(obj).State = EntityState.Modified;
            return updatedEntry;
        }
    }
}
