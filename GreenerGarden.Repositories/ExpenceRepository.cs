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
        public async Task<Expence> GetById(int id)
        {
            var expence = await _appContext.Expences.FindAsync(id);
            return expence;
        }

        public async Task<Expence> Delete(int id)
        {
            Expence existing = await _appContext.Expences.FindAsync(id);
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

        public async Task<Expence> Update(Expence obj, int id)
        {
            //var updatedEntry = _appContext.Expences.Attach(obj).Entity;
            //_appContext.Entry(obj).State = EntityState.Modified;
            Expence updatedEntry = await _appContext.Set<Expence>().FindAsync(id);
            _appContext.Entry(updatedEntry).CurrentValues.SetValues(obj);
            return updatedEntry;
        }
    }
}
