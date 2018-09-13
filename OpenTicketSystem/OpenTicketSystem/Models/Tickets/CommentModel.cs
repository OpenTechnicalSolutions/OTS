using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models.Tickets
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int PublisherUserId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Comment { get; set; }
        public bool PublicFacing { get; set; }
        public bool EmailSent { get; set; }

        public CommentModel()
        {
           
        }
    }
}
