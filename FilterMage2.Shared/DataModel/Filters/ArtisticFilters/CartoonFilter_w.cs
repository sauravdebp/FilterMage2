using System;
using System.Collections.Generic;
using System.Text;
using Lumia.Imaging.Artistic;
using FilterMage2.DataModel.FilterSettings.SettingTypes;

namespace FilterMage2.DataModel.Filters.ArtisticFilters
{
    class CartoonFilter_w : FilterWrapper<CartoonFilter>
    {
        public BoolSetting distinctEdgesSetting;

        public CartoonFilter_w()
        {
            this.FilterName = "Cartoon";
            this.InitSettings();
            this.InitFilter();
        }

        private void InitSettings()
        {
            this.distinctEdgesSetting = new BoolSetting("Distinct Edges", true);
            this.distinctEdgesSetting.PropertyChanged += distinctEdgesSetting_PropertyChanged;
        }

        void distinctEdgesSetting_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.Filter.DistinctEdges = this.distinctEdgesSetting.SettingValue;
        }

        private void InitFilter()
        {
            this.Filter = new CartoonFilter(distinctEdgesSetting.SettingValue);
        }
    }
}
