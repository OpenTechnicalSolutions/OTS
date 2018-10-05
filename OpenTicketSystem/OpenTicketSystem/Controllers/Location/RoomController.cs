using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models.Locations;
using OpenTicketSystem.Repositories.LocationRepositories;
using OpenTicketSystem.ViewModels;

namespace OpenTicketSystem.Controllers.Location
{
    public class RoomController : Controller
    {
        private RoomRepository _roomRepository;

        public RoomController(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        // GET: Room
        public ActionResult Index()
        {
            return View();
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            var room = _roomRepository.GetById(id);
            return View(room);
        }

        // GET: Room/Create
        public ActionResult Create(int BuildingNumber)
        {
            ViewBag.BuildingNumber = BuildingNumber;
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            if (!ModelState.IsValid)
                return View(room);

            if (room == null)
                return NotFound();

            // TODO: Add insert logic here
            _roomRepository.Add(room);
            return RedirectToAction(nameof(Details), "Building", new { Id = room.BuildingNumber });
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            var room = _roomRepository.GetById(id);
            return View(room);
        }

        // POST: Room/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Room room)
        {
            if (!ModelState.IsValid)
                return View(room);

            try
            {
                // TODO: Add update logic here
                _roomRepository.Update(room);
                return RedirectToAction(nameof(Details), "Building", new { Id = room.BuildingNumber });
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            var room = _roomRepository.GetById(id);
            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Room room)
        {
            try
            {
                // TODO: Add delete logic here
                _roomRepository.Delete(room);
                return RedirectToAction(nameof(Details), "Building", new { Id = room.BuildingNumber });
            }
            catch
            {
                return View();
            }
        }

        public IActionResult BuildingRooms(int id)
        {
            var buildingRooms = new BuildingRoomsViewModel();
            buildingRooms.Rooms = _roomRepository.GetBuildingRooms(id).ToList();
            buildingRooms.BuildingNumber = id;
            return PartialView(buildingRooms);
        }

        public IActionResult RoomData()
        {
            return Json(_roomRepository.GetAll());
        }
    }
}