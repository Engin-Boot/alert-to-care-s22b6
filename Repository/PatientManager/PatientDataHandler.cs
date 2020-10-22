﻿using DatabaseManager;
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
            info.Id = GenerateId(_context);

            if (info.Id > _context.Facilities.Find(info.IcuId).BedCount)
                return HttpStatusCode.Ambiguous;

            if (BedListAssist.IsBedOccupied(
                _context, info.IcuId, info.BedId))
                return HttpStatusCode.Forbidden;

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

        public ListOfPatients GetAllPatients(DatabaseContext _context) =>
           new ListOfPatients()
           { PatientList = _context.Patients.ToList() };

        public Patient GetPatientById(int id, DatabaseContext _context) =>
            _context.Patients.Find(id);

        private static int GenerateId(DatabaseContext _context)
        {
            if (_context.Patients.Any())
                return _context.Patients.Max(f => f.Id) + 1;
            return default(int) + 1;
        }
    }
}
