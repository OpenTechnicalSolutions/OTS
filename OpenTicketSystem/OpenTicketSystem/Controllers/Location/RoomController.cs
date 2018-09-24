using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models.Locations;
using OpenTicketSystem.Repositories.LocationRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Controllers
{
    public class RoomController : Controller
    {
        private RoomRepository _roomRepository;

        public RoomController (RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IActionResult Index()
        {
            return View(_roomRepository.GetAll());
        }

        public IActionResult BuildingRooms(int buildingId)
        {
            return View(_roomRepository.GetBuildingRooms(buildingId));
        }

        public IActionResult RoomDetails(int id)
        {
            return View(_roomRepository.GetById(id));
        }

        public IActionResult AddRoom(int buildingId)
        {
            ViewBag.BuildingId = buildingId;
            return View();
        }
        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            if (!ModelState.IsValid)
                return View(room);

            _roomRepository.Add(room);

            return RedirectToAction("BuildingDetails", "Building", room.BuildingId);            
        }

        public IActionResult EditRoom(int id)
        {
            return View(_roomRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult EditRoom(Room room)
        {
            _roomRepository.Update(room);
            return RedirectToAction("RoomDetails", room.Id);
        }

        public IActionResult DeleteRoom(int roomId)
        {
            var buildingId = _roomRepository.GetById(roomId).BuildingId;
            _roomRepository.Delete(roomId);
            return RedirectToAction("BuildingDetails", "Building", buildingId);
        }
    }
}
