using alertToCare.Model;
using alertToCare.Service;
using System.Collections.Generic;
using System.Data.SQLite;


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
                PatientData patientData = new PatientData
                {
                    Id = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Address = rdr.GetString(2),
                    Email = rdr.GetString(3),
                    Bpm = rdr.GetDouble(4),
                    Spo2 = rdr.GetDouble(5),
                    RespRate = rdr.GetDouble(6),
                    IcuId = rdr.GetInt32(7),
                    BedId = rdr.GetString(8)
                };
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
                PatientData patientData = new PatientData
                {
                    Id = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Address = rdr.GetString(2),
                    Email = rdr.GetString(3),
                    Bpm = rdr.GetDouble(4),
                    Spo2 = rdr.GetDouble(5),
                    RespRate = rdr.GetDouble(6),
                    IcuId = rdr.GetInt32(7),
                    BedId = rdr.GetString(8)
                };
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
        public bool UpdatePatientInfo(int id, PatientData state)
        {
            if (state != null)
            {
                using var con = new SQLiteConnection(cs);
                con.Open();
                string stm = $"UPDATE patientsDetails SET bpm = {state.Bpm},spo2 = {state.Spo2},respRate = {state.RespRate} WHERE id = {id}";
                using var cmd = new SQLiteCommand(stm, con);
                using SQLiteDataReader rdr = cmd.ExecuteReader();
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