using alertToCare.Service;
using System.Data.SQLite;


namespace alertToCare.ServiceImpl
{
    public class ConfigurationImpl: IIcuConfigurationService
    {
        readonly string cs = @"URI=file:C:\BootCamp\CaseStudy2\alert-to-care-s22b6\test.db";
        System.Data.SQLite.SQLiteConnection con;
        System.Data.SQLite.SQLiteCommand cmd;
        
        public bool AddNewIcu(Model.IcuSetUpData newState)
        {
            if (newState != null)
            {
                con = new SQLiteConnection(cs);
                con.Open();
                cmd = new SQLiteCommand(con);
                cmd.CommandText = "INSERT INTO Icu(NumberOfBeds,LayoutOfBeds) VALUES('" + newState.BedsCount + "','" + newState.Layout + "')";
                cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }
        public bool UpdateIcu(int id, Model.IcuSetUpData state)
        {
            if (state != null)
            {
                using var con = new SQLiteConnection(cs);
                con.Open();
                string stm = $"UPDATE Icu SET NumberOfBeds = {state.BedsCount} WHERE IcuIdNumber = {id}";
                using var cmd = new SQLiteCommand(stm, con);
                using SQLiteDataReader rdr = cmd.ExecuteReader();
                return true;
            }
            return false;
        }
    }
}
