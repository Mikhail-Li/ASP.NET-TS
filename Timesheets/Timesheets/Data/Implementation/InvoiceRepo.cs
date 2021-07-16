using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Implementation
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly TimesheetDbContext _context;

        public InvoiceRepo(TimesheetDbContext context)
        {
            _context = context;
        }
        
        public async Task<Invoice> GetItem(Guid id)
        {
            var result = await _context.Invoices
                        .Where(x => x.Id == id)
                        .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<Invoice>> GetItems()
        {
            var result = await _context.Invoices.ToListAsync();
            return result;
        }

        public async Task Add(Invoice item)
        {
            await _context.Invoices.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Invoice item)
        {
            _context.Invoices.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
        }
    }
}