using Models;
using System;
using System.Reflection;

namespace RepositoryManager.VitalManager
{
    public class VitalsStatus
    {
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
            var limitprop = typeof(VitalLimits).GetProperty(prop.Name);
            var limitValue = (DoubleLimits)limitprop.GetValue(limits, null);

            if (IsAbove(input, limitValue))
                return "Above";
            if (IsBelow(input, limitValue))
                return "Below";
            return "Normal";
        }

        private static bool IsBelow(object input, DoubleLimits limitValue)
        {
            return limitValue.Min != null && (double)input < limitValue.Min;
        }

        private static bool IsAbove(object input, DoubleLimits limitValue)
        {
            return limitValue.Max != null && (double)input > limitValue.Max;
        }

        private static PropertyInfo[] GetProperties<T>() => typeof(T).GetProperties();

        readonly VitalLimits limits = new VitalLimits
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

