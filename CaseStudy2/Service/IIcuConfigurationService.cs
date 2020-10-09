using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy2.Service
{
    public interface IIcuConfigurationService
    {
        public void AddNewIcu(Model.IcuSetUpData newState);
    }
}
