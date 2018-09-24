using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models.Tickets;
using OpenTicketSystem.Repositories.TicketRepositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenTicketSystem.Controllers.Ticket
{
    public class CommentController : Controller
    {
        private CommentRepository _commentRepository;

        public CommentController(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_commentRepository.GetAll());
        }

        public IActionResult GetTicketComments(int ticketId)
        {
            return View(_commentRepository.GetByTicketId(ticketId));
        }

        public IActionResult CommentDetails(int id)
        {
            return View(_commentRepository.GetById(id));
        }

        public IActionResult AddComment(int ticketId)
        {
            ViewBag.TicketId = ticketId;
            return View();
        }

        [HttpPost]
        public IActionResult AddComment(CommentModel comment)
        {
            if (!ModelState.IsValid)
                return View(comment);

            _commentRepository.Add(comment);
            return RedirectToAction("Details", "Ticket", comment.TicketId);
        }
    }
}
