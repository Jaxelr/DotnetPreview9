using System.Threading.Channels;

namespace DotnetLibraryPreview9;

public class Threading
{
    public async Task IterateThrough()
    {
        using HttpClient http = new();

        Task<string> dotnet = http.GetStringAsync("http://dot.net");
        Task<string> bing = http.GetStringAsync("http://www.bing.com");
        Task<string> ms = http.GetStringAsync("http://microsoft.com");

        await foreach (Task<string> t in Task.WhenEach(bing, dotnet, ms))
        {
            Console.WriteLine(t.Result);
        }
    }

    public async Task PrioritizedUnboundedChannel()
    {
        // By default Channels are FIFO
        // This new channel allows you to prioritize items upon reading
        // as based on the Comparer<T>
        Channel<int> c = Channel.CreateUnboundedPrioritized<int>();

        await c.Writer.WriteAsync(1);
        await c.Writer.WriteAsync(5);
        await c.Writer.WriteAsync(2);
        await c.Writer.WriteAsync(4);
        await c.Writer.WriteAsync(3);
        c.Writer.Complete();

        while (await c.Reader.WaitToReadAsync())
        {
            while (c.Reader.TryRead(out int item))
            {
                Console.Write($"{item} ");
            }
        }
        // Output: 1 2 3 4 5
    }
}
