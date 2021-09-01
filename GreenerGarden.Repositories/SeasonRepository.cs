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
    public interface ISeasonRepository: IRepository<Season>
    {
        Task<Season> GetCurrentSeason();
    }

    public class SeasonRepository : ISeasonRepository
    {
        private readonly ApplicationDbContext _appContext;
        public SeasonRepository(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Season> GetById(int id)
        {
            var season = await _appContext.Seasons.FindAsync(id);
            return season;
        }

        public async Task<Season> Delete(int id)
        {
            Season existing = await _appContext.Seasons.FindAsync(id);
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

        public async Task<Season> Update(Season obj, int id)
        {
            //var updatedEntry = _appContext.Seasons.Attach(obj).Entity;
            //_appContext.Entry(obj).State = EntityState.Modified;
            Season updatedEntry = await _appContext.Set<Season>().FindAsync(id);
            _appContext.Entry(updatedEntry).CurrentValues.SetValues(obj);
            return updatedEntry;
        }

        public async Task<Season> GetCurrentSeason()
        {
            int maxId = _appContext.Seasons.Max(x => x.Id);
            Season currentSeason = _appContext.Seasons.Find(maxId);
            return currentSeason;
        }
    }
}
