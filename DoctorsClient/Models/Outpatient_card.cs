using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.Models
{
    public class Outpatient_card
    {
        [Key]
        public int id { get; set; }
        public string date { get; set; }
        public TimeSpan time { get; set; }
        public string inspection_description { get; set; }
        [ForeignKey("Doctor")]
        public int doctorid { get; set; }
        public Doctor Doctor { get; set; }
        [ForeignKey("Patient")]
        public int patientid { get; set; }
        public Patient Patient { get; set; }
        [ForeignKey("Diagnose")]
        public int diagnoseid { get; set; }
        public Diagnose Diagnose { get; set; }
        [ForeignKey("Medication")]
        public int medicationid { get; set; }
        public Medication Medication { get; set; }

        public List<int> symptomid { get; set; }
        public virtual List<Symptom> Symptom { get; set; }

        public List<int> test_resultid { get; set; }
        public virtual List<Test_result> Test_Result { get; set; }
    }
}
