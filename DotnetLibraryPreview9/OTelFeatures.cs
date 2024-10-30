using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace DotnetLibraryPreview9
{
    public class OTelFeatures
    {
        void AddLinkActivity()
        {
            // AddLink(ActivityLink) API lets you link an Activity object to other tracing contexts after it's created
            // Before this could only be done in the constructor.
            ActivityContext activityContext = new(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.None);
            ActivityLink activityLink = new(activityContext);

            Activity activity = new("LinkTest");
            // This aligns with the OTel specs.
            activity.AddLink(activityLink);
        }


        void MetricsGauge()
        {
            // The Gauge instrument is designed to record non-additive values when changes occur.
            // For example: Background noise levels, temperature, etc.

            Meter soundMeter = new("MeasurementLibrary.Sound");
            Gauge<int> gauge = soundMeter.CreateGauge<int>(
                name: "NoiseLevel",
                unit: "dB", // Decibels.
                description: "Background Noise Level"
                );
            gauge.Record(10, new TagList() { { "Room1", "dB" } });
        }
    }
}
