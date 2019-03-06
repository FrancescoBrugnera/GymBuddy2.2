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

        public GymController(GymBuddyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Shop()
        {
            var results = _context.Lessons
                .OrderBy(l => l.Category)
                .ToList();
            return View();
        }
    }
}
