using DatabaseManager;
using Models;
using System.Net;

namespace RepositoryManager.PatientManager
{
    public interface IPatientDataHandler
    {
        HttpStatusCode AddPatientToDatabase(Patient info, DatabaseContext _context);
        HttpStatusCode RemovePatientFromDb(int id, DatabaseContext _context);

    }
}
