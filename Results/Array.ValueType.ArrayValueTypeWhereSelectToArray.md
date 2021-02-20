## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                                Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |    **193.87 ns** |   **0.574 ns** |   **0.509 ns** |  **2.89** |    **0.02** |  **0.0725** |     **-** |     **-** |     **152 B** |
|                       ValueLinq_Stack |    10 |    150.87 ns |   0.714 ns |   0.633 ns |  2.25 |    0.02 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Push |    10 |    408.93 ns |   1.493 ns |   1.324 ns |  6.09 |    0.05 |  0.0725 |     - |     - |     152 B |
|             ValueLinq_SharedPool_Pull |    10 |    301.74 ns |   0.734 ns |   0.613 ns |  4.49 |    0.03 |  0.0725 |     - |     - |     152 B |
|                ValueLinq_Ref_Standard |    10 |    175.76 ns |   0.643 ns |   0.602 ns |  2.62 |    0.02 |  0.0725 |     - |     - |     152 B |
|                   ValueLinq_Ref_Stack |    10 |    138.13 ns |   0.583 ns |   0.487 ns |  2.06 |    0.02 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    323.71 ns |   1.208 ns |   1.071 ns |  4.82 |    0.03 |  0.0725 |     - |     - |     152 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    300.35 ns |   0.538 ns |   0.420 ns |  4.48 |    0.03 |  0.0725 |     - |     - |     152 B |
|        ValueLinq_ValueLambda_Standard |    10 |    202.35 ns |   0.927 ns |   0.822 ns |  3.01 |    0.03 |  0.0725 |     - |     - |     152 B |
|           ValueLinq_ValueLambda_Stack |    10 |    157.58 ns |   1.101 ns |   1.030 ns |  2.35 |    0.02 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    337.31 ns |   0.860 ns |   0.762 ns |  5.02 |    0.04 |  0.0725 |     - |     - |     152 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    318.37 ns |   1.249 ns |   1.168 ns |  4.74 |    0.03 |  0.0725 |     - |     - |     152 B |
|                               ForLoop |    10 |     67.20 ns |   0.497 ns |   0.465 ns |  1.00 |    0.00 |  0.2218 |     - |     - |     464 B |
|                           ForeachLoop |    10 |     74.72 ns |   0.621 ns |   0.518 ns |  1.11 |    0.01 |  0.2218 |     - |     - |     464 B |
|                                  Linq |    10 |    160.64 ns |   1.643 ns |   1.537 ns |  2.39 |    0.02 |  0.3097 |     - |     - |     648 B |
|                            LinqFaster |    10 |     87.59 ns |   0.351 ns |   0.274 ns |  1.31 |    0.01 |  0.3901 |     - |     - |     816 B |
|                                LinqAF |    10 |    245.47 ns |   4.862 ns |   4.775 ns |  3.66 |    0.07 |  0.2065 |     - |     - |     432 B |
|                            StructLinq |    10 |    145.25 ns |   0.607 ns |   0.507 ns |  2.16 |    0.02 |  0.1185 |     - |     - |     248 B |
|                  StructLinq_IFunction |    10 |    112.06 ns |   0.439 ns |   0.389 ns |  1.67 |    0.01 |  0.0726 |     - |     - |     152 B |
|                             Hyperlinq |    10 |    116.66 ns |   0.408 ns |   0.361 ns |  1.74 |    0.01 |  0.0725 |     - |     - |     152 B |
|                   Hyperlinq_IFunction |    10 |     98.90 ns |   0.313 ns |   0.244 ns |  1.47 |    0.01 |  0.0726 |     - |     - |     152 B |
|                                       |       |              |            |            |       |         |         |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **20,218.06 ns** |  **40.361 ns** |  **35.779 ns** |  **1.68** |    **0.01** | **30.2887** |     **-** |     **-** |   **64080 B** |
|                       ValueLinq_Stack |  1000 | 13,654.55 ns |  52.477 ns |  49.087 ns |  1.14 |    0.01 | 30.2887 |     - |     - |   64080 B |
|             ValueLinq_SharedPool_Push |  1000 | 16,639.14 ns | 153.109 ns | 143.218 ns |  1.39 |    0.01 | 15.1367 |     - |     - |   32216 B |
|             ValueLinq_SharedPool_Pull |  1000 | 13,429.97 ns |  36.126 ns |  32.025 ns |  1.12 |    0.00 | 15.1367 |     - |     - |   32216 B |
|                ValueLinq_Ref_Standard |  1000 | 14,051.54 ns |  70.045 ns |  62.093 ns |  1.17 |    0.01 | 30.2887 |     - |     - |   64080 B |
|                   ValueLinq_Ref_Stack |  1000 | 13,660.60 ns |  46.759 ns |  41.450 ns |  1.14 |    0.01 | 30.2887 |     - |     - |   64080 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 14,365.07 ns |  42.232 ns |  37.437 ns |  1.20 |    0.00 | 15.1367 |     - |     - |   32216 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 14,773.61 ns |  35.375 ns |  31.359 ns |  1.23 |    0.00 | 15.1367 |     - |     - |   32216 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 14,026.64 ns |  86.106 ns |  76.331 ns |  1.17 |    0.01 | 30.2887 |     - |     - |   64080 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 13,764.56 ns |  96.109 ns |  85.198 ns |  1.15 |    0.01 | 30.2887 |     - |     - |   64080 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 13,632.08 ns | 103.091 ns |  86.086 ns |  1.14 |    0.01 | 15.1367 |     - |     - |   32216 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 13,269.01 ns | 163.309 ns | 152.759 ns |  1.11 |    0.01 | 15.1367 |     - |     - |   32216 B |
|                               ForLoop |  1000 | 12,001.80 ns |  38.847 ns |  30.329 ns |  1.00 |    0.00 | 46.5088 |     - |     - |   97720 B |
|                           ForeachLoop |  1000 | 13,716.97 ns | 118.080 ns | 104.675 ns |  1.14 |    0.01 | 46.5088 |     - |     - |   97720 B |
|                                  Linq |  1000 | 15,457.05 ns | 187.979 ns | 175.835 ns |  1.29 |    0.02 | 31.2195 |     - |     - |   65792 B |
|                            LinqFaster |  1000 | 13,118.03 ns |  67.148 ns |  59.525 ns |  1.09 |    0.00 | 45.4407 |     - |     - |   96240 B |
|                                LinqAF |  1000 | 26,578.24 ns | 252.271 ns | 223.632 ns |  2.21 |    0.02 | 46.5088 |     - |     - |   97688 B |
|                            StructLinq |  1000 | 15,193.83 ns | 106.487 ns |  94.398 ns |  1.27 |    0.01 | 15.3809 |     - |     - |   32312 B |
|                  StructLinq_IFunction |  1000 |  9,993.12 ns |  49.391 ns |  43.783 ns |  0.83 |    0.00 | 15.1367 |     - |     - |   32216 B |
|                             Hyperlinq |  1000 | 10,196.23 ns |  46.463 ns |  38.798 ns |  0.85 |    0.00 | 15.1367 |     - |     - |   32216 B |
|                   Hyperlinq_IFunction |  1000 |  8,157.60 ns |  37.996 ns |  31.728 ns |  0.68 |    0.00 | 15.1367 |     - |     - |   32216 B |
