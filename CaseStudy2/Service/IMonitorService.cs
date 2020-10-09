using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy2.Service
{
    public interface IMonitorService
    {
       public  bool VitalsAreOk(Double bpm, Double spo2, Double respRate);
    }
}
