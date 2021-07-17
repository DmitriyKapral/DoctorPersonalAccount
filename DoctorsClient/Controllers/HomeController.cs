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


        /// <summary>
        /// Вывод пациентов записанных к доктору
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("GetPatients/{date}")]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<PatientsView>), 200)]
        [ProducesResponseType(typeof(Exception), 400)]
        public IActionResult GetPatient(string date)
        {
            var patient_view = new List<PatientsView>();
            var cards = db.Appointments.Where(p => p.date == date && p.doctorid == CurrentDoctor().id).ToList();
            if (cards == null)
                return BadRequest();
            foreach (var item in cards)
            {
                Patient patient = db.Patients.Where(p => p.id == item.patientid).FirstOrDefault();
                patient_view.Add(new PatientsView()
                {
                    id = patient.id,
                    name = patient.name,
                    surname = patient.surname,
                    patronymic = patient.patronymic,
                    numberPolicy = patient.numberpolicy,
                    email = patient.email,
                    numberPhone = patient.phone,
                    age = patient.age,
                    time = item.time
                });
            }
            return Ok(patient_view ?? new List<PatientsView>());
        }
        /// <summary>
        /// Вывод истории посещения
        /// </summary>
        /// <param name="id">id пациента</param>
        /// <returns></returns>
        [HttpGet("GetHistory/{id}")]
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
                    id = item.id,
                    diagnose = diagnose.name,
                    nameDoctor = doctor.name,
                    surnamedoctor = doctor.surname,
                    patronymicdoctor = doctor.patronymic,
                    date = item.date,
                    type = typeOfDisease.name
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
                Patient patient = db.Patients.FirstOrDefault(p => p.id == item.patientid);
                Doctor doctor = db.Doctors.FirstOrDefault(p => p.id == item.doctorid);
                Position position = db.Positions.FirstOrDefault(p => p.id == doctor.positionid);
                TypeOfDisease typeOfDisease = db.TypeOfDiseases.FirstOrDefault(p => p.id == item.typeofdiseaseid);
                Diagnose diagnose = db.Diagnoses.FirstOrDefault(p => p.id == item.diagnoseid);
                Medication medication = db.Medications.FirstOrDefault(p => p.id == item.medicationid);

                card_view.Add(new CardView()
                {
                    id = item.medicationid,
                    fioPatient = patient.surname + " " + patient.name + " " + patient.patronymic,
                    dateTime = item.date + "T" + item.time,
                    fioDoctor = doctor.surname + " " + doctor.name + " " + doctor.patronymic,
                    positionDoctor = position.name,
                    symptom = symptom,
                    type = typeOfDisease.name,
                    diagnose = diagnose.name,
                    inspection_description = item.inspection_description,
                    textMedication = medication.text,
                    idPatient = patient.id,
                    test_result = new List<string>()
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
        /// Добавление сдачи анализов
        /// </summary>
        /// <param name="appointmentTestView"></param>
        /// <returns></returns>
        [HttpPost("AddTest")]
        public IActionResult PostTest([FromBody] AppointmentTestView appointmentTestView)
        {
            var datetime = appointmentTestView.datetime.Split("T");
            AppointmentTest appointmentTest = new AppointmentTest
            {
                name = appointmentTestView.name,
                date = datetime[0],
                time = datetime[1],
                patientid = appointmentTestView.patientid,
                doctorid = CurrentDoctor().id
            };
            db.AppointmentTests.Add(appointmentTest);
            db.SaveChanges();
            return Ok(200);
        }

        /// <summary>
        /// Вывод результатов анализов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("testResult/{id}")]
        public IActionResult TestResultId(int id)
        {
            var card = db.Outpatient_cards.FirstOrDefault(p => p.id == id).test_resultid;
            List<Test_resultView> test_ResultViews = new List<Test_resultView>();
            foreach (var item in card)
            {
                test_ResultViews.Add(new Test_resultView
                {
                    name = db.Test_Results.FirstOrDefault(p => p.id == item).name,
                    urlresult = db.Test_Results.FirstOrDefault(p => p.id == item).urlresult
                });
            }
            return Ok(test_ResultViews ?? new List<Test_resultView>());
        }

        /// <summary>
        /// Добавление записи в амблутарную карту (Нужно получать id авторизированного доктора)
        /// </summary>
        /// <param name="cardView"></param>
        /// <returns></returns>
        [HttpPost("Post")]
        [DisableRequestSizeLimit]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(Exception), 400)]
        public IActionResult PostRecord([FromBody]CardView cardView)
        {
            int iddiagonose = 0;
            int idmedication = 0;
            int idtype = 0;
            var symptoms = cardView.symptom.Split(", ");
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

            if (db.Diagnoses.FirstOrDefault(p => p.name == cardView.diagnose) == null)
            {
                Diagnose diagnose = new Diagnose
                {
                    name = cardView.diagnose
                };
                db.Diagnoses.Add(diagnose);
                db.SaveChanges();
            }
            iddiagonose = db.Diagnoses.FirstOrDefault(p => p.name == cardView.diagnose).id;


            if (db.Medications.FirstOrDefault(p => p.text == cardView.textMedication) == null)
            {
                Medication medication = new Medication
                {
                    text = cardView.textMedication
                };
                db.Medications.Add(medication);
                db.SaveChanges();
            }
            idmedication = db.Medications.ToList().LastOrDefault().id;

            if (db.TypeOfDiseases.FirstOrDefault(p => p.name == cardView.type) == null)
            {
                TypeOfDisease typeOfDisease = new TypeOfDisease
                {
                    name = cardView.type
                };
                db.TypeOfDiseases.Add(typeOfDisease);
                db.SaveChanges();
            }
            idtype = db.TypeOfDiseases.FirstOrDefault(p => p.name == cardView.type).id;

            var datetime = cardView.dateTime.Split("T");


            Outpatient_card outpatient_Card = new Outpatient_card
            {
                date = datetime[0],
                time = datetime[1],
                inspection_description = cardView.inspection_description,
                doctorid = CurrentDoctor().id,
                patientid = cardView.idPatient,
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


        /// <summary>
        /// Вывод типов заболеваний
        /// </summary>
        /// <returns></returns>
        [HttpGet("Types")]
        public IActionResult GetTypes()
        { 
            return Ok(db.TypeOfDiseases.ToList());
        }

        /// <summary>
        /// Вывод диагнозов
        /// </summary>
        /// <returns></returns>
        [HttpGet("Diagnose")]
        public IActionResult GetDiagnose()
        {
            return Ok(db.Diagnoses.ToList());
        }

        /// <summary>
        /// Вывод симптомов
        /// </summary>
        /// <returns></returns>
        [HttpGet("Symptoms")]
        public IActionResult GetSympoms()
        {
            return Ok(db.Symptoms.ToList());
        }


        /// <summary>
        /// Вывод авторизированного доктора
        /// </summary>
        /// <returns></returns>
        [HttpGet("Doctor")]
        public IActionResult GetDoctor()
        {
            var doctor_view = new List<DoctorView>();
            doctor_view.Add(new DoctorView()
            {
                fio = CurrentDoctor().surname + " " + CurrentDoctor().name + " " + CurrentDoctor().patronymic,
                position = db.Positions.FirstOrDefault(p => p.id == CurrentDoctor().positionid).name
            });
            return Ok(doctor_view ?? new List<DoctorView>());
        }

        /// <summary>
        /// Добавление записи к врачу
        /// </summary>
        /// <param name="appointmentview"></param>
        /// <returns></returns>
        [HttpPost("AddAppointment")]
        public IActionResult AddAppointment([FromBody]_AppointmentView appointmentview)
        {
            var datetime = appointmentview.datetime.Split("T");
            Appointment appointment = new Appointment
            {
                date = datetime[0].ToString(),
                time = datetime[1],
                patientid = appointmentview.idpatient,
                doctorid = CurrentDoctor().id
            };
            db.Appointments.Add(appointment);
            db.SaveChanges();
            return Ok(200);
        }

        /// <summary>
        /// Вывод пациента по ФИО и Номеру полиса
        /// </summary>
        /// <param name="searchPatient"></param>
        /// <returns></returns>
        [HttpPost("SearchPatient")]
        public IActionResult SearchPatient([FromBody]SearchPatient searchPatient)
        {
            if(searchPatient.fio == null)
                return BadRequest();
            var fio = searchPatient.fio.Split(" ");
            Patient patient = db.Patients.FirstOrDefault(p => p.name == fio[1] && p.surname == fio[0] && p.patronymic == fio[2] && p.numberpolicy == searchPatient.numberpolicy);
            if (patient == null)
                return BadRequest();
            else
                return Ok(patient);
        }


        /// <summary>
        /// Авторизаця
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Auth")]
        [Authorize]
        [AllowAnonymous]
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
                token = encodedJwt,
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
        [Authorize]
        public Doctor CurrentDoctor()
        {
            string DoctorId = User.Claims.First(c => c.Type == "Id").Value;
            var doctor =  db.Doctors.FirstOrDefault(p => p.id == Int32.Parse(DoctorId));
            return doctor;
        }
    }
}
