using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Repositories.UserRepositories
{
    public class TechnicalGroupRepository : IRepository<TechnicalGroup>
    {
        private readonly AppDbContext _dbContext;

        public TechnicalGroupRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TechnicalGroup addObject)
        {
            _dbContext.TechnicalGroups.Add(addObject);
        }

        public void Delete(TechnicalGroup deleteObject)
        {
            _dbContext.TechnicalGroups.DefaultIfEmpty(deleteObject);
        }

        public void Delete(int objId)
        {
            Delete(GetById(objId));
        }

        public IEnumerable<TechnicalGroup> GetAll()
        {
            return _dbContext.TechnicalGroups;
        }

        public TechnicalGroup GetById(int id)
        {
            return _dbContext.TechnicalGroups.FirstOrDefault(tg => tg.Id == id);
        }

        public void Update(TechnicalGroup obj)
        {
            _dbContext.TechnicalGroups.Update(obj);
        }
    }
}
