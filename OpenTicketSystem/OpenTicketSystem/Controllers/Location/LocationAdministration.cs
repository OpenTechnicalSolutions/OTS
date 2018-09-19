using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Locations;
using OpenTicketSystem.Repositories;
using OpenTicketSystem.Repositories.LocationRepositories;
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
        #region Departments
        public IActionResult Index()
        {
            return RedirectToAction("Departments");
        }

        public IActionResult Departments()
        {
            var departments = _departmentRepo.GetAll();
            return View(departments);
        }
        public IActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDepartment(DepartmentModel departmentModel)
        {
            if(ModelState.IsValid)
            {
                _departmentRepo.Add(departmentModel);
                return RedirectToAction("Departments");
            }

            return View(departmentModel);
        }
        public IActionResult DepartmentDetails(int deptId)
        {
            return View(_departmentRepo.GetById(deptId));
        }
        public IActionResult EditDepartment(int deptId)
        {
            return View(_departmentRepo.GetById(deptId));
        }
        [HttpPost]
        public IActionResult EditDepartment(DepartmentModel deptModel)
        {
            if(ModelState.IsValid)
            {
                _departmentRepo.Update(deptModel);
                return RedirectToAction("Departments");
            }
            return View(deptModel);
        }
        #endregion
        #region Buildings
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
        public IActionResult BuildingDetails (int buildingId)
        {
            ViewBag.Rooms = _roomRepo.GetBuildingRooms(buildingId);
            return View(_buildingRepo.GetById(buildingId));
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
                return RedirectToAction("BuildingDetails", building.Id);
            }
            return View(building);
        }
        #endregion
        #region Rooms

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
                return RedirectToAction("BuildingDetails", room.BuildingId);
            }
            return View(room);
        }
        public IActionResult RoomDetails(int roomId)
        {
            return View(_roomRepo.GetById(roomId));
        }
        public IActionResult EditRoom(int roomId)
        {
            return View(_roomRepo.GetById(roomId));
        }
        [HttpPost]
        public IActionResult EditRoom(Room room)
        {
            if(ModelState.IsValid)
            {
                _roomRepo.Update(room);
                return RedirectToAction("RoomDetails", room.Id);
            }
            return View(room);
        }
        #endregion
    }
}
