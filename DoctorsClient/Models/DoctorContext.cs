using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DoctorsClient.Models
{
    public class DoctorContext : DbContext
    {
        public DbSet<Patient> patients { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Test> test { get; set; }
        public DbSet<Testtwo> testtwo { get; set; }
        public DbSet<Diagnose> diagnoses { get; set; }
        public DbSet<Medication> medications { get; set; }
        public DbSet<Outpatient_card> outpatient_cards { get; set; }
        public DbSet<Symptom> symptoms { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        //public DbSet<Order> orders { get; set; }

        public DoctorContext(DbContextOptions<DoctorContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
