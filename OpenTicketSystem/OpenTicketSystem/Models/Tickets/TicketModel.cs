using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models.Tickets
{
    public enum Status { InProgress, OnHold, InQueue, WaitingForDetails, Updated }
    public class TicketModel
    {
        public int Id { get; set; }
        public string CustomerUserId { get; set; }
        public string TechnicianUserId { get; set; }
        public Status Status { get; set; }

        public int TechnicalGroupId { get; set; }
        public int SubTechnicalGroupId { get; set; }

        public DateTime TimeStamp { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public TicketModel()
        {
            
        }
    }
}
