using DatabaseManager;
using Models;
using System;
using System.Linq;

namespace RepositoryManager.VitalManager
{
    public class VitalDataHandler : IVitalDataHandler
    {
        public VitalStatus MonitorVitals(VitalModel info, DatabaseContext _context)
        {
            VitalLimits limits = GetLimits();
            return new VitalStatus
            {
                Bpm = Enum.GetName(typeof(VitalStatus.Status),
                BpmIsOk(limits.BpmLimits, info.Vital.Bpm)),
                Spo2 = Enum.GetName(typeof(VitalStatus.Status),
                Spo2IsOk(limits.Spo2Min, info.Vital.Spo2)),
                RespRate = Enum.GetName(typeof(VitalStatus.Status),
                RespRateIsOk(limits.RespRateLimits, info.Vital.RespRate)),
                PatientInfo = _context.Patients
                .Where(p => p.BedId == info.BedId && p.IcuId == info.IcuId)
                .FirstOrDefault()
            };
        }


        private VitalStatus.Status BpmIsOk(DoubleLimits dlimits, double bpm)
        {
            if (bpm < dlimits.Min)
                return VitalStatus.Status.Below;
            else if (bpm > dlimits.Max)
                return VitalStatus.Status.Below;
            return VitalStatus.Status.Normal;
        }

        private VitalStatus.Status Spo2IsOk(double Spo2min, double Spo2)
        {
            if (Spo2 < Spo2min)
                return VitalStatus.Status.Below;
            return VitalStatus.Status.Normal;

        }
        private VitalStatus.Status RespRateIsOk(DoubleLimits dlimits, double respRate)
        {
            if (respRate < dlimits.Min)
                return VitalStatus.Status.Below;
            else if (respRate > dlimits.Max)
                return VitalStatus.Status.Above;
            return VitalStatus.Status.Normal;
        }

        private VitalLimits GetLimits()
        {
            return new VitalLimits
            {
                RespRateLimits = new DoubleLimits
                {
                    Max = 95,
                    Min = 30
                },
                Spo2Min = 90,
                BpmLimits = new DoubleLimits
                {
                    Max = 150,
                    Min = 70
                }
            };
        }
    }
}
