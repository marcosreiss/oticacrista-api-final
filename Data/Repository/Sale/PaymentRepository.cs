using Microsoft.EntityFrameworkCore;
using OticaCrista.Data;
using OticaCrista.Models.Sale;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OticaCrista.Repositories
{
    public class PaymentRepository
    {
        private readonly OticaCristaContext _context;

        public PaymentRepository(OticaCristaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentModel>> GetAllAsync(int skip, int take)
        {
            return await _context.Payments
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<PaymentModel?> GetByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task<PaymentModel> AddAsync(PaymentModel payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<PaymentModel?> UpdateAsync(PaymentModel payment)
        {
            var existingPayment = await _context.Payments.FindAsync(payment.Id);
            if (existingPayment == null)
                return null;

            _context.Entry(existingPayment).CurrentValues.SetValues(payment);
            await _context.SaveChangesAsync();
            return existingPayment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
                return false;

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
