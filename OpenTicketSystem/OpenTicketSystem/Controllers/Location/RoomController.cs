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
            return View();
        }

        // GET: Room/Create
        public ActionResult Create(int id)
        {
            var room = new Room();
            room.BuildingId = id;
            return View(room);
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            if (!ModelState.IsValid)
                return View(room);

            try
            {
                // TODO: Add insert logic here
                _roomRepository.Add(room);
                return RedirectToAction(nameof(Details), "Building", room.BuildingId);
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Room/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _roomRepository.Delete(id);
                return RedirectToAction(nameof(Index));
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
    }
}