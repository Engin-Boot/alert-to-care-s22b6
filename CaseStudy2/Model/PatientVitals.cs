using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy2.Model
{
    public class PatientVitals
    {
        public int Id { get; set; }
        public float Bpm { get; set; }
        public float Spo2 { get; set; }
        public float RespRate { get; set; }
    }
}
