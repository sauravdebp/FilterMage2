using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FilterMage2.DataModel.FilterSettings
{
    public class FilterSetting<SettingType> : INotifyPropertyChanged
    {
        private String _settingName;
        public String SettingName
        {
            get { return this._settingName; }
            private set { this._settingName = value; }
        }

        private SettingType _settingValue;
        public SettingType SettingValue
        {
            get { return this._settingValue; }
            set
            {
                if(!this._settingValue.Equals(value))
                {
                    this._settingValue = value;
                    this.NotifyPropertyChanged("SettingValue");
                }
            }
        }

        public FilterSetting(String settingName, SettingType settingValue)
        {
            this.SettingName = settingName;
            this.SettingValue = settingValue;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
