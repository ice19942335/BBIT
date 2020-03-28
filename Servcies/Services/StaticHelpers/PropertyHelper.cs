using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.StaticHelpers
{
    public static class PropertyHelper
    {
        public static bool IsAnyPropIsNull(object obj)
        {
            return obj.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string))
                .Select(pi => (string)pi.GetValue(obj))
                .Any(value => string.IsNullOrEmpty(value));
        }
    }
}
