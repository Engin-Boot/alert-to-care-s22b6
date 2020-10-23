using DatabaseManager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryManager.Utilities
{
    public class BedListAssist
    {
        public static bool IsBedOccupied(DatabaseContext _context, int IcuId, int BedId) =>
            SpiltString(_context.Facilities.Find(IcuId).OccupiedBeds)
                    .Contains(BedId.ToString());

        private static List<string> SpiltString(string occupiedBeds)
        {
            if (occupiedBeds == null)
                return new List<string>();
            return occupiedBeds.Split(',').ToList();
        }


        public static void AddBedOccupancy(DatabaseContext _context, int IcuId, int BedId)
        {
            List<string> Beds = SpiltString(_context.Facilities.Find(IcuId).OccupiedBeds);
            Beds.Add(BedId.ToString());
            SaveContext(_context, IcuId, JoinString(Beds));
        }

        private static void SaveContext(DatabaseContext _context, int IcuId, string olist)
        {

            var IcuEntity = _context.Facilities.Find(IcuId);
            IcuEntity.OccupiedBeds = olist;
            _context.Entry(IcuEntity)
                .Property("OccupiedBeds").IsModified = true;
            _context.SaveChangesAsync();
        }

        private static string JoinString(List<string> beds) =>
             String.Join(",", beds);

        public static void ChangeBedStatusToAvailable(DatabaseContext _context, int IcuId, int BedId)
        {
            List<string> Beds = SpiltString(_context.Facilities.Find(IcuId).OccupiedBeds);
            Beds.Remove(BedId.ToString());
            SaveContext(_context, IcuId, JoinString(Beds));
        }

        public static bool DoesIcuIdExists(DatabaseContext _context, int IcuId) =>
             _context.Facilities.Find(IcuId) != null;

        public static bool IsValidBedId(DatabaseContext _context, int BedId, int IcuId) =>
            BedId <= _context.Facilities.Find(IcuId).BedCount;

    }
}

