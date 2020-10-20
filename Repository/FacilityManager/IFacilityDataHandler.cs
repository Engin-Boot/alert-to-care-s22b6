using DatabaseManager;
using Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RepositoryManager.FacilityManager
{
    public interface IFacilityDataHandler
    {
        HttpStatusCode AddNewIcu(int TotalBeds, DatabaseContext _context);
        HttpStatusCode UpdateIcu(Facility info, DatabaseContext _context);
        IEnumerable<Facility> GetAllIcuDetails(DatabaseContext _context);
        Facility GetIcuDetailsById(int id, DatabaseContext _context);
    }
}
