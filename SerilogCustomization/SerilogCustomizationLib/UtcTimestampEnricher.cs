/*
 * CODE OWNERS: Tom Puckett
 * OBJECTIVE: <What and WHY.>
 * DEVELOPER NOTES: <What future developers need to know.>
 */

using Serilog.Core;
using Serilog.Events;

namespace PinPointApi
{
    /// <summary>
    /// A Serilog LogEvent enricher, adds a named property to each logevent to store UTC timestamp for any sink that wants to reference it
    /// Found this at https://github.com/serilog/serilog/issues/735 there are some formatting ideas there also
    /// </summary>
    public class UtcTimestampEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            // When this enricher is incorporated into the Serilog LoggerConfiguration (e.g. `.Enrich.With<UtcTimestampEnricher>()`)
            // the named parameter below can be referenced in an outputTemplate of a sink, (e.g. instead of the built in parameter "Timestamp")
            LogEventProperty utcTimestampProperty = propertyFactory.CreateProperty("UtcTimestamp", logEvent.Timestamp.UtcDateTime);
            logEvent.AddPropertyIfAbsent(utcTimestampProperty);
        }
    }
}
