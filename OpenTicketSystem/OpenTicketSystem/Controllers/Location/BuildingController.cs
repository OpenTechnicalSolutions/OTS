using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models.Locations;
using OpenTicketSystem.Repositories.LocationRepositories;
using OpenTicketSystem.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenTicketSystem.Controllers.Location
{
    public class BuildingController : Controller
    {
        private BuildingRepository _buildingRespository;
        private RoomRepository _roomRepository;

        public BuildingController(BuildingRepository buildingRepository, RoomRepository roomRepository)
        {
            _buildingRespository = buildingRepository;
            _roomRepository = roomRepository;
        }
        // GET: /Building/
        public IActionResult Index()
        {
            return View(_buildingRespository.GetAll());
        }
        // GET: /Building/Details/5
        public IActionResult Details(int id)
        {
            var rooms = new BuildingRoomsViewModel()
            {
                BuildingNumber = id,
                Rooms = _roomRepository.GetBuildingRooms(id).ToList()
            };

            var buildingDetails = new BuildingDetailsViewModel()
            {
                Building = _buildingRespository.GetById(id),
                Rooms = rooms
            };
            return View(buildingDetails);
        }
        // GET: /Building/Create
        public IActionResult Create()
        {
            return View();
        }
        // Post: /Building/Create/<building object>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Building building)
        {
            if (!ModelState.IsValid)
                return View(building);

            _buildingRespository.Add(building);
            return RedirectToAction(nameof(Index));
        }
        // GET: /Building/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_buildingRespository.GetById(id));
        }
        //POST: /Building/Edit/<building object>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Building building)
        {
            if (!ModelState.IsValid)
                return View(building);

            _buildingRespository.Update(building);
            return RedirectToAction(nameof(Index));
        }
        // GET: TechnicalGroup/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_buildingRespository.GetById(id));
        }
        // POST: TechnicalGroup/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection iform)
        {
            try
            {
                // TODO: Add delete logic here                
                _buildingRespository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult BuildingData()
        {
            return Json(_buildingRespository.GetAll());
        }
    }
}
