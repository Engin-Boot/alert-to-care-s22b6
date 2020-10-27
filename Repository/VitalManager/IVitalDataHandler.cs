using DatabaseManager;
using Models;

namespace RepositoryManager.VitalManager
{
    public interface IVitalDataHandler
    {
        VitalStatus MonitorVitals(VitalModel info, DatabaseContext context);
    }
}
