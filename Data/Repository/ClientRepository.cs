using Microsoft.EntityFrameworkCore;
using OticaCrista.Data;
using OticaCrista.Models;

namespace OticaCrista.Repositories
{
    public class ClientRepository
    {
        private readonly OticaCristaContext _context;

        public ClientRepository(OticaCristaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientModel>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<ClientModel?> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<ClientModel> AddAsync(ClientModel client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<ClientModel?> UpdateAsync(ClientModel client)
        {
            var existingClient = await _context.Clients.FindAsync(client.Id);
            if (existingClient == null)
                return null;

            _context.Entry(existingClient).CurrentValues.SetValues(client);
            await _context.SaveChangesAsync();
            return existingClient;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return false;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
