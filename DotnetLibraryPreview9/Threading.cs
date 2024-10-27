﻿namespace DotnetLibraryPreview9;

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
}
