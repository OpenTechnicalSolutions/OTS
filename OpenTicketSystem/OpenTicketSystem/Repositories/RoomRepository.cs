using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Repositories
{
    public class RoomRepository : IRepository<Room>
    {
        private AppDbContext _dbContext;

        public RoomRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Room addObject)
        {
            _dbContext.Rooms.Add(addObject);
            _dbContext.SaveChanges();
        }

        public void Delete(Room deleteObject)
        {
            _dbContext.Rooms.Remove(deleteObject);
            _dbContext.SaveChanges();
        }

        public void Delete(int objId)
        {
            Delete(GetById(objId));
        }

        public IEnumerable<Room> GetAll()
        {
            return _dbContext.Rooms;
        }

        public Room GetById(int id)
        {
            return _dbContext.Rooms.FirstOrDefault(r => r.Id == id);
        }

        public void Update(Room obj)
        {
            var entity = _dbContext.Rooms.FirstOrDefault(b => b.Id == obj.Id);
            if (entity != null)
                _dbContext.Rooms.Update(entity);
        }

        public IEnumerable<Room> GetBuildingRooms(int buildingId)
        {
            return _dbContext.Rooms.Where(r => r.BuildingId == buildingId);
        }
    }
}
