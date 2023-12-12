namespace Intelligence.Data;

internal class BackpackRepository
{
    private List<string> _store = new List<string>();

    internal void Insert(string element)
    {
        _store.Add(element);
    }

    internal void Delete(string element)
    {
        _store.Remove(element);
    }

    internal List<string> FetchAll()
    {
        return _store;
    }

    internal int ElementCount(string name)
    {
        int count = (from element in _store
                    where element == name
                    select element).Count();

        return count;
    }
}