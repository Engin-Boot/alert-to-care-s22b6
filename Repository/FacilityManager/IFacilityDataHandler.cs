using DatabaseManager;
using Models;
using System.Net;

namespace RepositoryManager.FacilityManager
{
    public interface IFacilityDataHandler
    {
        HttpStatusCode AddNewIcu(int totalBeds, DatabaseContext context);
        HttpStatusCode UpdateIcu(Facility info, DatabaseContext context);
        ListOfFacility GetAllIcuDetails(DatabaseContext context);
        Facility GetIcuDetailsById(int id, DatabaseContext context);
    }
}
