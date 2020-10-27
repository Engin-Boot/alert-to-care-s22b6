using DatabaseManager;
using Models;
using RepositoryManager.Utilities;
using System.Linq;
using System.Net;

namespace RepositoryManager.PatientManager
{
    public class PatientDataHandler : IPatientDataHandler
    {
        public HttpStatusCode AddPatientToDatabase(Patient info, DatabaseContext context)
        {
            if (!BedListAssist.DoesIcuIdExists(context, info.IcuId))
                return HttpStatusCode.NotFound;

            if (!BedListAssist.IsValidBedId(context, info.BedId, info.IcuId))
                return HttpStatusCode.Forbidden;

            if (BedListAssist.IsBedOccupied(
                context, info.IcuId, info.BedId))
                return HttpStatusCode.Forbidden;

            info.Id = GenerateId(context);

            BedListAssist.AddBedOccupancy(context, info.IcuId, info.BedId);

            context.Patients.AddAsync(info);
            context.SaveChangesAsync();

            return HttpStatusCode.OK;

        }

        public HttpStatusCode RemovePatientFromDb(int id, DatabaseContext context)
        {
            var dinfo = context.Patients.Find(id);

            if (dinfo == null)
                return HttpStatusCode.NotFound;

            BedListAssist.ChangeBedStatusToAvailable(context, dinfo.IcuId, dinfo.BedId);

            context.Remove(dinfo);
            context.SaveChangesAsync();

            return HttpStatusCode.OK;
        }

        public ListOfPatients GetAllPatients(DatabaseContext context) =>
           new ListOfPatients()
           { PatientList = context.Patients.ToList() };

        public Patient GetPatientById(int id, DatabaseContext context) =>
            context.Patients.Find(id);

        private static int GenerateId(DatabaseContext context)
        {
            if (context.Patients.Any())
                return context.Patients.Max(f => f.Id) + 1;
            return default(int) + 1;
        }
    }
}
