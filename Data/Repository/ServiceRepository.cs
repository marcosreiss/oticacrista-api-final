using Microsoft.EntityFrameworkCore;
using OticaCrista.Data;
using OticaCrista.Models;

namespace OticaCrista.Repositories
{
    public class ServiceRepository
    {
        private readonly OticaCristaContext _context;

        public ServiceRepository(OticaCristaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceModel>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<ServiceModel?> GetByIdAsync(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<ServiceModel> AddAsync(ServiceModel service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<ServiceModel?> UpdateAsync(ServiceModel service)
        {
            var existingService = await _context.Services.FindAsync(service.Id);
            if (existingService == null)
                return null;

            _context.Entry(existingService).CurrentValues.SetValues(service);
            await _context.SaveChangesAsync();
            return existingService;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
                return false;

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
