using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models
{
    public interface ISelectOptionModel
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
