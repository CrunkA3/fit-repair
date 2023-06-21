namespace FitRepair;

public class FieldNumberDefinitions<T> where T : notnull
{
    public static readonly SortedList<T, FieldNumberDefinitions<T>> Values = new();

    internal FieldNumberDefinitions(T value)
    {
        _value = value;
        Unit = string.Empty;
        Values.Add(value, this);
    }

    internal FieldNumberDefinitions(T value, string unit)
    {
        _value = value;
        Unit = unit;
        Values.Add(value, this);
    }

    private readonly T _value;
    internal readonly string Unit;

    public static implicit operator T(FieldNumberDefinitions<T> value) => value._value;
    public static implicit operator FieldNumberDefinitions<T>(T value) => Values[value];
}