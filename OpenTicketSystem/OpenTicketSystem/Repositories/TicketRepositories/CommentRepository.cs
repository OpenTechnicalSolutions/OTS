using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Repositories.TicketRepositories
{
    public class CommentRepository : IRepository<CommentModel>
    {
        public AppDbContext _dbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void Add(CommentModel addObject)
        {
            _dbContext.Comments.Add(addObject);
        }

        public void Delete(CommentModel deleteObject)
        {
            _dbContext.Comments.Remove(deleteObject);
        }

        public void Delete(int objId)
        {
            Delete(GetById(objId));
        }

        public IEnumerable<CommentModel> GetAll()
        {
            return _dbContext.Comments;
        }

        public CommentModel GetById(int id)
        {
            var comments = _dbContext.Comments.FirstOrDefault(c => c.Id == id);
            return comments;
        }

        public void Update(CommentModel obj)
        {
            _dbContext.Comments.Update(obj);
        }

        public IEnumerable<CommentModel> GetByTicketId(int id)
        {
            return _dbContext.Comments.Where(c => c.Id == id);
        }
    }
}
