using System.Text.RegularExpressions;

namespace DotnetLibraryPreview9;

public class CollectionLookupsWithSpans
{
    /// We can now use ReadOnlySpan<char> as a key in a Dictionary.
    private static Dictionary<string, int> CountWords(ReadOnlySpan<char> input)
    {
        Dictionary<string, int> wordCounts = new(StringComparer.OrdinalIgnoreCase);

        Dictionary<string, int>.AlternateLookup<ReadOnlySpan<char>> spanLookup =
            wordCounts.GetAlternateLookup<ReadOnlySpan<char>>();

        foreach (Range wordRange in Regex.EnumerateSplits(input, @"\b\w+\b"))
        {
            ReadOnlySpan<char> word = input[wordRange];
            spanLookup[word] = spanLookup.TryGetValue(word, out int count) ? count + 1 : 1;
        }

        return wordCounts;
    }
}
