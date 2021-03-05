## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                                Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|--------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |    **212.59 ns** |   **0.380 ns** |   **0.336 ns** |  **4.15** |    **0.03** |  **0.0880** |       **-** |     **-** |     **184 B** |
|                       ValueLinq_Stack |    10 |    172.08 ns |   0.487 ns |   0.431 ns |  3.36 |    0.02 |  0.0880 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Push |    10 |    419.05 ns |   1.163 ns |   1.031 ns |  8.18 |    0.05 |  0.0877 |       - |     - |     184 B |
|             ValueLinq_SharedPool_Pull |    10 |    318.62 ns |   1.356 ns |   1.269 ns |  6.22 |    0.05 |  0.0877 |       - |     - |     184 B |
|                ValueLinq_Ref_Standard |    10 |    203.84 ns |   1.277 ns |   1.132 ns |  3.98 |    0.04 |  0.0880 |       - |     - |     184 B |
|                   ValueLinq_Ref_Stack |    10 |    162.04 ns |   0.869 ns |   0.726 ns |  3.16 |    0.02 |  0.0880 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Push |    10 |    338.65 ns |   1.522 ns |   1.349 ns |  6.61 |    0.05 |  0.0877 |       - |     - |     184 B |
|         ValueLinq_Ref_SharedPool_Pull |    10 |    319.24 ns |   0.826 ns |   0.732 ns |  6.23 |    0.04 |  0.0877 |       - |     - |     184 B |
|        ValueLinq_ValueLambda_Standard |    10 |    216.99 ns |   0.943 ns |   0.882 ns |  4.23 |    0.02 |  0.0880 |       - |     - |     184 B |
|           ValueLinq_ValueLambda_Stack |    10 |    180.24 ns |   1.446 ns |   1.282 ns |  3.52 |    0.04 |  0.0880 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    343.07 ns |   0.746 ns |   0.698 ns |  6.69 |    0.05 |  0.0877 |       - |     - |     184 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    342.92 ns |   0.837 ns |   0.783 ns |  6.69 |    0.05 |  0.0877 |       - |     - |     184 B |
|                               ForLoop |    10 |     51.25 ns |   0.350 ns |   0.310 ns |  1.00 |    0.00 |  0.1492 |       - |     - |     312 B |
|                           ForeachLoop |    10 |     60.58 ns |   0.711 ns |   0.630 ns |  1.18 |    0.01 |  0.1491 |       - |     - |     312 B |
|                                  Linq |    10 |    129.71 ns |   0.594 ns |   0.463 ns |  2.53 |    0.02 |  0.2525 |       - |     - |     528 B |
|                            LinqFaster |    10 |    127.99 ns |   1.030 ns |   0.913 ns |  2.50 |    0.02 |  0.4780 |       - |     - |   1,000 B |
|                                LinqAF |    10 |    227.50 ns |   3.560 ns |   3.330 ns |  4.44 |    0.07 |  0.1490 |       - |     - |     312 B |
|                            StructLinq |    10 |    155.35 ns |   0.573 ns |   0.536 ns |  3.03 |    0.02 |  0.1338 |       - |     - |     280 B |
|                  StructLinq_IFunction |    10 |    123.93 ns |   0.478 ns |   0.447 ns |  2.42 |    0.02 |  0.0880 |       - |     - |     184 B |
|                             Hyperlinq |    10 |    162.79 ns |   0.573 ns |   0.508 ns |  3.18 |    0.03 |  0.0880 |       - |     - |     184 B |
|                   Hyperlinq_IFunction |    10 |    135.67 ns |   0.937 ns |   0.877 ns |  2.65 |    0.03 |  0.0880 |       - |     - |     184 B |
|                                       |       |              |            |            |       |         |         |         |       |           |
|                    **ValueLinq_Standard** |  **1000** | **17,380.67 ns** |  **97.006 ns** |  **75.736 ns** |  **1.72** |    **0.01** | **31.2195** |       **-** |     **-** |  **65,504 B** |
|                       ValueLinq_Stack |  1000 | 14,945.63 ns |  44.392 ns |  39.352 ns |  1.49 |    0.01 | 30.2887 |       - |     - |  64,112 B |
|             ValueLinq_SharedPool_Push |  1000 | 16,629.01 ns | 118.274 ns | 104.847 ns |  1.65 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|             ValueLinq_SharedPool_Pull |  1000 | 13,412.95 ns |  64.141 ns |  56.859 ns |  1.33 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                ValueLinq_Ref_Standard |  1000 | 14,553.23 ns |  66.010 ns |  51.536 ns |  1.44 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                   ValueLinq_Ref_Stack |  1000 | 14,708.40 ns |  29.438 ns |  24.582 ns |  1.46 |    0.01 | 30.2887 |       - |     - |  64,112 B |
|         ValueLinq_Ref_SharedPool_Push |  1000 | 14,402.58 ns | 119.449 ns | 111.732 ns |  1.43 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|         ValueLinq_Ref_SharedPool_Pull |  1000 | 14,609.97 ns |  50.317 ns |  47.067 ns |  1.45 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 18,508.72 ns | 367.219 ns | 806.055 ns |  1.80 |    0.16 | 31.2195 |       - |     - |  65,504 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 14,147.06 ns | 164.313 ns | 153.698 ns |  1.41 |    0.01 | 30.2887 |       - |     - |  64,112 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 13,710.76 ns |  52.718 ns |  46.733 ns |  1.36 |    0.01 | 15.3809 |       - |     - |  32,248 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 13,390.61 ns |  93.569 ns |  87.525 ns |  1.33 |    0.02 | 15.3809 |       - |     - |  32,248 B |
|                               ForLoop |  1000 | 10,058.18 ns |  77.282 ns |  72.290 ns |  1.00 |    0.00 | 31.2347 |       - |     - |  65,504 B |
|                           ForeachLoop |  1000 | 11,693.23 ns |  74.520 ns |  69.706 ns |  1.16 |    0.01 | 31.2347 |       - |     - |  65,504 B |
|                                  Linq |  1000 | 14,574.11 ns | 111.188 ns |  98.565 ns |  1.45 |    0.01 | 31.2347 |       - |     - |  65,720 B |
|                            LinqFaster |  1000 | 15,825.02 ns |  83.310 ns |  77.928 ns |  1.57 |    0.01 | 58.3801 | 14.5874 |     - | 128,488 B |
|                                LinqAF |  1000 | 24,719.84 ns | 371.480 ns | 329.308 ns |  2.46 |    0.04 | 31.2195 |       - |     - |  65,504 B |
|                            StructLinq |  1000 | 14,443.23 ns |  57.416 ns |  50.898 ns |  1.44 |    0.01 | 15.3809 |       - |     - |  32,344 B |
|                  StructLinq_IFunction |  1000 | 10,219.08 ns |  58.086 ns |  51.492 ns |  1.02 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                             Hyperlinq |  1000 | 15,888.38 ns | 145.524 ns | 129.003 ns |  1.58 |    0.01 | 15.3809 |       - |     - |  32,248 B |
|                   Hyperlinq_IFunction |  1000 | 11,241.79 ns |  71.942 ns |  63.774 ns |  1.12 |    0.01 | 15.3809 |       - |     - |  32,248 B |
