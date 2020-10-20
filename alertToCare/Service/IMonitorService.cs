using System;

namespace alertToCare.Service
{
    public interface IMonitorService
    {
        public bool VitalsAreOk(string patientid, Double bpm, Double spo2, Double respRate);
    }
}
