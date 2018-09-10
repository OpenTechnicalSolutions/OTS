using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models.Users
{
    public class SubTechnicalGroup
    {
        public int Id { get; set; }
        public int TechincalGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
