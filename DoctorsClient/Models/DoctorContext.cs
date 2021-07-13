using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DoctorsClient.Models
{
    public class DoctorContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Testtwo> Testtwo { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Outpatient_card> Outpatient_cards { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Test_result> Test_Results { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<TypeOfDisease> TypeOfDiseases { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        //public DbSet<Order> orders { get; set; }

        public DoctorContext(DbContextOptions<DoctorContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
