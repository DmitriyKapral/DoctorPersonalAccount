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
        [HttpGet("get")]
        public IActionResult Gete()
        {
            return Ok(db.Patients.ToList());
        }
        [HttpGet("geting")]
        public IActionResult Geting(int? id = 1)
        {
            /*Account account = db.accounts.Find(id);
            account.test = db.test.Where(m => m.accountid == account.id);
            return Ok(account);*/
            var players = db.Test.Include(p => p.Account);
            return Ok(players.ToList());
        }
        [HttpGet("get/{date}")]
        public IActionResult Get(string date)
        {
            var card = db.Outpatient_cards.Include(p => p.Patient).Include(p => p.Doctor);
            return Ok(card.Where(p => p.date == date && p.doctorid == 1));//Надо будет как то запоминать айди доктора при авторизации
        }
        [HttpPost]
        public IActionResult Create(Account account)
        {
            //Добавляем игрока в таблицу
            db.Accounts.Add(account);
            db.SaveChanges();
            return Ok(200);
        }
        [HttpGet("{id}")]
        public Patient GetPatient(int id)
        {
            Patient patient = db.Patients.FirstOrDefault(x => x.id == id);
            return patient;
        }
        [HttpGet ("hello")]
        public IActionResult Details(int id = 1)
        {
            Outpatient_card student = db.Outpatient_cards.Find(id);
            ViewBag.symptoms = db.Outpatient_cards.ToList();
            return Ok(student);
        }
        /*[HttpGet]
        public IActionResult GetRecord()
        {

        }*/




    }
}
