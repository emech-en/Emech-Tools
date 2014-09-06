﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;
using EmechTools.Persian.DataTypes;
using EmechTools.Persian.Helpers;

namespace EmechTools.Persian
{
    // Programmer: Emech
    // Description: PersianDateTime
    // Date: 1393/06/13 10:33:14 AM
    [Serializable]
    public struct PersianDateTime : ICloneable, IComparable<PersianDateTime>, IEquatable<PersianDateTime>, IConvertible, ISerializable
    {
        internal static PersianCalendar PersianCalendar = new PersianCalendar();
        internal PersianDateTimeData Data;

        public PersianDateTime(DateTime dateTime)
        {
            this.Data = new PersianDateTimeData();
            this.Data.Init();
            this.Data.Year = PersianCalendar.GetYear(dateTime);
            this.Data.Month = PersianCalendar.GetMonth(dateTime);
            this.Data.Day = PersianCalendar.GetDayOfMonth(dateTime);
            this.Data.Hour = PersianCalendar.GetHour(dateTime);
            this.Data.Minute = PersianCalendar.GetMinute(dateTime);
            this.Data.Second = PersianCalendar.GetSecond(dateTime);
        }

        public PersianDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            this.Data = new PersianDateTimeData();
            this.Data.Init();
            this.Data.Year = year;
            this.Data.Month = month;
            this.Data.Day = day;
            this.Data.Hour = hour;
            this.Data.Minute = minute;
            this.Data.Second = second;
        }

        public int Year
        {
            get { return this.Data.Year; }
        }

        public int Month
        {
            get { return this.Data.Month; }
        }

        public int Day
        {
            get { return this.Data.Day; }
        }

        public int Hour
        {
            get { return this.Data.Hour; }
        }

        public int Minute
        {
            get { return this.Data.Minute; }
        }

        public int Second
        {
            get { return this.Data.Second; }
        }

        public static PersianDateTime Now
        {
            get { return DateTime.Now.ToPersianDateTime(); }
        }

        public long Ticks
        {
            get { return ((DateTime)this).Ticks; }
        }

        public static ReadOnlyCollection<string> MonthNames
        {
            get
            {
                var monthNames = new List<string>
				{
					PersianMonth.Farvardin.GetItemDescription(),
					PersianMonth.Ordibehesht.GetItemDescription(),
					PersianMonth.Khordad.GetItemDescription(),
					PersianMonth.Tir.GetItemDescription(),
					PersianMonth.Mordad.GetItemDescription(),
					PersianMonth.Sharivar.GetItemDescription(),
					PersianMonth.Mehr.GetItemDescription(),
					PersianMonth.Aban.GetItemDescription(),
					PersianMonth.Azar.GetItemDescription(),
					PersianMonth.Dey.GetItemDescription(),
					PersianMonth.Bahman.GetItemDescription(),
					PersianMonth.Esfand.GetItemDescription()
				};
                return new ReadOnlyCollection<string>(monthNames);
            }
        }

        public PersianDayOfWeek DayOfWeek
        {
            get { return (PersianDayOfWeek)PersianCalendar.GetDayOfWeek(this); }
        }

        public string DayOfWeekTitle
        {
            get { return this.DayOfWeek.GetItemDescription(); }
        }

        #region ICloneable Members
        public object Clone()
        {
            return new PersianDateTime(this.Year, this.Month, this.Day, this.Hour, this.Minute, this.Second);
        }
        #endregion

        #region IComparable<PersianDateTime> Members
        public int CompareTo(PersianDateTime other)
        {
            return DateTime.Compare(this, other);
        }
        #endregion

        #region IConvertible Members
        public DateTime ToDateTime(IFormatProvider provider)
        {
            return this;
        }

        TypeCode IConvertible.GetTypeCode()
        {
            throw new NotSupportedException();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }
        #endregion

        #region IEquatable<PersianDateTime> Members
        public bool Equals(PersianDateTime other)
        {
            return this.CompareTo(other) == 0;
        }
        #endregion

        #region ISerializable Members
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
        #endregion

        public static int Compare(string persianDateTime1, string persianDateTime2)
        {
            PersianDateTime p1, p2;
            if (!TryParsePersian(persianDateTime1, out p1))
                throw new InvalidCastException("cannot cast persianDateTime1 to PersianDateTime");
            if (!TryParsePersian(persianDateTime2, out p2))
                throw new InvalidCastException("cannot cast persianDateTime2 to PersianDateTime");
            return p1.CompareTo(p2);
        }

        public static implicit operator string(PersianDateTime persianDateTime)
        {
            return string.Format(CultureInfo.CurrentCulture,
                "{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}",
                persianDateTime.Data.Year,
                persianDateTime.Data.Month,
                persianDateTime.Data.Day,
                persianDateTime.Data.Hour,
                persianDateTime.Data.Minute,
                persianDateTime.Data.Second);
        }

        public static implicit operator PersianDateTime(string persianDateTimeString)
        {
            return ParsePersian(persianDateTimeString);
        }

        public static implicit operator PersianDateTime(DateTime dateTime)
        {
            return dateTime.ToPersianDateTime();
        }

