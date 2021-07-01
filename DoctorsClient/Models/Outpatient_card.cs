using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.Models
{
    public class Outpatient_card
    {
        public int id { get; set; }
        public string date { get; set; }
        public TimeSpan time { get; set; }
        public string inspection_description { get; set; }
        public int doctorid { get; set; }
        public Doctor Doctor { get; set; }
        public int patientid { get; set; }
        public Patient Patient { get; set; }
        public int diagnoseid { get; set; }
        public Diagnose Diagnose { get; set; }
        public int medicationid { get; set; }
        public Medication Medication { get; set; }

        public virtual ICollection<Symptom> Symptoms { get; set; }
        public Outpatient_card()
        {
            Symptoms = new List<Symptom>();
        }
    }
}
