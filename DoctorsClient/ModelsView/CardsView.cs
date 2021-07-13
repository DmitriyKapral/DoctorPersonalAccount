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
        public int id { get; set; }
        public string diagnose { get; set; }
        public string nameDoctor { get; set; }
        public string surnamedoctor { get; set; }
        public string patronymicdoctor { get; set; }
        public string date { get; set; }
        public string type { get; set; }
    }
}
