using Prm.SerilogCustomization;
using Serilog;
using System;
using System.Globalization;

namespace Demo
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
    }

    class CustomDateFormatter : IFormatProvider
    {
        readonly IFormatProvider basedOn;
        readonly string datePattern;
        readonly string timePattern;

        public CustomDateFormatter(IFormatProvider basedOn, string datePattern="", string timePattern = "")
        {
            this.datePattern = datePattern;
            this.timePattern = timePattern;
            this.basedOn = basedOn;
        }
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(DateTimeFormatInfo))
            {
                var basedOnFormatInfo = (DateTimeFormatInfo)basedOn.GetFormat(formatType);
                var dateFormatInfo = (DateTimeFormatInfo)basedOnFormatInfo.Clone();
                if (!string.IsNullOrEmpty(datePattern))
                {
                    dateFormatInfo.ShortDatePattern = this.datePattern;
                }
                if (!string.IsNullOrEmpty(timePattern))
                {
                    dateFormatInfo.LongTimePattern = this.timePattern;
                }
                return dateFormatInfo;
            }
            return this.basedOn.GetFormat(formatType);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string outputTemplate = "{UtcTimestamp:o} [{Level:u3}] {Message}{NewLine}{Exception}";
            var formatter = new CustomDateFormatter(new CultureInfo("en-AU"), "dd-MMM-yyyy", "HH:mm:ss.fffK");
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(formatProvider: new CultureInfo("en-AU"), outputTemplate: outputTemplate) //Console1
                .WriteTo.Console(formatProvider: formatter, outputTemplate: outputTemplate)                //Console2
                .Enrich.With<UtcTimestampEnricher>()
                .CreateLogger();

            var exampleUser = new User { Id = 1, Name = "Adam", Created = DateTime.Now };
            Log.Information("Created {@User} on {Created}", exampleUser, DateTime.Now);

            Log.CloseAndFlush();
        }
    }
}
