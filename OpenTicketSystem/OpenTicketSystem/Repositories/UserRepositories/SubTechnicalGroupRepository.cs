using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Repositories.UserRepositories
{
    public class SubTechnicalGroupRepository : IRepository<SubTechnicalGroup>
    {
        private readonly AppDbContext _dbContext;

        public SubTechnicalGroupRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(SubTechnicalGroup addObject)
        {
            _dbContext.SubTechnicalGroups.Add(addObject);
        }

        public void Delete(SubTechnicalGroup deleteObject)
        {
            _dbContext.SubTechnicalGroups.Remove(deleteObject);
        }

        public void Delete(int objId)
        {
            Delete(GetById(objId));
        }

        public IEnumerable<SubTechnicalGroup> GetAll()
        {
            return _dbContext.SubTechnicalGroups;
        }

        public SubTechnicalGroup GetById(int id)
        {
            return _dbContext.SubTechnicalGroups.FirstOrDefault(stg => stg.Id == id);
        }

        public void Update(SubTechnicalGroup obj)
        {
            _dbContext.SubTechnicalGroups.Update(obj);
        }

        public IEnumerable<SubTechnicalGroup> GetByTechnicalGroup(int techGroupId)
        {
            return GetAll().Where(stg => stg.TechnicalGroupId == techGroupId);
        }
    }
}
