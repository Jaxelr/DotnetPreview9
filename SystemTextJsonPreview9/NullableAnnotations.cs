namespace SystemTextJsonPreview9;

#nullable disable
public class NullableAnnotations
{
    JsonSerializerOptions options = new() { RespectNullableAnnotations = true };

    public NullableAnnotations() { }

    public void SerializePoco()
    {

        MyPoco invalidValue = new(Name: null!);
        JsonSerializer.Serialize(invalidValue, options);

        Console.WriteLine(invalidValue);
        Console.Read();
    }

    public void DeserializePoco()
    {
        string json = """{"Name":null}""";
        var value = JsonSerializer.Deserialize<MyPoco>(json, options);

        Console.WriteLine(value);
        Console.Read();
    }

    record MyPoco(string Name);
}
