using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models.Entities;
using Timesheets.Data.Ef;

namespace Timesheets.Data.Implementation
{
    public class UserRepo : IUserRepo
    {

        private readonly TimesheetDbContext _context;

        public UserRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetItem(Guid id)
        {
            var result = await _context.Users
                        .Where(x => x.Id == id)
                        .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<User>> GetItems()
        {
            var result = await _context.Users.ToListAsync();

            return result;
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete (Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByLoginAndPasswordHash(string login, byte[] passwordHash)
        {
            return await _context.Users
                    .Where(x => x.Username == login && x.PasswordHash == passwordHash)
                    .FirstOrDefaultAsync();
        }
    }
}
