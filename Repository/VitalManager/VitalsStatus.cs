using Models;
using System;
using System.Reflection;

namespace RepositoryManager.VitalManager
{
    public class VitalsStatus
    {
        readonly VitalLimits limits = GetLimitValue();

        public VitalStatus CheckVitalStatus(Vitals info)
        {
            var VitalStatusResult = new VitalStatus();

            var infoProperties = GetProperties<Vitals>();
            foreach (var prop in infoProperties)
            {
                var Resultprop = typeof(VitalStatus).GetProperty(prop.Name);
                Resultprop.SetValue(VitalStatusResult,
                    CheckVitalInRange(prop, prop.GetValue(info,null)));
            }
            return VitalStatusResult;

        }

        private string CheckVitalInRange(PropertyInfo prop, object input)
        {
            var limitValue = GetLimits(prop);

            if (limitValue.Max!= null && (double)input > limitValue.Max)
                return "Above";
            else if (limitValue.Min!= null && (double)input < limitValue.Min)
                return "Below";
            return "Normal";

        }

        private static PropertyInfo[] GetProperties<T>() => typeof(T).GetProperties();

        private DoubleLimits GetLimits(PropertyInfo prop)
        {
            var Limitprop = typeof(VitalLimits).GetProperty(prop.Name);
            return (DoubleLimits)Limitprop.GetValue(limits,null);
        }

        private static VitalLimits GetLimitValue()
        {
            return new VitalLimits
            {
                RespRate = new DoubleLimits
                {
                    Max = 95,
                    Min = 30
                },
                Spo2 = new DoubleLimits
                {
                    Max = null,
                    Min = 90,
                },
                Bpm = new DoubleLimits
                {
                    Max = 150,
                    Min = 70
                }
            };
        }
    }
}
