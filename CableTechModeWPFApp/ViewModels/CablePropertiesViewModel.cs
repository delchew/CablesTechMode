using CablesDatabaseEFCoreFirebird.Entities;
using CableTechModeCommon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CableTechModeWPFApp.ViewModels
{
    public class CablePropertiesViewModel
    {

        private static readonly string _connectionString = "character set=utf8;user id=SYSDBA;password=masterkey;dialect=3;data source=localhost;port number=3050;initial catalog=e:\\databases\\CABLES.FDB";

        private DBRepository _dBRepository;
        public DBRepository DBRepository
        {
            get
            {
                if (_dBRepository == null)
                    return new DBRepository(_connectionString);
                return _dBRepository;
            }
        }
        public ObservableCollection<CableShortName> CableShortNames { get; private set; }

        public CablePropertiesViewModel()
        {
            CableShortNames = new ObservableCollection<CableShortName>(DBRepository.GetCablesShortNames());
        }
    }
}
