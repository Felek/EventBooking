using EventBooking.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task SaveChanges();
    }
}
