# HLQ003: Public methods should return highest admissible level interfaces

## Cause

Public method returns a lower level interface than the one supported by the value returned.

## Rule description

`IEnumerable<T>` is commonly used to return a read-only view of a collection. This interface only allows sequencial enumeration of the items, resulting in methods like [`Count()`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count) to have complexity O(n).

[`Count()`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count) contains optimizations to avoid this issue by trying to cast to other types and take advantage of its interfaces. This is not intuitive to the user, complicates the implementation of `Count()` and still incurs on a performance penalty.

The following interfaces also give read-only views of a collection, with more capabilities:

- [`IReadOnlyCollection<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1) - has a `Count` property with complexity O(1).
- [`IReadOnlyList<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1) - has an indexer that allows random access and the use of `for` loop instead of `foreach`.
- [`IReadOnlyDictionary<TKey, TValue>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2) - all the read operations common to `Dictionary<TKey, TValue>`.

The use of these interfaces makes the capabilities explicit and result in much better performance.

## How to fix violations

Change the return type by the one suggested.

## When to suppress warnings

When, for contractual reasons, the return type cannot change.

## Example of a violation

### Code

```csharp
IEnumerable<int> Method()
{
    return new[] { 0, 1, 2, 4, 5 };
}
```

## Example of how to fix

### Code

```csharp
IReadOnlyList<int> Method()
{
    return new[] { 0, 1, 2, 4, 5 };
}
```
