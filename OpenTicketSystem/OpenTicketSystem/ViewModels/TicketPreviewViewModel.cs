using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.ViewModels
{
    public class TicketPreviewViewModel
    {
        public int TicketId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Subject { get; set; }
    }
}
