![GitHub last commit (main)](https://img.shields.io/github/last-commit/NetFabric/NetFabric.Hyperlinq/main.svg?style=flat-square&logo=github)
[![Build and test](https://github.com/NetFabric/NetFabric.Hyperlinq/workflows/Build%20and%20test/badge.svg?style=flat-square)](https://github.com/NetFabric/NetFabric.Hyperlinq/actions)
[![Coverage](https://img.shields.io/coveralls/github/NetFabric/NetFabric.Hyperlinq/main?style=flat-square&logo=coveralls)](https://coveralls.io/github/NetFabric/NetFabric.Hyperlinq)
[![NuGet Version](https://img.shields.io/nuget/v/NetFabric.Hyperlinq.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/NetFabric.Hyperlinq/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/NetFabric.Hyperlinq.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/NetFabric.Hyperlinq/) 
[![Gitter](https://img.shields.io/gitter/room/netfabric/netfabric.hyperlinq?style=flat-square&logo=gitter)](https://gitter.im/NetFabric/NetFabric.Hyperlinq)


# NetFabric.Hyperlinq

`NetFabric.Hyperlinq` contains alternative implementations of many operations found in the `System.Linq` namespace:

- Uses value-types to improve performance by making method calls non-virtual and reducing GC collections by not allocating on the heap. 
- Adds support for `Span<>`, `ReadOnlySpan<>`, `Memory<>` and `ReadOnlyMemory<>`.
- [Nullable reference type](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references) annotations.
- One single NuGet package support for both sync and async enumerables.

This implementation **favors performance in detriment of assembly binary size** (lots of overloads).

## Contents

- [Fast enumeration](#fast-enumeration)
- [Reduced heap allocations](#reduced-heap-allocations)
- [Benchmarks](#benchmarks)
- [Usage](#usage)
  - [Value delegates](#value-delegates)
  - [Generation operations](#generation-operations)
  - [Method return types](#method-return-types)
  - [Composition](#composition)
  - [Option](#option)
  - [Buffer pools](#buffer-pools)
  - [SIMD](#simd)
- [Documentation](#documentation)
- [Supported operations](#supported-operations)
- [References](#references)
- [Credits](#credits)
- [License](#license)

## Fast enumeration

`NetFabric.Hyperlinq` can enumerate faster the results of a query than `System.Linq` by performing all of the following:

- Merges multiple enumerators into a single one for several more scenarios.
- It does not box value-type enumerators so, calls to the `Current` property and the `MoveNext()` method are non-virtual.
- All the enumerables returned by operations define a value-type enumerator.
- Whenever possible, the enumerator returned by the public `GetEnumerator()` or `GetAsyncEnumerator()` does not implement `IDisposable`. This allows the `foreach` that enumerates the result to be inlinable. 
- Operations enumerate the source using the indexer when the source is an array, `ArraySegment<>`, `Span<>`, `ReadOnlySpan<>`, `Memory<>`, `ReadOnlyMemory<>`, or implements `IReadOnlyList<>`. 
- `Range()` and `Repeat()` return enumerables that implement `IReadOnlyCollection<>` and `ICollection<>`. `Return()` and `Select()` return enumerables that implement `IReadOnlyList<>` and `IList<>`.
- Use of buffer pools in operations like `Distinct()`, `ToArray()` and `ToList()`.
- Use of SIMD in `Sum()` and `SelectVector()`.
- Elimination of conditional branchs in `Where().Count()`.
- Allows the JIT compiler to perform optimizations on array enumeration whenever possible.
- Takes advantage of `EqualityComparer<>.Default` devirtualization whenever possible.

The performance is equivalent when the enumerator is a reference-type. This happens when the enumerable is generated using `yield` or when it's cast to one of the BCL enumerable interfaces (`IEnumerable`, `IEnumerable<>`, `IReadOnlyCollection<>`, `ICollection<>`, `IReadOnlyList<>`, `IList<>`, or `IAsyncEnumerable<>`). In the case of operation composition, this only affects the first operation. The subsequent operations will have value-type enumerators.

## Reduced heap allocations

`NetFabric.Hyperlinq` allocates as much as possible on the stack. Enumerables and enumerators are defined as value-types. Generics constraints are used for the operation parameters so that the value-types are not boxed.

It only allocates on the heap for the following cases:

- Operations that use `ICollection<>.CopyTo()`, `ICollection<>.Contains()`, or `IList<>.IndexOf()` will box enumerables that are value-types.   
- `ToArray()` and `ToList()` allocate their results on the heap. You can use the `ToArray()` overload that take an buffer pool as parameter so that its result is not managed by the garbage collector.

## Benchmarks

The results of the benchmarks comparing multiple LINQ libraries can be found in the [LinqBenchmarks](https://github.com/NetFabric/LinqBenchmarks) repository. 

The results of the benchmarks included in this repository can be found in the [Benchmarks](https://github.com/NetFabric/NetFabric.Hyperlinq/tree/main/Benchmarks) folder. 

The names of the benchmarks are structured as follow:

- The library used:
  - _Linq_ - the `System.Linq` namespace (includes [System.Linq.Async](https://www.nuget.org/packages/System.Linq.Async/), [System.Interactive](https://www.nuget.org/packages/System.Interactive/), and [System.Interactive.Async](https://www.nuget.org/packages/System.Interactive.Async/))
  - _StructLinq_ - [StructLinq](https://www.nuget.org/packages/StructLinq/)
  - _Hyperlinq_ - [NetFabric.Hyperlinq](https://www.nuget.org/packages/NetFabric.Hyperlinq/)
- The type of collection used as source:
  - _Array_ - an array
  - _Span_ - a `Span<>`
  - _Memory_ - a `Memory<>`
  - _Enumerable_ - implements `IEnumerable<>`
  - _Collection_ - implements `IReadOnlyCollection<>` and `ICollection<>`
  - _List_ - implements `IReadOnlyList<>` and `IList<>` but not an array
  - _AsyncEnumerable_ - implements `IAsyncEnumerable<>`
- The type of enumerator provided by the source:
  - _Value_ - the enumerator is a value type
  - _Reference_ - the enumerator is a reference type
- The contents of the source:
  - _Sequential_ - contains numbers in sequential order
  - _Random_ - contains numbers in random order  
- How the result of the operation is iterated:
  - _For_ - a `for` loop is used to call the indexer
  - _Foreach_ - a `foreach` loop is used to call the enumerator  


## Usage

- Add the [`NetFabric.Hyperlinq` NuGet package](https://www.nuget.org/packages/NetFabric.Hyperlinq/) to your project.
- Optionally, also add the [`NetFabric.Hyperlinq.Analyzer` NuGet package](https://www.nuget.org/packages/NetFabric.Hyperlinq.Analyzer/) to your project. It's a Roslyn analyzer that suggests performance improvements on your enumeration source code. No dependencies are added to your assemblies.
- Add an `using NetFabric.Hyperlinq` directive to all source code files where you want to use `NetFabric.Hyperlinq`. It can coexist with `System.Linq` and `System.Linq.Async` directives:

``` csharp
using System;
using System.Linq;
using NetFabric.Hyperlinq; // add this directive
```

- Use the methods `AsValueEnumerable()` to make any collection usable with `NetFabric.Hyperlinq`. This includes arrays, `Memory<>`, `ReadOnlyMemory<>`, `Span<>`, `ReadOnlySpan<>`, BCL collections, and any other implementation of `IEnumerable<>`. Use `AsAsyncValueEnumerable()` for any implementation of `IAsyncEnumerable<>`.

``` csharp
public static void Example(IReadOnlyList<int> list)
{
  var result = list
    .AsValueEnumerable()
    .Where(item => item > 2)
    .Select(item => item * 2);

  foreach(var value in result)
    Console.WriteLine(value);
}
```

- `Netfabric.Hyperlinq` contains special versions of `AsValueEnumerable()` for better performance with all collections in the `System.Collections.Immutable` namespace. Projects targetting .NET Framework, `netcoreapp2.1` or `netstandard2.0`, require the addition of the [`NetFabric.Hyperlinq.Immutable` NuGet package](https://www.nuget.org/packages/NetFabric.Hyperlinq.Immutable/) dependency.

- All enumerables returned by `NetFabric.Hyperlinq` are compatible with `System.Linq`. 

`OrderByDescending()` is not yet available in `Netfabric.Hyperlinq` but can still be used without requiring any conversion:

``` csharp
public static void Example(IReadOnlyList<int> list)
{
  var result = list
    .AsValueEnumerable()
    .Where(item => item > 2)
    .OrderByDescending(item => item) // is not yet available in Netfabric.Hyperlinq
    .AsValueEnumerable()
    .Select(item => item * 2);

  foreach(var value in result)
    Console.WriteLine(value);
}
```

To add `NetFabric.Hyperlinq` operations after a `System.Linq` operation, simply add one more `AsValueEnumerable()` or `AsAsyncValueEnumerable()`.

### Value delegates

Calling a lambda expression for each item of the collection is very expensive. `NetFabric.Hyperlinq` supports a much more performant alternative.

- Declare a `struct` that implements `IFunction<>` or `IFunctionIn<>`. 

``` csharp
readonly struct DoubleOfInt32
    : IFunction<int, int>
{
    public int Invoke(int element)
        => element * 2;
}

readonly struct DoubleOfInt32ByRef
    : IFunctionIn<int, int>
{
    public int Invoke(in int element)
        => element * 2;
}
```

- Add the name of the structure to the method generics arguments

``` csharp
public static void Example(IReadOnlyList<int> list)
{
  var result = list
    .AsValueEnumerable()
    .Select<int, DoubleOfInt32>();

  foreach(var value in result)
    Console.WriteLine(value);
}
```

### Generation operations

In `NetFabric.Hyperlinq`, the generation operations like `Empty()`, `Range()`, `Repeat()` and `Return()` are static methods implemented in the static class `ValueEnumerable`. To use the equivalent operations from `NetFabric.Hyperlinq`, simply replace `Enumerable` for `ValueEnumerable`.

``` csharp
public static void Example(int count)
{
  var source = ValueEnumerable
    .Range(0, count)
    .Select(item => item * 2);

  foreach(var value in source)
    Console.WriteLine(value);
}
```

### Method return types

Usually, when returning a query, it's used `IEnumerable<>` as the method return type:

``` csharp
public static IEnumerable<int> Example(int count)
  => ValueEnumerable
    .Range(0, count)
    .Select(value => value * 2);
```

This allows the caller to use `System.Linq` or a `foreach` loop to pull and process the result. `NetFabric.Hyperlinq` can also be used but the `AsValueEnumerable()` conversion method has to be used.

The operation in `NetFabric.Hyperlinq` are implemented so that they return the highest level enumeration interface possible. For example, the `Range()` operation return implements `IValueReadOnlyList<,>` and the subsequent `Select()` return does the same thing. `IValueReadOnlyList<,>` derives from `IReadOnlyList<>` so, we can change the method to return this interface:

``` csharp
public static IReadOnlyList<int> Example(int count)
  => ValueEnumerable
    .Range(0, count)
    .Select(value => value * 2);
```

Now, the caller is free to use the enumerator or the indexer, which are provided by this interface. This means that, all previous methods of iteration can be used plus the `for` loops, which is much more efficient. The indexer performs fewer internal operations and doesn't need an enumerator instance. `NetFabric.Hyperlinq` can also be used and the `AsValueEnumerable()` conversion method still has to be used but, `NetFabric.Hyperlinq` will now use the indexer.

Otherwise, `NetFabric.Hyperlinq` will use enumerators. It implements all enumerators as value types. This allows the enumerators not to be allocated on the heap and calls to its methods to be non-virtual. The `IEnumerable<>` interface, and all other derived BCL interfaces, convert the enumerator to the `IEnumerator<>` interface. This results in the enumerator to be boxed, undoing the mentioned benefits.

`NetFabric.Hyperlinq` defines enumerable interfaces that contain the enumerator type as a generic parameter. This allows the caller to use it without boxing. Consider changing the method to return one of these interfaces:

``` csharp
public static IValueReadOnlyList<int, ReadOnlyList.SelectEnumerable<ValueEnumerable.RangeEnumerable, int, int>.DisposableEnumerator> Example(int count)
  => ValueEnumerable
    .Range(0, count)
    .Select(value => value * 2);
```

The caller is now able to use `NetFabric.Hyperlinq` without requiring the `AsValueEnumerable()` conversion method. In this case, it will use the indexer in all subsequent operations but the enumerator is still available. In other cases (`IValueEnumerable<,>`, `IValueReadOnlyCollection<,>` and `IAsyncValueEnumerable<,>`) it will use the enumerator.

`NetFabric.Hyperlinq` also implements the enumerables as value types. Returning an interface means that the enumerable will still be boxed. If you want to also avoid this, consider changing the return type to be the actual enumerable type. In this case:

``` csharp
public static ReadOnlyList.SelectEnumerable<ValueEnumerable.RangeEnumerable, int, int> Example(int count)
  => ValueEnumerable
    .Range(0, count)
    .Select(value => value * 2);
```

**NOTE:** Returning the enumerable type or a value enumeration interface, allows major performance improvements but creates a library design issue. Changes in the method implementation may result in changes to the retun type. This is a breaking change. This is an issue on the public API but not so much for the private and internal methods. Take this into consideration when deciding on the return type.

### Composition

`NetFabric.Hyperlinq` operations can be composed just like with `System.Linq`. The difference is on how each one optimizes the internals to reduce the number of enumerators required to iterate the values.

Both `System.Linq` and `NetFabric.Hyperlinq` optimize the code in the following example so that only one enumerator is used to perform both the `Where()` and the `Select()`:

``` csharp
var result = source.AsValueEnumerable()
    .Where(item => item > 2)
    .Select(item => item * 2);
```

But, `System.Linq` does not do the same for this other example:

``` csharp
var result = source.AsValueEnumerable()
    .Where(item => item > 2)
    .First();
```

`System.Linq` has a second overload for methods, like `First()` and `Single()`, that take the predicate as a parameter and allow the `Where()` to be removed. In `NetFabric.Hyperlinq` this is not required. With the intention of reducing the code to be maintained and tested, these other overloads actually are not available in `NetFabric.Hyperlinq`.

`NetFabric.Hyperlinq` includes many more composition optimizations. In the following code, only one enumerator is used, and only because of the `Where()` operation. Otherwise, the indexer would have been used instead. Also, the `Select()` is applied after `First()`, so that it's applied to only to the resulting item:

``` csharp
var result = array.AsValueEnumerable()
    .Skip(1)
    .Take(10)
    .Where(item => item > 2)
    .Select(item => item * 2)
    .First();
```

### Option

In `System.Linq`, the aggregation operations like `First()`, `Single()` and `ElementAt()`, throw an exception when the source has no items. Often, empty collections are a valid scenario and exception handling is very slow. `System.Linq` has alternative methods like `FirstOrDefault()`, `SingleOrDefault()` and `ElementAtOrDefault()`, that return the `default` value instead of throwing. This is still an issue when the items are value-typed, where there's no way to distinguish between an empty collection and a valid item.

In `NetFabric.Hyperlinq`, aggregation operations return an `Option<>` type. This is similar in behavior to the [`Nullable<>`](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1) but it can contain reference types. 

Here's a small example using `First()`:

``` csharp
var result = source.AsValueEnumerable().First();
if (result.IsSome)
  Console.WriteLine(result.Value);
```

It also provides a deconstructor so, you can convert it to a tuple:

``` csharp
var (isSome, value) = source.AsValueEnumerable().First();
if (isSome)
  Console.WriteLine(value);
```

If you prefer a more functional approach, you can use `Match()` to specify the value returned when the collection has values and when it's empty. Here's how to use it to define the previous behavior of `First()` and `FirstOrDefault()`:

``` csharp
var first = source.AsValueEnumerable().First().Match(
  item => item,
  () => throw new InvalidOperationException("Sequence contains no elements"));

var firstOrDefault = source.AsValueEnumerable().First().Match(
  item => item,
  () => default);

Console.WriteLine(first);
Console.WriteLine(firstOrDefault);
```

`Match()` can also be used to define actions:

``` csharp
source.AsValueEnumerable().First().Match(
  item => Console.WriteLine(item),
  () => { });
```

The `NetFabric.Hyperlinq` operations can be applied to `Option<>`, including `Where()`, `Select()` and `SelectMany()`. These return another `Option<>` with the predicate/selector applied to the value, if it exists.

```csharp
source.AsValueEnumerable().First().Where(item => item > 2).Match(
  item => Console.WriteLine(item),
  () => { });
```

### Buffer pools

[Buffer pools](https://adamsitnik.com/Array-Pool/) allow the use of heap memory without adding pressure to the garbage collector. It preallocates a chunk of memory and "rents" it as required. The garbage collector will add this memory to the Large Object Heap (LOH).

`ToArray()` is usually used to cache values for a brief period. `Netfabric.Hyperlinq` adds an oveload that takes a `MemoryPool<>` as a parameter:

``` csharp
using var buffer = source.AsValueEnumerable()
    .ToArray(MemoryPool<int>.Shared);
var memory = buffer.Memory;
// use memory here
```

It returns an [`IMemoryOwner<>`](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1). The `using` statement guarantees that it is disposed and the buffer automatically returned to the pool. 

### SIMD

`NetFabric.Hyperlinq` uses SIMD implicitly to improve performance when possible, but many times it can only be done explicitly by calling specific operations.

SIMD improves performance by performing the same operations simultaneously on multiple items. The operation can only be performed if this number is met. This means that a remaining number of items has to be processed without SIMD.

The items processed simultaneously are stored inside a [`System.Numerics.Vector`](https://docs.microsoft.com/en-us/dotnet/api/system.numerics.vector-1) structure.

Operations that require an expression to process data, on the SIMD-enable equivalent require an expression that applies it at the [`System.Numerics.Vector`](https://docs.microsoft.com/en-us/dotnet/api/system.numerics.vector-1) level and another one at the item level.

For this reason, and also because SIMD cannot be applied to all data types, SIMD specific operations have be called. The method has a `Vector` post-fix in the name.

``` csharp
var result = list
  .AsValueEnumerable()
  .SelectVector(item = item * 2, item = item * 2)
  .ToArray();
```

These methods also support value delegates. In this case, the `struct` containing the expressions must implement two `IFunction<,>`. 

``` csharp
readonly struct DoubleOfInt32
    : IFunction<Vector<int>, Vector<int>>
    , IFunction<int, int>
{
    public Vector<int> Invoke(Vector<int> element)
        => element * 2;

    public int Invoke(int element)
        => element * 2;
}

public static void Example(List<int> list)
{
  var result = list
    .AsValueEnumerable()
    .SelectVector<int, DoubleOfInt32>()
    .ToArray();

  foreach(var value in result)
    Console.WriteLine(value);
}
```

Please note that the operation `SelectVector()` does not return and enumerable. It returns the context required for subsequent operations like `ToArray()`, `ToList()`, and `Sum()`. 

Up until now I haven't found a way to improve the performance of `Select()` by using SIMD. The returned context allows the use of composition, exposing only the operations that can gain with the use of SIMD.  

## Documentation

Articles explaining implementation:

- [Optimizing LINQ](https://medium.com/@antao.almada/netfabric-hyperlinq-optimizing-linq-348e02566cef)
- [Generation Operations](https://medium.com/@antao.almada/netfabric-hyperlinq-generation-operations-6530826a70ca)
- [Select Operation](https://medium.com/@antao.almada/netfabric-hyperlinq-select-operation-e4ac2bbfb187)
- [Zero Allocation](https://medium.com/@antao.almada/netfabric-hyperlinq-zero-allocation-fe5d0dd6b1a6)

## Supported operations

- Aggregation
  - `Count()`
  - `Sum()`
- Conversion
  - `AsEnumerable()`
  - `AsValueEnumerable()`
  - `ToArray()`
  - `ToList()`
  - `ToDictionary(Func<TSource, TKey>)`
  - `ToDictionary(Func<TSource, TKey>, IEqualityComparer<TKey>)`
  - `ToDictionary(Func<TSource, TKey>, Func<TSource, TElement>)`
  - `ToDictionary(Func<TSource, TKey>, Func<TSource, TElement>, IEqualityComparer<TKey>)`
- Element
  - `ElementAt()`
  - `First()`
  - `Single()`
- Filtering
  - `Where(Func<TSource, bool>)`
  - `Where(Func<TSource, int, bool>)`
- Generation
  - `Create(Func<TEnumerator>)`
  - `Empty()`
  - `Range(int, int)`
  - `Repeat(TSource, int)`
  - `Return(TSource)`
- Projection
  - `Select(Func<TSource, TResult>)`
  - `Select(Func<TSource, int, TResult>)`
  - `SelectMany(IValueEnumerable<TSource>)`
- Partitioning
  - `Take(int)`
  - `Skip(int)`
- Quantifier
  - `All(Func<TSource, bool>)`
  - `All(Func<TSource, int, bool>)`
  - `Any()`
  - `Any(Func<TSource, bool>)`
  - `Any(Func<TSource, int, bool>)`
  - `Contains(TSource)`
  - `Contains(TSource, IEqualityComparer<TSource>)`
- Set
  - `Distinct(TSource)`
  - `Distinct(TSource, IEqualityComparer<TSource>)`

## References

- [Enumeration in .NET](https://blog.usejournal.com/enumeration-in-net-d5674921512e) by Antão Almada
- [Performance of value-type vs reference-type enumerators](https://medium.com/@antao.almada/performance-of-value-type-vs-reference-type-enumerators-820ab1acc291) by Antão Almada
- [Performance Tuning for .NET Core](https://reubenbond.github.io/posts/dotnet-perf-tuning) by Reuben Bond
- [ValueLinqBenchmarks](https://gist.github.com/benaadams/294cbd41ec1179638cb4b5495a15accf) by Ben Adams
- [C# - How method calling works](http://www.levibotelho.com/development/how-method-calling-works/) by Levi Botelho
- [Improving .NET Disruptor performance — Part 2](https://medium.com/@ocoanet/improving-net-disruptor-performance-part-2-5bf456cd595f) by Olivier Coanet
- [Optimizing string.Count all the way from LINQ to hardware accelerated vectorized instructions](https://medium.com/@SergioPedri/optimizing-string-count-all-the-way-from-linq-to-hardware-accelerated-vectorized-instructions-186816010ad9) by Sergio Pedri 
- [Simulating Return Type Inference in C#](https://tyrrrz.me/blog/return-type-inference) by Alexey Golub
- [Pooling large arrays with ArrayPool](https://adamsitnik.com/Array-Pool/) by Adam Sitnik

## Credits

The following open-source projects are used to build and test this project:

- [.NET](https://github.com/dotnet)
- [BenchmarkDotNet](https://benchmarkdotnet.org/)
- [coveralls](https://coveralls.io)
- [coverlet](https://github.com/tonerdo/coverlet)
- [ILRepack](https://github.com/gluck/il-repack)
- [ILRepack.MSBuild.Task](https://github.com/peters/ILRepack.MSBuild.Task)
- [NetFabric.Assertive](https://github.com/NetFabric/NetFabric.Assertive)
- [NetFabric.Hyperlinq.Analyzer](https://github.com/NetFabric/NetFabric.Hyperlinq.Analyzer)
- [Nullable](https://github.com/manuelroemer/Nullable)
- [Source Link](https://github.com/dotnet/sourcelink)
- [xUnit.net](https://xunit.net/)

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more info.
