using OpenTicketSystem.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.ViewModels
{
    public class TicketQueue : List<TicketModel>
    {
        public string QueueName { get; set; }
        public TicketQueue (IEnumerable<TicketModel> tl)
        {
            this.AddRange(tl);
        }
    }

    public class TicketQueueViewModel : List<TicketQueue>
    {

    }
}
