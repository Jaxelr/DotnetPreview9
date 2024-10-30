namespace CSharp13Preview9;

public class ParamsCollections
{
    public ParamsCollections()
    {
        var persons = new List<Person>
        {
           new("Mads", "Torgersen"),
           new("Dustin", "Campbell"),
           new("Kathleen", "Dollard")
        };

        // array overload is used
        WriteNames(new string[] { "Mads", "Dustin", "Kathleen" });

        // IEnumerable overload is used
        WriteNames(persons.Select(person => person.FirstName));

        // most efficient overload is used: currently ReadOnlySpan
        WriteNames("Mads", "Dustin", "Kathleen");
    }

    //Old Style
    public void WriteNames(params string[] names)
   => Console.WriteLine(String.Join(", ", names));

    //New options
    public void WriteNames(params ReadOnlySpan<string> names)
       => Console.WriteLine(String.Join(", ", names));

    //New options
    public void WriteNames(params IEnumerable<string> names)
       => Console.WriteLine(String.Join(", ", names));

    public record Person(string FirstName, string LastName);
}
