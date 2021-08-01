﻿using GreenerGarden.Data;
using GreenerGarden.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenerGarden.Repositories
{
    public interface IYieldRepository : IRepository<CropYield>
    {

    }
    public class CropYieldRepository
    {
        private readonly ApplicationDbContext _appContext;
        public CropYieldRepository(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<CropYield> GetById(int id)
        {
            var cropYield = await _appContext.CropYields.FindAsync(id);
            return cropYield;
        }

        public async Task<CropYield> Delete(int id)
        {
            CropYield existing = await _appContext.CropYields.FindAsync(id);
            var result = _appContext.CropYields.Remove(existing).Entity;
            return result;
        }

        public async Task<IEnumerable<CropYield>> GetAllAsync()
        {
            var data = await _appContext.CropYields.ToListAsync();
            return data;
        }

        public async Task<CropYield> Insert(CropYield obj)
        {
            var data = await _appContext.CropYields.AddAsync(obj);
            return data.Entity;
        }

        public void Save()
        {
            _appContext.SaveChanges();
        }

        public async Task<CropYield> Update(CropYield obj, int id)
        {
            //var updatedEntry = await _appContext.CropYields.Attach(obj).Entity;
            //_appContext.Entry(obj).State = EntityState.Modified;
            CropYield updatedEntry = await _appContext.Set<CropYield>().FindAsync(id);
            _appContext.Entry(updatedEntry).CurrentValues.SetValues(obj);
            return updatedEntry;
        }
    }
}
