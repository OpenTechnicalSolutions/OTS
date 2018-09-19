using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models.Locations;
using OpenTicketSystem.Repositories.LocationRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Controllers
{
    public class RoomController : Controller
    {
        private RoomRepository _roomRepository;

        public RoomController (RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public JsonResult Index()
        {
            return Json(_roomRepository.GetAll());
        }

        public IActionResult RoomDetails(int id)
        {
            return View(_roomRepository.GetById(id));
        }

        public IActionResult AddRoom()
        {
            return View();
        }
        [HttpPost]
        public void AddRoom(Room room)
        {
            _roomRepository.Add(room);
        }
    }
}
