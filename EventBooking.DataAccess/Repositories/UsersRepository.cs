using EventBooking.DataAccess;
using EventBooking.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MainDbContext _context;

        public UserRepository(MainDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
