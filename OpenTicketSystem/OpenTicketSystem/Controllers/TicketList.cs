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
            var tickets = _ticketRepository.GetTickets();
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

        public IActionResult TicketDetails(int id)
        {
            var ticket = _ticketRepository.GetTicketById(id);
            return View(ticket);
        }
    }
}
