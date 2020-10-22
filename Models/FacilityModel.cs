using System.Collections.Generic;

namespace Models
{
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
}

