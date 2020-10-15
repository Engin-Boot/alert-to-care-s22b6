using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alertToCare.Model
{
    public class PatientData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int IcuId { get; set; }
        public string BedId { get; set; }
        public Double Bpm { get; set; }
        public Double Spo2 { get; set; }
        public Double RespRate { get; set; }
    }
}
