﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsClient.Models
{
    public class TypeOfDisease
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
