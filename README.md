![GitHub last commit (master)](https://img.shields.io/github/last-commit/NetFabric/NetFabric.Hyperlinq/master.svg?logo=github&logoColor=lightgray&style=popout-square)
[![Build](https://img.shields.io/azure-devops/build/aalmada/3c5b5cb8-c151-4c9f-b98b-6d679b103f3f/3/master.svg?style=popout-square&logo=data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxMiIgaGVpZ2h0PSIxMiI+PGcgZmlsbD0iIzlmOWY5ZiIgZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiPjxwYXRoIGQ9Ik0wIDloMXYyaDJ2MUgwek0uNjY3IDRoMy4wNjhMNi4yMDMuNDQ0QzYuMzkuMTY3IDYuNzAxIDAgNy4wMzUgMEgxMS41YS41LjUgMCAwIDEgLjUuNXY0LjQ2NWExIDEgMCAwIDEtLjQ0NS44MzJMOCA4LjI2NXYzLjA2OGEuNjY3LjY2NyAwIDAgMS0uNjY3LjY2N0g1bC0xLTEgMS4yNS0xLjI1LTEtMUwzIDEwIDIgOWwxLjI1LTEuMjUtMS0xTDEgOCAwIDdWNC42NjdDMCA0LjI5OS4yOTggNCAuNjY3IDR6TTEwLjUgM2ExLjUgMS41IDAgMSAxLTMgMCAxLjUgMS41IDAgMCAxIDMgMHoiLz48L2c+PC9zdmc+)](https://dev.azure.com/aalmada/NetFabric.Hyperlinq/)
[![Unit Tests](https://img.shields.io/azure-devops/tests/aalmada/3c5b5cb8-c151-4c9f-b98b-6d679b103f3f/3/master.svg?style=popout-square&logo=data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxMiIgaGVpZ2h0PSIxMiI+PGcgZmlsbD0iIzlmOWY5ZiIgZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiPjxwYXRoIGQ9Ik0wIDloMXYyaDJ2MUgwek0uNjY3IDRoMy4wNjhMNi4yMDMuNDQ0QzYuMzkuMTY3IDYuNzAxIDAgNy4wMzUgMEgxMS41YS41LjUgMCAwIDEgLjUuNXY0LjQ2NWExIDEgMCAwIDEtLjQ0NS44MzJMOCA4LjI2NXYzLjA2OGEuNjY3LjY2NyAwIDAgMS0uNjY3LjY2N0g1bC0xLTEgMS4yNS0xLjI1LTEtMUwzIDEwIDIgOWwxLjI1LTEuMjUtMS0xTDEgOCAwIDdWNC42NjdDMCA0LjI5OS4yOTggNCAuNjY3IDR6TTEwLjUgM2ExLjUgMS41IDAgMSAxLTMgMCAxLjUgMS41IDAgMCAxIDMgMHoiLz48L2c+PC9zdmc+)](https://dev.azure.com/aalmada/NetFabric.Hyperlinq/)
[![Coverage](https://img.shields.io/azure-devops/coverage/aalmada/3c5b5cb8-c151-4c9f-b98b-6d679b103f3f/3/master.svg?style=popout-square&logo=data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxMiIgaGVpZ2h0PSIxMiI+PGcgZmlsbD0iIzlmOWY5ZiIgZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiPjxwYXRoIGQ9Ik0wIDloMXYyaDJ2MUgwek0uNjY3IDRoMy4wNjhMNi4yMDMuNDQ0QzYuMzkuMTY3IDYuNzAxIDAgNy4wMzUgMEgxMS41YS41LjUgMCAwIDEgLjUuNXY0LjQ2NWExIDEgMCAwIDEtLjQ0NS44MzJMOCA4LjI2NXYzLjA2OGEuNjY3LjY2NyAwIDAgMS0uNjY3LjY2N0g1bC0xLTEgMS4yNS0xLjI1LTEtMUwzIDEwIDIgOWwxLjI1LTEuMjUtMS0xTDEgOCAwIDdWNC42NjdDMCA0LjI5OS4yOTggNCAuNjY3IDR6TTEwLjUgM2ExLjUgMS41IDAgMSAxLTMgMCAxLjUgMS41IDAgMCAxIDMgMHoiLz48L2c+PC9zdmc+)](https://dev.azure.com/aalmada/NetFabric.Hyperlinq/)
[![NuGet Version](https://img.shields.io/nuget/v/NetFabric.Hyperlinq.svg?style=popout-square&logoColor=lightgray&logo=nuget)](https://www.nuget.org/packages/NetFabric.Hyperlinq/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/NetFabric.Hyperlinq.svg?style=popout-square&logoColor=lightgray&logo=nuget)](https://www.nuget.org/packages/NetFabric.Hyperlinq/)


# NetFabric.Hyperlinq

Hyperlinq outperfoms LINQ for collections that implement `IReadOnlyList<T>` (E.g. arrays and `List<T>`) and collections that have value-type enumerators (E.g. collections in the `System.Collections.Generic` namespace). For any other collection, it also outforms LINQ when operation composition is used.

## Usage

1. Add the [**NetFabric.Hyperlinq** NuGet package](https://www.nuget.org/packages/NetFabric.Hyperlinq/) to your project.
1. Optionaly, also add the [**NetFabric.Hyperlinq.Analyzer** NuGet package](https://www.nuget.org/packages/NetFabric.Hyperlinq.Analyzer/) to your project. It's a Roslyn analyzer that suggests performance improvements on your enumeration source code. No dependencies are added to your assemblies.
1. Add a `using NetFabric.Hyperlinq` directive to all source code files where you want Hyperlinq to be used.
1. `NetFabric.Hyperlinq` and `System.Linq` namespaces can co-exist side-by-side. 
   1. `NetFabric.Hyperlinq` implements explicit collection types and higher-order interfaces on the extension methods. These take precedence over the `IEnumerable<T>` extension methods implemented in `System.Linq`.
   1. In the cases where the above doesn't apply, use the `AsValueEnumerable<TSource>()` extension method. `NetFabric.Hyperlinq` implementations will be used for the following operations. For collections that are value-types and/or return enumerators that are value-types, favor the use of the `AsValueEnumerable<TEnumerable, TEnumerator, TSource>()` overload to avoid boxing.
   1. `NetFabric.Hyperlinq` does not implement all `System.Linq` operations. The `System.Linq` implementations will be automatically used. You'll have to use `AsValueEnumerable()` again in the composition chain to return to `NetFabric.Hyperlinq` implementations.


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

Continuous-integration is hosted by [Azure DevOps](https://dev.azure.com/aalmada/NetFabric.Hyperlinq)

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE.txt) file for more info.