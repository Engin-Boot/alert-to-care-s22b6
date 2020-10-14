using System;

namespace CaseStudy2.Service
{
    public interface IIcuConfigurationService
    {
        public bool AddNewIcu(Model.IcuSetUpData newState);
    }
}
