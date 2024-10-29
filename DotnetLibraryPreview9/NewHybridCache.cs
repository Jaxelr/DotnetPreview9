using Microsoft.Extensions.Caching.Hybrid;
using System.ComponentModel;

namespace DotnetLibraryPreview9;

public class NewHybridCache(HybridCache cache)
{
    private readonly HybridCache _cache = cache;

    /* - Example values that could be added to the bootstrapping of the hybrid cache
        options.MaximumPayloadBytes = 1024 * 1024;
        options.MaximumKeyLength = 1024;
        options.DefaultEntryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(5),
            LocalCacheExpiration = TimeSpan.FromMinutes(5)
        };
     */

    public async Task<string> GetSomeInfoAsync(string name, int id, CancellationToken token = default)
    {
        // This call checks first on the local in memory cache, if missed, checks on the secondary cache (Redis/Cosmos/Sql Server)
        // If both miss, it will call the GetDataFromTheSourceAsync method and store the result in both caches

        // This call is thread safe and will only call GetDataFromTheSourceAsync once for the same key
        // providing "Stampede" protection to prevent parallel fetches of the same work.
        return await _cache.GetOrCreateAsync(
            $"{name}-{id}", // Unique key to the cache entry
            async cancel => await GetDataFromTheSourceAsync(name, id, cancel),
            cancellationToken: token
        );
    }

    public async Task<string> GetDataFromTheSourceAsync(string name, int id, CancellationToken token)
    {
        await Task.Delay(1, token);
        string someInfo = $"someinfo-{name}-{id}";
        return someInfo;
    }

    public async Task<string> RemoveCacheEntry(string name, int id)
    {
        // Removes the cache entry from both the local in memory cache and the secondary cache
        await _cache.RemoveAsync($"{name}-{id}");
        return $"Cache entry {name}-{id} removed";
    }

    // We can enhance the performance of our serialization to the secondary cache, by marking immutable and sealed the class
    // This will ensure that the serialization is optimized.
    [ImmutableObject(true)]
    public sealed class Poco
    {
        public int Key { get; set; }
        public string? Value { get; set; }
    }
}
