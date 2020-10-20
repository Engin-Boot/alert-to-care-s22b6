using DatabaseManager;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryManager.VitalManager
{
    public interface IVitalDataHandler
    {
        VitalStatus MonitorVitals(VitalModel info, DatabaseContext _context);
    }
}
