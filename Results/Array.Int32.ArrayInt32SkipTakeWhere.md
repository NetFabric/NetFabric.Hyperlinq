## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |      **9.160 ns** |  **0.0383 ns** |  **0.0339 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  2,450.600 ns | 13.5904 ns | 12.0475 ns | 267.53 |    1.32 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    234.730 ns |  4.1833 ns |  3.7084 ns |  25.63 |    0.40 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |     72.414 ns |  0.3225 ns |  0.3016 ns |   7.91 |    0.05 | 0.1147 |     - |     - |     240 B |
|               LinqAF | 1000 |    10 |  2,057.617 ns |  8.8713 ns |  8.2982 ns | 224.59 |    1.22 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     85.071 ns |  0.7316 ns |  0.6109 ns |   9.29 |    0.09 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     40.261 ns |  0.1365 ns |  0.1276 ns |   4.40 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     64.320 ns |  0.3928 ns |  0.3482 ns |   7.02 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     59.215 ns |  0.1719 ns |  0.1524 ns |   6.46 |    0.02 |      - |     - |     - |         - |
|                      |      |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |    **957.817 ns** | **11.4188 ns** | **10.1225 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  5,156.425 ns | 27.3061 ns | 25.5422 ns |   5.39 |    0.06 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 16,611.702 ns | 74.7727 ns | 66.2840 ns |  17.34 |    0.16 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 |  4,340.171 ns | 28.1734 ns | 24.9750 ns |   4.53 |    0.06 | 6.7215 |     - |     - |  14,064 B |
|               LinqAF | 1000 |  1000 | 15,541.466 ns | 86.1850 ns | 76.4008 ns |  16.23 |    0.19 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  5,657.485 ns | 52.4941 ns | 46.5347 ns |   5.91 |    0.09 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  1,670.349 ns | 24.5266 ns | 22.9422 ns |   1.75 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  6,745.433 ns | 10.8435 ns |  9.6125 ns |   7.04 |    0.07 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  2,190.835 ns | 33.3972 ns | 31.2398 ns |   2.29 |    0.03 |      - |     - |     - |         - |
