using DatabaseManager;
using Models;
using System;
using System.Linq;

namespace RepositoryManager.VitalManager
{
    public class VitalDataHandler : IVitalDataHandler
    {
        public VitalStatus MonitorVitals(VitalModel info, DatabaseContext context)
        {
            VitalsStatus Vitalcheck = new VitalsStatus();
            var Vitals = Vitalcheck.CheckVitalStatus(info.Vital);
            Vitals.PatientInfo = _context.Patients
                .Where(p => p.BedId == info.BedId && p.IcuId == info.IcuId)
                .FirstOrDefault();

            return Vitals;          
        }
    }
}
