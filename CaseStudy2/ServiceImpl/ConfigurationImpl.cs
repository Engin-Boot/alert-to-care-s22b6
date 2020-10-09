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
        readonly string cs = @"URI=file:C:\BootCamp\CaseStudy-2\alert-to-care-s22b6\test.db";
        public void AddNewIcu(Model.IcuSetUpData newState)
        {
            
            using var con = new SQLiteConnection(cs);
            con.Open();
            using var cmd = new SQLiteCommand(con);
            cmd.CommandText = "INSERT INTO IcuData(NumberOfBeds,BedName,LayoutOfBeds) VALUES('" + newState.BedsCount + "','" + newState.BedId + "','" + newState.Layout + "')";
            cmd.ExecuteNonQuery();
        }
    }
}
