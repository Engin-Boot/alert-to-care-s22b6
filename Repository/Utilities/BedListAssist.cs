using DatabaseManager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryManager.Utilities
{
    public class BedListAssist
    {
        public static bool IsBedOccupied(DatabaseContext context, int icuId, int bedId) =>
            SpiltString(context.Facilities.Find(icuId).OccupiedBeds)
                    .Contains(bedId.ToString());

        private static List<string> SpiltString(string occupiedBeds)
        {
            if (occupiedBeds == null)
                return new List<string>();
            return occupiedBeds.Split(',').ToList();
        }


        public static void AddBedOccupancy(DatabaseContext context, int icuId, int bedId)
        {
            List<string> beds = SpiltString(context.Facilities.Find(icuId).OccupiedBeds);
            beds.Add(bedId.ToString());
            SaveContext(context, icuId, JoinString(beds));
        }

        private static void SaveContext(DatabaseContext context, int icuId, string olist)
        {

            var IcuEntity = context.Facilities.Find(icuId);
            IcuEntity.OccupiedBeds = olist;
            context.Entry(IcuEntity)
                .Property("OccupiedBeds").IsModified = true;
            context.SaveChangesAsync();
        }

        private static string JoinString(List<string> beds) =>
             String.Join(",", beds);

        public static void ChangeBedStatusToAvailable(DatabaseContext context, int icuId, int bedId)
        {
            List<string> beds = SpiltString(context.Facilities.Find(icuId).OccupiedBeds);
            beds.Remove(bedId.ToString());
            SaveContext(context, icuId, JoinString(beds));
        }

        public static bool DoesicuIdExists(DatabaseContext context, int icuId) =>
             context.Facilities.Find(icuId) != null;

        public static bool IsValidbedId(DatabaseContext context, int bedId, int icuId) =>
            bedId <= context.Facilities.Find(icuId).BedCount;

    }
}

