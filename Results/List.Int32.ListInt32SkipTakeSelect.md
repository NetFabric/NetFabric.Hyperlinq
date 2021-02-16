## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    83.59 ns |  0.286 ns |  0.254 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 4,413.80 ns | 22.512 ns | 19.957 ns | 52.80 |    0.27 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |   100 |   950.79 ns |  3.747 ns |  3.505 ns | 11.37 |    0.06 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   794.80 ns |  2.622 ns |  2.190 ns |  9.50 |    0.04 | 0.6533 |     - |     - |    1368 B |
|                      LinqAF | 1000 |   100 | 5,067.15 ns | 37.107 ns | 32.894 ns | 60.62 |    0.45 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   265.06 ns |  0.731 ns |  0.610 ns |  3.17 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   166.59 ns |  0.220 ns |  0.172 ns |  1.99 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   207.92 ns |  0.632 ns |  0.591 ns |  2.49 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   169.81 ns |  0.519 ns |  0.460 ns |  2.03 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   221.71 ns |  0.877 ns |  0.777 ns |  2.65 |    0.01 |      - |     - |     - |         - |
