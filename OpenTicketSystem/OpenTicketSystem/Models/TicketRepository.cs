using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models
{
    public class TicketRepository : ITicketRepository
    {

        private AppDbContext _appDbContext { get; set; }

        public TicketRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public TicketModel GetTicketById(int id)
        {
            return _appDbContext.Tickets.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<TicketModel> GetTickets()
        {
            return _appDbContext.Tickets;
        }

        public void Add(TicketModel ticketModel)
        {
            _appDbContext.Tickets.Add(ticketModel);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _appDbContext.Tickets.Remove(GetTicketById(id));
        }
    }
}
