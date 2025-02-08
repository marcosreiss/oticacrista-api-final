using Microsoft.EntityFrameworkCore;
using OticaCrista.Data;
using OticaCrista.Models.Sale;

namespace OticaCrista.Repositories
{
    public class SaleRepository
    {
        private readonly OticaCristaContext _context;

        public SaleRepository(OticaCristaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SaleModel>> GetAllAsync(int skip, int take)
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Products)
                .Include(s => s.Services)
                .Include(s => s.Payment)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<SaleModel?> GetByIdAsync(int id)
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Products)
                .Include(s => s.Services)
                .Include(s => s.Payment)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<SaleModel> AddAsync(SaleModel sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task<SaleModel?> UpdateAsync(SaleModel sale)
        {
            var existingSale = await _context.Sales.FindAsync(sale.Id);
            if (existingSale == null)
                return null;

            _context.Entry(existingSale).CurrentValues.SetValues(sale);
            await _context.SaveChangesAsync();
            return existingSale;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
                return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
