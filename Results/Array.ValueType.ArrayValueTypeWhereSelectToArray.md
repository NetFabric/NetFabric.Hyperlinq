## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                                Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |    **186.62 ns** |   **1.330 ns** |   **2.433 ns** |  **2.77** |    **0.02** |  **0.0725** |     **-** |     **-** |     **152 B** |
|                       ValueLinq_Stack |    10 |    148.70 ns |   0.590 ns |   0.552 ns |  2.21 |    0.01 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push |    10 |    416.02 ns |   1.183 ns |   1.048 ns |  6.17 |    0.02 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull |    10 |    306.73 ns |   1.307 ns |   1.159 ns |  4.55 |    0.03 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard |    10 |    173.06 ns |   0.337 ns |   0.299 ns |  2.57 |    0.01 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack |    10 |    138.83 ns |   0.410 ns |   0.384 ns |  2.06 |    0.01 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    340.30 ns |   0.660 ns |   0.585 ns |  5.05 |    0.03 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    304.35 ns |   0.576 ns |   0.538 ns |  4.52 |    0.03 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard |    10 |    194.00 ns |   0.990 ns |   1.100 ns |  2.88 |    0.02 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack |    10 |    156.45 ns |   1.260 ns |   1.178 ns |  2.32 |    0.01 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    339.67 ns |   1.721 ns |   1.437 ns |  5.04 |    0.04 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    325.45 ns |   0.708 ns |   0.628 ns |  4.83 |    0.03 |  0.0725 |     - |     - |     152 B |
|                               ForLoop |    10 |     67.41 ns |   0.381 ns |   0.318 ns |  1.00 |    0.00 |  0.2218 |     - |     - |     464 B |
|                           ForeachLoop |    10 |     75.11 ns |   0.432 ns |   0.383 ns |  1.12 |    0.01 |  0.2218 |     - |     - |     464 B |
|                                  Linq |    10 |    160.72 ns |   1.142 ns |   1.013 ns |  2.38 |    0.02 |  0.3097 |     - |     - |     648 B |
|                            LinqFaster |    10 |     88.46 ns |   0.558 ns |   0.522 ns |  1.31 |    0.01 |  0.3901 |     - |     - |     816 B |
|                                LinqAF |    10 |    231.71 ns |   3.281 ns |   3.069 ns |  3.45 |    0.04 |  0.2065 |     - |     - |     432 B |
|                            StructLinq |    10 |    147.07 ns |   0.488 ns |   0.381 ns |  2.18 |    0.01 |  0.1185 |     - |     - |     248 B |
|                  StructLinq_IFunction |    10 |    112.67 ns |   0.365 ns |   0.323 ns |  1.67 |    0.01 |  0.0726 |     - |     - |     152 B |
|                             Hyperlinq |    10 |    150.40 ns |   1.452 ns |   1.358 ns |  2.23 |    0.02 |  0.0725 |     - |     - |     152 B |
|                   Hyperlinq_IFunction |    10 |    129.68 ns |   0.645 ns |   0.504 ns |  1.92 |    0.01 |  0.0725 |     - |     - |     152 B |
|                                       |       |              |            |            |       |         |         |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **13,901.09 ns** |  **49.680 ns** |  **44.040 ns** |  **1.15** |    **0.01** | **30.2887** |     **-** |     **-** |  **64,080 B** |
|                       ValueLinq_Stack |  1000 | 13,613.44 ns |  44.135 ns |  36.854 ns |  1.13 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push |  1000 | 16,483.72 ns | 193.129 ns | 150.782 ns |  1.37 |    0.02 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull |  1000 | 13,035.18 ns |  67.901 ns |  56.700 ns |  1.08 |    0.00 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard |  1000 | 14,193.84 ns |  47.376 ns |  39.561 ns |  1.18 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack |  1000 | 13,808.34 ns |  52.982 ns |  44.243 ns |  1.14 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 14,267.44 ns |  83.255 ns |  73.803 ns |  1.18 |    0.00 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 13,826.46 ns |  38.648 ns |  34.260 ns |  1.15 |    0.00 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 14,088.15 ns |  97.069 ns |  90.799 ns |  1.17 |    0.01 | 30.2887 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 13,813.01 ns | 109.570 ns |  97.131 ns |  1.14 |    0.01 | 30.2887 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 13,563.17 ns |  72.526 ns |  64.292 ns |  1.12 |    0.01 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 13,086.94 ns | 114.009 ns |  89.011 ns |  1.08 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                               ForLoop |  1000 | 12,064.96 ns |  52.580 ns |  46.610 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                           ForeachLoop |  1000 | 14,041.26 ns | 123.063 ns | 109.092 ns |  1.16 |    0.01 | 46.5088 |     - |     - |  97,720 B |
|                                  Linq |  1000 | 15,226.09 ns | 124.922 ns | 116.852 ns |  1.26 |    0.01 | 31.2347 |     - |     - |  65,792 B |
|                            LinqFaster |  1000 | 12,912.82 ns |  66.690 ns |  55.689 ns |  1.07 |    0.01 | 45.4407 |     - |     - |  96,240 B |
|                                LinqAF |  1000 | 26,368.30 ns | 394.896 ns | 369.386 ns |  2.18 |    0.03 | 46.5088 |     - |     - |  97,688 B |
|                            StructLinq |  1000 | 14,215.28 ns |  94.596 ns |  88.486 ns |  1.18 |    0.01 | 15.3809 |     - |     - |  32,312 B |
|                  StructLinq_IFunction |  1000 | 10,156.67 ns |  50.704 ns |  44.948 ns |  0.84 |    0.00 | 15.1367 |     - |     - |  32,216 B |
|                             Hyperlinq |  1000 | 16,269.23 ns |  99.929 ns |  78.018 ns |  1.35 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                   Hyperlinq_IFunction |  1000 | 11,156.07 ns |  56.434 ns |  50.027 ns |  0.92 |    0.01 | 15.1367 |     - |     - |  32,216 B |
