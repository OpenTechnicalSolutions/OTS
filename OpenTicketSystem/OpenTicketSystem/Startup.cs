using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Users;
using OpenTicketSystem.Repositories;
using OpenTicketSystem.Repositories.LocationRepositories;
using OpenTicketSystem.Repositories.TicketRepositories;
using OpenTicketSystem.Repositories.UserRepositories;

namespace OpenTicketSystem
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppIdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<TicketRepository, TicketRepository>();
            services.AddTransient<BuildingRepository, BuildingRepository>();
            services.AddTransient<DepartmentRepository, DepartmentRepository>();
            services.AddTransient<RoomRepository, RoomRepository>();
            services.AddTransient<CommentRepository, CommentRepository>();
            services.AddTransient<TechnicalGroupRepository, TechnicalGroupRepository>();
            services.AddTransient<SubTechnicalGroupRepository, SubTechnicalGroupRepository>();

           
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<AppIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            AccountDataInitializer.SeedUsersAndRoles(userManager, roleManager);
            
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

        }
    }
}
