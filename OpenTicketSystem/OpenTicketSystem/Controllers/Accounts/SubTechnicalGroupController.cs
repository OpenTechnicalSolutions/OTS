using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models.Users;
using OpenTicketSystem.Repositories.UserRepositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenTicketSystem.Controllers.Accounts
{
    public class SubTechnicalGroupController : Controller
    {

        private SubTechnicalGroupRepository _subTechnicalGroupRepository;

        public SubTechnicalGroupController(SubTechnicalGroupRepository subTechnicalGroupRepository)
        {
            _subTechnicalGroupRepository = subTechnicalGroupRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_subTechnicalGroupRepository.GetAll());
        }

        public IActionResult SubTechnicalGroupDetails(int id)
        {
            return View(_subTechnicalGroupRepository.GetById(id));
        }

        public IActionResult CreateSubTechnicalGroup(int technicalGroupId)
        {
            ViewBag.TechnicalGroupId = technicalGroupId;
            return View();
        }

        [HttpPost]
        public IActionResult CreateSubTechnicalGroup(SubTechnicalGroup subTechnicalGroup)
        {
            if (!ModelState.IsValid)
                return View(subTechnicalGroup);

            _subTechnicalGroupRepository.Add(subTechnicalGroup);
            return RedirectToAction("TechnicalGroupDetails", "TechnicalGroup", subTechnicalGroup.TechincalGroupId);
        }
    }
}
