using System.Text.Json.Nodes;

namespace SystemTextJsonPreview9;

public class OrderJsonProperties
{
    public OrderJsonProperties()
    {
        JsonObject jObj = new()
        {
            ["key1"] = true,
            ["key3"] = 3
        };

        Console.WriteLine(jObj is IList<KeyValuePair<string, JsonNode?>>); // True.

        // Insert a new key-value pair at the correct position.
        int key3Pos = jObj.IndexOf("key3") is int i and >= 0 ? i : 0;
        jObj.Insert(key3Pos, "key2", "two");

        foreach (KeyValuePair<string, JsonNode?> item in jObj)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        // Output:
        // key1: true
        // key2: two
        // key3: 3
    }
}
