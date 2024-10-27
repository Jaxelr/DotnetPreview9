using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetLibraryPreview9;

public class NewOrderedDictionary
{
    //Dotnet had an OrderedDictionary class but did not support generics.
    public NewOrderedDictionary()
    {
        OrderedDictionary<string, int> d = new()
        {
            ["a"] = 1,
            ["b"] = 2,
            ["c"] = 3,
        };

        d.Add("d", 4);
        d.RemoveAt(0);
        d.RemoveAt(2);
        d.Insert(0, "e", 5);

        foreach (KeyValuePair<string, int> entry in d)
        {
            Console.WriteLine(entry);
        }

        // Output:
        // [e, 5]
        // [b, 2]
        // [c, 3]
    }
}
