namespace SystemTextJsonPreview9;

public class CustomizeIndentation
{
    JsonSerializerOptions options = new()
    {
        WriteIndented = true,
        IndentCharacter = '\t',
        IndentSize = 1,
    };

    public CustomizeIndentation()
    {
        var text = JsonSerializer.Serialize(new { Value = 42 }, options);
        Console.WriteLine(text);

    }
}
