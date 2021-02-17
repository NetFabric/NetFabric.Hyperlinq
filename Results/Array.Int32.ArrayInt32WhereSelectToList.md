## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                                Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **55.575 ns** |  **0.4054 ns** |  **0.3593 ns** |  **9.70** |    **0.10** | **0.0152** |     **-** |     **-** |      **32 B** |
|                       ValueLinq_Stack |     0 |    97.129 ns |  0.2638 ns |  0.2468 ns | 16.95 |    0.13 | 0.0151 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push |     0 |   303.743 ns |  1.0360 ns |  0.9691 ns | 53.02 |    0.43 | 0.0148 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull |     0 |   213.362 ns |  0.4981 ns |  0.4416 ns | 37.25 |    0.25 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard |     0 |    66.964 ns |  0.1468 ns |  0.1301 ns | 11.69 |    0.09 | 0.0151 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack |     0 |    94.378 ns |  0.6555 ns |  0.6132 ns | 16.47 |    0.19 | 0.0151 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   243.760 ns |  0.8216 ns |  0.7685 ns | 42.56 |    0.32 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   214.825 ns |  0.3717 ns |  0.3104 ns | 37.51 |    0.25 | 0.0153 |     - |     - |      32 B |
|                               ForLoop |     0 |     5.729 ns |  0.0469 ns |  0.0416 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                           ForeachLoop |     0 |     5.769 ns |  0.0393 ns |  0.0367 ns |  1.01 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                  Linq |     0 |    32.012 ns |  0.1540 ns |  0.1365 ns |  5.59 |    0.06 | 0.0152 |     - |     - |      32 B |
|                            LinqFaster |     0 |    23.898 ns |  0.1332 ns |  0.1246 ns |  4.17 |    0.04 | 0.0268 |     - |     - |      56 B |
|                                LinqAF |     0 |    61.647 ns |  0.1682 ns |  0.1404 ns | 10.76 |    0.07 | 0.0151 |     - |     - |      32 B |
|                            StructLinq |     0 |    81.676 ns |  0.4530 ns |  0.4237 ns | 14.26 |    0.12 | 0.0726 |     - |     - |     152 B |
|                  StructLinq_IFunction |     0 |    61.281 ns |  0.3788 ns |  0.3543 ns | 10.70 |    0.08 | 0.0267 |     - |     - |      56 B |
|                             Hyperlinq |     0 |    20.739 ns |  0.0802 ns |  0.0669 ns |  3.62 |    0.03 | 0.0153 |     - |     - |      32 B |
|                   Hyperlinq_IFunction |     0 |    19.130 ns |  0.0851 ns |  0.0754 ns |  3.34 |    0.03 | 0.0153 |     - |     - |      32 B |
|                                       |       |              |            |            |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |    **10** |   **193.577 ns** |  **0.9610 ns** |  **0.8519 ns** |  **7.33** |    **0.05** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |    10 |   148.860 ns |  0.4593 ns |  0.4297 ns |  5.64 |    0.02 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |    10 |   356.977 ns |  1.4159 ns |  1.2552 ns | 13.53 |    0.08 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |    10 |   262.663 ns |  1.1241 ns |  1.0514 ns |  9.95 |    0.04 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |    10 |   173.291 ns |  0.5878 ns |  0.4908 ns |  6.57 |    0.03 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |    10 |   130.231 ns |  0.3945 ns |  0.3497 ns |  4.94 |    0.03 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   284.316 ns |  0.8219 ns |  0.7688 ns | 10.78 |    0.06 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   256.780 ns |  1.1838 ns |  0.9242 ns |  9.73 |    0.04 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |    10 |    26.385 ns |  0.1333 ns |  0.1113 ns |  1.00 |    0.00 | 0.0343 |     - |     - |      72 B |
|                           ForeachLoop |    10 |    26.218 ns |  0.1526 ns |  0.1274 ns |  0.99 |    0.01 | 0.0343 |     - |     - |      72 B |
|                                  Linq |    10 |    96.127 ns |  0.4812 ns |  0.4266 ns |  3.64 |    0.02 | 0.0842 |     - |     - |     176 B |
|                            LinqFaster |    10 |    72.314 ns |  0.4104 ns |  0.3839 ns |  2.74 |    0.02 | 0.0763 |     - |     - |     160 B |
|                                LinqAF |    10 |   101.564 ns |  0.3377 ns |  0.2820 ns |  3.85 |    0.02 | 0.0343 |     - |     - |      72 B |
|                            StructLinq |    10 |   145.236 ns |  0.6657 ns |  0.5559 ns |  5.50 |    0.03 | 0.0763 |     - |     - |     160 B |
|                  StructLinq_IFunction |    10 |    99.517 ns |  0.3090 ns |  0.2580 ns |  3.77 |    0.02 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq |    10 |   116.971 ns |  0.2728 ns |  0.2418 ns |  4.43 |    0.02 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |    10 |    95.650 ns |  0.3390 ns |  0.2831 ns |  3.63 |    0.02 | 0.0305 |     - |     - |      64 B |
|                                       |       |              |            |            |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **5,315.547 ns** | **24.5190 ns** | **20.4745 ns** |  **2.33** |    **0.01** | **2.0523** |     **-** |     **-** |    **4304 B** |
|                       ValueLinq_Stack |  1000 | 6,044.039 ns | 16.7413 ns | 13.9797 ns |  2.65 |    0.02 | 1.9913 |     - |     - |    4176 B |
|             ValueLinq_SharedPool_Push |  1000 | 5,355.572 ns | 15.9107 ns | 14.1045 ns |  2.35 |    0.01 | 0.9842 |     - |     - |    2072 B |
|             ValueLinq_SharedPool_Pull |  1000 | 6,894.389 ns | 24.6807 ns | 21.8788 ns |  3.02 |    0.02 | 0.9842 |     - |     - |    2072 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 2,619.791 ns | 15.1084 ns | 13.3932 ns |  1.15 |    0.00 | 2.0561 |     - |     - |    4304 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 2,680.530 ns |  7.8196 ns |  7.3145 ns |  1.17 |    0.00 | 1.9951 |     - |     - |    4176 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 2,986.825 ns |  9.0111 ns |  7.9881 ns |  1.31 |    0.01 | 0.9880 |     - |     - |    2072 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 2,865.919 ns | 16.8577 ns | 14.9439 ns |  1.26 |    0.01 | 0.9880 |     - |     - |    2072 B |
|                               ForLoop |  1000 | 2,281.337 ns | 13.0781 ns | 10.9208 ns |  1.00 |    0.00 | 2.0561 |     - |     - |    4304 B |
|                           ForeachLoop |  1000 | 2,283.274 ns | 21.6621 ns | 18.0888 ns |  1.00 |    0.01 | 2.0561 |     - |     - |    4304 B |
|                                  Linq |  1000 | 5,152.996 ns | 22.4536 ns | 19.9046 ns |  2.26 |    0.01 | 2.1057 |     - |     - |    4408 B |
|                            LinqFaster |  1000 | 4,890.452 ns | 15.5524 ns | 13.7868 ns |  2.14 |    0.01 | 3.8834 |     - |     - |    8136 B |
|                                LinqAF |  1000 | 7,376.094 ns | 21.3192 ns | 17.8025 ns |  3.23 |    0.01 | 2.0523 |     - |     - |    4304 B |
|                            StructLinq |  1000 | 5,864.412 ns | 25.4399 ns | 23.7965 ns |  2.57 |    0.02 | 1.0300 |     - |     - |    2168 B |
|                  StructLinq_IFunction |  1000 | 2,938.155 ns | 13.4408 ns | 11.2237 ns |  1.29 |    0.01 | 0.9880 |     - |     - |    2072 B |
|                             Hyperlinq |  1000 | 5,312.576 ns | 23.3876 ns | 19.5297 ns |  2.33 |    0.01 | 0.9842 |     - |     - |    2072 B |
|                   Hyperlinq_IFunction |  1000 | 2,677.467 ns | 12.5828 ns | 11.7699 ns |  1.17 |    0.01 | 0.9880 |     - |     - |    2072 B |
