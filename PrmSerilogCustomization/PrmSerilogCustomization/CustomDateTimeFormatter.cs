using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Serilog.Core;
using Serilog.Events;

namespace Prm.SerilogCustomization
{
    /// <summary>
    /// Formatter that can be instantiated with date and time formatting strings
    /// </summary>
    public class CustomDateTimeFormatter : IFormatProvider
    {
        readonly IFormatProvider _basedOn;
        readonly string _datePattern;
        readonly string _timePattern;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="basedOn"></param>
        /// <param name="datePattern">null or "" to use the active culture</param>
        /// <param name="timePattern">null or "" to use the active culture</param>
        public CustomDateTimeFormatter(IFormatProvider basedOn, string datePattern, string timePattern)
        {
            _timePattern = timePattern;
            _datePattern = datePattern;
            _basedOn = basedOn;
        }

        /// <summary>
        /// Implements the inherited interface method
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(DateTimeFormatInfo))
            {
                var basedOnFormatInfo = (DateTimeFormatInfo)_basedOn.GetFormat(formatType);
                var dateFormatInfo = (DateTimeFormatInfo)basedOnFormatInfo.Clone();
                dateFormatInfo.ShortDatePattern = _datePattern;
                dateFormatInfo.LongTimePattern = _timePattern;
                return dateFormatInfo;
            }
            return this._basedOn.GetFormat(formatType);
        }
    }
}
