using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models.Entities;
using Timesheets.Models.Dto;
using Timesheets.Data.Interfaces;
using System.Security.Cryptography;
using Timesheets.Infrastructure.Extensions;
using Timesheets.Domain.Managers.Interfaces;

namespace Timesheets.Domain.Managers.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo _userRepo;

        public UserManager (IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> GetUserByLoginAndPasswordHash(LoginRequest request)
        {
            var passwordHash = GetPasswordHash(request.Password);
            var user = await _userRepo.GetByLoginAndPasswordHash(request.Login, passwordHash);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepo.GetItems();
        }

        public async Task<Guid> CreateUser(CreateUserRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                PasswordHash = GetPasswordHash(request.Password),
                Role = request.Role
            };

            await _userRepo.Add (user);

            return user.Id;
        }

        public async Task UpdateUser(Guid id, CreateUserRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var user = new User()
            {
                Id = id,
                Username = request.Username,
                PasswordHash = GetPasswordHash(request.Password),
                Role = request.Role
            };

            await _userRepo.Update(user);
        }

        public async Task DeleteUser(Guid id)
        {
            await _userRepo.Delete(id);
        }

        private static byte[] GetPasswordHash(string password)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            }
        }
    }
}
