using Cables.Common;
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

        public IEnumerable<string> GetInsulationPolymerGroups(string cableShortName)
        {
            var groups = from b in _context.InsulatedBillets
                         join pg in _context.PolymerGroups on b.PolymerGroupId equals pg.Id
                         join csn in _context.CableShortNames on b.CableShortNameId equals csn.Id
                         where csn.ShortName == cableShortName
                         group pg by pg.Title into g
                         select g.Key;
            return groups.AsNoTracking().ToArray();
        }

        public IEnumerable<string> GetCoverPolymerGroups(string cableShortName)
        {
            var groups = from lcb in _context.ListCableBillets
                         join c in _context.Cables on lcb.CableId equals c.Id
                         join ib in _context.InsulatedBillets on lcb.BilletId equals ib.Id
                         join csn in _context.CableShortNames on ib.CableShortNameId equals csn.Id
                         join pg in _context.PolymerGroups on c.CoverPolymerGroupId equals pg.Id
                         where csn.ShortName == cableShortName
                         select pg.Title;
            return groups.AsNoTracking().Distinct().ToArray();
        }

        public IEnumerable<InsulatedBillet> GetBilletsByCableShortNameId(int CableShortNameId)
        {
            var billets = _context.InsulatedBillets.AsNoTracking()
                                                      .Include(b => b.Conductor)
                                                      .Where(b => b.CableShortNameId == CableShortNameId)
                                                      .ToList();
            return billets;
        }

        public IEnumerable<string> GetFireProtetionClasses(string cableShortName)
        {
            var classes = from lcb in _context.ListCableBillets
                       join c in _context.Cables on lcb.CableId equals c.Id
                       join ib in _context.InsulatedBillets on lcb.BilletId equals ib.Id
                       join csn in _context.CableShortNames on ib.CableShortNameId equals csn.Id
                       join fpc in _context.FireProtectionClasses on c.FireProtectionClassId equals fpc.Id
                       where csn.ShortName == cableShortName
                       select fpc.Designation;
            return classes.AsNoTracking().Distinct().ToArray();
        }

        public IEnumerable<int> GetCablePropertySets(string cableShortName) //Дичь))
        {
            var sets = (from lcb in _context.ListCableBillets
                         join c in _context.Cables on lcb.CableId equals c.Id
                         join ib in _context.InsulatedBillets on lcb.BilletId equals ib.Id
                         join csn in _context.CableShortNames on ib.CableShortNameId equals csn.Id
                         join lcp in _context.ListCableProperties on c.Id equals lcp.CableId
                         join cp in _context.CableProperties on lcp.PropertyId equals cp.Id
                         where csn.ShortName == cableShortName
                         group c by cp.BitNumber into g
                         select g.Key).Distinct();
            return sets.ToArray();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
