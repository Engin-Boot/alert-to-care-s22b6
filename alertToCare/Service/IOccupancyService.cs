using alertToCare.Model;
using System.Collections.Generic;


namespace alertToCare.Service
{
    public interface IOccupancyService
    {
        public PatientData CheckBedStatus(string BedId);

        public void AddNewPatient(Model.PatientData newState);
        public void UpdatePatientInfo(string PatientId, Model.PatientData state);
        public PatientData DishchargePatient(string PatientId);
        public IEnumerable<PatientData> GetPatientDetails(string PatientId);
    }
}
