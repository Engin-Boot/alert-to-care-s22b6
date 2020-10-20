using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class VitalModel
    {
        [Key]
        public int IcuId { get; set; }

        public int BedId { get; set; }
        public Vitals Vital { get; set; }
    }

    public class Vitals
    {
        public double Bpm { get; set; }
        public double Spo2 { get; set; }
        public double RespRate { get; set; }
    }

    public class VitalStatus
    {
        public enum Status { Above, Normal, Below};

        public Patient PatientInfo { get; set; }
        public string Bpm { get; set; }
        public string Spo2 { get; set; }
        public string RespRate { get; set; }
    }

    public class VitalLimits
    {
        public DoubleLimits BpmLimits { get; set; }
        public double Spo2Min { get; set; } 
        public DoubleLimits RespRateLimits { get; set; }
      
    }
    public class DoubleLimits
    {
        public double Max { get; set; }
        public double Min { get; set; }
    }
}
