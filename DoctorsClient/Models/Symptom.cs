using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.Models
{
    public class Symptom
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<Outpatient_card> Outpatient_Cards { get; set; }
        public Symptom()
        {
            Outpatient_Cards = new List<Outpatient_card>();
        }
    }
}
