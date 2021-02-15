## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    78.89 ns |  1.379 ns |  1.290 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 5,340.72 ns | 78.602 ns | 69.679 ns |  67.70 |    1.15 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,825.19 ns | 15.261 ns | 14.275 ns |  23.14 |    0.46 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   990.04 ns |  9.232 ns |  8.635 ns |  12.55 |    0.22 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 9,320.81 ns | 82.086 ns | 72.767 ns | 118.16 |    1.97 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   404.15 ns |  6.363 ns |  5.952 ns |   5.12 |    0.09 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   192.31 ns |  1.525 ns |  1.352 ns |   2.44 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   350.02 ns |  5.056 ns |  4.729 ns |   4.44 |    0.08 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   187.91 ns |  1.692 ns |  1.582 ns |   2.38 |    0.04 |      - |     - |     - |         - |
