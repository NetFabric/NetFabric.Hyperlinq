## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |         Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **11.17 ns** |  **0.033 ns** |  **0.028 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  4,203.55 ns | 17.954 ns | 15.916 ns | 376.20 |    1.47 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |    10 |    199.05 ns |  0.506 ns |  0.423 ns |  17.82 |    0.04 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |    122.99 ns |  0.683 ns |  0.570 ns |  11.01 |    0.05 | 0.1528 |     - |     - |     320 B |
|               LinqAF | 1000 |    10 |  4,835.18 ns | 25.858 ns | 22.922 ns | 432.53 |    1.94 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     78.29 ns |  0.327 ns |  0.290 ns |   7.01 |    0.03 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     39.79 ns |  0.077 ns |  0.072 ns |   3.56 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     61.09 ns |  0.153 ns |  0.143 ns |   5.47 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     55.21 ns |  0.074 ns |  0.062 ns |   4.94 |    0.01 |      - |     - |     - |         - |
|                      |      |       |              |           |           |        |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **1,195.69 ns** |  **5.476 ns** |  **4.854 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  7,767.49 ns | 23.665 ns | 19.761 ns |   6.50 |    0.03 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |  1000 | 15,788.67 ns | 43.350 ns | 40.550 ns |  13.21 |    0.06 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 |  8,033.40 ns | 53.770 ns | 47.666 ns |   6.72 |    0.05 | 5.9204 |     - |     - |  12,416 B |
|               LinqAF | 1000 |  1000 | 19,663.75 ns | 34.841 ns | 29.093 ns |  16.44 |    0.08 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  6,124.66 ns | 10.807 ns |  9.024 ns |   5.12 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  2,025.68 ns | 12.454 ns | 11.040 ns |   1.69 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  6,584.11 ns | 16.420 ns | 14.556 ns |   5.51 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  1,920.14 ns |  7.641 ns |  7.148 ns |   1.61 |    0.01 |      - |     - |     - |         - |
