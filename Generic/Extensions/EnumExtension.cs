using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace AutomationTest.Generic.Extensions
{
    public static class EnumExtension
    {
        /// <summary> 
        /// Fetch description of enum.
        /// </summary> 
        /// <param name="value"></param> 
        /// <returns></returns> 
        public static string FetchDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
    }
}
