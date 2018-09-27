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
            return PartialView(_departmentRepo.GetAll());
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
                return RedirectToAction(nameof(Details), departmentModel.Id);
            }

            return View(departmentModel);
        }
        // GET: /Department/Details/5
        public IActionResult Details(int deptId)
        {
            return View(_departmentRepo.GetById(deptId));
        }
        // GET: /Department/Edit/5
        public IActionResult Edit(int deptId)
        {
            return View(_departmentRepo.GetById(deptId));
        }
        // POST: /Department/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentModel deptModel)
        {
            if(ModelState.IsValid)
            {
                _departmentRepo.Update(deptModel);
                return RedirectToAction(nameof(Index), nameof(LocationController), LocationController.LocationIndex.Departments);
            }
            return View(deptModel);
        }
    }
}
