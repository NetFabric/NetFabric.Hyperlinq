## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |          Mean |       Error |        StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |--------------:|------------:|--------------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |      **9.934 ns** |   **0.2823 ns** |     **0.4225 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  7,991.649 ns | 159.0686 ns |   321.3265 ns | 811.74 |   50.66 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |    10 |    289.796 ns |   5.1366 ns |     5.7093 ns |  29.08 |    1.36 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |    142.979 ns |   0.8525 ns |     0.7557 ns |  14.45 |    0.72 | 0.1528 |     - |     - |     320 B |
|               LinqAF | 1000 |    10 |  4,700.029 ns |  34.2924 ns |    28.6357 ns | 475.92 |   23.59 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     88.917 ns |   0.3668 ns |     0.3251 ns |   8.99 |    0.44 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     39.191 ns |   0.0674 ns |     0.0630 ns |   3.96 |    0.19 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     56.101 ns |   0.6585 ns |     0.6159 ns |   5.66 |    0.29 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     36.435 ns |   0.1298 ns |     0.1150 ns |   3.68 |    0.19 |      - |     - |     - |         - |
|                      |      |       |               |             |               |        |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |    **891.585 ns** |   **4.5422 ns** |     **4.2488 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 | 15,269.304 ns | 293.5446 ns |   391.8735 ns |  17.09 |    0.48 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |  1000 | 32,122.742 ns | 635.7693 ns | 1,629.7197 ns |  36.29 |    1.50 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 | 11,122.762 ns | 109.3142 ns |    91.2823 ns |  12.49 |    0.11 | 5.9204 |     - |     - |   12416 B |
|               LinqAF | 1000 |  1000 | 28,541.420 ns | 423.6059 ns |   396.2413 ns |  32.01 |    0.53 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  4,387.538 ns |  21.0168 ns |    19.6592 ns |   4.92 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  1,771.786 ns |  12.8321 ns |    11.3753 ns |   1.99 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  4,951.622 ns |  21.8600 ns |    19.3783 ns |   5.56 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  5,509.413 ns |  13.2007 ns |    11.7021 ns |   6.18 |    0.03 |      - |     - |     - |         - |
