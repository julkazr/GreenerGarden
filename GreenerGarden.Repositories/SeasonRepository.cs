using GreenerGarden.Data.Entities;
using GreenerGarden.MVC.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenerGarden.Repositories
{
    public interface ISeasonRepository: IRepository<Season>
    {

    }

    public class SeasonRepository : ISeasonRepository
    {
        private readonly ApplicationDbContext _appContext;
        public SeasonRepository(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }
        public Season GetById(int id)
        {
            var season = _appContext.Seasons.Find(id);
            return season;
        }

        public Season Delete(int id)
        {
            Season existing = _appContext.Seasons.Find(id);
            var result = _appContext.Seasons.Remove(existing).Entity;
            return result;
        }

        public async Task<IEnumerable<Season>> GetAllAsync()
        {
            var data = await _appContext.Seasons.ToListAsync();
            return data;
        }

        public Season Insert(Season obj)
        {
            var data = _appContext.Seasons.Add(obj).Entity;
            return data;
        }

        public void Save()
        {
            _appContext.SaveChanges();
        }

        public Season Update(Season obj)
        {
            var updatedEntry = _appContext.Seasons.Attach(obj).Entity;
            _appContext.Entry(obj).State = EntityState.Modified;
            return updatedEntry;
        }
    }
}
