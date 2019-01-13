using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace bunny_music.Base
{
    public class ViewModelBaseNotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged<TPropertyType>(Expression<Func<TPropertyType>> projection)
        {
            //this.OnPropertyChanged(this.PropertyChanged, projection);
        }

        public void OnPropertyChanged(string thePropertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(thePropertyName));
        }
    }
}