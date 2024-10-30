namespace SystemTextJsonPreview9;

public class RespectNonOptionalParams
{
    record Person(string Name, int Age);

    public void DefaultBehavior()
    {
        var result = JsonSerializer.Deserialize<Person>("{}");
        Console.WriteLine(result);
        // Person { Name = , Age = 0 }
    }

    record MyPoco(string Required, string? Optional = null);

    JsonSerializerOptions options = new() { RespectRequiredConstructorParameters = true };
    public void NewBehavior()
    {
        string json = """{"Optional": "value"}""";
        JsonSerializer.Deserialize<MyPoco>(json, options);
        // JsonException: JSON deserialization for type 'MyPoco' 
        // was missing required properties including: 'Required'.
    }
}
