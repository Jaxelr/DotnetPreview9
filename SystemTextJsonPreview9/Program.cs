using System.Text.Json.Nodes;
using System.Text.Json.Schema;
using System.Text.Json.Serialization;

var a = new CustomizeEnums();

JsonSerializerOptions options = JsonSerializerOptions.Default;
JsonNode schema = options.GetJsonSchemaAsNode(typeof(Person));
Console.WriteLine(schema.ToString());


//Control the output of your jsonschema exporter by modifying the json serializer options
JsonSerializerOptions options2 = new(JsonSerializerOptions.Default)
{
    PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper,
    NumberHandling = JsonNumberHandling.WriteAsString,
    UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
    
};

schema = options2.GetJsonSchemaAsNode(typeof(Person));
//Console.WriteLine(schema.ToString());

JsonSerializerOptions options3 = JsonSerializerOptions.Default;
JsonSchemaExporterOptions exporterOptions = new()
{
    // Marks root-level types as non-nullable
    TreatNullObliviousAsNonNullable = true,
};

schema = options3.GetJsonSchemaAsNode(typeof(Person), exporterOptions);
//Console.WriteLine(schema.ToString());

Console.Read();


record Person(string Name, int Age, string? Address = null);