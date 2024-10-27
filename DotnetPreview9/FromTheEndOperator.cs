namespace CSharp13Preview9;

public class FromTheEndOperator
{
    public FromTheEndOperator()
    {
        //From the End Operator
        var test = new Test
        {
            Numbers =
            {
                [^1] = 1,
                [^2] = 2,
                [^3] = 3,
                [^4] = 4,
                [^5] = 5,
            }
        };

        Console.WriteLine(string.Join(", ", test.Numbers));
        // 5, 4, 3, 2, 1
    }
}

public class Test
{
    public int[] Numbers = new int[5];
}
