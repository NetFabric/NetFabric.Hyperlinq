## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

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
|                     ForLoop | 1000 |   100 |    83.52 ns |  0.211 ns |  0.187 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 4,457.20 ns | 14.751 ns | 12.318 ns | 53.36 |    0.15 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |   100 |   992.22 ns |  3.195 ns |  2.668 ns | 11.88 |    0.04 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   779.27 ns |  3.073 ns |  2.566 ns |  9.33 |    0.02 | 0.6533 |     - |     - |    1368 B |
|                      LinqAF | 1000 |   100 | 5,594.18 ns | 13.987 ns | 13.083 ns | 66.96 |    0.21 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   243.83 ns |  1.088 ns |  1.018 ns |  2.92 |    0.01 | 0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |   100 |   189.08 ns |  0.542 ns |  0.480 ns |  2.26 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   197.24 ns |  0.468 ns |  0.391 ns |  2.36 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   162.47 ns |  0.373 ns |  0.311 ns |  1.95 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   218.00 ns |  0.563 ns |  0.499 ns |  2.61 |    0.01 |      - |     - |     - |         - |
