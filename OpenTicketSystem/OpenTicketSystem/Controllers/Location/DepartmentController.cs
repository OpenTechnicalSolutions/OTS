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
    public class DepartmentController : Controller
    {
        private DepartmentRepository _departmentRepo;

        public DepartmentController(DepartmentRepository departmentRepo)
        {
            _departmentRepo = departmentRepo;
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
    }
}
