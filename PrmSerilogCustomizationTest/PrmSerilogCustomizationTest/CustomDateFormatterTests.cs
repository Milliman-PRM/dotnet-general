/*
 * CODE OWNERS: Tom Puckett
 * OBJECTIVE: Unit tests for custom formatters in the Prm.SerilogCustomization namespace
 * DEVELOPER NOTES: <What future developers need to know.>
 */

using Prm.SerilogCustomization;
using Serilog;
using Serilog.Events;
using System;
using System.Globalization;
using Xunit;

namespace PrmSerilogCustomizationTest
{
    public class CustomDateFormatterTests
    {
        [Theory]
        [InlineData("yyyy", "HH:mm:ss.fffK")]
        [InlineData("abc", "def")]
        public void FormatterAcceptsSpecifiedDateTimePatterns(string DateSpecifier, string TimeSpecifier)
        {
            #region Arrange
            var formatter = new CustomDateTimeFormatter(CultureInfo.InvariantCulture, DateSpecifier, TimeSpecifier);
            #endregion

            #region act
            var format = formatter.GetFormat(typeof(DateTimeFormatInfo));
            #endregion

            #region Assert
            var formatInfo = Assert.IsType<DateTimeFormatInfo>(format);
            Assert.Equal(DateSpecifier, formatInfo.ShortDatePattern);
            Assert.Equal(TimeSpecifier, formatInfo.LongTimePattern);
            #endregion
        }

        [Fact]
        public void EnricherDoesSomethingRight()
        {
            #region Arrange
            var enricher = new UtcTimestampEnricher();
            #endregion

            #region act
            LoggerConfiguration loggerConfiguration = new LoggerConfiguration()
                .Enrich.With<UtcTimestampEnricher>()
                .WriteTo.Debug();
            Log.Logger = loggerConfiguration.CreateLogger();
            #endregion

            #region assert
            #endregion
        }

    }
}
