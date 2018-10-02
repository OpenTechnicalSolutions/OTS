using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Controllers.Location;
using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Locations;
using OpenTicketSystem.Repositories;
using OpenTicketSystem.Repositories.LocationRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Controllers.Location
{
    public class DepartmentController : Controller
    {
        private DepartmentRepository _departmentRepo;

        public DepartmentController(DepartmentRepository departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }
        // GET: /Department/
        public IActionResult Index()
        {
            var depts = _departmentRepo.GetAll();
            return PartialView(depts);
        }
        // GET: /Department/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: /Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentModel departmentModel)
        {
            if(ModelState.IsValid)
            {
                _departmentRepo.Add(departmentModel);
                return RedirectToAction(nameof(Index), "Location", 0);
            }

            return View(departmentModel);
        }
        // GET: /Department/Details/5
        public IActionResult Details(int Id)
        {
            var dept = _departmentRepo.GetById(Id);
            return View(dept);
        }
        // GET: /Department/Edit/5
        public IActionResult Edit(int Id)
        {
            var dept = _departmentRepo.GetById(Id);
            return View(dept);
        }
        // POST: /Department/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentModel deptModel)
        {
            if(ModelState.IsValid)
            {
                _departmentRepo.Update(deptModel);
                return RedirectToAction(nameof(Index), "Location", 0);
            }
            return View(deptModel);
        }
         // GET: TechnicalGroup/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_departmentRepo.GetById(id));
        }

        // POST: TechnicalGroup/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection iform)
        {
            try
            {
                // TODO: Add delete logic here
                _departmentRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}
