using CaseStudy2.Service;
using System.Data.SQLite;
using CaseStudy2.Model;

namespace CaseStudy2.ServiceImpl
{
    public class OccupancyServiceImpl:IOccupancyService
    {
        readonly string cs = @"URI=file:C:\Bootcamp\CaseStudy2\alert-to-care-s22b6\test.db";
       
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
            cmd.CommandText = "INSERT INTO patientsDetails(name, address,email) VALUES('" + newState.Name+"','"+ newState.Address+ "','" + newState.Email+ "')";
            cmd.ExecuteNonQuery();
        }
    }
}
