using DatabaseManager;
using Models;
using System.Net;

namespace RepositoryManager.PatientManager
{
    public interface IPatientDataHandler
    {
        HttpStatusCode AddPatientToDatabase(Patient info, DatabaseContext context);
        HttpStatusCode RemovePatientFromDb(int id, DatabaseContext context);
        ListOfPatients GetAllPatients(DatabaseContext context);
        Patient GetPatientById(int id, DatabaseContext context);
    }
}
