## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Skip | Count |         Mean |      Error |     StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----- |------ |-------------:|-----------:|-----------:|---------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |    **10** |     **11.02 ns** |   **0.073 ns** |   **0.061 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |    10 |  4,337.55 ns |  20.613 ns |  17.213 ns |   393.79 |    2.83 |  0.0153 |     - |     - |      40 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |    10 |    200.96 ns |   0.613 ns |   0.574 ns |    18.25 |    0.11 |  0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 5 | .NET 5.0 | 1000 |    10 |    126.49 ns |   2.372 ns |   1.981 ns |    11.48 |    0.21 |  0.1528 |     - |     - |     320 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |    10 |  4,185.21 ns |  23.628 ns |  22.101 ns |   380.14 |    3.84 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |    10 | 60,888.17 ns | 194.558 ns | 181.990 ns | 5,527.52 |   28.81 | 15.8081 |     - |     - |  33,159 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |    10 |  6,297.99 ns |  31.162 ns |  24.329 ns |   571.99 |    2.87 |  0.4425 |     - |     - |     936 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |    10 |     77.60 ns |   0.315 ns |   0.280 ns |     7.04 |    0.04 |  0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     40.96 ns |   0.126 ns |   0.112 ns |     3.72 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |    10 |     64.23 ns |   0.690 ns |   0.576 ns |     5.83 |    0.06 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |     56.64 ns |   0.664 ns |   0.588 ns |     5.14 |    0.07 |       - |     - |     - |         - |
|                      |        |          |      |       |              |            |            |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 | 1000 |    10 |     11.25 ns |   0.057 ns |   0.053 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |    10 |  3,408.85 ns |  15.236 ns |  11.895 ns |   303.16 |    2.18 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |    10 |    113.63 ns |   0.437 ns |   0.408 ns |    10.10 |    0.05 |  0.0726 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | .NET 6.0 | 1000 |    10 |    123.23 ns |   1.063 ns |   0.943 ns |    10.96 |    0.11 |  0.1528 |     - |     - |     320 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |    10 |  4,229.92 ns |  21.847 ns |  19.367 ns |   376.14 |    3.26 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |    10 | 56,269.21 ns | 247.143 ns | 231.178 ns | 5,003.36 |   34.34 | 15.6250 |     - |     - |  32,716 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |    10 |  5,613.61 ns |  25.098 ns |  23.476 ns |   499.15 |    3.65 |  0.4425 |     - |     - |     936 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |    10 |     74.12 ns |   0.620 ns |   0.550 ns |     6.59 |    0.06 |  0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     41.18 ns |   0.149 ns |   0.132 ns |     3.66 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |    10 |     64.04 ns |   0.214 ns |   0.200 ns |     5.69 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |     57.12 ns |   0.488 ns |   0.408 ns |     5.08 |    0.05 |       - |     - |     - |         - |
|                      |        |          |      |       |              |            |            |          |         |         |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** | **1000** |  **1000** |  **1,216.92 ns** |   **7.396 ns** |   **6.556 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  7,740.10 ns |  51.651 ns |  43.131 ns |     6.36 |    0.05 |  0.0153 |     - |     - |      40 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 15,986.45 ns |  62.725 ns |  52.378 ns |    13.13 |    0.10 |  0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 | 10,163.60 ns | 145.392 ns | 113.513 ns |     8.35 |    0.10 |  5.9204 |     - |     - |  12,416 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 19,289.34 ns |  64.003 ns |  56.737 ns |    15.85 |    0.10 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 75,812.87 ns | 265.329 ns | 235.207 ns |    62.30 |    0.37 | 16.7236 |     - |     - |  35,120 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 24,292.42 ns |  92.449 ns |  86.477 ns |    19.96 |    0.13 |  0.4272 |     - |     - |     936 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  5,384.25 ns |  22.222 ns |  20.786 ns |     4.43 |    0.02 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  1,585.28 ns |  11.942 ns |  11.170 ns |     1.30 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  4,518.07 ns |  20.541 ns |  19.214 ns |     3.72 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  2,064.75 ns |   9.582 ns |   8.963 ns |     1.70 |    0.01 |       - |     - |     - |         - |
|                      |        |          |      |       |              |            |            |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,192.87 ns |   9.053 ns |   8.468 ns |     1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  6,235.75 ns |  23.850 ns |  18.620 ns |     5.23 |    0.04 |  0.0153 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |  1000 |  7,738.78 ns |  34.188 ns |  30.307 ns |     6.49 |    0.06 |  0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 |  8,033.17 ns | 102.531 ns |  85.618 ns |     6.73 |    0.08 |  5.9204 |     - |     - |  12,416 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 18,383.70 ns |  90.824 ns |  84.957 ns |    15.41 |    0.12 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 67,862.45 ns | 326.726 ns | 305.620 ns |    56.89 |    0.52 | 16.4795 |     - |     - |  34,677 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 20,877.58 ns | 132.340 ns | 103.322 ns |    17.52 |    0.19 |  0.4272 |     - |     - |     936 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  5,317.53 ns |  23.805 ns |  21.103 ns |     4.46 |    0.04 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  1,505.40 ns |   6.358 ns |   4.964 ns |     1.26 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  6,679.72 ns |  12.708 ns |   9.922 ns |     5.60 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  5,091.24 ns |  20.658 ns |  19.323 ns |     4.27 |    0.03 |       - |     - |     - |         - |
