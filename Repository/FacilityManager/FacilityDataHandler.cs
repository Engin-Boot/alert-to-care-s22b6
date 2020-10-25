using DatabaseManager;
using Models;
using System.Linq;
using System.Net;

namespace RepositoryManager.FacilityManager
{
    public class FacilityDataHandler : IFacilityDataHandler
    {
        public HttpStatusCode AddNewIcu(int totalBeds, DatabaseContext context)
        {
            var info = new Facility
            {
                BedCount = totalBeds,
                Id = GenerateId(context)
            };

            context.Facilities.AddAsync(info);
            context.SaveChangesAsync();

            return HttpStatusCode.OK;
        }

        public HttpStatusCode UpdateIcu(Facility info, DatabaseContext context)
        {
            var dinfo = context.Facilities.Find(info.Id);

            if (dinfo == null)
                return HttpStatusCode.NotFound;

            dinfo.BedCount = info.BedCount;
            context.Entry(dinfo).Property("BedCount").IsModified = true;

            context.SaveChangesAsync();

            return HttpStatusCode.OK;
        }

        public ListOfFacility GetAllIcuDetails(DatabaseContext context) =>
           new ListOfFacility()
           { FacilityList = context.Facilities.ToList() };

        public Facility GetIcuDetailsById(int id, DatabaseContext context) =>
                 context.Facilities.Find(id);

        private static int GenerateId(DatabaseContext context)
        {
            if (context.Facilities.Any())
                return context.Facilities.Max(f => f.Id) + 1;
            return default(int) + 1;
        }

    }
}
