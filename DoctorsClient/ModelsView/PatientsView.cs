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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string NumberPolicy { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public int Age { get; set; }
        public string Time { get; set; }
    }
}
