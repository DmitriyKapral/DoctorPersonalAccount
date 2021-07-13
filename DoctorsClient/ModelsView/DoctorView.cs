using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.ModelsView
{
    public class DoctorView
    {
        [Key]
        public int id { get; set; }
        public string fio { get; set; }
        public string position { get; set; } 
    }
}
