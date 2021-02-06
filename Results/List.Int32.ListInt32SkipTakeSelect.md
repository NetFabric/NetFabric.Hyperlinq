## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|                     ForLoop | 1000 |   100 |    66.74 ns |  0.537 ns |  0.502 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 3,713.90 ns | 18.775 ns | 16.643 ns | 55.65 |    0.55 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |   100 |   947.61 ns |  6.026 ns |  5.636 ns | 14.20 |    0.17 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   790.91 ns |  2.617 ns |  2.320 ns | 11.85 |    0.10 | 0.6533 |     - |     - |    1368 B |
|                      LinqAF | 1000 |   100 | 5,020.15 ns |  9.231 ns |  8.183 ns | 75.23 |    0.58 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   250.74 ns |  0.630 ns |  0.558 ns |  3.76 |    0.03 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   167.41 ns |  0.508 ns |  0.475 ns |  2.51 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   218.54 ns |  0.821 ns |  0.768 ns |  3.27 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   162.33 ns |  0.471 ns |  0.393 ns |  2.43 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   221.06 ns |  0.651 ns |  0.544 ns |  3.31 |    0.03 |      - |     - |     - |         - |
