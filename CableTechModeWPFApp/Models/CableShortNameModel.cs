using CablesDatabaseEFCoreFirebird.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CableTechModeWPFApp.Models
{
    public class CableShortNameModel : INotifyPropertyChanged
    {
        private CableShortName _cableShortName;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id
        {
            get { return _cableShortName.Id; }
        }

        public string ShortName
        {
            get { return _cableShortName.ShortName; }
        }



        private void OnPropertyChanged (string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
