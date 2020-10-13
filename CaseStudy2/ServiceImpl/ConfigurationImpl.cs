using CaseStudy2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using CaseStudy2.Model;

namespace CaseStudy2.ServiceImpl
{
    public class ConfigurationImpl : IIcuConfigurationService
    {
        readonly string cs = @"URI=file:C:\BootCamp\CaseStudy2\alert-to-care-s22b6\test.db";
        public bool AddNewIcu(Model.IcuSetUpData newState)
        {
            if (newState != null)
            {
                using var con = new SQLiteConnection(cs);
                con.Open();
                using var cmd = new SQLiteCommand(con);
                cmd.CommandText = "INSERT INTO Icu(NumberOfBeds,LayoutOfBeds) VALUES('" + newState.BedsCount + "','" + newState.Layout + "')";
                cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }
    }
}
