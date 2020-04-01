using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Flat;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Tenant;

namespace Services.StaticHelpers
{
    public static class PropertyHelper
    {
        public static bool IsAnyPropIsNull(object obj)
        {
            return obj.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string))
                .Select(pi => (string)pi.GetValue(obj))
                .Any(string.IsNullOrEmpty);
        }

        public static bool IsAnyPropIsNullExceptFlatId(object obj)
        {
            return obj.GetType().GetProperties()
                .Where((PropertyInfo pi) =>
                {
                    if (pi.PropertyType == typeof(string) && pi.Name == nameof(CreateTenantRequest.FlatId))
                        return false;

                    return pi.PropertyType == typeof(string);
                })
                .Select(pi => (string)pi.GetValue(obj))
                .Any(string.IsNullOrEmpty);
        }
    }
}
