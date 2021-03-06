﻿using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace OpenTicketSystem.Repositories.LocationRepositories
{
    public class BuildingRepository : IRepository<Building>
    {
        private AppDbContext _dbContext;

        public BuildingRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Building addObject)
        {
            _dbContext.Buildings.Add(addObject);
            _dbContext.SaveChanges();
        }

        public void Delete(Building deleteObject)
        {
            _dbContext.Buildings.Remove(deleteObject);
            _dbContext.SaveChanges();
        }

        public void Delete(int objId)
        {
            Delete(GetById(objId));
        }

        public IEnumerable<Building> GetAll()
        {
            return _dbContext.Buildings;
        }

        public Building GetById(int id)
        {
            return _dbContext.Buildings.FirstOrDefault(b => b.Id == id);
        }

        public void Update(Building obj)
        {
            _dbContext.Buildings.Update(obj);
            _dbContext.SaveChanges();
            
        }
    }
}
