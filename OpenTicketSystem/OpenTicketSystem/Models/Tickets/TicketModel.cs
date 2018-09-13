﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models.Tickets
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string CustomerUserId { get; set; }
        public string TechnicianUserId { get; set; }

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
