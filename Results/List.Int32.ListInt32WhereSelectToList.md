## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                                        Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **221.32 ns** |  **1.517 ns** |  **1.419 ns** |  **6.31** |    **0.07** | **0.0305** |     **-** |     **-** |      **64 B** |
|                               ValueLinq_Stack |    10 |    181.16 ns |  1.776 ns |  1.575 ns |  5.17 |    0.07 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Push |    10 |    374.21 ns |  1.897 ns |  1.584 ns | 10.68 |    0.10 | 0.0305 |     - |     - |      64 B |
|                     ValueLinq_SharedPool_Pull |    10 |    305.27 ns |  2.168 ns |  1.810 ns |  8.71 |    0.07 | 0.0305 |     - |     - |      64 B |
|                ValueLinq_ValueLambda_Standard |    10 |    195.43 ns |  1.319 ns |  1.234 ns |  5.58 |    0.06 | 0.0305 |     - |     - |      64 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    155.35 ns |  0.834 ns |  0.696 ns |  4.43 |    0.04 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    305.14 ns |  2.270 ns |  1.773 ns |  8.71 |    0.09 | 0.0305 |     - |     - |      64 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    286.38 ns |  1.365 ns |  1.210 ns |  8.17 |    0.08 | 0.0305 |     - |     - |      64 B |
|                    ValueLinq_Standard_ByIndex |    10 |    193.55 ns |  1.410 ns |  1.250 ns |  5.53 |    0.06 | 0.0303 |     - |     - |      64 B |
|                       ValueLinq_Stack_ByIndex |    10 |    154.95 ns |  1.322 ns |  1.172 ns |  4.42 |    0.05 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    389.11 ns |  2.139 ns |  1.786 ns | 11.11 |    0.11 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    277.31 ns |  1.595 ns |  1.332 ns |  7.92 |    0.09 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    178.87 ns |  1.608 ns |  1.425 ns |  5.11 |    0.07 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    146.22 ns |  0.986 ns |  0.770 ns |  4.17 |    0.05 | 0.0303 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    310.80 ns |  1.168 ns |  0.976 ns |  8.87 |    0.09 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    258.55 ns |  1.666 ns |  1.391 ns |  7.38 |    0.08 | 0.0305 |     - |     - |      64 B |
|                                       ForLoop |    10 |     35.03 ns |  0.386 ns |  0.322 ns |  1.00 |    0.00 | 0.0343 |     - |     - |      72 B |
|                                   ForeachLoop |    10 |     48.23 ns |  0.304 ns |  0.254 ns |  1.38 |    0.01 | 0.0344 |     - |     - |      72 B |
|                                          Linq |    10 |    114.97 ns |  0.451 ns |  0.376 ns |  3.28 |    0.03 | 0.1070 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     75.28 ns |  0.577 ns |  0.512 ns |  2.15 |    0.03 | 0.0650 |     - |     - |     136 B |
|                                        LinqAF |    10 |    163.84 ns |  0.716 ns |  0.634 ns |  4.67 |    0.05 | 0.0343 |     - |     - |      72 B |
|                                    StructLinq |    10 |    150.03 ns |  0.711 ns |  0.630 ns |  4.28 |    0.04 | 0.0763 |     - |     - |     160 B |
|                          StructLinq_IFunction |    10 |    102.68 ns |  1.316 ns |  1.166 ns |  2.93 |    0.04 | 0.0305 |     - |     - |      64 B |
|                                     Hyperlinq |    10 |    115.83 ns |  0.852 ns |  0.755 ns |  3.30 |    0.04 | 0.0305 |     - |     - |      64 B |
|                           Hyperlinq_IFunction |    10 |     95.62 ns |  0.505 ns |  0.421 ns |  2.73 |    0.03 | 0.0305 |     - |     - |      64 B |
|                                               |       |              |           |           |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **5,458.54 ns** | **38.912 ns** | **36.398 ns** |  **1.52** |    **0.01** | **2.0523** |     **-** |     **-** |   **4,304 B** |
|                               ValueLinq_Stack |  1000 |  8,616.33 ns | 36.553 ns | 32.403 ns |  2.39 |    0.02 | 1.9836 |     - |     - |   4,176 B |
|                     ValueLinq_SharedPool_Push |  1000 |  5,546.87 ns | 33.163 ns | 29.399 ns |  1.54 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  7,961.86 ns | 38.974 ns | 34.550 ns |  2.21 |    0.02 | 0.9766 |     - |     - |   2,072 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  3,636.60 ns | 10.744 ns |  8.972 ns |  1.01 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  8,591.68 ns | 40.171 ns | 35.610 ns |  2.39 |    0.02 | 1.9836 |     - |     - |   4,176 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  3,102.92 ns | 16.207 ns | 13.533 ns |  0.86 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  8,406.90 ns | 44.412 ns | 37.086 ns |  2.34 |    0.02 | 0.9766 |     - |     - |   2,072 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  5,449.95 ns | 40.042 ns | 33.436 ns |  1.51 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  6,515.31 ns | 50.467 ns | 44.738 ns |  1.81 |    0.02 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  6,062.33 ns | 23.283 ns | 20.640 ns |  1.68 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  7,457.52 ns | 42.483 ns | 37.660 ns |  2.07 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  4,421.41 ns | 16.525 ns | 13.799 ns |  1.23 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  3,735.09 ns | 31.064 ns | 25.940 ns |  1.04 |    0.01 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  3,036.31 ns | 21.117 ns | 18.720 ns |  0.84 |    0.01 | 0.9880 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,743.17 ns | 41.771 ns | 39.073 ns |  0.76 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                                       ForLoop |  1000 |  3,600.34 ns | 19.947 ns | 18.659 ns |  1.00 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                                   ForeachLoop |  1000 |  4,146.51 ns | 29.642 ns | 24.753 ns |  1.15 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|                                          Linq |  1000 |  5,734.16 ns | 25.384 ns | 21.197 ns |  1.59 |    0.01 | 2.1286 |     - |     - |   4,456 B |
|                                    LinqFaster |  1000 |  6,438.45 ns | 30.179 ns | 28.229 ns |  1.79 |    0.01 | 3.0441 |     - |     - |   6,376 B |
|                                        LinqAF |  1000 | 13,415.95 ns | 82.248 ns | 72.911 ns |  3.73 |    0.02 | 2.0447 |     - |     - |   4,304 B |
|                                    StructLinq |  1000 |  5,527.67 ns | 30.771 ns | 27.278 ns |  1.54 |    0.01 | 1.0300 |     - |     - |   2,168 B |
|                          StructLinq_IFunction |  1000 |  3,137.86 ns | 34.657 ns | 30.722 ns |  0.87 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                                     Hyperlinq |  1000 |  5,650.76 ns | 44.101 ns | 36.826 ns |  1.57 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|                           Hyperlinq_IFunction |  1000 |  3,817.85 ns | 25.099 ns | 23.477 ns |  1.06 |    0.01 | 0.9842 |     - |     - |   2,072 B |
