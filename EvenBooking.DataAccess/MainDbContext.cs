using EvenBooking.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EvenBooking.DataAccess
{
    public class MainDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>().HasIndex(e => e.Id);
        }
    }
}
