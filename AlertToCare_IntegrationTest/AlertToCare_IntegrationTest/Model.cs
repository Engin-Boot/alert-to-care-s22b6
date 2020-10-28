using System.Collections.Generic;

namespace AlertToCare_IntegrationTest
{
    class Model
    {
    }
    public class Facility
    {
        public int Id { get; set; }
        public int BedCount { get; set; }
        public string OccupiedBeds { get; set; }
    }

    public class ListOfFacility
    {
        public List<Facility> FacilityList { get; set; }
    }
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public int BedId { get; set; }
        public int IcuId { get; set; }
    }

    public class ListOfPatients
    {
        public List<Patient> PatientList { get; set; }
    }
    public class VitalModel
    {
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
        public enum Status { Above, Normal, Below };

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
