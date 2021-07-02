using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.Models
{
    public class Test_result
    {
        [Key]
        public int id { get; set; }
        public string urlresult { get; set; }
        public string date { get; set; }

        public List<int> outpatient_cardid { get; set; }
        public virtual List<Outpatient_card> Outpatient_Card { get; set; }
    }
}
