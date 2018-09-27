using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        // GET: /Building/
        public IActionResult Index()
        {
            return PartialView(_buildingRespository.GetAll());
        }
        // GET: /Building/Details/5
        public IActionResult Details(int id)
        {
            return View(_buildingRespository.GetById(id));
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
            return RedirectToAction(nameof(Building), building.Id);
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
            return RedirectToAction(nameof(Index), nameof(LocationController), LocationController.LocationIndex.Buildings);
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
    }
}
