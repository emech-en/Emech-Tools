using System;
using EmechTools.Persian.Attributes;

namespace EmechTools.Persian.DataTypes
{
    // Programmer: Emech
    // Description: PersianDateTime
    // Date: 1393/06/13 10:33:14 AM
    public enum PersianDayOfWeek
    {
        [LocalizedDescription(cultureName: "fa-IR", description: "يکشنبه")]
        [LocalizedDescription(cultureName: "en-US", description: "YekShanbeh")]
        YekShanbeh,
        [LocalizedDescription(cultureName: "fa-IR", description: "دوشنبه")]
        [LocalizedDescription(cultureName: "en-US", description: "DoShanbeh")]
        DoShanbeh,
        [LocalizedDescription(cultureName: "fa-IR", description: "سه‏شنبه")]
        [LocalizedDescription(cultureName: "en-US", description: "SehShanbeh")]
        SeShanbeh,
        [LocalizedDescription(cultureName: "fa-IR", description: "چهارشنبه")]
        [LocalizedDescription(cultureName: "en-US", description: "ChaharShanbeh")]
        ChaharShanbeh,
        [LocalizedDescription(cultureName: "fa-IR", description: "پنجشنبه")]
        [LocalizedDescription(cultureName: "en-US", description: "PanjShanbeh")]
        PanjShanbeh,
        [LocalizedDescription(cultureName: "fa-IR", description: "جمعه")]
        [LocalizedDescription(cultureName: "en-US", description: "Jomeh")]
        Jomeh,
        [LocalizedDescription(cultureName: "fa-IR", description: "شنبه")]
        [LocalizedDescription(cultureName: "en-US", description: "Shanbeh")]
        Shanbeh,
    }
}
