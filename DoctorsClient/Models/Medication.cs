﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.Models
{
    public class Medication
    {
        [Key]
        public int id { get; set; }
        public string text { get; set; }
        public ICollection<Outpatient_card> Outpatient_Card { get; set;  }
    }
}
