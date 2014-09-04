using System;

namespace EmechTools.Persian.Attributes
{
    // Programmer: Emech
    // Description: PersianDateTime
    // Date: 1393/06/13 10:33:14 AM
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    internal sealed class LocalizedDescriptionAttribute : Attribute
    {
        public LocalizedDescriptionAttribute(string cultureName)
            : this(cultureName, string.Empty)
        {
        }

        public LocalizedDescriptionAttribute(string cultureName, string description)
        {
            if (cultureName == null)
                throw new ArgumentNullException("cultureName");
            this.CultureName = cultureName;
            this.Description = description;
        }

        public string CultureName { get; set; }
        public string Description { get; set; }
    }
}
