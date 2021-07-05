using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.Models
{
    public class Test
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<Account> Account { get; set; }

    }
}
