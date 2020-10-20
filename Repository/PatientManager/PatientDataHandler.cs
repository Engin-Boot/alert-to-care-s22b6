using DatabaseManager;
using Models;
using RepositoryManager.PatientManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RepositoryManager.PatientManager
{
    public class PatientDataHandler : IPatientDataHandler
    {
        public HttpStatusCode AddPatientToDatabase(Patient info,DatabaseContext _context)
        {
            if (_context.Facilities.Find(info.IcuId).OccupiedBeds.Contains(info.BedId))
                return HttpStatusCode.Forbidden;

            info.Id = GenerateId(_context);
            _context.Facilities.Find(info.IcuId).OccupiedBeds.Add(info.BedId);

            _context.Entry(_context.Facilities.Find(info.IcuId))
                .Property("OccupiedBeds").IsModified = true;

            _context.Patients.AddAsync(info);
            _context.SaveChangesAsync();

            return HttpStatusCode.OK;
            
        }

        public HttpStatusCode RemovePatientFromDb(int id, DatabaseContext _context)
        {
            var Dinfo = _context.Patients.Find(id);

            if (Dinfo == null)
                return HttpStatusCode.NotFound;

            _context.Remove(Dinfo);
            _context.SaveChangesAsync();

            return HttpStatusCode.OK;
        }


        private static int GenerateId(DatabaseContext _context)
        {
            if (_context.Patients.Any())
                return _context.Patients.Max(f => f.Id);
            return 1;
        }
    }
}
