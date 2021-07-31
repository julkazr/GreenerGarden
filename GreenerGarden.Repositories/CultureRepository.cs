using GreenerGarden.Data.Entities;
using GreenerGarden.MVC.Data;
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
        public Culture GetById(int id)
        {
            var culture = _appContext.Cultures.Find(id);
            return culture;
        }

        public Culture Delete(int id)
        {
            Culture existing = _appContext.Cultures.Find(id);
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

        public Culture Update(Culture obj)
        {
            var updatedEntry = _appContext.Cultures.Attach(obj).Entity;
            _appContext.Entry(obj).State = EntityState.Modified;
            return updatedEntry;
        }
    }
}
