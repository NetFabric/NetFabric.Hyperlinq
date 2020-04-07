![GitHub last commit (master)](https://img.shields.io/github/last-commit/NetFabric/NetFabric.Hyperlinq/master.svg?style=flat-square&logo=github)
[![Build (master)](https://img.shields.io/github/workflow/status/NetFabric/NetFabric.Hyperlinq/.NET%20Core/master.svg?style=flat-square&logo=github)](https://github.com/NetFabric/NetFabric.Hyperlinq/actions)
[![Coverage](https://img.shields.io/coveralls/github/NetFabric/NetFabric.Hyperlinq/master?style=flat-square&logo=coveralls)](https://coveralls.io/github/NetFabric/NetFabric.Hyperlinq)
[![NuGet Version](https://img.shields.io/nuget/v/NetFabric.Hyperlinq.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/NetFabric.Hyperlinq/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/NetFabric.Hyperlinq.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/NetFabric.Hyperlinq/) 
[![Gitter](https://img.shields.io/gitter/room/netfabric/netfabric.hyperlinq?style=flat-square&logo=gitter)](https://gitter.im/NetFabric/NetFabric.Hyperlinq)


# NetFabric.Hyperlinq

Hyperlinq** is an alternative implementation of several operations found in both the `System.Linq` and `System.Linq.Async` namespaces:

- Uses value-types to improve performance by making method calls non-virtual and reducing GC collections by not allocating on the heap. 

- Adds support for `Span<>` and `Memory<>`.

This implementation **favors performance in detriment of assembly binary size** (lots of overloads).

## Contents

- [Usage](#usage)
  - [BCL Collections](#bcl-collections)
  - [AsValueEnumerable and AsAsyncValueEnumerable](#asvalueenumerable-and-asasyncvalueenumerable)
  - [Method return types](#method-return-types)
  - [Composition](#composition)
  - [Option](#option)
- [Documentation](#documentation)
- [Supported operations](#supported-operations)
- [Benchmarks](#benchmarks)
- [References](#references)
- [Credits](#credits)
- [License](#license)

## Usage

1. Add the [*NetFabric.Hyperlinq* NuGet package](https://www.nuget.org/packages/NetFabric.Hyperlinq/) to your project.
1. Optionally, also add the [*NetFabric.Hyperlinq.Analyzer* NuGet package](https://www.nuget.org/packages/NetFabric.Hyperlinq.Analyzer/) to your project. It's a Roslyn analyzer that suggests performance improvements on your enumeration source code. No dependencies are added to your assemblies.
1. Add an `using NetFabric.Hyperlinq` directive to all source code files where you want to use *NetFabric.Hyperlinq*. It can coexist with `System.Linq` and `System.Linq.Async` directives:

``` csharp
using System;
using System.Linq;
using System.Linq.Async;
using NetFabric.Hyperlinq; // add this directive
```

### BCL Collections

*NetFabric.Hyperlinq* includes bindings for collections available in the namespaces; `System`, `System.Collections.Generic` and `System.Collections.Immutable`. This includes:

- arrays
- `Span<>`, `ReadOnlySpan<>`, `Memory<>` and `ReadOnlyMemory<>`
- `List<>`, `Dictionary<>`, `Stack<>`, ...
- `ImmutableArray<>`, `ImmutableList<>`, `ImmutableStack<>`, ...

For all these collections, once the directive is added, *NetFabric.Hyperlinq* will used automatically.

``` csharp
public static void Example(ReadOnlySpan<int> span)
{
  var result = span
    .Where(item => item > 2)
    .Select(item => item * 2);

  foreach(var value in result)
    Console.WriteLine(value);
}
```

### AsValueEnumerable and AsAsyncValueEnumerable

*NetFabric.Hyperlinq* implements operations (extension methods) for the interfaces:

- `IValueEnumerable<,>`
- `IValueReadOnlyCollection<,>`
- `IValueReadOnlyList<,>`
- `IAsyncValueEnumerable<,>`

If the collection does not implement any of these, you have to use the conversion methods `AsValueEnumerable()` or `AsAsyncValueEnumerable()` to use the *NetFabric.Hyperlinq* operations. (Except for the BCL collections where specific bindings are provided.)

In the following example, `AsValueEnumerable()` converts `IReadOnlyList<>` to `IValueReadOnlyList<>`. The subsequent operations used are the ones implemented in *NetFabric.Hyperlinq* (if available):

``` csharp
public static void Example(IReadOnlyList<int> list)
{
  var result = list
    .AsValueEnumerable()
    .Where(item => item > 2)
    .Select(item => item * 2);

  foreach(var value in result)
  {
    Console.WriteLine(value);
  }
}
```

The conversion methods can also be applied to the output of *LINQ* operators. This is useful when you use operations not available in *NetFabric.Hyperlinq* or that do not return a value enumeration interfaces.

``` csharp
public static void Example(IReadOnlyList<int> list)
{
  var result = list
    .AsValueEnumerable()
    .Where(item => item > 2)
    .OrderByDescending(item => item) // does not return a value enumeration interfaces
    .AsValueEnumerable()
    .Select(item => item * 2);

  foreach(var value in result)
    Console.WriteLine(value);
}
```

All value enumeration interfaces derive from `IEnumerable<>` or `IAsyncEnumerable` so, as you can see in the previous example, they can be used as the input of *LINQ* operations or of any other third-party library.

### Generation operations

In *NetFabric.Hyperlinq*, the generation operations like `Empty()`, `Range()`, `Repeat()` and `Return()` are static methods implemented in the static class `ValueEnumerable`. To use these, instead of the ones from *LINQ*, simply replace `Enumerable` for `ValueEnumerable`.

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

This allows the caller to use *LINQ* or a `foreach` loop to pull and process the result. *NetFabric.Hyperlinq* can also be used but the `AsValueEnumerable()` conversion method has to be used.

The operation in *NetFabric.Hyperlinq* are implemented so that they return the highest level enumeration interface possible. For example, the `Range()` operation returns `IValueReadOnlyList<,>` and the subsequent `Select()` does not change this. `IValueReadOnlyList<,>` derives from `IReadOnlyList<>` so, we can change the method to return this interface:

``` csharp
public static IReadOnlyList<int> Example(int count)
  => ValueEnumerable
    .Range(0, count)
    .Select(value => value * 2);
```

Now, the caller is free to use the enumerator or the indexer, which are provided by this interface. This means that, all previous methods of iteration can be used plus the `for` loops, which are much more efficient. The indexer performs fewer internal operations and doesn't need an enumerator instance. *NetFabric.Hyperlinq* can also be used and the `AsValueEnumerable()` conversion method still has to be used but, *NetFabric.Hyperlinq* will now use the indexer.

Otherwise, *NetFabric.Hyperlinq* will use enumerators. It implements all enumerators as value types. This allows the enumerators not to be allocated on the heap and calls to its methods to be non-virtual. The `IEnumerable<>` interface, and all other derived BCL interfaces, convert the enumerator to the `IEnumerator<>` interface. This results in the enumerator to be boxed, undoing the mentioned benefits.

*NetFabric.Hyperlinq* defines value enumerable interfaces that contain the enumerator type as a generic parameter. This allows the caller to use it without boxing. Consider changing the method to return one of these interfaces:

``` csharp
public static IValueReadOnlyList<int, ReadOnlyList.SelectEnumerable<ValueEnumerable.RangeEnumerable, int, int>.DisposableEnumerator> Example(int count)
  => ValueEnumerable
    .Range(0, count)
    .Select(value => value * 2);
```

The caller is now able to use *NetFabric.Hyperlinq* without requiring the `AsValueEnumerable()` conversion method. In this case, it will use the indexer in all subsequent operations but the enumerator is still available. In other cases (`IValueEnumerable<,>`, `IValueReadOnlyCollection<,>` and `IAsyncValueEnumerable<,>`) it will use the enumerator.

Finding the correct generic types is hard but the *NetFabric.Hyperlinq.Analyzer* can help you. It will inform you when the type can be changed and to what types.

*NetFabric.Hyperlinq* also implements the enumerables as value types. Returning an interface means that the enumerable will still be boxed. If you want to also avoid this, consider changing the return type to be the actual enumerable type. In this case:

``` csharp
public static ReadOnlyList.SelectEnumerable<ValueEnumerable.RangeEnumerable, int, int> Example(int count)
  => ValueEnumerable
    .Range(0, count)
    .Select(value => value * 2);
```

The *NetFabric.Hyperlinq.Analyzer* can also help you here.

**NOTE:** Returning the enumerable type or a value enumeration interface, allows major performance improvements but creates a library design issue. Changes in the method implementation may result in changes to the retun type. This is a breaking change. This is an issue on the public API but not so much for the private and internal methods. Take this into consideration when deciding on the return type.

### Composition

*NetFabric.Hyperlinq* operations can be composed just like with *LINQ*. The difference is on how each one optimizes the internals to reduce the number of enumerators required to iterate the values.

Both *LINQ* and *NetFabric.Hyperlinq* optimize the code in the following example so that only one enumerator is used to perform both the `Where()` and the `Select()`:

``` csharp
var result = source.Where(item => item > 2).Select(item => item * 2);
```

But, *LINQ* does not do the same for this other example:

``` csharp
var result = source.Where(item => item > 2).First();
```

*LINQ* has a second overload for methods, like `First()` and `Single()`, that take the predicate as a parameter and allow the `Where()` to be removed. In *NetFabric.Hyperlinq* this is not required. It optimizes internally the code to have the same behavior. With the intention of reducing the code to be mantained and tested, these other overloads actually are not available.

*NetFabric.Hyperlinq* includes many more composition optimizations. In the following code, only one enumerator is used, and only because of the `Where()` operation. Otherwise, the indexer would have been used instead. The `Select()` is applied after `First()`, so that it's applied to only one of the items:

``` csharp
var result = array.Skip(1).Take(10).Where(item => item > 2).Select(item => item * 2).First();
```

### Option

## Documentation

- [Optimizing LINQ](https://medium.com/@antao.almada/netfabric-hyperlinq-optimizing-linq-348e02566cef)
- [Generation Operations](https://medium.com/@antao.almada/netfabric-hyperlinq-generation-operations-6530826a70ca)
- [Select Operation](https://medium.com/@antao.almada/netfabric-hyperlinq-select-operation-e4ac2bbfb187)
- [Zero Allocation](https://medium.com/@antao.almada/netfabric-hyperlinq-zero-allocation-fe5d0dd6b1a6)

## Supported operations

- Aggregation
  - `Count()`
- Conversion
  - `AsEnumerable()`
  - `AsValueEnumerable()`
  - `ToArray()`
  - `ToList()`
  - `ToDictionary(Selector<TSource, TKey>)`
  - `ToDictionary(Selector<TSource, TKey>, IEqualityComparer<TKey>)`
  - `ToDictionary(Selector<TSource, TKey>, Selector<TSource, TElement>)`
  - `ToDictionary(Selector<TSource, TKey>, Selector<TSource, TElement>, IEqualityComparer<TKey>)`
- Element
  - `ElementAt()`
  - `First()`
  - `Single()`
- Filtering
  - `Where(Predicate<TSource>)`
  - `Where(PredicateAt<TSource>)`
- Generation
  - `Create(Func<TEnumerator>)`
  - `Empty()`
  - `Range(int, int)`
  - `Repeat(TSource, int)`
  - `Return(TSource)`
- Projection
  - `Select(Selector<TSource, TResult>)`
  - `Select(SelectorAt<TSource, TResult>)`
  - `SelectMany(IValueEnumerable<TSource>)`
- Partitioning
  - `Take(int)`
  - `Skip(int)`
- Quantifier
  - `All(Predicate<TSource>)`
  - `All(PredicateAt<TSource>)`
  - `Any()`
  - `Any(Predicate<TSource>)`
  - `Any(PredicateAt<TSource>)`
  - `Contains(TSource)`
  - `Contains(TSource, IEqualityComparer<TSource>)`
- Set
  - `Distinct(TSource)`
  - `Distinct(TSource, IEqualityComparer<TSource>)`

## Benchmarks

The repository contains a [benchmarks project](https://github.com/NetFabric/NetFabric.Hyperlinq/tree/master/NetFabric.Hyperlinq.Benchmarks) based on [BenchmarkDotNet](https://benchmarkdotnet.org) that compares `NetFabric.Hyperlinq` to `System.Linq` for many of the supported operations and its combinations.

## References

- [Enumeration in .NET](https://blog.usejournal.com/enumeration-in-net-d5674921512e) by Antão Almada
- [Performance of value-type vs reference-type enumerators](https://medium.com/@antao.almada/performance-of-value-type-vs-reference-type-enumerators-820ab1acc291) by Antão Almada
- [Performance Tuning for .NET Core](https://reubenbond.github.io/posts/dotnet-perf-tuning) by Reuben Bond
- [ValueLinqBenchmarks](https://gist.github.com/benaadams/294cbd41ec1179638cb4b5495a15accf) by Ben Adams
- [C# - How method calling works](http://www.levibotelho.com/development/how-method-calling-works/) by Levi Botelho
- [Improving .NET Disruptor performance — Part 2](https://medium.com/@ocoanet/improving-net-disruptor-performance-part-2-5bf456cd595f) by Olivier Coanet
- [Optimizing string.Count all the way from LINQ to hardware accelerated vectorized instructions](https://medium.com/@SergioPedri/optimizing-string-count-all-the-way-from-linq-to-hardware-accelerated-vectorized-instructions-186816010ad9) by Sergio Pedri 
- [Simulating Return Type Inference in C#](https://tyrrrz.me/blog/return-type-inference) by Alexey Golub

## Credits

The following open-source projects are used to build and test this project:

- [.NET](https://github.com/dotnet)
- [BenchmarkDotNet](https://benchmarkdotnet.org/)
- [coveralls](https://coveralls.io)
- [coverlet](https://github.com/tonerdo/coverlet)
- [NetFabric.Assertive](https://github.com/NetFabric/NetFabric.Assertive)
- [Nullable](https://github.com/manuelroemer/Nullable)
- [Source Link](https://github.com/dotnet/sourcelink)
- [Uno.SourceGeneration](https://github.com/unoplatform/Uno.SourceGeneration)
- [xUnit.net](https://xunit.net/)

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more info.
