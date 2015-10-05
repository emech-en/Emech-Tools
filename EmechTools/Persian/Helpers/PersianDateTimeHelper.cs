using System;
using EmechTools.Persian.DataTypes;

namespace EmechTools.Persian.Helpers
{
    // Programmer: Emech
    // Description: PersianDateTime
    // Date: 1393/06/13 10:33:14 AM
    public static class PersianDateTimeHelper
    {
        public static PersianDateTime PersianToPersianDateTime(this string persianDateTimeString)
        {
            return PersianDateTime.ParsePersian(persianDateTimeString);
        }

        public static PersianDateTime EnglishToPersianDateTime(this string englishDateTimeString)
        {
            return PersianDateTime.ParseEnglish(englishDateTimeString);
        }

        public static PersianDateTime ToPersianDateTime(this DateTime dateTime)
        {
            return new PersianDateTime(dateTime);
        }

        public static int GetDayOfMonth(this PersianMonth persianMonth, int year)
        {
            switch (persianMonth)
            {
                case PersianMonth.Farvardin:
                case PersianMonth.Ordibehesht:
                case PersianMonth.Khordad:
                case PersianMonth.Tir:
                case PersianMonth.Mordad:
                case PersianMonth.Sharivar:
                    return 31;
                case PersianMonth.Mehr:
                case PersianMonth.Aban:
                case PersianMonth.Azar:
                case PersianMonth.Dey:
                case PersianMonth.Bahman:
                    return 30;
                case PersianMonth.Esfand:
                    return PersianDateTime.PersianCalendar.IsLeapYear(year) ? 30 : 29;
            }
            return 0;
        }

        public static int GetDayOfMonth(this PersianMonth persianMonth)
        {
            switch (persianMonth)
            {
                case PersianMonth.Farvardin:
                case PersianMonth.Ordibehesht:
                case PersianMonth.Khordad:
                case PersianMonth.Tir:
                case PersianMonth.Mordad:
                case PersianMonth.Sharivar:
                    return 31;
                case PersianMonth.Mehr:
                case PersianMonth.Aban:
                case PersianMonth.Azar:
                case PersianMonth.Dey:
                case PersianMonth.Bahman:
                    return 30;
                case PersianMonth.Esfand:
                    return 29;
            }
            return 0;
        }

        public static bool IsPersianDateTime(this string s)
        {
            PersianDateTime persianDateTime;
            return PersianDateTime.TryParsePersian(s, out persianDateTime);
        }
    }
}
