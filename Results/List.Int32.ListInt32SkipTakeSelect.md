## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    82.96 ns |  0.857 ns |  0.760 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 4,496.37 ns | 83.505 ns | 69.731 ns | 54.27 |    1.11 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |   100 | 1,024.82 ns |  3.117 ns |  2.915 ns | 12.35 |    0.13 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   779.10 ns |  2.562 ns |  2.139 ns |  9.40 |    0.09 | 0.6533 |     - |     - |    1368 B |
|                      LinqAF | 1000 |   100 | 5,394.41 ns | 15.421 ns | 12.877 ns | 65.10 |    0.59 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   250.77 ns |  0.692 ns |  0.578 ns |  3.03 |    0.03 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   167.23 ns |  0.331 ns |  0.276 ns |  2.02 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   196.52 ns |  0.741 ns |  0.657 ns |  2.37 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   161.79 ns |  0.375 ns |  0.333 ns |  1.95 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   196.10 ns |  0.490 ns |  0.383 ns |  2.37 |    0.02 |      - |     - |     - |         - |
