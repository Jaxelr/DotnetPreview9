using System.Text.RegularExpressions;

namespace CSharp13Preview9;

public partial class PartialProperties
{
    [GeneratedRegex("abc|def")]
    private static partial Regex AbcRegex { get; }

    public bool IsMatchAbc(string text)
        => AbcRegex.IsMatch(text);
}

public partial class PartialPropertiesSetter
{
    // Declaring declaration
    public partial string Name { get; set; }
}

public partial class PartialPropertiesSetter
{
    // implementation declaration:
    private string? _name;
    public partial string Name
    {
        get => _name ?? string.Empty;
        set => _name = value;
    }
}
