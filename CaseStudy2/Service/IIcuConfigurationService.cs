using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy2.Service
{
    public interface IIcuConfigurationService
    {
        public bool AddNewIcu(Model.IcuSetUpData newState);
    }
}
