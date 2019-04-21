using GymBuddy.Data;
using GymBuddy.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymBuddy.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LessonsController : Controller
    {
        private readonly IGymBuddyRepository _repository;

        public LessonsController(IGymBuddyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Lesson>> Get()
        {
            try
            {
                return Ok(_repository.GetAllLessons());
            }
            catch
            {
                return BadRequest("failed to return all lessons");
            }
            
        }
    }
}

