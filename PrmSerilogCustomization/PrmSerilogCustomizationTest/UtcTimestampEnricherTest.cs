/*
 * CODE OWNERS: Tom Puckett
 * OBJECTIVE: Unit tests for the PRM UtcTimestamp event enricher
 * DEVELOPER NOTES: <What future developers need to know.>
 */

using Prm.SerilogCustomization;
using Serilog;
using Serilog.Events;
using System;
using System.Linq;
using Xunit;

namespace PrmSerilogCustomizationTest
{
    public class UtcTimestampEnricherTest
    {
        [Fact]
        public void UtcTimestampEnricher_StoresCorrectUtcDateTime()
        {
            #region Arrange
            var enricher = new UtcTimestampEnricher();
            LogEventObserver logObserver = new LogEventObserver();

            LoggerConfiguration loggerConfiguration = new LoggerConfiguration()
                .Enrich.With<UtcTimestampEnricher>()
                .WriteTo.Observers(events => events.Subscribe(logObserver));
            Log.Logger = loggerConfiguration.CreateLogger();
            #endregion

            #region act
            Log.Error("Hello world error");
            #endregion

            #region assert
            Assert.Single(logObserver.AllObservedLogEventList);
            Assert.Contains("UtcTimestamp", logObserver.AllObservedLogEventList[0].Properties.Keys, StringComparer.OrdinalIgnoreCase);

            // Yes, the following query of the underlying IDictionary is needed here.  The Properties indexer returns something that can't be used as a DateTime instance, so that's non-useful
            var rawValue = Assert.IsType<ScalarValue>(logObserver.AllObservedLogEventList.Single().Properties.Single(p => p.Key == "UtcTimestamp").Value);

            var eventUtcTimestamp = Assert.IsType<DateTime>(rawValue.Value);
            var eventTimeStamp = logObserver.AllObservedLogEventList[0].Timestamp;

            Assert.Equal(DateTimeKind.Utc, eventUtcTimestamp.Kind);
            Assert.Equal(DateTimeKind.Local, eventTimeStamp.LocalDateTime.Kind);
            Assert.Equal(eventTimeStamp, eventUtcTimestamp);
            Assert.Equal(eventTimeStamp.Offset.TotalHours, (eventTimeStamp.LocalDateTime - eventUtcTimestamp).TotalHours);
            #endregion
        }

    }
}
