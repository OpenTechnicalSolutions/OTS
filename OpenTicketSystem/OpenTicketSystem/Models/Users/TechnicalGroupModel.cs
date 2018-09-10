using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models.Users
{
    public class TechnicalGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SubTechnicalGroup> SubDepartments { get; set; }
    }
}
