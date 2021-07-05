using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorsClient.Models;

namespace DoctorsClient.ModelsView
{
    public class CardView
    {
        public int IdRecord { get; set; }
        public string DateTime { get; set; }
        public string FIODoctor { get; set; }
        public string PositionDoctor { get; set; }
        public string Symptom { get; set; }
        public string Type { get; set; }
        public string Diagnose { get; set; }
        public string Inspection_description { get; set; }
        public string TestMedication { get; set; }
    }
}
