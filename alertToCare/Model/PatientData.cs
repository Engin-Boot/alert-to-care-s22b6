using System;

namespace alertToCare.Model
{
    public class PatientData
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string IcuId { get; set; }
        public string BedId { get; set; }
        public Double Bpm { get; set; }
        public Double Spo2 { get; set; }
        public Double RespRate { get; set; }
    }
}
