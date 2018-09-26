using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models.Users;
using OpenTicketSystem.Repositories.UserRepositories;

namespace OpenTicketSystem.Controllers.Accounts
{
    public class TechnicalGroupController : Controller
    {
        private TechnicalGroupRepository _technicalGroupRepository;

        public TechnicalGroupController(TechnicalGroupRepository technicalGroupRepository)
        {
            _technicalGroupRepository = technicalGroupRepository;
        }

        // GET: TechnicalGroup
        public ActionResult Index()
        {
            return View(_technicalGroupRepository.GetAll());
        }

        // GET: TechnicalGroup/Details/5
        public ActionResult Details(int id)
        {
            return View(_technicalGroupRepository.GetById(id));
        }

        // GET: TechnicalGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TechnicalGroup/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TechnicalGroup technicalGroup)
        {
            if (!ModelState.IsValid)
                return View(technicalGroup);

            try
            {
                // TODO: Add insert logic here                
                _technicalGroupRepository.Add(technicalGroup);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(technicalGroup);
            }
        }

        // GET: TechnicalGroup/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_technicalGroupRepository.GetById(id));
        }

        // POST: TechnicalGroup/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TechnicalGroup technicalGroup)
        {
            try
            {
                // TODO: Add update logic here
                _technicalGroupRepository.Update(technicalGroup);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(technicalGroup);
            }
        }

        // GET: TechnicalGroup/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_technicalGroupRepository.GetById(id));
        }

        // POST: TechnicalGroup/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection iform)
        {
            try
            {
                // TODO: Add delete logic here
                _technicalGroupRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}