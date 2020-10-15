using alertToCare.Service;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
