using System;

namespace alertToCare.Service
{
    public interface IIcuConfigurationService
    {
        public bool AddNewIcu(Model.IcuSetUpData newState);
        public bool UpdateIcu(int id, Model.IcuSetUpData state);
    }
}
