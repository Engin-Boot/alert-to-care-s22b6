using alertToCare.Service;
using System;
using System.Data.SQLite;


namespace alertToCare.ServiceImpl
{
    public class MonitorServiceImpl : IMonitorService
    {
        public bool VitalsAreOk(string patientid, double bpm, double spo2, double respRate)
        {
            throw new NotImplementedException();
        }
    }
}