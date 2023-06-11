namespace FitRepair;

public abstract class FieldNumberDefinitions<T> where T : notnull
{
    public static readonly SortedList<T, FieldNumberDefinitions<T>> Values = new SortedList<T, FieldNumberDefinitions<T>>();

    internal FieldNumberDefinitions(T value)
    {
        _value = value;
        Values.Add(value, this);
    }
    private readonly T _value;

    public static implicit operator T(FieldNumberDefinitions<T> value) => value._value;
    public static implicit operator FieldNumberDefinitions<T>(T value) => Values[value];
}