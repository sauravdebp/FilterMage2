using System;
using System.Collections.Generic;
using System.Text;
using FilterMage2.DataModel.Filters;
using Lumia.Imaging;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Windows.Storage.Streams;

namespace FilterMage2.DataModel
{
    public class Effect
    {
        FilterEffect effect;
        List<IFilter> effectFilters;
        
        ObservableCollection<FilterWrapper<IFilter>> _activeFilters;
        public ObservableCollection<FilterWrapper<IFilter>> ActiveFilters
        {
            get { return this._activeFilters; }
            private set { this._activeFilters = value; }
        }

        IImageProvider sourceImage;
        public IRandomAccessStream SourceImageStream
        {
            set
            {
                this.sourceImage = new RandomAccessStreamImageSource(value);
            }
        }

        WriteableBitmap _effectOutput;
        public WriteableBitmap EffectOutput
        {
            get { return this._effectOutput; }
            private set { this._effectOutput = value; }
        }

        public Effect()
        {
            this.ActiveFilters = new ObservableCollection<FilterWrapper<IFilter>>();
            this.ActiveFilters.CollectionChanged += ActiveFilters_CollectionChanged;
            this.effectFilters = new List<IFilter>();
        }

        public Effect(IRandomAccessStream sourceImageStream)
            : this()
        {
            this.SourceImageStream = sourceImageStream;
        }

        void ActiveFilters_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.MaintainFiltersArray(e);
            this.ApplyEffect();
        }

        void ApplyEffect()
        {
            this.effect = new FilterEffect(this.sourceImage);
            this.effect.Filters = this.effectFilters;
            
        }

        void MaintainFiltersArray(NotifyCollectionChangedEventArgs args)
        {
            switch(args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach(FilterWrapper<IFilter> item in args.NewItems)
                    {
                        this.effectFilters.Add(item.Filter);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach(FilterWrapper<IFilter> item in args.OldItems)
                    {
                        this.effectFilters.Remove(item.Filter);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
