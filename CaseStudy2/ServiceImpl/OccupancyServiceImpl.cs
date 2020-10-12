using CaseStudy2.Service;
using System.Data.SQLite;
using CaseStudy2.Model;

namespace CaseStudy2.ServiceImpl
{
    public class OccupancyServiceImpl:IOccupancyService
    {
        readonly string cs = @"URI=file:C:\BootCamp\CaseStudy2\alert-to-care-s22b6\test.db";
        MonitorServiceImpl _monitorServiceImpl = new MonitorServiceImpl();
       
        public bool CheckBedStatus(int id)
        {
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = "select status from bed where id =" + id;
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            string status = "";
            if (rdr.Read())
            {
                status = rdr.GetString(0);
            }

            if (status == "Yes")
            {
                return true;
            }
            return false;
        }

        public void AddNewPatient(PatientData newState)
        {
            using var con = new SQLiteConnection(cs);
            con.Open();
            using var cmd = new SQLiteCommand(con);
            cmd.CommandText = "INSERT INTO patientsDetails(name, address,email, bpm,spo2,respRate,icuId,bedId) VALUES('" + newState.Name + "','" + newState.Address + "','" + newState.Email + "'," + newState.Bpm + "," + newState.Spo2 + "," + newState.RespRate + "," + newState.IcuId + ",'" + newState.BedId + "')";
            cmd.ExecuteNonQuery();
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
                var spo2 = rdr.GetDouble (1);
                var resprate = rdr.GetDouble(2);
                if (_monitorServiceImpl.VitalsAreOk(bpm, spo2, resprate) == true)
                {
                    status =  true;
                }
                else
                {
                    status =  false;
                }
            }
            return status;

        }
    }
}
