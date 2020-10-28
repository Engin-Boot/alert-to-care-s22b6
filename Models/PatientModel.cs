using JetBrains.Annotations;
using System.Collections.Generic;

namespace Models
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public int BedId { get; set; }
        public int IcuId { get; set; }
    }

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class ListOfPatients
    {
        public List<Patient> PatientList { get; set; }
    }
}
