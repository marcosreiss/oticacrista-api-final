using Microsoft.EntityFrameworkCore;
using OticaCrista.Data;
using OticaCrista.Models.Sale;

namespace OticaCrista.Repositories
{
    public class SaleProductItemRepository
    {
        private readonly OticaCristaContext _context;

        public SaleProductItemRepository(OticaCristaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SaleProductItem>> GetAllAsync(int skip, int take)
        {
            return await _context.SalesProducts
                .Include(sp => sp.Product)
                .Include(sp => sp.Sale)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<SaleProductItem?> GetByIdAsync(int id)
        {
            return await _context.SalesProducts
                .Include(sp => sp.Product)
                .Include(sp => sp.Sale)
                .FirstOrDefaultAsync(sp => sp.Id == id);
        }

        public async Task<SaleProductItem> AddAsync(SaleProductItem saleProductItem)
        {
            _context.SalesProducts.Add(saleProductItem);
            await _context.SaveChangesAsync();
            return saleProductItem;
        }

        public async Task<SaleProductItem?> UpdateAsync(SaleProductItem saleProductItem)
        {
            var existingSaleProductItem = await _context.SalesProducts.FindAsync(saleProductItem.Id);
            if (existingSaleProductItem == null)
                return null;

            _context.Entry(existingSaleProductItem).CurrentValues.SetValues(saleProductItem);
            await _context.SaveChangesAsync();
            return existingSaleProductItem;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var saleProductItem = await _context.SalesProducts.FindAsync(id);
            if (saleProductItem == null)
                return false;

            _context.SalesProducts.Remove(saleProductItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}