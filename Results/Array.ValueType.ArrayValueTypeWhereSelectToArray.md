## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

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
|                    **ValueLinq_Standard** |    **10** |    **195.18 ns** |   **1.653 ns** |   **1.466 ns** |  **2.40** |    **0.03** |  **0.0725** |     **-** |     **-** |     **152 B** |
|                       ValueLinq_Stack |    10 |    162.71 ns |   0.664 ns |   0.554 ns |  2.00 |    0.02 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push |    10 |    433.66 ns |   4.835 ns |   8.469 ns |  5.35 |    0.12 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull |    10 |    320.36 ns |   3.119 ns |   2.765 ns |  3.94 |    0.06 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard |    10 |    184.52 ns |   0.991 ns |   0.828 ns |  2.27 |    0.02 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack |    10 |    153.71 ns |   1.605 ns |   1.423 ns |  1.89 |    0.02 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    346.58 ns |   1.367 ns |   1.142 ns |  4.27 |    0.04 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    323.00 ns |   1.554 ns |   1.378 ns |  3.97 |    0.05 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard |    10 |    200.06 ns |   1.582 ns |   1.321 ns |  2.46 |    0.01 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack |    10 |    167.46 ns |   1.145 ns |   1.071 ns |  2.06 |    0.02 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    353.74 ns |   2.018 ns |   1.887 ns |  4.35 |    0.05 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    331.48 ns |   1.282 ns |   1.136 ns |  4.08 |    0.04 |  0.0725 |     - |     - |     152 B |
|                               ForLoop |    10 |     81.38 ns |   0.845 ns |   0.790 ns |  1.00 |    0.00 |  0.2218 |     - |     - |     464 B |
|                           ForeachLoop |    10 |     89.94 ns |   0.813 ns |   0.678 ns |  1.11 |    0.01 |  0.2218 |     - |     - |     464 B |
|                                  Linq |    10 |    184.10 ns |   2.381 ns |   2.111 ns |  2.26 |    0.03 |  0.3095 |     - |     - |     648 B |
|                            LinqFaster |    10 |    110.34 ns |   1.083 ns |   0.960 ns |  1.36 |    0.02 |  0.3901 |     - |     - |     816 B |
|                                LinqAF |    10 |    253.86 ns |   3.720 ns |   3.106 ns |  3.13 |    0.04 |  0.2065 |     - |     - |     432 B |
|                            StructLinq |    10 |    176.01 ns |   1.850 ns |   1.640 ns |  2.16 |    0.03 |  0.1185 |     - |     - |     248 B |
|                  StructLinq_IFunction |    10 |    121.09 ns |   1.234 ns |   1.094 ns |  1.49 |    0.02 |  0.0725 |     - |     - |     152 B |
|                             Hyperlinq |    10 |    159.69 ns |   1.058 ns |   0.884 ns |  1.97 |    0.02 |  0.0725 |     - |     - |     152 B |
|                   Hyperlinq_IFunction |    10 |    133.80 ns |   0.722 ns |   0.640 ns |  1.65 |    0.02 |  0.0725 |     - |     - |     152 B |
|                                       |       |              |            |            |       |         |         |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **16,191.89 ns** | **106.232 ns** |  **88.708 ns** |  **1.08** |    **0.01** | **30.2734** |     **-** |     **-** |  **64,080 B** |
|                       ValueLinq_Stack |  1000 | 16,687.48 ns | 214.452 ns | 190.106 ns |  1.11 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|             ValueLinq_SharedPool_Push |  1000 | 18,015.84 ns | 178.213 ns | 157.982 ns |  1.20 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|             ValueLinq_SharedPool_Pull |  1000 | 14,952.55 ns | 112.369 ns | 105.110 ns |  1.00 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                ValueLinq_Ref_Standard |  1000 | 16,673.26 ns |  66.046 ns |  58.548 ns |  1.11 |    0.00 | 30.2734 |     - |     - |  64,080 B |
|                   ValueLinq_Ref_Stack |  1000 | 16,602.57 ns | 109.520 ns |  91.455 ns |  1.10 |    0.01 | 30.2734 |     - |     - |  64,080 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 15,673.93 ns | 113.792 ns |  95.022 ns |  1.04 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 14,829.65 ns |  84.271 ns |  74.704 ns |  0.99 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 16,458.02 ns | 315.166 ns | 337.224 ns |  1.10 |    0.03 | 30.2734 |     - |     - |  64,080 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 16,225.99 ns | 125.730 ns | 117.608 ns |  1.08 |    0.01 | 30.2734 |     - |     - |  64,080 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 15,056.44 ns |  80.557 ns |  71.412 ns |  1.00 |    0.01 | 15.1367 |     - |     - |  32,216 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 14,383.15 ns | 119.247 ns | 105.709 ns |  0.96 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                               ForLoop |  1000 | 15,035.11 ns |  80.038 ns |  66.835 ns |  1.00 |    0.00 | 46.5088 |     - |     - |  97,720 B |
|                           ForeachLoop |  1000 | 16,649.62 ns | 149.473 ns | 132.504 ns |  1.11 |    0.01 | 46.5088 |     - |     - |  97,720 B |
|                                  Linq |  1000 | 17,863.73 ns | 115.108 ns | 107.672 ns |  1.19 |    0.01 | 31.2195 |     - |     - |  65,792 B |
|                            LinqFaster |  1000 | 15,375.87 ns | 105.617 ns |  93.627 ns |  1.02 |    0.01 | 45.4407 |     - |     - |  96,240 B |
|                                LinqAF |  1000 | 30,029.58 ns | 260.313 ns | 230.761 ns |  2.00 |    0.02 | 46.5088 |     - |     - |  97,688 B |
|                            StructLinq |  1000 | 16,298.81 ns |  95.663 ns |  84.802 ns |  1.08 |    0.01 | 15.3809 |     - |     - |  32,312 B |
|                  StructLinq_IFunction |  1000 | 11,410.91 ns | 140.129 ns | 117.014 ns |  0.76 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                             Hyperlinq |  1000 | 17,128.16 ns | 102.959 ns |  91.271 ns |  1.14 |    0.01 | 15.1367 |     - |     - |  32,216 B |
|                   Hyperlinq_IFunction |  1000 | 12,334.31 ns |  78.707 ns |  69.772 ns |  0.82 |    0.00 | 15.1367 |     - |     - |  32,216 B |
