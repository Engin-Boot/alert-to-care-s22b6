using DatabaseManager;
using Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RepositoryManager.PatientManager
{
    public interface IPatientDataHandler
    {
        HttpStatusCode AddPatientToDatabase(Patient info, DatabaseContext _context);
        HttpStatusCode RemovePatientFromDb(int id, DatabaseContext _context);

    }
}
