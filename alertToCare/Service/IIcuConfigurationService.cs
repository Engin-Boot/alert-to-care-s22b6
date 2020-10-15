using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alertToCare.Service
{
    public interface IIcuConfigurationService
    {
        public bool AddNewIcu(Model.IcuSetUpData newState);
    }
}
