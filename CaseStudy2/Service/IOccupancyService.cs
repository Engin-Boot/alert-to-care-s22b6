using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy2.Service
{
    public interface IOccupancyService
    {
        public bool CheckBedStatus(int id);

        void AddNewPatient(Model.PatientData newState);

        public bool DishchargePatient(int id);
    }
}
