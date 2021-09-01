using GreenerGarden.Data.Entities;
using GreenerGarden.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace GreenerGarden.Repositories
{
    public interface ICultureRepository : IRepository<Culture>
    {
        IEnumerable<Culture> GetCulturesBySeasonId(int id);
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

        public Culture Insert(Culture obj)
        {
            var data = _appContext.Cultures.Add(obj).Entity;
            return data;
        }

        public void Save()
        {
            _appContext.SaveChanges();
        }

        public async Task<Culture> Update(Culture obj, int id)
        {
            //var updatedentry = await _appcontext.cultures.attach(obj);
            //_appcontext.entry(obj).state = entitystate.modified;
            Culture updatedEntry = await _appContext.Set<Culture>().FindAsync(id);
            _appContext.Entry(updatedEntry).CurrentValues.SetValues(obj);
            return updatedEntry;
        }

        public IEnumerable<Culture> GetCulturesBySeasonId(int id)
        {
            var data = _appContext.Cultures.Where(x => x.SeasonId == id);
            return data;
        }
    }
}
