
using System;
using System.ComponentModel;
using System.Reflection;

namespace PB.Console
{
  public static class PropertyExtension
  {
    public static void SetPropertyValue(this object obj, string propName, object value)
    {
      PropertyInfo property = obj.GetType().GetProperty(propName);
      Type conversionType = property.PropertyType;
      if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof (Nullable<>)))
      {
        if (value == null)
        {
          property.SetValue(obj, (object) null, (object[]) null);
          return;
        }
        conversionType = new NullableConverter(property.PropertyType).UnderlyingType;
      }
      property.SetValue(obj, Convert.ChangeType(value, conversionType), (object[]) null);
    }

    public static object GetPropertyValue(this object obj, string propName) => obj.GetType().GetProperty(propName).GetValue(obj, (object[]) null);
  }
}
