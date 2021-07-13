using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.ModelsView
{
    public class PatientsView
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public string numberPolicy { get; set; }
        public string email { get; set; }
        public string numberPhone { get; set; }
        public int age { get; set; }
        public string time { get; set; }
    }
}
