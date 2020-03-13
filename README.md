![GitHub last commit (master)](https://img.shields.io/github/last-commit/NetFabric/NetFabric.Hyperlinq/master.svg?style=flat-square&logo=github)
[![Build (master)](https://img.shields.io/github/workflow/status/NetFabric/NetFabric.Hyperlinq/.NET%20Core/master.svg?style=flat-square&logo=github)](https://github.com/NetFabric/NetFabric.Hyperlinq/actions)
[![Coverage](https://coveralls.io/repos/github/NetFabric/NetFabric.Hyperlinq/badge.svg?branch=master?style=flat-square&logo=coveralls)](https://dev.azure.com/aalmada/NetFabric.Hyperlinq/)
[![NuGet Version](https://img.shields.io/nuget/v/NetFabric.Hyperlinq.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/NetFabric.Hyperlinq/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/NetFabric.Hyperlinq.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/NetFabric.Hyperlinq/) 
[![Gitter](https://img.shields.io/gitter/room/netfabric/netfabric.hyperlinq?style=flat-square&logo=gitter)](https://gitter.im/NetFabric/NetFabric.Hyperlinq)


# NetFabric.Hyperlinq

*Hyperlinq* outperforms *LINQ* on collections that implement `IReadOnlyList<T>` (E.g. arrays and `List<T>`) and collections that have value-typed enumerators (E.g. collections in the `System.Collections.Generic` and `System.Collections.Immutable` namespaces). For any other collection, it also outperforms *LINQ* when multiple operations are composed.

This implementation favors performance and reduction of heap allocations, in detriment of assembly binary size (lots of overloads).

## Usage

1. Add the *NetFabric.Hyperlinq* [NuGet package](https://www.nuget.org/packages/NetFabric.Hyperlinq/) to your project.
1. Optionally, also add the *NetFabric.Hyperlinq.Analyzer* [NuGet package](https://www.nuget.org/packages/NetFabric.Hyperlinq.Analyzer/) to your project. It's a Roslyn analyzer that suggests performance improvements on your enumeration source code. No dependencies are added to your assemblies.
1. Add an `using NetFabric.Hyperlinq` directive to all source code files where you want to use *NetFabric.Hyperlinq*.
1. Use the `ValueEnumerable` static class for generation operations (E.g. `ValueEnumerable.Empty()`, `ValueEnumerable.Range(...)`, `ValueEnumerable.Repeat(...)`, `ValueEnumerable.Return(...)`, etc.)
1. *NetFabric.Hyperlinq* and *System.Linq* namespaces can co-exist:
   1. *NetFabric.Hyperlinq* uses explicit collection types and higher-order interfaces on its extension methods. These take precedence over the `IEnumerable<T>` extension methods implemented in *System.Linq*.
   1. In the cases where doesn't automatically apply, use the `AsValueEnumerable<TSource>()` extension method. *NetFabric.Hyperlinq* implementations will then be used for the subsequent operations. For collections that are value-types and/or return enumerators that are value-types, favor the use of the `AsValueEnumerable<TEnumerable, TEnumerator, TSource>()` overload to avoid boxing.
   1. *NetFabric.Hyperlinq* does not implement all *System.Linq* operations. In these cases, the `System.Linq` implementations will be automatically used. You'll can use `AsValueEnumerable()` on its result to apply *NetFabric.Hyperlinq* implementations from that point on.

```csharp
using System.Collections.Generic;
using System.Linq;
using NetFabric.Hyperlinq; // add this directive

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var list = ValueEnumerable.Range(0, 10).ToList(); // Hyperlinq operations are used

            var a = list // Hyperlinq operations are used by default on List<>
                .Where(i => i > 0) 
                .Select(i => i * 10);
            
            var b = list // Hyperlinq operations are used by default on List<>
                .Where(i => i > 0) 
                .OrderByDescending(i => i) // Hyperlinq does not yet support this operation so LINQ is used
                .AsValueEnumerable() // Hyperlinq operations are used on subsequent operations
                .Select(i => i * 10);

            var c = MyRange(0, 10) // LINQ operations are used by default on IEnumerable<>
                .AsValueEnumerable() // Hyperlinq operations are used on subsequent operations
                .Where(i => i > 0)
                .Count();
        }

        // 'yield' generates a reference-type enumerable with a reference-type enumerator
        static IEnumerable<int> MyRange(int start, int count)
        {
            var end = start + count;
            for (var value = start; value < end; value++)
                yield return value;
        }
    }
}
```

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
  - `TryElementAt()`
  - `ElementAt()`
  - `ElementAtOrDefault()`
  - `First()`
  - `FirstOrDefault()`
  - `Single()`
  - `SingleOrDefault()`
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
- Other
  - `ForEach(Action<TSource>)`
  - `ForEach(ActionAt<TSource>)`

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
