using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models
{
    public interface ITicketRepository
    {
        IEnumerable<TicketModel> GetTickets();

        TicketModel GetTicketById(int id);
    }
}
