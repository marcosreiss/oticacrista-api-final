using Microsoft.EntityFrameworkCore;
using OticaCrista.Data;
using OticaCrista.Models.Sale;

namespace OticaCrista.Repositories
{
    public class SaleServiceItemRepository
    {
        private readonly OticaCristaContext _context;

        public SaleServiceItemRepository(OticaCristaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SaleServiceItem>> GetAllAsync(int skip, int take)
        {
            return await _context.SalesServices
                .Include(ss => ss.Service)
                .Include(ss => ss.Sale)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<SaleServiceItem?> GetByIdAsync(int id)
        {
            return await _context.SalesServices
                .Include(ss => ss.Service)
                .Include(ss => ss.Sale)
                .FirstOrDefaultAsync(ss => ss.Id == id);
        }

        public async Task<SaleServiceItem> AddAsync(SaleServiceItem saleServiceItem)
        {
            _context.SalesServices.Add(saleServiceItem);
            await _context.SaveChangesAsync();
            return saleServiceItem;
        }

        public async Task<SaleServiceItem?> UpdateAsync(SaleServiceItem saleServiceItem)
        {
            var existingSaleServiceItem = await _context.SalesServices.FindAsync(saleServiceItem.Id);
            if (existingSaleServiceItem == null)
                return null;

            _context.Entry(existingSaleServiceItem).CurrentValues.SetValues(saleServiceItem);
            await _context.SaveChangesAsync();
            return existingSaleServiceItem;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var saleServiceItem = await _context.SalesServices.FindAsync(id);
            if (saleServiceItem == null)
                return false;

            _context.SalesServices.Remove(saleServiceItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}