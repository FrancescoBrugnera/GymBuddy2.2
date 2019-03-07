using GymBuddy.Data;
using GymBuddy.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymBuddy.Controllers
{
    public class GymController : Controller
    {
        private readonly GymBuddyContext _context;
        private readonly IGymBuddyRepository _repo;

        public GymController(GymBuddyContext context, IGymBuddyRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            //throw new InvalidOperationException("An error has occurred");
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(object model)
        {
            return View();
        }

        public IActionResult Shop()
        {
            var results = _repo.GetAllLessons();
            return View(results);
        }
    }
}
