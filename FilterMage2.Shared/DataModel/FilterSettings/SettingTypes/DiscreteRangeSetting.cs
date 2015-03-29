using System;
using System.Collections.Generic;
using System.Text;

namespace FilterMage2.DataModel.FilterSettings.SettingTypes
{
    public class DiscreteRangeSetting<T> : FilterSetting<T>
    {
        private List<T> _valueList;
        public List<T> ValueList 
        {
            get { return this._valueList; }
            private set { this._valueList = value; }
        }

        public DiscreteRangeSetting(String settingName, T settingValue, params T[] discreteValues)
            : base(settingName, settingValue)
        {
            ValueList = new List<T>(discreteValues);
        }
    }
}
