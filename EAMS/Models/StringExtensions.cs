using System;

namespace EAMS.Models
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
    }
}