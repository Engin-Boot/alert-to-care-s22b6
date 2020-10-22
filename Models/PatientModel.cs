using System.Collections.Generic;

namespace Models
{
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
}
