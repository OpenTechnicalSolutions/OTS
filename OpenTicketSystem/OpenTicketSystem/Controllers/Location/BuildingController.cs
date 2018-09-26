using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models.Locations;
using OpenTicketSystem.Repositories.LocationRepositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenTicketSystem.Controllers.Location
{
    public class BuildingController : Controller
    {
        private BuildingRepository _buildingRespository;

        public BuildingController(BuildingRepository buildingRepository)
        {
            _buildingRespository = buildingRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_buildingRespository.GetAll());
        }

        public IActionResult BuildingDetails(int id)
        {
            return View(_buildingRespository.GetById(id));
        }

        public IActionResult CreateBuilding()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBuilding(Building building)
        {
            if (!ModelState.IsValid)
                return View(building);

            _buildingRespository.Add(building);
            return RedirectToAction("BuildingsDetails", building.Id);
        }

        public IActionResult EditBuilding(int id)
        {
            return View(_buildingRespository.GetById(id));
        }

        [HttpPost]
        public IActionResult EditBuilding(Building building)
        {
            if (!ModelState.IsValid)
                return View(building);

            _buildingRespository.Update(building);
            return RedirectToAction("BuildingDetails", building.Id);
        }
    }
}
