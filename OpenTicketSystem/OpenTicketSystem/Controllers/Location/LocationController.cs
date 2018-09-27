using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Controllers.Location
{
    public class LocationController : Controller
    {
        public enum LocationIndex { Departments, Buildings }

        public IActionResult Index(LocationIndex li)
        {
            ViewBag.LocationIndex = li;
            return View();
        }
    }
}
