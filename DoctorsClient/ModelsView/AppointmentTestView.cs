using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.ModelsView
{
    public class AppointmentTestView
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string datetime { get; set; }
        [ForeignKey("Patient")]
        public int patientid { get; set; }
    }
}
