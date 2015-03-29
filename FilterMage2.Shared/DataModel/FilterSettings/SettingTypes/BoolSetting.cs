using System;
using System.Collections.Generic;
using System.Text;

namespace FilterMage2.DataModel.FilterSettings.SettingTypes
{
    public class BoolSetting : FilterSetting<Boolean>
    {
        public BoolSetting(String settingName, Boolean settingValue)
            : base(settingName, settingValue)
        {

        }
    }
}
