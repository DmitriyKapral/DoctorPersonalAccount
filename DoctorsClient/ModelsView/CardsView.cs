using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.ModelsView
{
    public class CardsView
    {
        [Key]
        public int IdHistory { get; set; }
        public string Diagnose { get; set; }
        public string NameDoctor { get; set; }
        public string SurnameDoctor { get; set; }
        public string PatronymicDoctor { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
    }
}
