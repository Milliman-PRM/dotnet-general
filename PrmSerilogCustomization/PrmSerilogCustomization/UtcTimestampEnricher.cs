/*
 * CODE OWNERS: Tom Puckett
 * OBJECTIVE: <What and WHY.>
 * DEVELOPER NOTES: Found this at https://github.com/serilog/serilog/issues/735 there are some additional formatting ideas there also
 */

using Serilog.Core;
using Serilog.Events;

namespace Prm.SerilogCustomization
{
    /// <summary>
    /// A Serilog LogEvent enricher, adds a property named `UtcTimestamp` to each LogEvent.  Any sink's outputTemplate can reference it.
    /// </summary>
    public class UtcTimestampEnricher : ILogEventEnricher
    {
        /// <summary>
        /// Adds a property named `UtcTimestamp` to each LogEvent
        /// </summary>
        /// <param name="logEvent"></param>
        /// <param name="propertyFactory"></param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            // When this enricher is incorporated into the Serilog LoggerConfiguration (e.g. `.Enrich.With<UtcTimestampEnricher>()`)
            // the named parameter below can be referenced in an outputTemplate of a sink, (e.g. instead of the built in parameter "Timestamp")
            LogEventProperty utcTimestampProperty = propertyFactory.CreateProperty("UtcTimestamp", logEvent.Timestamp.UtcDateTime);
            logEvent.AddPropertyIfAbsent(utcTimestampProperty);
        }
    }
}
