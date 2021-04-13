## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |    Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|---------:|--------:|--------:|--------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **23.44 ns** |   **0.109 ns** |   **0.102 ns** |     **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     33.40 ns |   0.318 ns |   0.265 ns |     1.43 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     93.14 ns |   1.620 ns |   1.515 ns |     3.97 |    0.07 |  0.0497 |       - |     - |     104 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     86.29 ns |   1.246 ns |   1.165 ns |     3.68 |    0.05 |  0.3901 |       - |     - |     816 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    145.35 ns |   2.845 ns |   3.699 ns |     6.23 |    0.16 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 44,883.47 ns | 288.037 ns | 255.337 ns | 1,915.08 |   10.77 | 71.4111 |       - |     - | 151,033 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    271.01 ns |   1.394 ns |   1.235 ns |    11.56 |    0.08 |  0.3939 |       - |     - |     824 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     59.54 ns |   0.368 ns |   0.344 ns |     2.54 |    0.02 |  0.0153 |       - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     56.73 ns |   0.311 ns |   0.291 ns |     2.42 |    0.02 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    102.84 ns |   1.376 ns |   1.287 ns |     4.39 |    0.06 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     75.66 ns |   0.606 ns |   0.567 ns |     3.23 |    0.03 |       - |       - |     - |         - |
|                      |        |          |       |              |            |            |          |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     23.42 ns |   0.095 ns |   0.089 ns |     1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     34.03 ns |   0.094 ns |   0.088 ns |     1.45 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     78.40 ns |   1.154 ns |   1.079 ns |     3.35 |    0.05 |  0.0497 |       - |     - |     104 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     87.62 ns |   0.972 ns |   0.862 ns |     3.74 |    0.04 |  0.3901 |       - |     - |     816 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    143.49 ns |   2.866 ns |   3.923 ns |     6.11 |    0.16 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 42,193.62 ns | 325.402 ns | 288.461 ns | 1,801.11 |   13.95 | 68.5425 | 12.4512 |     - | 150,782 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    257.42 ns |   4.122 ns |   3.856 ns |    10.99 |    0.18 |  0.3939 |       - |     - |     824 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     58.96 ns |   0.279 ns |   0.261 ns |     2.52 |    0.01 |  0.0153 |       - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     56.27 ns |   0.160 ns |   0.150 ns |     2.40 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    101.39 ns |   0.909 ns |   0.851 ns |     4.33 |    0.03 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     75.22 ns |   0.753 ns |   0.704 ns |     3.21 |    0.03 |       - |       - |     - |         - |
|                      |        |          |       |              |            |            |          |         |         |         |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **4,911.29 ns** |  **19.526 ns** |  **18.265 ns** |     **1.00** |    **0.00** |       **-** |       **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  5,966.49 ns |  33.365 ns |  26.049 ns |     1.22 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 11,709.43 ns |  52.854 ns |  49.440 ns |     2.38 |    0.01 |  0.0458 |       - |     - |     104 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 13,378.38 ns | 137.738 ns | 128.840 ns |     2.72 |    0.03 | 45.4407 |       - |     - |  96,240 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 15,501.75 ns | 303.540 ns | 337.384 ns |     3.15 |    0.08 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 60,892.22 ns | 197.820 ns | 175.362 ns |    12.40 |    0.04 | 86.9141 |       - |     - | 183,113 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 19,714.12 ns | 116.041 ns | 108.545 ns |     4.01 |    0.02 |  0.3662 |       - |     - |     824 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  8,708.32 ns |  33.611 ns |  31.440 ns |     1.77 |    0.01 |  0.0153 |       - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  6,879.20 ns |  24.363 ns |  21.597 ns |     1.40 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 14,313.09 ns |  70.416 ns |  65.867 ns |     2.91 |    0.02 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  9,531.47 ns | 158.220 ns | 132.121 ns |     1.94 |    0.03 |       - |       - |     - |         - |
|                      |        |          |       |              |            |            |          |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  4,901.32 ns |  27.188 ns |  25.432 ns |     1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  5,881.94 ns |  24.416 ns |  22.839 ns |     1.20 |    0.01 |       - |       - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 11,604.92 ns |  63.329 ns |  49.443 ns |     2.37 |    0.02 |  0.0458 |       - |     - |     104 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 13,766.51 ns |  61.423 ns | 104.301 ns |     2.82 |    0.03 | 45.4407 |       - |     - |  96,240 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 15,861.71 ns | 268.616 ns | 251.263 ns |     3.24 |    0.05 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 58,697.56 ns | 216.723 ns | 180.974 ns |    11.98 |    0.05 | 81.1157 | 13.4888 |     - | 182,859 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 18,453.58 ns | 132.485 ns | 123.926 ns |     3.77 |    0.03 |  0.3662 |       - |     - |     824 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  6,763.90 ns |  29.583 ns |  26.225 ns |     1.38 |    0.01 |  0.0153 |       - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  5,650.34 ns |  22.230 ns |  20.794 ns |     1.15 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 12,380.91 ns |  59.360 ns |  55.526 ns |     2.53 |    0.02 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  8,519.41 ns |  63.707 ns |  59.591 ns |     1.74 |    0.02 |       - |       - |     - |         - |
