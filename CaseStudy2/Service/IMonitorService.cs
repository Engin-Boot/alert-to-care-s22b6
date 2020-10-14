using System;

namespace CaseStudy2.Service
{
    public interface IMonitorService
    {
        public  bool VitalsAreOk(Double bpm, Double spo2, Double respRate);
        public bool MonitorRespRate(int id);
        public bool Monitorspo2s(int id);
        public bool Monitorbpm(int id);
    }
}
