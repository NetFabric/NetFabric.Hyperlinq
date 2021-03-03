## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |         Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **11.12 ns** |  **0.029 ns** |  **0.026 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  4,195.06 ns | 10.206 ns |  7.968 ns | 377.25 |    1.50 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |    10 |    198.36 ns |  0.562 ns |  0.499 ns |  17.84 |    0.07 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |    121.77 ns |  0.595 ns |  0.528 ns |  10.95 |    0.06 | 0.1528 |     - |     - |     320 B |
|               LinqAF | 1000 |    10 |  4,626.69 ns | 18.032 ns | 15.985 ns | 416.13 |    2.18 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     91.38 ns |  0.390 ns |  0.346 ns |   8.22 |    0.04 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     39.94 ns |  0.072 ns |  0.068 ns |   3.59 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     60.23 ns |  0.191 ns |  0.179 ns |   5.42 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     54.52 ns |  0.092 ns |  0.082 ns |   4.90 |    0.01 |      - |     - |     - |         - |
|                      |      |       |              |           |           |        |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **1,194.49 ns** |  **2.282 ns** |  **2.023 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  7,730.10 ns | 49.278 ns | 75.253 ns |   6.50 |    0.09 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |  1000 | 15,731.83 ns | 36.666 ns | 32.503 ns |  13.17 |    0.03 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 |  7,991.39 ns | 25.962 ns | 24.285 ns |   6.69 |    0.03 | 5.9204 |     - |     - |  12,416 B |
|               LinqAF | 1000 |  1000 | 19,881.79 ns | 79.959 ns | 74.793 ns |  16.64 |    0.08 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  6,119.67 ns |  9.279 ns |  8.680 ns |   5.12 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  1,781.34 ns |  5.529 ns |  5.172 ns |   1.49 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  6,574.04 ns | 15.523 ns | 13.761 ns |   5.50 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  1,913.42 ns |  3.980 ns |  3.323 ns |   1.60 |    0.00 |      - |     - |     - |         - |
