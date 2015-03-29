using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FilterMage2.DataModel.Filters
{
    public abstract class FilterWrapper<FilterType>
    {
        private FilterType _filter;
        public FilterType Filter
        {
            get { return this._filter; }
            protected set { this._filter = value; }
        }

        private String _filterName;
        public String FilterName
        {
            get { return this._filterName; }
            protected set { this._filterName = value; }
        }
    }
}
