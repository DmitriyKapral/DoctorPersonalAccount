using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DoctorsClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DoctorsClient.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {

        DoctorContext db;
        public HomeController(DoctorContext context)
        {
            db = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Content(User.Identity.Name);
            }
            return Content("не аутентифицирован");
        }
        public IActionResult About()
        {
            return Content("Authorized");
        }
        /* public IActionResult Index()
         {
             return View(db.patients.ToList());
         }*/
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(db.patients.ToList());
        }
        [HttpGet("geting")]
        public IActionResult Geting()
        {
            var players = db.test.Include(p => p.Account);
            return Ok(players.ToList());
        }
        [HttpGet("{date}")]
        public IActionResult GetPatients(string date)
        {
            var card = db.outpatient_cards.Include(p => p.Patient).Include(p => p.Doctor);
            return Ok(card.Where(p => p.date == date && p.doctorid == 1));//Надо будет как то запоминать айди доктора при авторизации
        }
        /*[HttpGet]
        public IActionResult GetRecord()
        {

        }*/




    }
}
