using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.Models
{
    public class Appointment
    {
        [Key]
        public int id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        [ForeignKey("Patient")]
        public int patientid { get; set; }
        [ForeignKey("Doctor")]
        public int doctorid { get; set; }
    }
}
