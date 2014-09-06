using System;
using System.ComponentModel;
using System.Text;

namespace EmechTools.Persian
{
    // Programmer: Emech
    // Description: PersianDateTime
    // Date: 1393/06/13 10:33:14 AM
    internal static class Extensions
    {
        internal static string ParseName(this string name)
        {
            name.Replace(" ", "");
            var parserResult = new StringBuilder();
            foreach (var currChar in name)
            {
                if (!char.IsDigit(currChar) && ((currChar.ToString().CompareTo("_") == 0) || (currChar.ToString().CompareTo(currChar.ToString().ToUpper()) == 0)))
                    parserResult.Append(' ');
                parserResult.Append(currChar);
            }
            return parserResult.ToString().Trim();
        }

        internal static string GetItemDescription(this Enum value)
        {
            return value.GetItemDescription(true);
        }

        internal static string GetItemDescription(this Enum value, bool parseNameIfNoDescription)
        {
            var descriptionAttribute = value.GetItemAttribute<DescriptionAttribute>();
            return ((descriptionAttribute == null) ? value.ToString().ParseName() : descriptionAttribute.Description);
        }

        internal static TAttribute GetItemAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            if (value == null)
                return default(TAttribute);
            var attributes = (TAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(TAttribute), false);
            return ((attributes.Length > 0) ? attributes[0] : default(TAttribute));
        }
    }

}
