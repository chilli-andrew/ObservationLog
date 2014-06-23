using System;
using System.Linq.Expressions;

namespace Rusty.ObservationLog.Windows.ViewModels
{
    public class ReflectionHelpers
    {
        public static string GetPropertyName<TObject, TPropName>(Expression<Func<TObject, TPropName>> property)
        {
            string propertyName = ((MemberExpression)property.
                Body).Member.Name;
            return propertyName;
        }
    }
}