using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace EightApi
{
    public class Instrumentation
    {
        internal const string ActivitySourceName = "EightApi";
        internal const string MeterName = "EightApi";
        private readonly Meter meter;

        public Instrumentation()
        {
            string? version = typeof(Instrumentation).Assembly.GetName().Version?.ToString();
            this.ActivitySource = new ActivitySource(ActivitySourceName, version);
            this.meter = new Meter(MeterName, version);
            this.FreezingDaysCounter = this.meter.CreateCounter<long>("weather.days.freezing", "The number of days where the temperature is below freezing");
        }

        public ActivitySource ActivitySource { get; }

        public Counter<long> FreezingDaysCounter { get; }

        public void Dispose()
        {
            this.ActivitySource.Dispose();
            this.meter.Dispose();
        }
    }
}
