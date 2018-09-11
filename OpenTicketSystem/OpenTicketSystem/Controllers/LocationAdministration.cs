using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Locations;
using OpenTicketSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Controllers
{
    public class LocationAdministration : Controller
    {
        private BuildingRepository _buildingRepo;
        private DepartmentRepository _departmentRepo;
        private RoomRepository _roomRepo;

        public LocationAdministration(BuildingRepository buildingRepo, DepartmentRepository departmentRepo, RoomRepository roomRepo)
        {
            _buildingRepo = buildingRepo;
            _departmentRepo = departmentRepo;
            _roomRepo = roomRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Departments()
        {
            var departments = _departmentRepo.GetAll();
            return View(departments);
        }

        public IActionResult Buildings()
        {
            var buildings = _buildingRepo.GetAll();
            return View(buildings);
        }

        public IActionResult Rooms(int buildingId)
        {
            var rooms = _roomRepo.GetAll();
            return View(rooms);
        }

        public IActionResult AddBuilding()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBuilding(Building building)
        {
            if(ModelState.IsValid)
            {
                _buildingRepo.Add(building);
                return RedirectToAction("Buildings");
            }
            return View(building);
        }


    }
}
