namespace CSharp13Preview9;

//Old pattern of locking objects
public class OldLock
{
    private readonly object _lockObj = new();
    private static int sharedResource = 0;

    public void IncrementResource()
    {
        lock (_lockObj)
        {
            sharedResource++;
        }
    }
}

//New pattern of locking objects
public class NewLock
{
    private readonly Lock _lockObj = new();
    private static int sharedResource = 0;

    public void IncrementResource()
    {
        using (_lockObj.EnterScope())
        {
            sharedResource++;
        }
    }
}
