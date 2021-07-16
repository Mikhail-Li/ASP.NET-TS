using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Models.Entities;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;

namespace Timesheets.Data.Implementation
{
    public class ClientRepo : IClientRepo
    {
        private readonly TimesheetDbContext _context;

        public ClientRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetItem(Guid id)
        {
            var result = await _context.Clients
                        .Where(x => x.Id == id)
                        .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<Client>> GetItems()
        {
            var result = await _context.Clients.ToListAsync();

            return result;
        }

        public async Task Add(Client item)
        {
            await _context.Clients.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Client item)
        {
            _context.Clients.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}