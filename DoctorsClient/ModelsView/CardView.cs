using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DoctorsClient.Models;

namespace DoctorsClient.ModelsView
{
    public class CardView
    {
        [Key]
        public int id { get; set; }
        public string fioPatient { get; set; }
        public string dateTime { get; set; }
        public string fioDoctor { get; set; }
        public string positionDoctor { get; set; }
        public string symptom { get; set; }
        public string type { get; set; }
        public string diagnose { get; set; }
        public string inspection_description { get; set; }
        public string textMedication { get; set; }
        [ForeignKey("Patient")]
        public List<string> test_result { get; set; }
        public int idPatient { get; set; }
    }
}
