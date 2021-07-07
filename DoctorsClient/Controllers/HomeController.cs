﻿using Microsoft.AspNetCore.Mvc;
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
using Microsoft.AspNetCore.Http;
using DoctorsClient.ModelsView;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace DoctorsClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {

        DoctorContext db;
        public HomeController(DoctorContext context)
        {
            db = context;
        }
        /*[Authorize]
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
        }*/
        [HttpGet("get")]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), 400)]
        public IActionResult Gete()
        {
            return Ok(db.Patients.ToList());
        }
        [HttpGet("geting")]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), 400)]
        public IActionResult Geting(int? id = 1)
        {
            /*Account account = db.accounts.Find(id);
            account.test = db.test.Where(m => m.accountid == account.id);
            return Ok(account);*/
            var players = db.Test.Include(p => p.Account);
            return Ok(players.ToList());
        }
        [HttpGet("get/{date}")]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), 400)]
        public IActionResult Get(string date)
        {
            var card = db.Outpatient_cards.Include(p => p.Patient).Include(p => p.Doctor);
            return Ok(card.Where(p => p.date == date && p.doctorid == 1));//Надо будет как то запоминать айди доктора при авторизации
        }
        /*[HttpPost]
        public IActionResult Create(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return Ok(200);
        }*/
        [HttpPost]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), 400)]
        public IActionResult GetPatient(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return Ok(200);
        }

        [HttpGet("hello")]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), 400)]
        public IActionResult Details(int id = 2)
        {
            Account student = db.Accounts.Find(id);
            ViewBag.test = db.Test.ToList();
            return View(student);
        }
        [HttpGet("cards/{id}")]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), 400)]
        public Outpatient_card Cards(int id)
        {
            Outpatient_card card = db.Outpatient_cards.FirstOrDefault(x => x.id == id);
            return card;
        }

        /*[HttpGet]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), 400)]
        public IActionResult GetHistory()
        {
            List<Outpatient_card> outpatient_Card = new List<Outpatient_card>();
            var 
        }*/
        [HttpGet("gettest")]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<Account>), 200)]
        [ProducesResponseType(typeof(Exception), 400)]
        public IActionResult Gettest()
        {
            return View(db.Accounts.ToList());
        }

        /// <summary>
        /// Вывод пациентов записанных к доктору(доделать, вывести текущего пользователя и получить его айди)
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("GetPatients")]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<PatientsView>), 200)]
        [ProducesResponseType(typeof(Exception), 400)]
        public IActionResult GetPatient(string date)
        {
            var patient_view = new List<PatientsView>();
            var cards = db.Outpatient_cards.Where(p => p.date == date && p.doctorid == CurrentDoctor().id).ToList();
            foreach (var item in cards)
            {
                Patient patient = db.Patients.Where(p => p.id == item.patientid).FirstOrDefault();
                patient_view.Add(new PatientsView()
                {
                    Id = patient.id,
                    Name = patient.name,
                    Surname = patient.surname,
                    Patronymic = patient.patronymic,
                    NumberPolicy = patient.numberpolicy,
                    Email = patient.email,
                    NumberPhone = patient.phone,
                    Age = patient.age,
                    Time = item.time
                });
            }
            return Ok(patient_view ?? new List<PatientsView>());
        }
        /// <summary>
        /// Вывод истории посещения
        /// </summary>
        /// <param name="id">id пациента</param>
        /// <returns></returns>
        [HttpGet("GetHistory")]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CardsView>), 200)]
        [ProducesResponseType(typeof(Exception), 400)]
        public IActionResult GetHistory(int id)
        {
            var card_view = new List<CardsView>();
            var cards = db.Outpatient_cards.Where(p => p.patientid == id).ToList();
            foreach (var item in cards)
            {
                Diagnose diagnose = db.Diagnoses.FirstOrDefault(p => p.id == item.diagnoseid);
                Doctor doctor = db.Doctors.FirstOrDefault(p => p.id == item.doctorid);
                TypeOfDisease typeOfDisease = db.TypeOfDiseases.FirstOrDefault(p => p.id == item.typeofdiseaseid);
                card_view.Add(new CardsView()
                {
                    IdHistory = item.id,
                    Diagnose = diagnose.name,
                    NameDoctor = doctor.name,
                    SurnameDoctor = doctor.surname,
                    PatronymicDoctor = doctor.patronymic,
                    Date = item.date,
                    Type = typeOfDisease.name
                });
            }
            return Ok(card_view ?? new List<CardsView>());
        }


        /// <summary>
        /// Вывод подробной записи
        /// </summary>
        /// <param name="id">id записи</param>
        /// <returns></returns>
        [HttpGet("GetRecord/{id}")]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CardView>), 200)]
        [ProducesResponseType(typeof(Exception), 400)]
        public IActionResult GetRecord(int id = 1)
        {
            var card_view = new List<CardView>();
            var cards = db.Outpatient_cards.Where(p => p.id == id).ToList();
            foreach (var item in cards)
            {
                string symptom = "";
                for (int i = 0; i < item.symptomid.Count(); i++)
                {
                    symptom += db.Symptoms.FirstOrDefault(p => p.id == item.symptomid[i]).name + ";";
                }
                symptom = symptom.Substring(0, symptom.Length - 1);
                Doctor doctor = db.Doctors.FirstOrDefault(p => p.id == item.doctorid);
                Position position = db.Positions.FirstOrDefault(p => p.id == doctor.positionid);
                TypeOfDisease typeOfDisease = db.TypeOfDiseases.FirstOrDefault(p => p.id == item.typeofdiseaseid);
                Diagnose diagnose = db.Diagnoses.FirstOrDefault(p => p.id == item.diagnoseid);
                Medication medication = db.Medications.FirstOrDefault(p => p.id == item.medicationid);


                card_view.Add(new CardView()
                {
                    IdRecord = item.medicationid,
                    DateTime = item.date + " " + item.time,
                    FIODoctor = doctor.surname + " " + doctor.name + " " + doctor.patronymic,
                    PositionDoctor = position.name,
                    Symptom = symptom,
                    Type = typeOfDisease.name,
                    Diagnose = diagnose.name,
                    Inspection_description = item.inspection_description,
                    TestMedication = medication.text
                });
            }
            return Ok(card_view ?? new List<CardView>());
        }
        /// <summary>
        /// Вывод пациента по айди
        /// </summary>
        /// <param name="id">id Пациента</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), 400)]
        public Patient GetPatient(int id)
        {
            Patient patient = db.Patients.FirstOrDefault(x => x.id == id);
            return patient;
        }


        /// <summary>
        /// Добавление записи в амблутарную карту (Нужно получать id авторизированного доктора)
        /// </summary>
        /// <param name="cardView"></param>
        /// <param name="idPatient"></param>
        /// <returns></returns>
        [HttpPost("Post")]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(Exception), 400)]
        public IActionResult PostRecord(CardView cardView, int idPatient)
        {
            int iddiagonose = 0;
            int idmedication = 0;
            int idtype = 0;
            var symptoms = cardView.Symptom.Split(';');
            List<int> idsymptoms = new List<int>();
            for (int i = 0; i < symptoms.Length; i++)
            {
                if(db.Symptoms.FirstOrDefault(p => p.name == symptoms[i]) == null)
                {
                    Symptom symptom = new Symptom
                    {
                        name = symptoms[i]
                    };
                    db.Symptoms.Add(symptom);
                    db.SaveChanges();
                }
                idsymptoms.Add(db.Symptoms.FirstOrDefault(p => p.name == symptoms[i]).id);
            }
            idsymptoms.Sort();

            if (db.Diagnoses.FirstOrDefault(p => p.name == cardView.Diagnose) == null)
            {
                Diagnose diagnose = new Diagnose
                {
                    name = cardView.Diagnose
                };
                db.Diagnoses.Add(diagnose);
                db.SaveChanges();
            }
            iddiagonose = db.Diagnoses.FirstOrDefault(p => p.name == cardView.Diagnose).id;


            if (db.Medications.FirstOrDefault(p => p.text == cardView.TestMedication) == null)
            {
                Medication medication = new Medication
                {
                    text = cardView.TestMedication
                };
                db.Medications.Add(medication);
                db.SaveChanges();
            }
            idmedication = db.Medications.ToList().LastOrDefault().id;

            if (db.TypeOfDiseases.FirstOrDefault(p => p.name == cardView.Type) == null)
            {
                TypeOfDisease typeOfDisease = new TypeOfDisease
                {
                    name = cardView.Type
                };
                db.TypeOfDiseases.Add(typeOfDisease);
                db.SaveChanges();
            }
            idtype = db.TypeOfDiseases.FirstOrDefault(p => p.name == cardView.Type).id;

            var datetime = cardView.DateTime.Split(" ");


            Outpatient_card outpatient_Card = new Outpatient_card
            {
                date = datetime[0],
                time = datetime[1],
                inspection_description = cardView.Inspection_description,
                doctorid = CurrentDoctor().id,
                patientid = idPatient,
                diagnoseid = iddiagonose,
                medicationid = idmedication,
                typeofdiseaseid = idtype,
                symptomid = idsymptoms,
                test_resultid = new List<int>()
            };
            db.Outpatient_cards.Add(outpatient_Card);
            db.SaveChanges();
            return Ok(200);
        }




        /*[HttpPost, Route("login")]
        public IActionResult Login([FromBody] Doctor user)
        {
            if (user == null)
                return BadRequest("Invalid client request");

            if (user.email == )
        }
        */



        [HttpPost("Auth")]
        public IActionResult Token([FromBody]Login user)
        {
            var identity = GetIdentity(user.Email, user.Password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            Doctor doctor = db.Doctors.FirstOrDefault(x => x.email == username && x.password == password);
            if (doctor != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, doctor.email),
                    new Claim("Id", doctor.id.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }

        /// <summary>
        /// Получение текущего пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet("Current")]
        public Doctor CurrentDoctor()
        {
            string DoctorId = User.Claims.First(c => c.Type == "Id").Value;
            var doctor =  db.Doctors.FirstOrDefault(p => p.id == Int32.Parse(DoctorId));
            return doctor;
        }
    }
}
