using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BeerXML.Utilities
{
    public static class UnitExtensions
    {
        public static Type GetUnitFromQuantityType(this UnitsNet.QuantityType quantityType)
        {
            return typeof(UnitsNet.Length).GetTypeInfo().Assembly.DefinedTypes.Select(ti => ti.AsType()).Single(t => t.IsUnitStruct());
        }

        public static bool IsUnitStruct(this Type type)
        {
            return string.Equals(type.Namespace, "UnitsNet") 
                && type.GetProperty("QuantityType")  != null
                && type.GetProperty("QuantityType").PropertyType.IsAssignableFrom(typeof(UnitsNet.QuantityType));
        }

        public static bool IsValidUnit(this Type type, object unit)
        {
            if (unit == null) return false;
            return ((Array)type.GetProperty("Units").GetValue(null)).Cast<object>().Any(u => u.Equals(unit));
        }

        public static object GetBaseUnit(this Type type)
        {
            return (long)type.GetProperty("BaseUnit", BindingFlags.Static).GetValue(null);
        }

        public static object GetDefaultUnit(this Type type)
        {
            //beerxml defaults
            if (type == typeof(UnitsNet.Volume)) return UnitsNet.Units.VolumeUnit.Liter;
            if (type == typeof(UnitsNet.Mass)) return UnitsNet.Units.MassUnit.Kilogram;
            if (type == typeof(UnitsNet.Duration)) return UnitsNet.Units.DurationUnit.Minute;
            if (type == typeof(UnitsNet.Ratio)) return UnitsNet.Units.RatioUnit.Percent;
            if (type == typeof(UnitsNet.Temperature)) return UnitsNet.Units.TemperatureUnit.DegreeCelsius;
            if (type == typeof(UnitsNet.Pressure)) return UnitsNet.Units.PressureUnit.Kilopascal;

            //mks i assume?
            return type.GetBaseUnit();
        }

        public static object GetUnitStruct(this Type type, double value, object unit)
        {
            if (!type.IsUnitStruct()) throw new ArgumentException("type parameter must be a UnitsNet unit");
            MethodInfo creationMethod = type.GetMethods().Single(m => string.Equals(m.Name, "From") && m.GetParameters()[0].ParameterType == typeof(double));
            object _unit = type.IsValidUnit(unit) ? unit : type.GetDefaultUnit();
            return creationMethod.Invoke(null, new object[] { value, _unit });
        }
    }
}
