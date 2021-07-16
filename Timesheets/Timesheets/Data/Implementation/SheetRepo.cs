using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models.Entities;
using Timesheets.Data.Ef;
using Timesheets.Models.Dto;

namespace Timesheets.Data.Implementation
{
    public class SheetRepo: ISheetRepo
    {
        private readonly TimesheetDbContext _context;

        public SheetRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<Sheet> GetItem(Guid id)
        {
            var result = await _context.Sheets
                        .Where(x => x.Id == id)
                        .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
            var result =  await _context.Sheets.ToListAsync();
            
            return result;
        }

        public async Task<IEnumerable<Sheet>> GetItemsForInvoice(InvoiceRequest request)
        {
            var sheets = await _context.Sheets
                .Where(x => x.ContractId == request.ContractId)
                .Where(x => x.Date >= request.DateStart && x.Date <= request.DateEnd)
                .ToListAsync();

            return sheets;
        }

        public async Task Add(Sheet item)
        {
            await _context.Sheets.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Sheet item)
        {
            _context.Sheets.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var sheet = await _context.Sheets.FindAsync(id);
            _context.Sheets.Remove(sheet);
            await _context.SaveChangesAsync();
        }
    }
}