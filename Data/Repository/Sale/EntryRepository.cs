using Microsoft.EntityFrameworkCore;
using OticaCrista.Data;
using OticaCrista.Models.Sale;

namespace OticaCrista.Repositories
{
    public class EntryRepository
    {
        private readonly OticaCristaContext _context;

        public EntryRepository(OticaCristaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entry>> GetAllAsync()
        {
            return await _context.Entries.ToListAsync();
        }

        public async Task<Entry?> GetByIdAsync(int id)
        {
            return await _context.Entries.FindAsync(id);
        }

        public async Task<Entry> AddAsync(Entry entry)
        {
            _context.Entries.Add(entry);
            await _context.SaveChangesAsync();
            return entry;
        }

        public async Task<Entry?> UpdateAsync(Entry entry)
        {
            var existingEntry = await _context.Entries.FindAsync(entry.Id);
            if (existingEntry == null)
                return null;

            _context.Entry(existingEntry).CurrentValues.SetValues(entry);
            await _context.SaveChangesAsync();
            return existingEntry;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entry = await _context.Entries.FindAsync(id);
            if (entry == null)
                return false;

            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
