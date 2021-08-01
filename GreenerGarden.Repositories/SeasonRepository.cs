using GreenerGarden.Data.Entities;
using GreenerGarden.Data;
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

        public async Task<Season> Insert(Season obj)
        {
            var data = await _appContext.Seasons.AddAsync(obj);
            return data.Entity;
        }

        public async void Save()
        {
            await _appContext.SaveChangesAsync();
        }

        public async Task<Season> Update(Season obj, int id)
        {
            //var updatedEntry = _appContext.Seasons.Attach(obj).Entity;
            //_appContext.Entry(obj).State = EntityState.Modified;
            Season updatedEntry = await _appContext.Set<Season>().FindAsync(id);
            _appContext.Entry(updatedEntry).CurrentValues.SetValues(obj);
            return updatedEntry;
        }
    }
}
