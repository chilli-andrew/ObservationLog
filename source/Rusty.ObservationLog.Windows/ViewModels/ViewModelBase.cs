using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rusty.ObservationLog.Windows.ViewModels
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

            if ((oldValue == null && newValue != null) || !oldValue.Equals((T)newValue))
            {
                // Convert expression to a property name
                string propertyName = GetPropertyName<TResult>(property);
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
            string propertyName = GetPropertyName<TResult>(property);

            // Fire notify property changed event
            InternalNotifyPropertyChanged(propertyName);
        }

        private static string GetPropertyName<TResult>(Expression<Func<TModel, TResult>> property)
        {
            string propertyName = ((MemberExpression)property.
                Body).Member.Name;
            return propertyName;
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
