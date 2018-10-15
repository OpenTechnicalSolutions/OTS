using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Index(int technicalId)
        {
            return PartialView(_subTechnicalGroupRepository.GetByTechnicalGroup(technicalId));
        }

        public IActionResult Details(int id)
        {
            return View(_subTechnicalGroupRepository.GetById(id));
        }

        public IActionResult Create(int technicalGroupId)
        {
            ViewBag.TechnicalGroupId = technicalGroupId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubTechnicalGroup subTechnicalGroup)
        {
            if (!ModelState.IsValid)
                return View(subTechnicalGroup);

            _subTechnicalGroupRepository.Add(subTechnicalGroup);
            return RedirectToAction(nameof(Details), nameof(SubTechnicalGroup), subTechnicalGroup.TechnicalGroupId);
        }

        // GET: TechnicalGroup/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_subTechnicalGroupRepository.GetById(id));
        }

        // POST: TechnicalGroup/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubTechnicalGroup subTechnicalGroup)
        {
            try
            {
                // TODO: Add update logic here
                _subTechnicalGroupRepository.Update(subTechnicalGroup);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(subTechnicalGroup);
            }
        }

        // GET: TechnicalGroup/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_subTechnicalGroupRepository.GetById(id));
        }

        // POST: TechnicalGroup/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection iform)
        {
            var technicalGroupId = _subTechnicalGroupRepository.GetById(id).TechnicalGroupId;
            try
            {
                // TODO: Add delete logic here                
                _subTechnicalGroupRepository.Delete(id);
                return RedirectToAction(nameof(Details), nameof(TechnicalGroup), technicalGroupId);
            }
            catch
            {
                return RedirectToAction(nameof(Details), nameof(TechnicalGroup), technicalGroupId);
            }
        }

        public IActionResult SubTechnicalGroupData(int techgroupid)
        {
            return Json(_subTechnicalGroupRepository.GetByTechnicalGroup(techgroupid));
        }
    }
}
