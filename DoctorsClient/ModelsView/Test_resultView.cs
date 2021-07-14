using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.ModelsView
{
    public class Test_resultView
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string urlresult { get; set; }
    }
}
