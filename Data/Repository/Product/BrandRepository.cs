using Microsoft.EntityFrameworkCore;
using OticaCrista.Data;
using OticaCrista.Models.Product;

namespace OticaCrista.Data.Repository.Product
{
    public class BrandRepository
    {
        private readonly OticaCristaContext _context;

        public BrandRepository(OticaCristaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BrandModel>> GetAllAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<BrandModel?> GetByIdAsync(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public async Task<BrandModel> AddAsync(BrandModel brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<BrandModel?> UpdateAsync(BrandModel brand)
        {
            var existingBrand = await _context.Brands.FindAsync(brand.Id);
            if (existingBrand == null)
                return null;

            _context.Entry(existingBrand).CurrentValues.SetValues(brand);
            await _context.SaveChangesAsync();
            return existingBrand;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
                return false;

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
