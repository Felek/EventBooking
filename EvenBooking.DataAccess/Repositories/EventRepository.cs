using EvenBooking.DataAccess;
using EvenBooking.DataAccess.Entities;
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

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByCountry(string country)
        {
            country = country.ToLower();
            return await _context.Events.Where(b => b.Country.ToLower() == country).ToListAsync();
        }
    }
}
