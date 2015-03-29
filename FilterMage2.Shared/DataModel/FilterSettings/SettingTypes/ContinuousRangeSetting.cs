using System;
using System.Collections.Generic;
using System.Text;

namespace FilterMage2.DataModel.FilterSettings.SettingTypes
{
    public class ContinuousRangeSetting<T> : FilterSetting<T>
    {
        private T _max;
        public T Max
        {
            get { return this._max; }
            private set { this._max = value; }
        }

        private T _min;
        public T Min
        {
            get { return this._min; }
            private set { this._min = value; }
        }

        public ContinuousRangeSetting(String settingName, T settingValue, T maxValue, T minValue)
            : base(settingName, settingValue)
        {
            this.Max = maxValue;
            this.Min = minValue;
        }
    }
}
