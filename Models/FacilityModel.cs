using JetBrains.Annotations;
using System.Collections.Generic;

namespace Models
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class Facility
    {
        public int Id { get; set; }
        public int BedCount { get; set; }
        public string OccupiedBeds { get; set; }
    }

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class ListOfFacility
    {
        public List<Facility> FacilityList { get; set; }
    }
}

