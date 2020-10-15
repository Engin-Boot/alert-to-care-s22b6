using alertToCare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alertToCare.Service
{
    public interface IOccupancyService
    {
        public bool CheckBedStatus(string id);

        public bool AddNewPatient(Model.PatientData newState);

        public bool DishchargePatient(int id);

        public List<PatientData> GetPatientsDetails();

        public List<PatientData> GetPatientDetails(int id);
    }
}
