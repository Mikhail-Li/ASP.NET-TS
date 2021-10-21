using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Implementation
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly TimesheetDbContext _context;

        public ServiceRepo(TimesheetDbContext context)
        {
            _context = context;
        }
        
        public async Task Add(Service item)
        {
            await _context.Services.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var service = await _context.Services.FindAsync(id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }

        public async Task<Service> GetItem(Guid id)
        {
            var result = await _context.Services
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            
            return result;
        }

        public async Task<IEnumerable<Service>> GetItems()
        {
            var result = await _context.Services.ToListAsync();
            
            return result;
        }

        public async Task Update(Service item)
        {
            _context.Services.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}