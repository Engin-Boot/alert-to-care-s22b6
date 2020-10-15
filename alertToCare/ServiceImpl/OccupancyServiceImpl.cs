using alertToCare.Model;
using alertToCare.Service;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace alertToCare.ServiceImpl
{
    public class OccupancyServiceImpl : IOccupancyService
    {
        readonly string cs = @"URI=file:C:\BootCamp\CaseStudy2\alert-to-care-s22b6\test.db";
        readonly MonitorServiceImpl _monitorServiceImpl = new MonitorServiceImpl();
        // System.Data.SQLite.SQLiteConnection con;
        //System.Data.SQLite.SQLiteCommand cmd;
        /*  public OccupancyServiceImpl()
          {
              using var con = new SQLiteConnection(cs);
              con.Open();
          }*/
        public List<PatientData> GetPatientsDetails()
        {
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = "SELECT * FROM patientsDetails";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            List<PatientData> patient = new List<PatientData>();
            while (rdr.Read())
            {
                PatientData patientData = new PatientData();
                patientData.Id = rdr.GetInt32(0);
                patientData.Name = rdr.GetString(1);
                patientData.Address = rdr.GetString(2);
                patientData.Email = rdr.GetString(3);
                patientData.Bpm = rdr.GetDouble(4);
                patientData.Spo2 = rdr.GetDouble(5);
                patientData.RespRate = rdr.GetDouble(6);
                patientData.IcuId = rdr.GetInt32(7);
                patientData.BedId = rdr.GetString(8);
                patient.Add(patientData);
            }
            return patient;
        }
        public List<PatientData> GetPatientDetails(int id)
        {
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = "SELECT * FROM patientsDetails where id=" + id;

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            List<PatientData> patient = new List<PatientData>();
            while (rdr.Read())
            {
                PatientData patientData = new PatientData();
                patientData.Id = rdr.GetInt32(0);
                patientData.Name = rdr.GetString(1);
                patientData.Address = rdr.GetString(2);
                patientData.Email = rdr.GetString(3);
                patientData.Bpm = rdr.GetDouble(4);
                patientData.Spo2 = rdr.GetDouble(5);
                patientData.RespRate = rdr.GetDouble(6);
                patientData.IcuId = rdr.GetInt32(7);
                patientData.BedId = rdr.GetString(8);
                patient.Add(patientData);
            }
            return patient;
        }

        public bool CheckBedStatus(string id)
        {
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = "select name from patientsDetails where bedId =" + id;
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            string status = null;
            if (rdr.Read())
            {
                status = rdr.GetString(0);
            }

            if (status != null)
            {
                return true;
            }
            return false;
        }

        public bool AddNewPatient(PatientData newState)
        {
            if (newState != null)
            {
                using var con = new SQLiteConnection(cs);
                con.Open();
                using var cmd = new SQLiteCommand(con);
                cmd.CommandText = "INSERT INTO patientsDetails(name, address,email, bpm,spo2,respRate,icuId,bedId) VALUES('" + newState.Name + "','" + newState.Address + "','" + newState.Email + "'," + newState.Bpm + "," + newState.Spo2 + "," + newState.RespRate + "," + newState.IcuId + ",'" + newState.BedId + "')";
                cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }
        public bool DishchargePatient(int id)
        {
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = "select bpm,spo2,respRate from patientsDetails where id =" + id;
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            bool status = false;
            if (rdr.Read())
            {
                var bpm = rdr.GetDouble(0);
                var spo2 = rdr.GetDouble(1);
                var resprate = rdr.GetDouble(2);
                if (_monitorServiceImpl.VitalsAreOk(bpm, spo2, resprate) == true)
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
