/*
 * CODE OWNERS: Tom Puckett
 * OBJECTIVE: Collects Serilog LogEvent objects written to a Serilog.Sinks.Observable sink
 * DEVELOPER NOTES: <What future developers need to know.>
 */

using Serilog.Events;
using System;
using System.Collections.Generic;

namespace PrmSerilogCustomizationTest
{
    /// <summary>
    /// Reference the nuget package Serilog.Sinks.Observable, then:
    /// <para>using Serilog;</para>
    /// <para>Log.Logger = new LoggerConfiguration().WriteTo.Observers(events => events.Subscribe(new LogEventObserver())).CreateLogger();</para>
    /// </summary>
    internal class LogEventObserver : IObserver<LogEvent>
    {
        /// <summary>
        /// Stores all LogEvent instances processed by the Serilog sink that this instance is observing
        /// </summary>
        internal List<LogEvent> AllObservedLogEventList { get; private set; } = new List<LogEvent>();

        public void OnCompleted()
        {}

        public void OnError(Exception ex)
        {}

        public void OnNext(LogEvent evt)
        {
            AllObservedLogEventList.Add(evt);
        }
    }
}
