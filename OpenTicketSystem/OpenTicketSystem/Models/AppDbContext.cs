using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenTicketSystem.Models.Locations;
using OpenTicketSystem.Models.Tickets;
using OpenTicketSystem.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models
{
    public class AppDbContext : IdentityDbContext<AppIdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //stuff
        }

        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<TechnicalGroup> TechnicalGroup { get; set; }
        public DbSet<SubTechnicalGroup> SubTechnicalGroup { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
    }
}
