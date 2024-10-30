using System.Text.Json.Serialization;

namespace SystemTextJsonPreview9;

public class CustomizeEnums
{
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
    enum MyEnum
    {
        Value1 = 1,
        [JsonStringEnumMemberName("Custom enum value")]
        Value2 = 2,
    }

    public CustomizeEnums()
    {
        var text = JsonSerializer.Serialize(MyEnum.Value1 | MyEnum.Value2); 
        Console.WriteLine(text); // "Value1, Custom enum value"
    }
}
