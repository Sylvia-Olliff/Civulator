using System.Reflection;

namespace Civulator.Models.Utility;

public abstract class Enumeration : IComparable
{
    public string Name { get; private set; }

    public int Id { get; private set; }

    private IdRegister Register { get; set; }

    protected Enumeration(string name)
    {
        Register = new(1, 1);
        Name = name;
        Id = Register.GetNext();
    }

    protected Enumeration(string name, int startingId, int increment)
    {
        Register = new(startingId, increment);
        Name = name;
        Id = Register.GetNext();
    }

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        if (obj is not Enumeration otherValue)
            return false;

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);

    private class IdRegister(int startingId, int increment)
    {
        private int _nextId = startingId;
        private int _increment = increment;

        private List<int> _registeredIds = [];

        public int GetNext()
        {
            int result = _nextId;
            _nextId += _increment;

            if (_registeredIds.Contains(result))
                return this.GetNext();
            return result;
        }
    }
}

