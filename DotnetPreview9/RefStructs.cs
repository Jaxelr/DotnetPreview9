/// What are ref structs?
/// Lives on same locations as structs (the Stack)
/// Cannot be moved to the heap
/// Cannot be boxed
/// Used for high performance with low memory allocation
namespace CSharp13Preview9;
public class RefStructs
{
    //ref struct can bow be used on async methods
    async Task UseInAsyncMethod()
    {
        await Task.Delay(1000);
        ReadOnlySpan<char> span = "Hello, World".AsSpan();
        // -- do something --
    }

    void UseInInterfaces()
    {
        Foo foo = new();
        //var _ = (IFoo)foo; //Still cant cast to interface, but can implement interfaces.
        foo.Action();
    }

    interface IFoo
    {
        void Action();
    }

    //It can also implement interfaces
    ref struct Foo : IFoo
    {
        public void Action()
        { 
            //do something
        }
    }

    //It can be used as a generic type
    class Foo<T> where T : allows ref struct
    {

    }
    class Bar<T> { }

    class Example<T> where T : allows ref struct
    {
        private Foo<T> _foo;
        // private Bar<T> bar; Not Allowed
    }
}