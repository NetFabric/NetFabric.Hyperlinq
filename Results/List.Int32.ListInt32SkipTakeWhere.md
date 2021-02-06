## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    78.48 ns |  0.456 ns |  0.426 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 4,520.80 ns | 24.515 ns | 22.931 ns | 57.61 |    0.45 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 1,259.45 ns |  4.034 ns |  3.576 ns | 16.04 |    0.12 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   856.81 ns |  2.757 ns |  2.444 ns | 10.91 |    0.07 | 0.7458 |     - |     - |    1560 B |
|               LinqAF | 1000 |   100 | 5,648.79 ns | 41.883 ns | 39.177 ns | 71.98 |    0.52 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   310.88 ns |  1.134 ns |  1.005 ns |  3.96 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   171.20 ns |  0.574 ns |  0.537 ns |  2.18 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   244.15 ns |  0.805 ns |  0.714 ns |  3.11 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   185.69 ns |  0.464 ns |  0.434 ns |  2.37 |    0.01 |      - |     - |     - |         - |
