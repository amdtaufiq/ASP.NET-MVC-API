using Logique_api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Logique_api.Repository.Users
{
    public class UserRepository : IUser<User>, IDisposable
    {
        public LogiqueDbContext _ctx { get; set; }

        public UserRepository(LogiqueDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Add(User user)
        {
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
        }

        public Task<List<User>> GetAll()
        {
            var users = _ctx.Users
                .Include(x => x.DetailUser)
                .Include(x => x.DetailUser.AddressUsers)
                .Include(x => x.DetailUser.CreditCard)
                .ToListAsync();

            return users;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> Login(LoginRequest loginRequest)
        {
            var user = await _ctx.Users.Where(x => 
            x.Email == loginRequest.Email && 
            x.Password == loginRequest.Password)
                .FirstAsync();

            if (user == null)
                return false;

            _ctx.Entry(user).State = EntityState.Modified;
            _ctx.Entry(user).Property(x => x.IsLogin).IsModified = true;
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Logout(Guid userId)
        {
            var user = await _ctx.Users.Where(x =>
            x.Id == userId)
                .FirstAsync();

            if (user == null)
                return false;

            _ctx.Entry(user).State = EntityState.Modified;
            _ctx.Entry(user).Property(x => x.IsLogin).IsModified = false;
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}