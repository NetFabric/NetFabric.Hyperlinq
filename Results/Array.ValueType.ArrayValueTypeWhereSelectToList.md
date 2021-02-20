## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                                Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|--------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |    **210.18 ns** |   **0.552 ns** |   **0.489 ns** |  **4.21** |    **0.03** |  **0.0880** |       **-** |     **-** |     **184 B** |
|                       ValueLinq_Stack |    10 |    172.55 ns |   0.882 ns |   0.688 ns |  3.46 |    0.02 |  0.0880 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push |    10 |    416.38 ns |   0.950 ns |   0.842 ns |  8.34 |    0.06 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull |    10 |    318.18 ns |   0.710 ns |   0.664 ns |  6.37 |    0.05 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard |    10 |    198.39 ns |   0.392 ns |   0.306 ns |  3.98 |    0.03 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack |    10 |    166.48 ns |   0.499 ns |   0.443 ns |  3.34 |    0.03 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    333.92 ns |   0.958 ns |   0.800 ns |  6.69 |    0.05 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    308.01 ns |   0.873 ns |   0.774 ns |  6.17 |    0.04 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard |    10 |    218.16 ns |   1.027 ns |   0.911 ns |  4.37 |    0.02 |  0.0880 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack |    10 |    181.67 ns |   1.379 ns |   1.290 ns |  3.64 |    0.04 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    343.02 ns |   0.623 ns |   0.583 ns |  6.87 |    0.05 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    327.12 ns |   0.803 ns |   0.627 ns |  6.56 |    0.05 |  0.0877 |       - |     - |     184 B |
|                               ForLoop |    10 |     49.92 ns |   0.382 ns |   0.339 ns |  1.00 |    0.00 |  0.1492 |       - |     - |     312 B |
|                           ForeachLoop |    10 |     60.10 ns |   0.699 ns |   0.620 ns |  1.20 |    0.02 |  0.1491 |       - |     - |     312 B |
|                                  Linq |    10 |    131.09 ns |   1.360 ns |   1.136 ns |  2.63 |    0.03 |  0.2525 |       - |     - |     528 B |
|                            LinqFaster |    10 |    121.57 ns |   0.642 ns |   0.569 ns |  2.44 |    0.02 |  0.4780 |       - |     - |    1000 B |
|                                LinqAF |    10 |    222.70 ns |   3.852 ns |   3.603 ns |  4.46 |    0.09 |  0.1490 |       - |     - |     312 B |
|                            StructLinq |    10 |    160.57 ns |   0.747 ns |   0.662 ns |  3.22 |    0.03 |  0.1338 |       - |     - |     280 B |
|                  StructLinq_IFunction |    10 |    119.74 ns |   0.641 ns |   0.535 ns |  2.40 |    0.02 |  0.0880 |       - |     - |     184 B |
|                             Hyperlinq |    10 |    124.80 ns |   0.344 ns |   0.287 ns |  2.50 |    0.02 |  0.0880 |       - |     - |     184 B |
|                   Hyperlinq_IFunction |    10 |    106.70 ns |   0.264 ns |   0.234 ns |  2.14 |    0.02 |  0.0880 |       - |     - |     184 B |
|                                       |       |              |            |            |       |         |         |         |       |           |
|                    **ValueLinq_Standard** |  **1000** | **16,626.54 ns** | **115.818 ns** | **102.670 ns** |  **1.65** |    **0.02** | **31.2195** |       **-** |     **-** |   **65504 B** |
|                       ValueLinq_Stack |  1000 | 14,042.62 ns |  84.477 ns |  79.020 ns |  1.39 |    0.01 | 30.2887 |       - |     - |   64112 B |
|             ValueLinq_SharedPool_Push |  1000 | 16,891.69 ns | 205.109 ns | 181.824 ns |  1.67 |    0.02 | 15.3809 |       - |     - |   32248 B |
|             ValueLinq_SharedPool_Pull |  1000 | 13,799.79 ns |  75.876 ns |  67.262 ns |  1.37 |    0.01 | 15.3809 |       - |     - |   32248 B |
|                ValueLinq_Ref_Standard |  1000 | 14,385.04 ns |  75.457 ns |  66.891 ns |  1.43 |    0.01 | 31.2347 |       - |     - |   65504 B |
|                   ValueLinq_Ref_Stack |  1000 | 14,979.84 ns |  48.100 ns |  40.166 ns |  1.48 |    0.01 | 30.2887 |       - |     - |   64112 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 14,472.62 ns |  89.249 ns |  83.483 ns |  1.44 |    0.01 | 15.3809 |       - |     - |   32248 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 13,678.11 ns |  73.813 ns |  65.433 ns |  1.36 |    0.01 | 15.3809 |       - |     - |   32248 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 14,020.02 ns |  65.319 ns |  54.544 ns |  1.39 |    0.01 | 31.2347 |       - |     - |   65504 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 14,109.65 ns |  98.981 ns |  87.744 ns |  1.40 |    0.01 | 30.2887 |       - |     - |   64112 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 13,819.39 ns |  76.232 ns |  63.657 ns |  1.37 |    0.01 | 15.3809 |       - |     - |   32248 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 13,120.11 ns |  97.635 ns |  81.530 ns |  1.30 |    0.01 | 15.3809 |       - |     - |   32248 B |
|                               ForLoop |  1000 | 10,084.89 ns |  79.731 ns |  74.581 ns |  1.00 |    0.00 | 31.2347 |       - |     - |   65504 B |
|                           ForeachLoop |  1000 | 11,667.89 ns |  69.319 ns |  61.450 ns |  1.16 |    0.01 | 31.2347 |       - |     - |   65504 B |
|                                  Linq |  1000 | 14,582.31 ns | 140.969 ns | 124.966 ns |  1.44 |    0.02 | 31.2347 |       - |     - |   65720 B |
|                            LinqFaster |  1000 | 15,545.81 ns |  86.332 ns |  76.531 ns |  1.54 |    0.01 | 58.3801 | 14.5874 |     - |  128488 B |
|                                LinqAF |  1000 | 33,363.19 ns | 104.078 ns |  97.355 ns |  3.31 |    0.02 | 31.2195 |       - |     - |   65504 B |
|                            StructLinq |  1000 | 15,090.48 ns |  47.313 ns |  39.509 ns |  1.49 |    0.01 | 15.3809 |       - |     - |   32344 B |
|                  StructLinq_IFunction |  1000 | 10,447.07 ns |  49.657 ns |  44.020 ns |  1.04 |    0.01 | 15.3809 |       - |     - |   32248 B |
|                             Hyperlinq |  1000 | 10,389.15 ns |  56.922 ns |  50.460 ns |  1.03 |    0.01 | 15.3809 |       - |     - |   32248 B |
|                   Hyperlinq_IFunction |  1000 |  8,176.91 ns |  59.302 ns |  52.570 ns |  0.81 |    0.00 | 15.3809 |       - |     - |   32248 B |
