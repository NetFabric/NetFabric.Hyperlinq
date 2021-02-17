## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta38](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta38)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |     **0** |    **50.046 ns** |  **1.0291 ns** |  **0.9626 ns** |  **9.02** |    **0.18** | **0.0152** |     **-** |     **-** |      **32 B** |
|                       ValueLinq_Stack |     0 |     0 |    69.308 ns |  0.8572 ns |  0.7599 ns | 12.50 |    0.14 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push |     0 |     0 |   251.822 ns |  1.3101 ns |  1.1614 ns | 45.42 |    0.37 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull |     0 |     0 |   173.077 ns |  2.8663 ns |  2.6812 ns | 31.20 |    0.48 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard |     0 |     0 |    45.338 ns |  0.9673 ns |  0.9500 ns |  8.16 |    0.17 | 0.0153 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack |     0 |     0 |    70.164 ns |  0.9320 ns |  0.8718 ns | 12.65 |    0.19 | 0.0151 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |     0 |   179.693 ns |  1.7030 ns |  1.5930 ns | 32.46 |    0.30 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |     0 |   171.792 ns |  0.7048 ns |  0.5503 ns | 31.00 |    0.21 | 0.0153 |     - |     - |      32 B |
|                               ForLoop |     0 |     0 |     5.545 ns |  0.0382 ns |  0.0338 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                           ForeachLoop |     0 |     0 |    29.028 ns |  0.1034 ns |  0.0917 ns |  5.24 |    0.03 | 0.0421 |     - |     - |      88 B |
|                                  Linq |     0 |     0 |    25.677 ns |  0.0468 ns |  0.0365 ns |  4.63 |    0.03 | 0.0153 |     - |     - |      32 B |
|                            LinqFaster |     0 |     0 |    26.083 ns |  0.0872 ns |  0.0816 ns |  4.71 |    0.03 | 0.0382 |     - |     - |      80 B |
|                                LinqAF |     0 |     0 |    45.548 ns |  0.1635 ns |  0.1450 ns |  8.22 |    0.06 | 0.0153 |     - |     - |      32 B |
|                            StructLinq |     0 |     0 |    37.445 ns |  0.1286 ns |  0.1140 ns |  6.75 |    0.05 | 0.0535 |     - |     - |     112 B |
|                  StructLinq_IFunction |     0 |     0 |    29.045 ns |  0.1040 ns |  0.0868 ns |  5.24 |    0.04 | 0.0267 |     - |     - |      56 B |
|                             Hyperlinq |     0 |     0 |    31.795 ns |  0.1580 ns |  0.1401 ns |  5.73 |    0.05 | 0.0267 |     - |     - |      56 B |
|                   Hyperlinq_IFunction |     0 |     0 |    29.861 ns |  0.1553 ns |  0.1453 ns |  5.39 |    0.04 | 0.0267 |     - |     - |      56 B |
|                        Hyperlinq_SIMD |     0 |     0 |    17.330 ns |  0.0707 ns |  0.0661 ns |  3.13 |    0.02 | 0.0153 |     - |     - |      32 B |
|              Hyperlinq_IFunction_SIMD |     0 |     0 |    19.128 ns |  0.0850 ns |  0.0795 ns |  3.45 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                       |       |       |              |            |            |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |    **10** |   **102.244 ns** |  **0.3075 ns** |  **0.2877 ns** |  **1.65** |    **0.01** | **0.0459** |     **-** |     **-** |      **96 B** |
|                       ValueLinq_Stack |     0 |    10 |   115.094 ns |  0.4185 ns |  0.3710 ns |  1.86 |    0.01 | 0.0459 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   316.737 ns |  0.8170 ns |  0.6379 ns |  5.12 |    0.02 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   222.720 ns |  1.6770 ns |  1.5687 ns |  3.60 |    0.03 | 0.0458 |     - |     - |      96 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |    99.434 ns |  0.3581 ns |  0.3350 ns |  1.61 |    0.01 | 0.0459 |     - |     - |      96 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |   102.738 ns |  0.2927 ns |  0.2738 ns |  1.66 |    0.01 | 0.0459 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   240.554 ns |  1.4447 ns |  1.2807 ns |  3.89 |    0.03 | 0.0458 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   211.686 ns |  1.0299 ns |  0.8041 ns |  3.42 |    0.01 | 0.0458 |     - |     - |      96 B |
|                               ForLoop |     0 |    10 |    61.878 ns |  0.2429 ns |  0.2272 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                           ForeachLoop |     0 |    10 |   123.285 ns |  0.6173 ns |  0.5774 ns |  1.99 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                  Linq |     0 |    10 |    77.314 ns |  0.4342 ns |  0.4061 ns |  1.25 |    0.01 | 0.0880 |     - |     - |     184 B |
|                            LinqFaster |     0 |    10 |    64.814 ns |  0.6030 ns |  0.5345 ns |  1.05 |    0.01 | 0.1070 |     - |     - |     224 B |
|                                LinqAF |     0 |    10 |   149.693 ns |  0.6793 ns |  0.6354 ns |  2.42 |    0.01 | 0.1032 |     - |     - |     216 B |
|                            StructLinq |     0 |    10 |    52.980 ns |  0.1933 ns |  0.1808 ns |  0.86 |    0.00 | 0.0726 |     - |     - |     152 B |
|                  StructLinq_IFunction |     0 |    10 |    36.553 ns |  0.1700 ns |  0.1419 ns |  0.59 |    0.00 | 0.0458 |     - |     - |      96 B |
|                             Hyperlinq |     0 |    10 |    47.868 ns |  0.1534 ns |  0.1281 ns |  0.77 |    0.00 | 0.0458 |     - |     - |      96 B |
|                   Hyperlinq_IFunction |     0 |    10 |    40.629 ns |  0.3044 ns |  0.2699 ns |  0.66 |    0.00 | 0.0458 |     - |     - |      96 B |
|                        Hyperlinq_SIMD |     0 |    10 |    51.795 ns |  0.2455 ns |  0.2297 ns |  0.84 |    0.00 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    43.674 ns |  0.1365 ns |  0.1277 ns |  0.71 |    0.00 | 0.0458 |     - |     - |      96 B |
|                                       |       |       |              |            |            |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **2,906.916 ns** | **47.2935 ns** | **41.9245 ns** |  **1.37** |    **0.02** | **1.9379** |     **-** |     **-** |    **4056 B** |
|                       ValueLinq_Stack |     0 |  1000 | 4,412.339 ns | 24.9975 ns | 23.3826 ns |  2.08 |    0.02 | 3.9291 |     - |     - |    8232 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,173.806 ns |  9.2375 ns |  8.1888 ns |  1.50 |    0.01 | 1.9379 |     - |     - |    4056 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 3,457.220 ns | 31.4418 ns | 26.2553 ns |  1.63 |    0.01 | 1.9379 |     - |     - |    4056 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 2,163.111 ns | 11.9787 ns | 10.6188 ns |  1.02 |    0.01 | 1.9379 |     - |     - |    4056 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,548.011 ns |  6.7649 ns |  6.3279 ns |  1.20 |    0.01 | 3.9330 |     - |     - |    8232 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,411.688 ns |  8.6724 ns |  8.1121 ns |  1.14 |    0.01 | 1.9379 |     - |     - |    4056 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,440.687 ns | 11.7298 ns | 10.9721 ns |  1.15 |    0.01 | 1.9379 |     - |     - |    4056 B |
|                               ForLoop |     0 |  1000 | 2,122.303 ns | 19.1443 ns | 17.9076 ns |  1.00 |    0.00 | 4.0207 |     - |     - |    8424 B |
|                           ForeachLoop |     0 |  1000 | 6,327.077 ns | 36.3432 ns | 32.2173 ns |  2.98 |    0.02 | 4.0436 |     - |     - |    8480 B |
|                                  Linq |     0 |  1000 | 3,014.207 ns |  7.5536 ns |  6.3076 ns |  1.42 |    0.01 | 1.9798 |     - |     - |    4144 B |
|                            LinqFaster |     0 |  1000 | 2,735.088 ns | 11.6679 ns | 10.9142 ns |  1.29 |    0.01 | 5.7793 |     - |     - |   12104 B |
|                                LinqAF |     0 |  1000 | 5,701.217 ns | 21.2947 ns | 19.9190 ns |  2.69 |    0.02 | 4.0207 |     - |     - |    8424 B |
|                            StructLinq |     0 |  1000 | 1,778.677 ns |  9.9762 ns |  8.3305 ns |  0.84 |    0.01 | 1.9646 |     - |     - |    4112 B |
|                  StructLinq_IFunction |     0 |  1000 |   737.236 ns |  6.5625 ns |  6.1386 ns |  0.35 |    0.00 | 1.9379 |     - |     - |    4056 B |
|                             Hyperlinq |     0 |  1000 | 2,336.945 ns | 23.2007 ns | 21.7020 ns |  1.10 |    0.01 | 1.9379 |     - |     - |    4056 B |
|                   Hyperlinq_IFunction |     0 |  1000 | 1,242.339 ns |  2.6448 ns |  2.3446 ns |  0.59 |    0.01 | 1.9379 |     - |     - |    4056 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   587.365 ns |  3.2042 ns |  2.9972 ns |  0.28 |    0.00 | 1.9341 |     - |     - |    4056 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   336.839 ns |  2.5470 ns |  2.3825 ns |  0.16 |    0.00 | 1.9341 |     - |     - |    4056 B |
