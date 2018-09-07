using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models.Tickets
{
    public class TicketModel
    {
        public int Id { get; set; }
        public int CustomerUserId { get; set; }
        public int TechnicianUserId { get; set; }

        public DateTime TimeStamp { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public List<CommentModel> Comments { get; set; }
    }
}
