using System;

namespace alertToCare.Service
{
    public interface IMonitorService
    {
        public bool VitalsAreOk(Double bpm, Double spo2, Double respRate);
        public bool MonitorRespRate(int id);
        public bool Monitorspo2(int id);
        public bool Monitorbpm(int id);
    }
}
