# HLQ001: Assigment causes boxing of enumerator

## Cause

An enumerable that creates value type enumerators is assigned to a non-public variable, field or property whose type causes the enumerator to be boxed.

## Rule description

Enumerables can be implemented so that they create value type enumerators. The advantage is that calls to its methods are not virtual.

Most collections in the .NET framework are implemented this way. Here's an excerpt of the `List<T>` implementation:

```csharp
public class List<T> : IList<T>, IList, IReadOnlyList<T>
{
    public Enumerator GetEnumerator()
        => new Enumerator(this);

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => new Enumerator(this);

    IEnumerator IEnumerable.GetEnumerator()
        => new Enumerator(this);
        
    public struct Enumerator : IEnumerator<T>, IEnumerator
    {
        public bool MoveNext()
        {
            ...
        }
            
        public T Current => _current;

        object IEnumerator.Current
        {
            get
            {
                ...
            }
        }       
    }
}
```

The public `GetEnumerator()` method returns the inner struct `Enumerator` while the other two `GetEnumerator()` methods return interfaces, causing the `Enumerator` to be boxed. These last two methods are implemented explicitly so that they are called when the `List<T>` is cast to one of these interfaces.

The C# `foreach` is implemented so that the public `GetEnumerator()` can be called. For example:

```csharp
var list = new List<int>();
foreach (var item in list)
    Console.WriteLine(item);
```

The compiler interpretes it as the following:

```csharp
List<int> list = new List<int>();
List<int>.Enumerator enumerator = list.GetEnumerator();
try
{
    while (enumerator.MoveNext())
    {
        int current = enumerator.Current;
        Console.WriteLine(current);
    }
}
finally
{
    ((IDisposable)enumerator).Dispose();
}
```

The `list` variable is declared as type `List<int>` and the `enumerator` variable as type `List<int>.Enumerator`.

Changing the `list` variable type, on the original code, to any of the interfaces implemented by `List<T>`:

```csharp
IReadOnlyList<int> list = new List<int>();
foreach (var item in list)
    Console.WriteLine(item);
```

Results on the type of `enumerator` to change to `IEnumerator<int>` or `IEnumerator`:

```csharp
IReadOnlyList<int> readOnlyList = new List<int>();
IEnumerator<int> enumerator = readOnlyList.GetEnumerator();
try
{
    while (enumerator.MoveNext())
    {
        int current = enumerator.Current;
        Console.WriteLine(current);
    }
}
finally
{
    if (enumerator != null)
    {
        enumerator.Dispose();
    }
}
```

This causes the `enumerator` to be copied to the heap and all calls of `MoveNext()` and `Current` to be virtual, reducing performance.

## How to fix violations

Change the type of the variable, field or property so that boxing is avoided. Using `var`, instead of the explicit type, guarantees that the correct type is always used.

## When to suppress warnings

Optionally, when `foreach` is not used to enumerate the collection.

## Example of a violation

The following example shows the multiples cases of assignment that are detected by this rule:

```csharp
class Class1
{
    IEnumerable<int> privateField = new List<int>();

    IEnumerable<int> PrivateProperty { get; set; } = new List<int>();

    void Method()
    {
        IEnumerable<int> localVariable = new List<int>();

        privateField = new List<int>();
        PrivateProperty = new List<int>();
        localVariable = new List<int>();
    }
}
```

## Example of how to fix

Changing the field and property types to `List<int>` and using `var` for the local variable declaration, solves the issue:

```csharp
class Class1
{
    List<int> privateField = new List<int>();

    List<int> PrivateProperty { get; set; } = new List<int>();

    void Method()
    {
        var localVariable = new List<int>();

        privateField = new List<int>();
        PrivateProperty = new List<int>();
        localVariable = new List<int>();
    }
}
```
