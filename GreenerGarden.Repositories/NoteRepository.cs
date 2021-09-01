using GreenerGarden.Data;
using GreenerGarden.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenerGarden.Repositories
{
    public interface INoteRepository : IRepository<Note>
    {

    }
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _appContext;
        public NoteRepository(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Note> GetById(int id)
        {
            var note = await _appContext.Notes.FindAsync(id);
            return note;
        }

        public async Task<Note> Delete(int id)
        {
            Note existing = await _appContext.Notes.FindAsync(id);
            var result = _appContext.Notes.Remove(existing).Entity;
            return result;
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            var data = await _appContext.Notes.ToListAsync();
            return data;
        }

        public Note Insert(Note obj)
        {
            var data = _appContext.Notes.Add(obj).Entity;
            return data;
        }

        public void Save()
        {
            _appContext.SaveChanges();
        }

        public async Task<Note> Update(Note obj, int id)
        {
            //var updatedEntry = _appContext.Notes.Attach(obj).Entity;
            //_appContext.Entry(obj).State = EntityState.Modified;
            Note updatedEntry = await _appContext.Set<Note>().FindAsync(id);
            _appContext.Entry(updatedEntry).CurrentValues.SetValues(obj);
            return updatedEntry;
        }
    }
}
