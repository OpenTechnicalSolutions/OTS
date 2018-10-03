using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Repositories.LocationRepositories
{
    public class DepartmentRepository : IRepository<DepartmentModel>
    {
        public AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(DepartmentModel addObject)
        {
            _dbContext.Departments.Add(addObject);
            _dbContext.SaveChanges();
        }

        public void Delete(DepartmentModel deleteObject)
        {
            _dbContext.Departments.Remove(deleteObject);
            _dbContext.SaveChanges();
        }

        public void Delete(int objId)
        {
            Delete(GetById(objId));
        }

        public IEnumerable<DepartmentModel> GetAll()
        {
            return _dbContext.Departments;
        }

        public DepartmentModel GetById(int id)
        {
            return _dbContext.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Update(DepartmentModel obj)
        {
                _dbContext.Departments.Update(obj);
                _dbContext.SaveChanges();
        }
    }
}
