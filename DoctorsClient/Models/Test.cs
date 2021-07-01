using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.Models
{
    public class Test
    {
        public int id { get; set; }
        public string name { get; set; }
        public int accountid { get; set; }
        public Account Account { get; set; }
        public int testtwoid { get; set; }
        public Testtwo Testtwo { get; set; }
    }
}
