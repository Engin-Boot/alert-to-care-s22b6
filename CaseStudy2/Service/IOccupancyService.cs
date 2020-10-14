using CaseStudy2.Model;
using System.Collections.Generic;

namespace CaseStudy2.Service
{
    public interface IOccupancyService
    {
        public bool CheckBedStatus(string id);

        public bool AddNewPatient(Model.PatientData newState);

        public bool DishchargePatient(int id);

        public List<PatientData> GetPatientsDetails();
    }
}
