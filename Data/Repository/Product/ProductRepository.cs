using Microsoft.EntityFrameworkCore;
using OticaCrista.Data;
using OticaCrista.Models.Product;

namespace OticaCrista.Data.Repository.Product
{
    public class ProductRepository
    {
        private readonly OticaCristaContext _context;

        public ProductRepository(OticaCristaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync(int skip, int take)
        {
            return await _context.Products
                .Skip(skip)
                .Take(take)
                .Include(p => p.Brand).ToListAsync();
        }

        public async Task<ProductModel?> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Brand).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductModel> AddAsync(ProductModel product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<ProductModel?> UpdateAsync(ProductModel product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct == null)
                return null;

            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
