using alertToCare.Model;
using System;
using System.Net;

namespace alertToCare.Service
{
    public interface IIcuConfigurationService
    {
        public void AddNewIcu(string IcuId, Model.IcuSetUpData newState);
        public void UpdateIcu(string IcuId, Model.IcuSetUpData state);
        public IcuSetUpData GetIcuDetails(string IcuId);
    }
}
