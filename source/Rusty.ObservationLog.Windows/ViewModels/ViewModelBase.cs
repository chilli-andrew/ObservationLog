using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Rusty.ObservationLog.WinForms.ViewModels
{
    public class ViewModelBase<TModel> : INotifyPropertyChanged
    {
        // Allows you to specify a lambda for notify property changed
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool CheckPropertyChanged<TResult>(Expression<Func<TModel, TResult>> property, ref TResult oldValue, ref TResult newValue)
        {
            if (oldValue == null && newValue == null)
            {
                return false;
            }

            if ((oldValue == null && newValue != null) || !oldValue.Equals((TResult)newValue))
            {
                // Convert expression to a property name
                string propertyName = ReflectionHelpers.GetPropertyName(property);
                oldValue = newValue;
                InternalNotifyPropertyChanged(propertyName);
                return true;
            }

            return false;
        }

        // Defined as virtual so you can override if you wish
        protected virtual void NotifyPropertyChanged<TResult>(Expression<Func<TModel, TResult>> property)
        {
            // Convert expression to a property name
            string propertyName = ReflectionHelpers.GetPropertyName(property);

            // Fire notify property changed event
            InternalNotifyPropertyChanged(propertyName);
        }

        protected void InternalNotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
