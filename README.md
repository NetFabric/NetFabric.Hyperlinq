# NetFabric.Hyperlinq

**This is work in progress!...**

This repository contains the results of my exploration on how LINQ performance can be improved by using modern C# features like constrained interfaces, readonly struct, refs, value tuples and so on.

## Supported operations:

- Aggregation
  - `Count()`
  - `Count(Func<TSource, bool>)`
- Conversion
  - `AsEnumerable()`
  - `AsReadOnlyCollection()`
  - `AsReadOnlyList()`
  - `ToArray()`
  - `ToList()`
- Element
  - `First()`
  - `First(Func<TSource, bool>)`
  - `FirstOrDefault()`
  - `FirstOrDefault(Func<TSource, bool>)`
  - `Single()`
  - `Single(Func<TSource, bool>)`
  - `SingleOrDefault()`
  - `SingleOrDefault(Func<TSource, bool>)`
- Filtering
  - `Where(Func<TSource, bool>)`
- Generation
  - `Create(Func<TEnumerator>)`
  - `Empty()`
  - `Range(int, int)`
  - `Repeat(TSource)`
  - `Repeat(TSource, int)`
  - `Return(TSource)`
- Projection
  - `Select(Func<TSource, TResult>)`

## Benchmarks

The solution contains a [benchmarks project](https://github.com/NetFabric/NetFabric.Hyperlinq/tree/master/NetFabric.Hyperlinq.Benchmarks) based on [BenchmarkDotNet](https://benchmarkdotnet.org) that compares `NetFabric.Hyperlinq` to `System.Linq` for many of the supported operations.

To get the latests benchmarks, clone the project and run it on your machine.

# NetFabric.Hyperlinq.Analyzer

The solution contains a [project for a Roslyn Analyzer](https://github.com/NetFabric/NetFabric.Hyperlinq/tree/master/NetFabric.Hyperlinq.Analyzer) that contains several enumeration related rules to help users improve performance.

The analyzer is independent of NetFabric.Hyperlinq. The rules are useful even if you only use `IEnumerable<T>` or `System.Linq`.

Check the documentation for the implemented rules at https://github.com/NetFabric/NetFabric.Hyperlinq/tree/master/NetFabric.Hyperlinq.Analyzer/docs/reference

# References

- [Enumeration in .NET](https://blog.usejournal.com/enumeration-in-net-d5674921512e)
- [Performance of value-type vs reference-type enumerators](https://medium.com/@antao.almada/performance-of-value-type-vs-reference-type-enumerators-820ab1acc291)
- [NetFabric.Hyperlinq — Optimizing LINQ](https://medium.com/@antao.almada/netfabric-hyperlinq-optimizing-linq-348e02566cef)
- [NetFabric.Hyperlinq — Generation Operations](https://medium.com/@antao.almada/netfabric-hyperlinq-generation-operations-6530826a70ca)
- [NetFabric.Hyperlinq — Select Operation](https://medium.com/@antao.almada/netfabric-hyperlinq-select-operation-e4ac2bbfb187)
- [Performance Tuning for .NET Core](https://reubenbond.github.io/posts/dotnet-perf-tuning)
- [benaadams/ValueLinqBenchmarks.cs](https://gist.github.com/benaadams/294cbd41ec1179638cb4b5495a15accf)

