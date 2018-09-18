using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models.Tickets;
using OpenTicketSystem.Models.Users;
using OpenTicketSystem.Repositories.TicketRepositories;
using OpenTicketSystem.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Controllers
{
    public class TicketList : Controller
    {
        private readonly TicketRepository _ticketRepository;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
       

        public TicketList(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var tickets = _ticketRepository.GetAll();
            var myTickets = new TicketQueue(tickets.Where(t => t.CustomerUserId == user.Id));
            myTickets.QueueName = "My Tickets";
            var myAssignedTickets = new TicketQueue(tickets.Where(t => t.TechnicianUserId == user.Id));
            myAssignedTickets.QueueName = "Assigned Tickets";
            var myGroupTickets = new TicketQueue(tickets.Where(t => t.SubTechnicalGroupId == user.SubTechnicalGroupId && t.TechnicianUserId == null));
            myGroupTickets.QueueName = "Group Tickets";

            var viewModel = new TicketQueueViewModel()
            {
                myTickets,
                myAssignedTickets,
                myGroupTickets
            };

            return View(viewModel);
        }

        public IActionResult MyTickets()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
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
