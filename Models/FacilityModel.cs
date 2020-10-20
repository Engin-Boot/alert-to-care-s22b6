using System.Collections.Generic;

namespace Models
{
    public class Facility
    {
        public int Id { get; set; }
        public int BedCount { get; set; }
        public List<BedList> OccupiedBeds { get; set; }
    }

    public class BedList
    {
        public int BedId { get; set; }
    }

    public class ListOfFacility
    {
        public List<Facility> FacilityList { get; set; }
    }
}

