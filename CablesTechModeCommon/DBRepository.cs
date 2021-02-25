using CablesDatabaseEFCoreFirebird;
using CablesDatabaseEFCoreFirebird.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CableTechModeCommon
{
    public class DBRepository
    {
        private readonly string _connectionString;
        public DBRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<CableShortName> GetCablesShortNames()
        {
            using (var context = new CablesContext(_connectionString))
            {
                var names = context.CableShortNames.AsNoTracking()
                                                   .ToList();
                return names;
            }
        }

        public IEnumerable<InsulatedBillet> GetBilletsByCableShortNameId(int CableShortNameId)
        {
            using (var context = new CablesContext(_connectionString))
            {
                var billets = context.InsulatedBillets.AsNoTracking()
                                                      .Include(b => b.Conductor)
                                                      .Where(b => b.CableShortNameId == CableShortNameId)
                                                      .ToList();
                return billets;
            }
        }
    }
}
