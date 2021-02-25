using CablesDatabaseEFCoreFirebird.Entities;
using System.Collections.ObjectModel;

namespace CableTechModeCommon
{
    public class ProgramDataRepository
    {
        public ObservableCollection<CableShortName> CableShortNames { get; set; }
        public ObservableCollection<InsulatedBillet> InsulatedBillets { get; set; }

        public ProgramDataRepository()
        {
            CableShortNames = new ObservableCollection<CableShortName>();
            InsulatedBillets = new ObservableCollection<InsulatedBillet>();
        }
    }
}
