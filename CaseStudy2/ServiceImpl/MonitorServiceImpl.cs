using CaseStudy2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy2.ServiceImpl
{
    public class MonitorServiceImpl :IMonitorService
    {
        
        public bool BpmIsOk(Double bpm, Double minBpm, Double maxBpm)
        {
            if (bpm < minBpm || bpm > maxBpm)
                return false;
            return true;
        }
       public  bool Spo2IsOk(Double spo2, Double minSpo2)
        {
            if (spo2 < minSpo2)
                return false;
            return true;
        }
         public bool RespRateIsOk(Double respRate, Double minRespRate, Double maxRespRate)
        {
            if (respRate < minRespRate || respRate > maxRespRate)
                return false;
            return true;
        }
         public bool BpmAndSpo2AreOk(Double bpm, Double spo2)
        {
            if (BpmIsOk(bpm, 70, 150) && Spo2IsOk(spo2, 90))
                return true;
            return false;
        }
        public bool VitalsAreOk(Double bpm, Double spo2, Double respRate)
        {
            if (BpmAndSpo2AreOk(bpm, spo2) && RespRateIsOk(respRate, 30, 95))
                return true;
            return false;
        }
    }
}
