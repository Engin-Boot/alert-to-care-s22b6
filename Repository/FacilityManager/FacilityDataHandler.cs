using DatabaseManager;
using Models;
using RepositoryManager.FacilityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RepositoryManager.FacilityManager
{
    public class FacilityDataHandler : IFacilityDataHandler
    {
        public HttpStatusCode AddNewIcu(int TotalBeds, DatabaseContext _context)
        {
            var info = new Facility()
            {
                BedCount = TotalBeds,
                Id = GenerateId(_context),
                OccupiedBeds = new List<int>() { }
            };

            _context.Facilities.AddAsync(info);
            _context.SaveChangesAsync();

            return HttpStatusCode.OK;
        }

        public HttpStatusCode UpdateIcu(Facility info, DatabaseContext _context)
        {
            var Dinfo = _context.Facilities.Find(info.Id);

            if ( Dinfo == null)
                return HttpStatusCode.NotFound;

            Dinfo.BedCount = info.BedCount;
            _context.Entry(Dinfo).Property("BedCount").IsModified = true;

            _context.SaveChangesAsync();

            return HttpStatusCode.OK;
        }

        public IEnumerable<Facility> GetAllIcuDetails(DatabaseContext _context)
        {
            return _context.Facilities.ToList();
        }

        public Facility GetIcuDetailsById(int id, DatabaseContext _context)
        {
            return _context.Facilities.Find(id);
        }

        public static int GenerateId(DatabaseContext _context)
        {
            if (_context.Facilities.Any())
                return _context.Facilities.Max(f => f.Id);
            return 1;
        }

    }
}
