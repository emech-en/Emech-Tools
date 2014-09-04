using System;
using System.Runtime.InteropServices;

namespace EmechTools.Persian.DataTypes
{
    // Programmer: Emech
    // Description: PersianDateTime
    // Date: 1393/06/13 10:33:14 AM
    [StructLayout(LayoutKind.Sequential)]
    internal struct PersianDateTimeData
    {
        internal int Year;
        internal int Month;
        internal int Day;
        internal int Hour;
        internal int Minute;
        internal int Second;

        internal bool HasDate;
        internal bool HasTime;

        internal void Init()
        {
            this.Year = this.Month = this.Day = this.Hour = this.Minute = this.Second = -1;
            this.HasDate = true;
            this.HasTime = true;
        }
    }
}
