namespace DotnetLibraryPreview9;

public class MorePreciseTimeSpan
{
    public MorePreciseTimeSpan()
    {
        //Since its a double value, its floating point precision is limited
        TimeSpan timeSpan1 = TimeSpan.FromSeconds(value: 101.832);
        Console.WriteLine($"timeSpan1 = {timeSpan1}");
        // timeSpan1 = 00:01:41.8319999

        // -- New overloads solve this, to generate better precision --
        TimeSpan timeSpan2 = TimeSpan.FromSeconds(seconds: 101, milliseconds: 832);
        Console.WriteLine($"timeSpan2 = {timeSpan2}");
        // timeSpan2 = 00:01:41.8320000
    }
}
