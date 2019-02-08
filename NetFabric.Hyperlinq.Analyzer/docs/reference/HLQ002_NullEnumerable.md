# HLQ002: Enumerable methods should not return null

## Cause

A method that returns an enumerable type is returning `null`.

## Rule description

Returning `null`, in the context of enumerables, is not the same as an empty enumerable. It's an invalid state.

The following `foreach` loop: 

```csharp
foreach (var item in DoSomething())
    Console.WriteLine(item);

IEnumerable<int> DoSomething() => null;
```

is interpreted by the compiler as:

```csharp
IEnumerator<int> enumerator = DoSomething().GetEnumerator();
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

Notice that, because `DoSomething()` returns `null`, [a `NullReferenceException` will be thrown](https://sharplab.io/#v2:C4LgTgrgdgNAJiA1AHwAIAYAEqCMBuAWACgNscAWQo41AZjIDZsAmMgdk2IG9jM/t6uJqnKYAsgEMAllAAUASk5F+mHspX8AZgHswAUwkBjABaZZANwlhMU4HoC2NqJgDie4AFEoEe3rASAIwAbPQV5Xg1I3ABOWVsHeSoVAF8IvjTGMloAHhlgAD5Xdy8fP0CQhUwAXkLvIKCqZKA==) when calling `GetEnumerator()`.

The enumerable should instead make the enumerator `MoveNext()` return `false` to stop the enumeration loop.

## How to fix violations

You can return an empty instance of an array or `List<T>`, or one of the following implementations of an empty enumerable:

[`System.Linq.Enumerable.Empty<TResult>()`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.empty), if method returns any of the following: 
- `IEnumerable` 
- `IEnumerable<TResult>`

`NetFabric.Hyperlinq.Enumerable.Empty<TResult>()`, if method returns any of the following: 
- `IEnumerable` 
- `IEnumerable<TResult>`
- `IReadOnlyCollection<TResult>`
- `IReadOnlyList<TResult>`

## When to suppress warnings

Supress warning only if you really don't want to return an empty enumerable.

## Example of a violation

### Description

### Code

```csharp
IEnumerable<int> Method(bool condition)
{
    if (condition)
        return null;

    ...
}
```

## Example of how to fix

Using an empty array:

```csharp
IEnumerable<int> Method1(bool condition)
{
    if (condition)
        return new int[0];

    ...
}
```

Using an empty `List<T>`:

```csharp
IEnumerable<int> Method1(bool condition)
{
    if (condition)
        return new List<int>();

    ...
}
```

Using `Enumerable.Empty<int>()`:

```csharp
IEnumerable<int> Method1(bool condition)
{
    if (condition)
        return Enumerable.Empty<int>();

    ...
}
```

