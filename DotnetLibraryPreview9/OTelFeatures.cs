using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetLibraryPreview9
{
    public class OTelFeatures
    {
        void AddLinkActivity()
        {
            // AddLink(ActivityLink) API lets you link an Activity object to other tracing contexts after it's created
            ActivityContext activityContext = new(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.None);
            ActivityLink activityLink = new(activityContext);

            Activity activity = new("LinkTest");
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
