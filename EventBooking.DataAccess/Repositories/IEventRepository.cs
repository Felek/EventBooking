using EventBooking.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.DataAccess.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event> Get(int id);
        Task<IEnumerable<Event>> GetByCountry(string country);
        void Add(Event eventToAdd);
        void Delete(Event eventToRemove);
        void Update(Event eventToUpdate);
        Task SaveChanges();
    }
}
