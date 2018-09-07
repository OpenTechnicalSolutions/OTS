using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Repositories
{ 
    public interface ITicketRepository
    {
        IEnumerable<TicketModel> GetTickets();

        TicketModel GetTicketById(int id);

        void Add(TicketModel ticketModel);

        void Delete(int id);
    }
}
