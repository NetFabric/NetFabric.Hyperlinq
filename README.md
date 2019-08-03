![GitHub last commit (master)](https://img.shields.io/github/last-commit/NetFabric/NetFabric.Hyperlinq/master.svg?logo=github&logoColor=lightgray&style=popout-square)
[![Build](https://img.shields.io/azure-devops/build/aalmada/3c5b5cb8-c151-4c9f-b98b-6d679b103f3f/3/master.svg?style=popout-square&logo=data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxMiIgaGVpZ2h0PSIxMiI+PGcgZmlsbD0iIzlmOWY5ZiIgZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiPjxwYXRoIGQ9Ik0wIDloMXYyaDJ2MUgwek0uNjY3IDRoMy4wNjhMNi4yMDMuNDQ0QzYuMzkuMTY3IDYuNzAxIDAgNy4wMzUgMEgxMS41YS41LjUgMCAwIDEgLjUuNXY0LjQ2NWExIDEgMCAwIDEtLjQ0NS44MzJMOCA4LjI2NXYzLjA2OGEuNjY3LjY2NyAwIDAgMS0uNjY3LjY2N0g1bC0xLTEgMS4yNS0xLjI1LTEtMUwzIDEwIDIgOWwxLjI1LTEuMjUtMS0xTDEgOCAwIDdWNC42NjdDMCA0LjI5OS4yOTggNCAuNjY3IDR6TTEwLjUgM2ExLjUgMS41IDAgMSAxLTMgMCAxLjUgMS41IDAgMCAxIDMgMHoiLz48L2c+PC9zdmc+)](https://dev.azure.com/aalmada/NetFabric.Hyperlinq/)
[![Unit Tests](https://img.shields.io/azure-devops/tests/aalmada/3c5b5cb8-c151-4c9f-b98b-6d679b103f3f/3/master.svg?style=popout-square&logo=data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxMiIgaGVpZ2h0PSIxMiI+PGcgZmlsbD0iIzlmOWY5ZiIgZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiPjxwYXRoIGQ9Ik0wIDloMXYyaDJ2MUgwek0uNjY3IDRoMy4wNjhMNi4yMDMuNDQ0QzYuMzkuMTY3IDYuNzAxIDAgNy4wMzUgMEgxMS41YS41LjUgMCAwIDEgLjUuNXY0LjQ2NWExIDEgMCAwIDEtLjQ0NS44MzJMOCA4LjI2NXYzLjA2OGEuNjY3LjY2NyAwIDAgMS0uNjY3LjY2N0g1bC0xLTEgMS4yNS0xLjI1LTEtMUwzIDEwIDIgOWwxLjI1LTEuMjUtMS0xTDEgOCAwIDdWNC42NjdDMCA0LjI5OS4yOTggNCAuNjY3IDR6TTEwLjUgM2ExLjUgMS41IDAgMSAxLTMgMCAxLjUgMS41IDAgMCAxIDMgMHoiLz48L2c+PC9zdmc+)](https://dev.azure.com/aalmada/NetFabric.Hyperlinq/)
[![Coverage](https://img.shields.io/azure-devops/coverage/aalmada/3c5b5cb8-c151-4c9f-b98b-6d679b103f3f/3/master.svg?style=popout-square&logo=data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxMiIgaGVpZ2h0PSIxMiI+PGcgZmlsbD0iIzlmOWY5ZiIgZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiPjxwYXRoIGQ9Ik0wIDloMXYyaDJ2MUgwek0uNjY3IDRoMy4wNjhMNi4yMDMuNDQ0QzYuMzkuMTY3IDYuNzAxIDAgNy4wMzUgMEgxMS41YS41LjUgMCAwIDEgLjUuNXY0LjQ2NWExIDEgMCAwIDEtLjQ0NS44MzJMOCA4LjI2NXYzLjA2OGEuNjY3LjY2NyAwIDAgMS0uNjY3LjY2N0g1bC0xLTEgMS4yNS0xLjI1LTEtMUwzIDEwIDIgOWwxLjI1LTEuMjUtMS0xTDEgOCAwIDdWNC42NjdDMCA0LjI5OS4yOTggNCAuNjY3IDR6TTEwLjUgM2ExLjUgMS41IDAgMSAxLTMgMCAxLjUgMS41IDAgMCAxIDMgMHoiLz48L2c+PC9zdmc+)](https://dev.azure.com/aalmada/NetFabric.Hyperlinq/)
[![NuGet Version](https://img.shields.io/nuget/v/NetFabric.Hyperlinq.svg?style=popout-square&logoColor=lightgray&logo=nuget)](https://www.nuget.org/packages/NetFabric.Hyperlinq/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/NetFabric.Hyperlinq.svg?style=popout-square&logoColor=lightgray&logo=nuget)](https://www.nuget.org/packages/NetFabric.Hyperlinq/)


# NetFabric.Hyperlinq

*Hyperlinq* outperfoms *LINQ* when enumerating collections that implement `IReadOnlyList<T>` (E.g. arrays and `List<T>`) and collections that have value-type enumerators (E.g. collections in the `System.Collections.Generic` namespace). For any other collection, it also outforms *LINQ* when multiple operations are composed.

This implementation favors performance and reduction of heap allocations, in detriment of binary size.

No dynamic code generation is used so it's ahead-of-time (AOT) compatible.

## Usage (3.0 and above)

1. Add the *NetFabric.Hyperlinq* [NuGet package](https://www.nuget.org/packages/NetFabric.Hyperlinq/) to your project.
1. Optionally, also add the *NetFabric.Hyperlinq.Analyzer* [NuGet package](https://www.nuget.org/packages/NetFabric.Hyperlinq.Analyzer/) to your project. It's a Roslyn analyzer that suggests performance improvements on your enumeration source code. No dependencies are added to your assemblies.
1. Add a `using NetFabric.Hyperlinq` directive to all source code files where you want to use *NetFabric.Hyperlinq*.
1. Use `ValueEnumerable` static class for generation operations (E.g. `ValueEnumerable.Empty()`, `ValueEnumerable.Range(...)`, `ValueEnumerable.Repeat(...)`, etc.)
1. *NetFabric.Hyperlinq* and *System.Linq* namespaces can co-exist: 
   1. *NetFabric.Hyperlinq* uses explicit collection types and higher-order interfaces on its extension methods. These take precedence over the `IEnumerable<T>` extension methods implemented in *System.Linq*.
   1. In the cases where the above doesn't apply, use the `AsValueEnumerable<TSource>()` extension method. *NetFabric.Hyperlinq* implementations will be used for the subsequent operations. For collections that are value-types and/or return enumerators that are value-types, favor the use of the `AsValueEnumerable<TEnumerable, TEnumerator, TSource>()` overload to avoid boxing.
   1. *NetFabric.Hyperlinq* does not implement all *System.Linq* operations. The `System.Linq` implementations will be automatically used. You'll have to use `AsValueEnumerable()` in the composition chain to return to *NetFabric.Hyperlinq* implementations.

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

## Supported operations:

- Aggregation
  - `Count()`
  - `Count(Func<TSource, bool>)`
  - `Count(Func<TSource, int, bool>)`
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
  - `TryFirst()`
  - `TryFirst(Func<TSource, bool>)`
  - `TryFirst(Func<TSource, int, bool>)`
  - `First()`
  - `First(Func<TSource, bool>)`
  - `First(Func<TSource, int, bool>)`
  - `FirstOrDefault()`
  - `FirstOrDefault(Func<TSource, bool>)`
  - `FirstOrDefault(Func<TSource, int, bool>)`
  - `TrySingle()`
  - `TrySingle(Func<TSource, bool>)`
  - `TrySingle(Func<TSource, int, bool>)`
  - `Single()`
  - `Single(Func<TSource, bool>)`
  - `Single(Func<TSource, int, bool>)`
  - `SingleOrDefault()`
  - `SingleOrDefault(Func<TSource, bool>)`
  - `SingleOrDefault(Func<TSource, int, bool>)`
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

## Benchmarks

The repository contains a [benchmarks project](https://github.com/NetFabric/NetFabric.Hyperlinq/tree/master/NetFabric.Hyperlinq.Benchmarks) based on [BenchmarkDotNet](https://benchmarkdotnet.org) that compares `NetFabric.Hyperlinq` to `System.Linq` for many of the supported operations and its combinations.

For the latest benchmarks, visit our [wiki](https://github.com/NetFabric/NetFabric.Hyperlinq/wiki).

Feel free to clone the repository and run the benchmarks on your machine. Feedback and contributions are welcome!

## References

- [Enumeration in .NET](https://blog.usejournal.com/enumeration-in-net-d5674921512e) by Antão Almada
- [Performance of value-type vs reference-type enumerators](https://medium.com/@antao.almada/performance-of-value-type-vs-reference-type-enumerators-820ab1acc291) by Antão Almada
- [Performance Tuning for .NET Core](https://reubenbond.github.io/posts/dotnet-perf-tuning) by Reuben Bond
- [ValueLinqBenchmarks](https://gist.github.com/benaadams/294cbd41ec1179638cb4b5495a15accf) by Ben Adams
- [C# - How method calling works](http://www.levibotelho.com/development/how-method-calling-works/) by Levi Botelho
- [Improving .NET Disruptor performance — Part 2](https://medium.com/@ocoanet/improving-net-disruptor-performance-part-2-5bf456cd595f) by Olivier Coanet

## Credits

The following open-source projects are used to build and test this project:

- [.NET](https://github.com/dotnet)
- [BenchmarkDotNet](https://benchmarkdotnet.org/)
- [coverlet](https://github.com/tonerdo/coverlet)
- [dnSpy](https://github.com/0xd4d/dnSpy)
- [Fluent Assertions](https://fluentassertions.com/)
- [Fody](https://github.com/Fody/Home)
- [Mono.Cecil](https://www.mono-project.com/docs/tools+libraries/libraries/Mono.Cecil/)
- [xUnit.net](https://xunit.net/)

Continuous-integration is hosted by [Azure DevOps](https://dev.azure.com/aalmada/NetFabric.Hyperlinq).

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE.txt) file for more info.