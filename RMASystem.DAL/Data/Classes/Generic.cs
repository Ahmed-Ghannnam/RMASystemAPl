using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMASystem.DAL;

public static class Generic
{
    public static T To<T>(this object o)
    {
        try
        {
            if (DBNull.Value.Equals(o))
                return GetNullValue<T>();

            Type type = typeof(T);
            if ((type == typeof(int)) || (type == typeof(int?)) || type.IsEnum)
                return (T)Convert.ChangeType(o, typeof(T), null);
            else if ((type == typeof(decimal)) || (type == typeof(decimal?)))
                return (T)Convert.ChangeType(o, typeof(decimal), null);
            // Needed?
            //else if (type == typeof(int?))
            //    return (T)Convert.ChangeType(o, typeof(int?), null);
            else if ((type == typeof(DateTime)) || (type == typeof(DateTime?) && (o != null)))
                o = DateTime.SpecifyKind((DateTime)o, DateTimeKind.Local);
            else if (type == typeof(Guid))
                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(o.ToString());
            else if (type == typeof(bool) || type == typeof(bool?))
                if (o.ToString().ToUpper() == "TRUE" || o.ToString().ToUpper() == "1")
                    return (T)Convert.ChangeType(true, typeof(T), null);
                else
                    return (T)Convert.ChangeType(false, typeof(T), null);
            return (T)o;
        }
        catch (Exception ex)
        {
            return GetNullValue<T>();
        }
    }

    public static T To<T>(this object o, object o2)
    {
        try
        {
            if (DBNull.Value.Equals(o))
                if (DBNull.Value.Equals(o2))
                    return GetNullValue<T>();
                else
                    o = o2;

            return o.To<T>();
        }
        catch (Exception ex)
        {
            return GetNullValue<T>();
        }
    }

    public static T ToValueType<T>(this object o)
    {
        try
        {
            if (DBNull.Value.Equals(o))
                return (T)Convert.ChangeType((int)ValueType.None, typeof(T), null);
            return o.To<T>();
        }
        catch
        {
            return GetNullValue<T>();
        }
    }

    public static object ValidateForDB<T>(this T value)
    {
        Type type = typeof(T);
        if (type == typeof(bool))
            return value.IsNull() ? (T)Convert.ChangeType(false, typeof(T), null) : value;
        else
            return value.IsNull() ? (object)DBNull.Value : value;
    }

    public static object ValidateValueTypeForDB(this int value)
    {
        if (value == (int)ValueType.None)
            return (object)DBNull.Value;
        return value.IsNull() ? (object)DBNull.Value : value;
    }

    public static object ValidateForDB<T>(this T value, T value2)
    {
        object o = DBNull.Value;
        Type type = typeof(T);
        if (type == typeof(bool))
        {
            if (value.IsNotNull())
                o = value;
            else if (value2.IsNotNull())
                o = value2;
            else
                o = (T)Convert.ChangeType(false, typeof(T), null);
        }
        else
        {
            if (value.IsNotNull())
                o = value;
            else if (value2.IsNotNull())
                o = value2;
        }
        return o;
    }

    public static T Validate<T>(this T value)
    {
        T nullValue = GetNullValue<T>();
        if (value == null)
            return nullValue;
        return value.IsNull() ? nullValue : (T)Convert.ChangeType(value, value.GetType(), null);
    }

    public static bool IsNull<T>(this T value)
    {
        if (typeof(T) == typeof(string))
            return string.IsNullOrEmpty(value as string) ? true : false;
        return (value == null || value.Equals(GetNullValue<T>()));
    }

    public static bool IsNotNull<T>(this T value)
    {
        return !value.IsNull();
    }

    public static T IsNull<T>(this object value, T value2)
    {
        if (typeof(T) == typeof(string))
            return string.IsNullOrEmpty(value as string) ? value2 : value.To<T>();
        return (value == null || value.Equals(GetNullValue<T>())) ? value2 : value.To<T>();
    }

    public static T GetNullValue<T>()
    {
        T nullValue = default(T);
        if (typeof(T) == typeof(int) ||
            typeof(T) == typeof(decimal) ||
            typeof(T) == typeof(float) ||
            typeof(T) == typeof(double) ||
            typeof(T) == typeof(long) ||
            typeof(T) == typeof(uint) ||
            typeof(T) == typeof(ulong))
            nullValue = (T)Convert.ChangeType(GlobalVars.NullNumberValue, typeof(T), null);
        if (typeof(T) == typeof(int?) ||
            typeof(T) == typeof(decimal?) ||
            typeof(T) == typeof(float?) ||
            typeof(T) == typeof(double?) ||
            typeof(T) == typeof(long?) ||
            typeof(T) == typeof(uint?) ||
            typeof(T) == typeof(ulong?))
            nullValue = default(T);
        else if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
            nullValue = (T)Convert.ChangeType(false, typeof(bool), null);
        else if (typeof(T) == typeof(Guid))
            nullValue = (T)Convert.ChangeType(Guid.Empty, typeof(Guid), null);
        else if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
            nullValue = (T)(object)(DateTime.SpecifyKind(new DateTime(), DateTimeKind.Local));

        return nullValue;
    }

    public static T GetNullValue2<T>()
    {
        T nullValue = default(T);
        if (typeof(T) == typeof(int) ||
            typeof(T) == typeof(decimal) ||
            typeof(T) == typeof(decimal) ||
            typeof(T) == typeof(decimal) ||
            typeof(T) == typeof(long) ||
            typeof(T) == typeof(uint) ||
            typeof(T) == typeof(ulong))
            nullValue = (T)Convert.ChangeType(0, typeof(T), null);
        if (typeof(T) == typeof(int?) ||
            typeof(T) == typeof(decimal?) ||
            typeof(T) == typeof(float?) ||
            typeof(T) == typeof(double?) ||
            typeof(T) == typeof(long?) ||
            typeof(T) == typeof(uint?) ||
            typeof(T) == typeof(ulong?))
            nullValue = default(T);
        else if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
            nullValue = (T)Convert.ChangeType(false, typeof(bool), null);
        else if (typeof(T) == typeof(Guid))
            nullValue = (T)Convert.ChangeType(Guid.Empty, typeof(Guid), null);
        else if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
            nullValue = (T)(object)(DateTime.SpecifyKind(new DateTime(), DateTimeKind.Local));

        return nullValue;
    }


    #region GetEnumFromObject
    public static T GetEnumFromObject<T>(this object o) where T : struct, IConvertible
    {
        if (o.IsNull())
            return default(T);
        Type type = o.GetType();
        if (type == typeof(KeyValueTriplet<Enum, int, string>))
        {
            return (T)Enum.ToObject(typeof(T), ((KeyValueTriplet<Enum, int, string>)o).Key);
        }
        else if (o is Enum)
        {
            return (T)Enum.ToObject(typeof(T), o);
        }
        else if (o is string || o is int)
        {
            return (T)Enum.ToObject(typeof(T), o.To<int>());
        }
        return default(T);
    }
    #endregion

}
