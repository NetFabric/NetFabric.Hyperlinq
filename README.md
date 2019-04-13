![GitHub last commit (master)](https://img.shields.io/github/last-commit/NetFabric/NetFabric.Hyperlinq/master.svg?logo=github&logoColor=lightgray&style=popout-square)
[![NuGet Version](https://img.shields.io/nuget/v/NetFabric.Hyperlinq.svg?style=popout-square&logoColor=lightgray&logo=nuget)](https://www.nuget.org/packages/NetFabric.Hyperlinq/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/NetFabric.Hyperlinq.svg?style=popout-square&logoColor=lightgray&logo=nuget)](https://www.nuget.org/packages/NetFabric.Hyperlinq/)

# NetFabric.Hyperlinq

This is a re-implementation of LINQ with improved performance, mainly by not boxing value-type enumerators and by using overloads for the [`IReadOnlyCollection<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection-1) and [`IReadOnlyList<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1) interfaces.

## Documentation

- [Optimizing LINQ](https://medium.com/@antao.almada/netfabric-hyperlinq-optimizing-linq-348e02566cef)
- [Generation Operations](https://medium.com/@antao.almada/netfabric-hyperlinq-generation-operations-6530826a70ca)
- [Select Operation](https://medium.com/@antao.almada/netfabric-hyperlinq-select-operation-e4ac2bbfb187)
- [Zero Allocation](https://medium.com/@antao.almada/netfabric-hyperlinq-zero-allocation-fe5d0dd6b1a6)

## Supported operations:

- Aggregation
  - `Count()`
  - `Count(Func<TSource, bool>)`
- Conversion
  - `AsEnumerable()`
  - `AsValueEnumerable()`
  - `ToArray()`
  - `ToList()`
- Element
  - `First()`
  - `First(Func<TSource, bool>)`
  - `FirstOrDefault()`
  - `FirstOrDefault(Func<TSource, bool>)`
  - `FirstOrNull() where TSource : struct`
  - `FirstOrNull(Func<TSource, bool>) where TSource : struct`
  - `Single()`
  - `Single(Func<TSource, bool>)`
  - `SingleOrDefault()`
  - `SingleOrDefault(Func<TSource, bool>)`
  - `SingleOrNull() where TSource : struct`
  - `SingleOrNull(Func<TSource, bool>) where TSource : struct` 
- Filtering
  - `Where(Func<TSource, bool>)`
- Generation
  - `Create(Func<TEnumerator>)`
  - `Empty()`
  - `Range(int, int)`
  - `Repeat(TSource, int)`
  - `Return(TSource)`
- Quantifier
  - `All(Func<TSource, bool>)`
  - `Any()`
  - `Any(Func<TSource, bool>)`
  - `Contains(TSource)`
  - `Contains(TSource, IEqualityComparer<TSource>)`
- Projection
  - `Select(Func<TSource, TResult>)`

## Benchmarks

The repository contains a [benchmarks project](https://github.com/NetFabric/NetFabric.Hyperlinq/tree/master/NetFabric.Hyperlinq.Benchmarks) based on [BenchmarkDotNet](https://benchmarkdotnet.org) that compares `NetFabric.Hyperlinq` to `System.Linq` for many of the supported operations and its combinations.

For the latest benchmarks, visit our [wiki](https://github.com/NetFabric/NetFabric.Hyperlinq/wiki).

Feel free to clone the repository and run the benchmarks on your machine. Feedback and contributions are welcome!

# References

- [Enumeration in .NET](https://blog.usejournal.com/enumeration-in-net-d5674921512e) by Antão Almada
- [Performance of value-type vs reference-type enumerators](https://medium.com/@antao.almada/performance-of-value-type-vs-reference-type-enumerators-820ab1acc291) by Antão Almada
- [Performance Tuning for .NET Core](https://reubenbond.github.io/posts/dotnet-perf-tuning) by Reuben Bond
- [ValueLinqBenchmarks](https://gist.github.com/benaadams/294cbd41ec1179638cb4b5495a15accf) by Ben Adams
- [C# - How method calling works](http://www.levibotelho.com/development/how-method-calling-works/) by Levi Botelho