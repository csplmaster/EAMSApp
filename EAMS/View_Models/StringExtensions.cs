using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace EAMS.View_Models
{
    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            if (value == null)
            {
                value = "Select";
            }
            //if (value != null)
            //{
            //    return (T)Enum.Parse(typeof(T), value, true);
            //}
            return (T)Enum.Parse(typeof(T), value, true);
        }
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
        //public static string DisplayName<T>(this Enum value)
        //{
        //    Type enumType = value.GetType();
        //    var enumValue = Enum.GetName(enumType, value);
        //    T member = enumType.GetMember(enumValue)[0];

        //    var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
        //    var outString = ((DisplayAttribute)attrs[0]).Name;

        //    if (((DisplayAttribute)attrs[0]).ResourceType != null)
        //    {
        //        outString = ((DisplayAttribute)attrs[0]).GetName();
        //    }

        //    return outString;
        //}
    }
}