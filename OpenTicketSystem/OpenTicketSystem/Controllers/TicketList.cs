using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models.Tickets;
using OpenTicketSystem.Repositories;
using OpenTicketSystem.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace OpenTicketSystem.Controllers
{
    public class TicketList : Controller
    {
        private readonly TicketRepository _ticketRepository;

        public TicketList(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Tickets";
            var tickets = _ticketRepository.GetAll().OrderByDescending(d => d.TimeStamp);
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
            var ticket = _ticketRepository.GetById(id);
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
