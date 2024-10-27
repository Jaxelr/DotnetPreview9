using System.Runtime.CompilerServices;

namespace CSharp13Preview9;

public class OverloadResolutionPriority
{
    public OverloadResolutionPriority()
    {
        var service = new MyService();

        //The compiler will select ReadOnlySpan<char>
        service.Display("Hello World!");
    }
}

public class MyService
{
    //Prioritize your overload based on the attribute.

    [OverloadResolutionPriority(1)]
    public void Display(string chars) =>
        Console.WriteLine(chars);

    //The higher the number means higher priority
    [OverloadResolutionPriority(2)]
    public void Display(ReadOnlySpan<char> chars) =>
        Console.WriteLine(chars.ToArray());
}
