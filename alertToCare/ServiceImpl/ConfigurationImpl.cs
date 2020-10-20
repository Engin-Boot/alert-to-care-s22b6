using alertToCare.Model;
using alertToCare.Service;
using System.Collections.Generic;
using System.Data.SQLite;


namespace alertToCare.ServiceImpl
{
    public class ConfigurationImpl : IIcuConfigurationService
    {
        //List<Models.PatientDataModel> _db = new List<PatientDataModel>();
        List<Model.IcuSetUpData> _db = new List<IcuSetUpData>();
        // ITransactionManager _tranx;
        public ConfigurationImpl()
        {

            _db.Add(new IcuSetUpData
            {
                IcuId = "ICU001",
                BedsCount = 10,
                Layout = "normal",
            }
            );
            _db.Add(new IcuSetUpData
            {
                IcuId = "ICU002",
                BedsCount = 12,
                Layout = "normal",
            }
           );
        }
        public IcuSetUpData GetIcuDetails(string IcuId)
        {
            for (int i = 0; i < _db.Count; i++)
            {
                if (_db[i].IcuId == IcuId)
                {
                    return _db[i];
                }
            }
            return null;
        }


        void IIcuConfigurationService.AddNewIcu(string IcuId, IcuSetUpData newState)
        {
            _db.Add(newState);
        }

        void IIcuConfigurationService.UpdateIcu(string IcuId, IcuSetUpData state)
        {
            throw new System.NotImplementedException();
        }
    }
}