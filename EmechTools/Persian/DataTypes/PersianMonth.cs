using System;
using EmechTools.Persian.Attributes;

namespace EmechTools.Persian.DataTypes
{
    // Programmer: Emech
    // Description: PersianDateTime
    // Date: 1393/06/13 10:33:14 AM
    public enum PersianMonth
    {
        [LocalizedDescription(cultureName: "fa-IR", description: "فررودين")]
        [LocalizedDescription(cultureName: "en-US", description: "Farvardin")]
        Farvardin,
        [LocalizedDescription(cultureName: "fa-IR", description: "ارديبهشت")]
        [LocalizedDescription(cultureName: "en-US", description: "Ordibehesht")]
        Ordibehesht,
        [LocalizedDescription(cultureName: "fa-IR", description: "خرداد")]
        [LocalizedDescription(cultureName: "en-US", description: "Khordad")]
        Khordad,
        [LocalizedDescription(cultureName: "fa-IR", description: "تير")]
        [LocalizedDescription(cultureName: "en-US", description: "Tir")]
        Tir,
        [LocalizedDescription(cultureName: "fa-IR", description: "مرداد")]
        [LocalizedDescription(cultureName: "en-US", description: "Mordad")]
        Mordad,
        [LocalizedDescription(cultureName: "fa-IR", description: "شهريور")]
        [LocalizedDescription(cultureName: "en-US", description: "Shahrivar")]
        Sharivar,
        [LocalizedDescription(cultureName: "fa-IR", description: "مهر")]
        [LocalizedDescription(cultureName: "en-US", description: "Mehr")]
        Mehr,
        [LocalizedDescription(cultureName: "fa-IR", description: "آبان")]
        [LocalizedDescription(cultureName: "en-US", description: "Aban")]
        Aban,
        [LocalizedDescription(cultureName: "fa-IR", description: "آذر")]
        [LocalizedDescription(cultureName: "en-US", description: "Azar")]
        Azar,
        [LocalizedDescription(cultureName: "fa-IR", description: "دي")]
        [LocalizedDescription(cultureName: "en-US", description: "Dey")]
        Dey,
        [LocalizedDescription(cultureName: "fa-IR", description: "بهمن")]
        [LocalizedDescription(cultureName: "en-US", description: "Bahman")]
        Bahman,
        [LocalizedDescription(cultureName: "fa-IR", description: "اسفند")]
        [LocalizedDescription(cultureName: "en-US", description: "Esfand")]
        Esfand
    }
}
