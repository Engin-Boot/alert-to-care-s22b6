using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alertToCare.Service
{
    public interface IMonitorService
    {
        public bool VitalsAreOk(Double bpm, Double spo2, Double respRate);
        public bool MonitorRespRate(int id);
        public bool Monitorspo2s(int id);
        public bool Monitorbpm(int id);
    }
}
