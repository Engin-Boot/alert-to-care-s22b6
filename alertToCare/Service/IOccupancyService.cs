using alertToCare.Model;
using System.Collections.Generic;


namespace alertToCare.Service
{
    public interface IOccupancyService
    {
        public bool CheckBedStatus(string id);

        public bool AddNewPatient(Model.PatientData newState);
        public bool UpdatePatientInfo(int id, Model.PatientData state);
        public bool DishchargePatient(int id);

        public List<PatientData> GetPatientsDetails();

        public List<PatientData> GetPatientDetails(int id);
    }
}
