using CablesDatabaseEFCoreFirebird;
using CablesDatabaseEFCoreFirebird.Entities;
using CableTechModeCommon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;

namespace CableTechModeWPFApp.ViewModels
{
    public class CablePropertiesViewModel : IDisposable
    {

        private static readonly string _connectionString = "character set=utf8;user id=SYSDBA;password=masterkey;dialect=3;data source=localhost;port number=3050;initial catalog=e:\\databases\\CABLES.FDB";

        private CablesContext _context;

        private ObservableCollection<CableShortName> _cableShortNames;
        public ObservableCollection<CableShortName> CableShortNames
        {
            get
            {
                if (_cableShortNames == null)
                {
                    _cableShortNames = new ObservableCollection<CableShortName>(_context.CableShortNames.AsNoTracking());
                    return _cableShortNames;
                }
                return _cableShortNames;
            }
        }
        private ObservableCollection<PolymerGroup> _polymerGroups;
        public ObservableCollection<PolymerGroup> PolymerGroups
        {
            get
            {
                if (_polymerGroups == null)
                {
                    _polymerGroups = new ObservableCollection<PolymerGroup>(_context.PolymerGroups.AsNoTracking());
                    return _polymerGroups;
                }
                return _polymerGroups;
            }
        }

        private ObservableCollection<Color> _cableColors;
        public ObservableCollection<Color> CableColors
        {
            get
            {
                if (_cableColors == null)
                {
                    _cableColors = new ObservableCollection<Color>(_context.Colors.AsNoTracking());
                    return _cableColors;
                }
                return _cableColors;
            }
        }

        private ObservableCollection<TwistedElementType> _twistedElementTypes;
        public ObservableCollection<TwistedElementType> TwistedElementTypes
        {
            get
            {
                if (_twistedElementTypes == null)
                {
                    _twistedElementTypes = new ObservableCollection<TwistedElementType>(_context.TwistedElementTypes.AsNoTracking());
                    return _twistedElementTypes;
                }
                return _twistedElementTypes;
            }
        }

        private ObservableCollection<FireProtectionClass> _fireProtectionClasses;
        public ObservableCollection<FireProtectionClass> FireProtectionClasses
        {
            get
            {
                if (_fireProtectionClasses == null)
                {
                    _fireProtectionClasses = new ObservableCollection<FireProtectionClass>(_context.FireProtectionClasses.AsNoTracking());
                    return _fireProtectionClasses;
                }
                return _fireProtectionClasses;
            }
        }

        private ObservableCollection<OperatingVoltage> _operatingVoltages;
        public ObservableCollection<OperatingVoltage> OperatingVoltages
        {
            get
            {
                if (_operatingVoltages == null)
                {
                    _operatingVoltages = new ObservableCollection<OperatingVoltage>(_context.OperatingVoltages.AsNoTracking());
                    return _operatingVoltages;
                }
                return _operatingVoltages;
            }
        }

        private ObservableCollection<TechnicalConditions> _technicalConditions;
        public ObservableCollection<TechnicalConditions> TechnicalConditions
        {
            get
            {
                if (_technicalConditions == null)
                {
                    _technicalConditions = new ObservableCollection<TechnicalConditions>(_context.TechnicalConditions.AsNoTracking());
                    return _technicalConditions;
                }
                return _technicalConditions;
            }
        }

        public CablePropertiesViewModel()
        {
            _context = new CablesContext(_connectionString);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
