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
using OpenTicketSystem.ViewModels;

namespace OpenTicketSystem.Models
{
    public class AppDbContext : IdentityDbContext<AppIdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //stuff
        }

        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<TechnicalGroup> TechnicalGroups { get; set; }
        public DbSet<SubTechnicalGroup> SubTechnicalGroups { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<OpenTicketSystem.ViewModels.UserAdapterModel> UserAdapterModel { get; set; }
    }
}
