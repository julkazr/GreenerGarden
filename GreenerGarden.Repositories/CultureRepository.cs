using GreenerGarden.Data.Entities;
using GreenerGarden.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenerGarden.Repositories
{
    public interface ICultureRepository : IRepository<Culture>
    {

    }
    public class CultureRepository : ICultureRepository
    {
        private readonly ApplicationDbContext _appContext;
        public CultureRepository(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Culture> GetById(int id)
        {
            var culture = await _appContext.Cultures.FindAsync(id);
            return culture;
        }

        public async Task<Culture> Delete(int id)
        {
            Culture existing = await _appContext.Cultures.FindAsync(id);
            var result = _appContext.Cultures.Remove(existing).Entity;
            return result;
        }

        public async Task<IEnumerable<Culture>> GetAllAsync()
        {
            var data = await _appContext.Cultures.ToListAsync();
            return data;
        }

        public async Task<Culture> Insert(Culture obj)
        {
            var data = await _appContext.Cultures.AddAsync(obj);
            return data.Entity;
        }

        public async void Save()
        {
            await _appContext.SaveChangesAsync();
        }

        public async Task<Culture> Update(Culture obj, int id)
        {
            //var updatedentry = await _appcontext.cultures.attach(obj);
            //_appcontext.entry(obj).state = entitystate.modified;
            Culture updatedEntry = await _appContext.Set<Culture>().FindAsync(id);
            _appContext.Entry(updatedEntry).CurrentValues.SetValues(obj);
            return updatedEntry;
        }
    }
}
