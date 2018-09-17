using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Repositories.TicketRepositories
{ 
    public class TicketRepository : IRepository<TicketModel>
    {

        private AppDbContext _appDbContext { get; set; }

        public TicketRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public void Add(TicketModel ticketModel)
        {
            _appDbContext.Tickets.Add(ticketModel);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
        }

        public IEnumerable<TicketModel> GetAll()
        {
            return _appDbContext.Tickets;
        }

        public TicketModel GetById(int id)
        {
            return _appDbContext.Tickets.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(TicketModel deleteObject)
        {
            _appDbContext.Tickets.Remove(deleteObject);
            _appDbContext.SaveChanges();
        }

        public void Update(TicketModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
