using DatabaseManager;
using Models;
using RepositoryManager.Utilities;
using System.Linq;
using System.Net;

namespace RepositoryManager.PatientManager
{
    public class PatientDataHandler : IPatientDataHandler
    {
        public HttpStatusCode AddPatientToDatabase(Patient info, DatabaseContext _context)
        {
            if (BedListAssist.IsBedOccupied(
                _context,info.IcuId,info.BedId))
                return HttpStatusCode.Forbidden;

            info.Id = GenerateId(_context);
            BedListAssist.AddBedOccupancy(_context, info.IcuId, info.BedId);

            _context.Patients.AddAsync(info);
            _context.SaveChangesAsync();

            return HttpStatusCode.OK;

        }

        public HttpStatusCode RemovePatientFromDb(int id, DatabaseContext _context)
        {
            var Dinfo = _context.Patients.Find(id);

            if (Dinfo == null)
                return HttpStatusCode.NotFound;

            BedListAssist.ChangeBedStatusToAvailable(_context, Dinfo.IcuId, Dinfo.BedId);

            _context.Remove(Dinfo);
            _context.SaveChangesAsync();

            return HttpStatusCode.OK;
        }


        private static int GenerateId(DatabaseContext _context)
        {
            if (_context.Patients.Any())
                return _context.Patients.Max(f => f.Id) + 1;
            return default(int) + 1;
        }
    }
}
