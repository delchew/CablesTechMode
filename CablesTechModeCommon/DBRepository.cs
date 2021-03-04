using CablesDatabaseEFCoreFirebird;
using CablesDatabaseEFCoreFirebird.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CableTechModeCommon
{
    public class DBRepository : IDisposable
    {
        private CablesContext _context;
        public DBRepository(string connectionString)
        {
            _context = new CablesContext(connectionString);
        }

        public IEnumerable<CableShortName> GetCablesShortNames()
        {
            var names = _context.CableShortNames.AsNoTracking()
                                                   .ToList();
            return names;
        }

        public IEnumerable<InsulatedBillet> GetBilletsByCableShortNameId(int CableShortNameId)
        {
            var billets = _context.InsulatedBillets.AsNoTracking()
                                                      .Include(b => b.Conductor)
                                                      .Where(b => b.CableShortNameId == CableShortNameId)
                                                      .ToList();
            return billets;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
