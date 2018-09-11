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




        //Buildings
        public IActionResult Buildings()
        {
            var buildings = _buildingRepo.GetAll();
            return View(buildings);
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
        public IActionResult EditBuilding(int BuildingId)
        {
            return View(_buildingRepo.GetById(BuildingId));
        }
        [HttpPost]
        public IActionResult EditBuilding(Building building)
        {
            if(ModelState.IsValid)
            {
                _buildingRepo.Update(building);
                return RedirectToAction("")
            }
            return View(building);
        }

        //Rooms
        public IActionResult Rooms(int buildingId)
        {
            var rooms = _roomRepo.GetAll();
            return View(rooms);
        }
        public IActionResult AddRoom(int buildingId)
        {
            ViewBag.BuildingId = buildingId;
            return View();
        }
        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomRepo.Add(room);
                return RedirectToAction("");
            }
            return View(room);
        }
        public IActionResult EditRoom(int roomId)
        {
            return View(_roomRepo.GetById(roomId));
        }

        public IActionResult EditRoom(Room room)
        {
            if(ModelState.IsValid)
            {
                _roomRepo.Update(room);
                RedirectToAction("")
            }
        }
    }
}
