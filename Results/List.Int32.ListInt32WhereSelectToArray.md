## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                                        Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **183.76 ns** |  **0.335 ns** |  **0.280 ns** |  **4.77** |    **0.01** | **0.0150** |     **-** |     **-** |      **32 B** |
|                               ValueLinq_Stack |    10 |    144.53 ns |  0.432 ns |  0.404 ns |  3.75 |    0.01 | 0.0150 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Push |    10 |    355.72 ns |  0.619 ns |  0.549 ns |  9.24 |    0.03 | 0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Pull |    10 |    280.96 ns |  0.617 ns |  0.577 ns |  7.30 |    0.02 | 0.0153 |     - |     - |      32 B |
|                ValueLinq_ValueLambda_Standard |    10 |    162.66 ns |  0.341 ns |  0.302 ns |  4.22 |    0.02 | 0.0150 |     - |     - |      32 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    127.35 ns |  0.393 ns |  0.348 ns |  3.31 |    0.01 | 0.0153 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    285.27 ns |  0.972 ns |  0.862 ns |  7.41 |    0.02 | 0.0153 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    271.17 ns |  0.581 ns |  0.515 ns |  7.04 |    0.03 | 0.0153 |     - |     - |      32 B |
|                    ValueLinq_Standard_ByIndex |    10 |    160.74 ns |  0.470 ns |  0.416 ns |  4.17 |    0.02 | 0.0153 |     - |     - |      32 B |
|                       ValueLinq_Stack_ByIndex |    10 |    123.83 ns |  0.339 ns |  0.283 ns |  3.22 |    0.01 | 0.0150 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    369.67 ns |  0.899 ns |  0.841 ns |  9.60 |    0.03 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    261.41 ns |  0.816 ns |  0.723 ns |  6.79 |    0.03 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    146.31 ns |  0.624 ns |  0.553 ns |  3.80 |    0.01 | 0.0150 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    112.77 ns |  0.161 ns |  0.134 ns |  2.93 |    0.01 | 0.0151 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    290.52 ns |  0.884 ns |  0.739 ns |  7.54 |    0.03 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    248.06 ns |  0.800 ns |  0.709 ns |  6.44 |    0.03 | 0.0153 |     - |     - |      32 B |
|                                       ForLoop |    10 |     38.51 ns |  0.111 ns |  0.099 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                                   ForeachLoop |    10 |     57.04 ns |  0.282 ns |  0.250 ns |  1.48 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                          Linq |    10 |    121.72 ns |  0.461 ns |  0.409 ns |  3.16 |    0.01 | 0.1068 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     56.86 ns |  0.350 ns |  0.292 ns |  1.48 |    0.01 | 0.0496 |     - |     - |     104 B |
|                                        LinqAF |    10 |    161.65 ns |  0.523 ns |  0.437 ns |  4.20 |    0.02 | 0.0341 |     - |     - |      72 B |
|                                    StructLinq |    10 |    130.02 ns |  0.226 ns |  0.176 ns |  3.38 |    0.01 | 0.0610 |     - |     - |     128 B |
|                          StructLinq_IFunction |    10 |     87.82 ns |  0.177 ns |  0.157 ns |  2.28 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     Hyperlinq |    10 |    106.90 ns |  0.317 ns |  0.297 ns |  2.78 |    0.01 | 0.0153 |     - |     - |      32 B |
|                           Hyperlinq_IFunction |    10 |     81.71 ns |  0.191 ns |  0.169 ns |  2.12 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                               |       |              |           |           |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **7,734.62 ns** | **10.763 ns** |  **9.541 ns** |  **2.39** |    **0.01** | **1.9684** |     **-** |     **-** |   **4,144 B** |
|                               ValueLinq_Stack |  1000 |  7,300.52 ns | 21.446 ns | 19.011 ns |  2.25 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|                     ValueLinq_SharedPool_Push |  1000 |  5,263.35 ns | 11.880 ns | 10.531 ns |  1.62 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  7,174.05 ns | 13.071 ns | 11.587 ns |  2.21 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  7,408.48 ns | 23.560 ns | 22.038 ns |  2.29 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  7,212.78 ns | 18.150 ns | 16.090 ns |  2.23 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  3,789.91 ns |  8.040 ns |  7.127 ns |  1.17 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  8,083.60 ns | 14.682 ns | 13.016 ns |  2.50 |    0.01 | 0.9613 |     - |     - |   2,040 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  6,210.86 ns | 15.235 ns | 13.506 ns |  1.92 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  6,718.00 ns | 31.583 ns | 26.373 ns |  2.07 |    0.01 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  5,502.95 ns | 14.137 ns | 11.805 ns |  1.70 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  6,100.70 ns | 10.527 ns |  9.332 ns |  1.88 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  2,427.07 ns | 10.986 ns |  9.739 ns |  0.75 |    0.00 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  2,545.35 ns |  9.706 ns |  9.079 ns |  0.79 |    0.01 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  2,989.63 ns |  8.605 ns |  7.628 ns |  0.92 |    0.00 | 0.9727 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,501.45 ns | 25.102 ns | 22.252 ns |  0.77 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                                       ForLoop |  1000 |  3,239.97 ns | 18.747 ns | 15.655 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                                   ForeachLoop |  1000 |  4,652.54 ns | 44.776 ns | 39.693 ns |  1.44 |    0.02 | 3.0289 |     - |     - |   6,344 B |
|                                          Linq |  1000 |  5,553.37 ns | 19.236 ns | 17.993 ns |  1.71 |    0.01 | 2.1896 |     - |     - |   4,592 B |
|                                    LinqFaster |  1000 |  5,975.44 ns | 34.921 ns | 30.957 ns |  1.84 |    0.01 | 3.0289 |     - |     - |   6,344 B |
|                                        LinqAF |  1000 | 12,725.67 ns | 20.448 ns | 17.075 ns |  3.93 |    0.02 | 3.0060 |     - |     - |   6,312 B |
|                                    StructLinq |  1000 |  5,856.75 ns | 24.407 ns | 20.381 ns |  1.81 |    0.01 | 1.0147 |     - |     - |   2,136 B |
|                          StructLinq_IFunction |  1000 |  2,883.65 ns |  8.305 ns |  7.362 ns |  0.89 |    0.00 | 0.9727 |     - |     - |   2,040 B |
|                                     Hyperlinq |  1000 |  5,042.46 ns | 20.269 ns | 16.926 ns |  1.56 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                           Hyperlinq_IFunction |  1000 |  2,393.10 ns | 10.533 ns |  9.337 ns |  0.74 |    0.00 | 0.9727 |     - |     - |   2,040 B |
