using DatabaseManager;
using Models;
using System.Collections.Generic;
using System.Net;

namespace RepositoryManager.FacilityManager
{
    public interface IFacilityDataHandler
    {
        HttpStatusCode AddNewIcu(int TotalBeds, DatabaseContext _context);
        HttpStatusCode UpdateIcu(Facility info, DatabaseContext _context);
        ListOfFacility GetAllIcuDetails(DatabaseContext _context);
        Facility GetIcuDetailsById(int id, DatabaseContext _context);
    }
}
