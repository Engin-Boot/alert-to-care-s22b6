using alertToCare.Model;
using alertToCare.Service;
using System.Collections.Generic;
using System.Data.SQLite;


namespace alertToCare.ServiceImpl
{
    public class OccupancyServiceImpl : IOccupancyService
    {
        readonly MonitorServiceImpl _monitorServiceImpl = new MonitorServiceImpl();

        PatientData IOccupancyService.CheckBedStatus(string BedId)
        {
            throw new System.NotImplementedException();
        }

        void IOccupancyService.AddNewPatient(PatientData newState)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePatientInfo(string PatientId, PatientData state)
        {
            throw new System.NotImplementedException();
        }

        public void DishchargePatient(string PatientId)
        {
            throw new System.NotImplementedException();
        }

        public List<PatientData> GetPatientDetails(string PatientId)
        {
            throw new System.NotImplementedException();
        }

        PatientData IOccupancyService.DishchargePatient(string PatientId)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<PatientData> IOccupancyService.GetPatientDetails(string PatientId)
        {
            throw new System.NotImplementedException();
        }
    }
}