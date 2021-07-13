using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.ModelsView
{
    public class _AppointmentView
    {
        [Key]
        public int id { get; set; }
        public string datetime { get; set; }
        [ForeignKey("Patient")]
        public int idpatient { get; set; }
    }
}
