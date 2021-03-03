## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |      **9.065 ns** |  **0.0282 ns** |  **0.0264 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  2,124.127 ns |  7.2759 ns |  6.8059 ns | 234.33 |    1.21 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    210.962 ns |  0.3081 ns |  0.2573 ns |  23.28 |    0.07 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |     66.090 ns |  0.3203 ns |  0.2996 ns |   7.29 |    0.05 | 0.1147 |     - |     - |     240 B |
|               LinqAF | 1000 |    10 |  2,002.244 ns |  3.9669 ns |  3.3125 ns | 220.93 |    0.76 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     76.371 ns |  0.2368 ns |  0.2099 ns |   8.43 |    0.03 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     39.140 ns |  0.0785 ns |  0.0734 ns |   4.32 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     60.231 ns |  0.1460 ns |  0.1366 ns |   6.64 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     54.850 ns |  0.0895 ns |  0.0793 ns |   6.05 |    0.02 |      - |     - |     - |         - |
|                      |      |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |    **923.308 ns** |  **3.2118 ns** |  **2.8472 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  4,521.065 ns | 15.1226 ns | 14.1456 ns |   4.90 |    0.02 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 15,695.183 ns | 51.2307 ns | 45.4147 ns |  17.00 |    0.06 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 |  4,134.985 ns | 18.8345 ns | 15.7277 ns |   4.48 |    0.02 | 6.7215 |     - |     - |  14,064 B |
|               LinqAF | 1000 |  1000 | 14,945.785 ns | 29.5215 ns | 24.6518 ns |  16.18 |    0.06 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  5,632.745 ns | 13.6753 ns | 12.1228 ns |   6.10 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  1,590.695 ns |  8.3358 ns |  7.3894 ns |   1.72 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  5,598.926 ns | 11.8132 ns | 10.4721 ns |   6.06 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  1,963.342 ns | 10.7096 ns |  9.4938 ns |   2.13 |    0.01 |      - |     - |     - |         - |
