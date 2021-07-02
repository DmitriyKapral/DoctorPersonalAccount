using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.Models
{
    public class Doctor
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public string fullname { get => $"{surname} {name} {patronymic}"; }
        public string email { get; set; }
        public string password { get; set; }
        [ForeignKey("Position")]
        public int positionid { get; set; }
        public Position Position { get; set; }

    }
}
