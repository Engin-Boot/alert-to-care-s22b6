using alertToCare.Service;
using System;
using System.Data.SQLite;


namespace alertToCare.ServiceImpl
{
    public class MonitorServiceImpl : IMonitorService
    {
        readonly string cs = @"URI=file:C:\BootCamp\CaseStudy2\alert-to-care-s22b6\test.db";
        System.Data.SQLite.SQLiteConnection con;
        // System.Data.SQLite.SQLiteCommand cmd;

        /*   public MonitorServiceImpl()
           {
               using var con = new SQLiteConnection(cs);
               con.Open();
           }*/
        public bool BpmIsOk(Double bpm, Double minBpm, Double maxBpm)
        {
            if (bpm < minBpm || bpm > maxBpm)
                return false;
            return true;
        }

        public bool Spo2IsOk(Double spo2, Double minSpo2)
        {
            if (spo2 < minSpo2)
                return false;
            return true;
        }
        public bool RespRateIsOk(Double respRate, Double minRespRate, Double maxRespRate)
        {
            if (respRate < minRespRate || respRate > maxRespRate)
                return false;
            return true;
        }
        public bool BpmAndSpo2AreOk(Double bpm, Double spo2)
        {
            if (BpmIsOk(bpm, 70, 150) && Spo2IsOk(spo2, 90))
                return true;
            return false;
        }
        public bool VitalsAreOk(Double bpm, Double spo2, Double respRate)
        {
            if (BpmAndSpo2AreOk(bpm, spo2) && RespRateIsOk(respRate, 30, 95))
                return true;
            return false;
        }

        public bool MonitorRespRate(int id)
        {
            con = new SQLiteConnection(cs);
            con.Open();
            string stm = "select respRate from patientsDetails where id =" + id;
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            bool status = false;
            if (rdr.Read())
            {
                var respRate = rdr.GetDouble(0);
                if (RespRateIsOk(respRate, 30, 95) == true)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            return status;
        }

        public bool Monitorspo2(int id)
        {
            con = new SQLiteConnection(cs);
            con.Open();
            string stm = "select spo2 from patientsDetails where id =" + id;
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            bool status = false;
            if (rdr.Read())
            {
                var spo2 = rdr.GetDouble(0);
                if (Spo2IsOk(spo2, 90) == true)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            return status;
        }
        public bool Monitorbpm(int id)
        {
            con = new SQLiteConnection(cs);
            con.Open();
            string stm = "select bpm from patientsDetails where id =" + id;
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            bool status = false;
            if (rdr.Read())
            {
                var bpm = rdr.GetDouble(0);
                if (BpmIsOk(bpm, 70, 150) == true)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            return status;
        }
    }
}