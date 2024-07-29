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
    public class EventRepository : IEventRepository
    {
        private readonly MainDbContext _context;

        public EventRepository(MainDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetByCountry(string country)
        {
            country = country.ToLower();
            return await _context.Events.Where(b => b.Country.ToLower() == country).AsNoTracking().ToListAsync();
        }

        public async Task<Event> Get(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public void Add(Event eventToAdd)
        {
            _context.Add(eventToAdd);
        }

        public void Delete(Event eventToRemove)
        {
            _context.Events.Remove(eventToRemove);
        }

        public void Update(Event eventToUpdate)
        {
            _context.Update(eventToUpdate);
        }

        public Task<bool> IsUserRegistered(int eventId, string email)
        {
            return _context.Events.AnyAsync(e => e.Id == eventId && e.Users.Any(u => u.Email == email));
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
