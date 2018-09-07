using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models;
using OpenTicketSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Controllers
{
    public class TicketList : Controller
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketList(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Tickets";
            var tickets = _ticketRepository.GetTickets().OrderByDescending(d => d.TimeStamp);
            var ticketViewModelList = new List<TicketPreviewViewModel>();
            foreach (var t in tickets)
                ticketViewModelList.Add(new TicketPreviewViewModel()
                {
                    TicketId = t.Id,
                    TimeStamp = t.TimeStamp,
                    Subject = t.Subject
                });
            return View(ticketViewModelList);
        }

        public IActionResult MyTickets()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewBag.Title = "Ticket Details";
            var ticket = _ticketRepository.GetTicketById(id);
            return View(ticket);
        }

        public IActionResult NewTicket()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewTicket(TicketModel ticketModel)
        {
            if(ModelState.IsValid)
            {
                _ticketRepository.Add(ticketModel);
                return RedirectToAction("Details", ticketModel.Id);
            }
            return View(ticketModel);
            
        }
    }
}
