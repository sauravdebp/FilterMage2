using System;
using System.Collections.Generic;
using System.Text;

namespace FilterMage2.DataModel.FilterSettings.SettingTypes
{
    public class EnumSetting<T> : FilterSetting<T>
    {
        Dictionary<String, T> _enums;
        public Dictionary<String, T> Enums
        {
            get { return this._enums; }
            private set { this._enums = value; }
        }

        public EnumSetting(String settingName, T settingValue)
            : base(settingName, settingValue)
        {
            this.Enums = new Dictionary<string, T>();
        }
    }
}
