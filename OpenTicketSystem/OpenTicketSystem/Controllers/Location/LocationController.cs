using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Controllers.Location
{
    public class LocationController : Controller
    {
        public IActionResult LocationAdmin(int id)
        {
            var locIndex = new LocationViewModel
            {
                LocationDrawData = (LocationDrawData)id
            };
            return View(locIndex);
        }
    }
}