        public static implicit operator DateTime(PersianDateTime persiandateTime)
        {
            return PersianCalendar.ToDateTime(persiandateTime.Year,
                persiandateTime.Month,
                persiandateTime.Day,
                persiandateTime.Hour,
                persiandateTime.Minute,
                persiandateTime.Second,
                0);
        }

        public static PersianDateTime operator +(PersianDateTime persiandateTime1, PersianDateTime persiandateTime2)
        {
            DateTime dateTime1 = persiandateTime1;
            DateTime dateTime2 = persiandateTime2;
            return dateTime1.Add(new TimeSpan(dateTime2.Ticks)).ToPersianDateTime();
        }

        public static PersianDateTime operator -(PersianDateTime persiandateTime1, PersianDateTime persiandateTime2)
        {
            DateTime dateTime1 = persiandateTime1;
            DateTime dateTime2 = persiandateTime2;
            return dateTime1.Subtract(new TimeSpan(dateTime2.Ticks)).ToPersianDateTime();
        }

        public static bool operator ==(PersianDateTime persiandateTime1, PersianDateTime persiandateTime2)
        {
            return persiandateTime1.Equals(persiandateTime2);
        }

        public static bool operator !=(PersianDateTime persiandateTime1, PersianDateTime persiandateTime2)
        {
            return !persiandateTime1.Equals(persiandateTime2);
        }

        public static PersianDateTime Add(PersianDateTime persiandateTime1, PersianDateTime persiandateTime2)
        {
            return persiandateTime1 + persiandateTime2;
        }

        public static PersianDateTime Subtract(PersianDateTime persiandateTime1, PersianDateTime persiandateTime2)
        {
            return persiandateTime1 - persiandateTime2;
        }

        public static PersianDateTime ParsePersian(string dateTimeString)
        {
            var result = new PersianDateTime { Data = { HasDate = (dateTimeString.IndexOf("/") > 0), HasTime = (dateTimeString.IndexOf(":") > 0) } };
            if (result.Data.HasDate)
            {
                string datePart = result.Data.HasTime ? dateTimeString.Substring(0, dateTimeString.IndexOf(" ")) : dateTimeString;
                if (!int.TryParse(datePart.Substring(0, datePart.IndexOf("/")), out result.Data.Year))
                    throw new ArgumentException("not valid date", "dateTimeString");
                datePart = datePart.Remove(0, datePart.IndexOf("/") + 1);
                if (!int.TryParse(datePart.Substring(0, datePart.IndexOf("/")), out result.Data.Month))
                    throw new ArgumentException("not valid date", "dateTimeString");
                datePart = datePart.Remove(0, datePart.IndexOf("/") + 1);
                if (!int.TryParse(datePart, out result.Data.Day))
                    throw new ArgumentException("not valid date", "dateTimeString");

                if (result.Data.Year < 1300)
                    result.Data.Year += 1300;
            }
            if (result.ToString().Equals("00:00:00 0000/00/00"))
                throw new ArgumentException("not valid date", "dateTimeString");
            return result;
        }

        public static PersianDateTime ParseEnglish(string dateTimeString)
        {
            return DateTime.Parse(dateTimeString, CultureInfo.CurrentCulture).ToPersianDateTime();
        }

        public string ToString(string format)
        {
            format = format.Trim().Replace("yyyy", this.Year.ToString("0000", CultureInfo.CurrentCulture));
            format = format.Trim().Replace("MMMM", MonthNames[this.Month - 1]);
            format = format.Trim().Replace("MM", this.Month.ToString("00", CultureInfo.CurrentCulture));
            format = format.Trim().Replace("dd", this.Day.ToString("00", CultureInfo.CurrentCulture));
            format = format.Trim().Replace("HH", this.Hour.ToString("00", CultureInfo.CurrentCulture));
            format = format.Trim().Replace("mm", this.Minute.ToString("00", CultureInfo.CurrentCulture));
            format = format.Trim().Replace("ss", this.Second.ToString("00", CultureInfo.CurrentCulture));
            return format;
        }

        public override string ToString()
        {
            return this.ToString("HH:mm:ss yyyy/MM/dd");
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PersianDateTime))
                return false;
            var target = (PersianDateTime)obj;
            return this.CompareTo(target) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ToDateString()
        {
            return this.ToDateString('/');
        }

        public string ToDateString(char separator)
        {
            return string.Concat(this.Year.ToString("0000", CultureInfo.CurrentCulture),
                separator,
                this.Month.ToString("00", CultureInfo.CurrentCulture),
                separator,
                this.Day.ToString("00", CultureInfo.CurrentCulture));
        }

        public DateTime ToDateTime()
        {
            return this;
        }

        private static InvalidCastException RaiseInvalidTypeCastException()
        {
            return new InvalidCastException(string.Format("Unable to cast {0} to the target type", "PersianDateTime"));
        }

        public PersianDateTime Add(PersianDateTime persiandateTime)
        {
            return Add(this, persiandateTime);
        }

        public static bool TryParsePersian(string str, out PersianDateTime result)
        {
            result = Now;
            try
            {
                result = ParsePersian(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
