## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                                        Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                            **ValueLinq_Standard** |    **10** |    **188.82 ns** |  **0.513 ns** |  **0.480 ns** |  **4.65** |    **0.02** | **0.0153** |     **-** |     **-** |      **32 B** |
|                               ValueLinq_Stack |    10 |    144.67 ns |  0.455 ns |  0.426 ns |  3.57 |    0.02 | 0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Push |    10 |    349.93 ns |  0.879 ns |  0.734 ns |  8.62 |    0.04 | 0.0153 |     - |     - |      32 B |
|                     ValueLinq_SharedPool_Pull |    10 |    276.10 ns |  0.940 ns |  0.833 ns |  6.80 |    0.05 | 0.0153 |     - |     - |      32 B |
|                ValueLinq_ValueLambda_Standard |    10 |    161.47 ns |  0.413 ns |  0.366 ns |  3.98 |    0.02 | 0.0150 |     - |     - |      32 B |
|                   ValueLinq_ValueLambda_Stack |    10 |    127.41 ns |  0.359 ns |  0.318 ns |  3.14 |    0.02 | 0.0150 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Push |    10 |    285.71 ns |  1.206 ns |  1.069 ns |  7.04 |    0.04 | 0.0153 |     - |     - |      32 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |    10 |    266.85 ns |  0.474 ns |  0.443 ns |  6.57 |    0.03 | 0.0153 |     - |     - |      32 B |
|                    ValueLinq_Standard_ByIndex |    10 |    159.93 ns |  0.453 ns |  0.402 ns |  3.94 |    0.02 | 0.0150 |     - |     - |      32 B |
|                       ValueLinq_Stack_ByIndex |    10 |    124.95 ns |  0.345 ns |  0.305 ns |  3.08 |    0.01 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push_ByIndex |    10 |    384.86 ns |  0.885 ns |  0.739 ns |  9.48 |    0.05 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull_ByIndex |    10 |    258.75 ns |  0.764 ns |  0.677 ns |  6.38 |    0.04 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |    10 |    146.10 ns |  0.755 ns |  0.669 ns |  3.60 |    0.02 | 0.0150 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |    10 |    111.52 ns |  0.301 ns |  0.267 ns |  2.75 |    0.01 | 0.0151 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |    10 |    290.02 ns |  0.573 ns |  0.508 ns |  7.15 |    0.03 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |    10 |    246.26 ns |  0.480 ns |  0.426 ns |  6.07 |    0.03 | 0.0153 |     - |     - |      32 B |
|                                       ForLoop |    10 |     40.58 ns |  0.213 ns |  0.178 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                                   ForeachLoop |    10 |     55.10 ns |  0.201 ns |  0.179 ns |  1.36 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                          Linq |    10 |    124.52 ns |  0.445 ns |  0.416 ns |  3.07 |    0.02 | 0.1070 |     - |     - |     224 B |
|                                    LinqFaster |    10 |     55.19 ns |  0.271 ns |  0.254 ns |  1.36 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                        LinqAF |    10 |    160.30 ns |  0.420 ns |  0.372 ns |  3.95 |    0.02 | 0.0341 |     - |     - |      72 B |
|                                    StructLinq |    10 |    124.62 ns |  0.415 ns |  0.347 ns |  3.07 |    0.02 | 0.0610 |     - |     - |     128 B |
|                          StructLinq_IFunction |    10 |     86.76 ns |  0.263 ns |  0.219 ns |  2.14 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     Hyperlinq |    10 |    103.56 ns |  0.332 ns |  0.277 ns |  2.55 |    0.02 | 0.0153 |     - |     - |      32 B |
|                           Hyperlinq_IFunction |    10 |     73.82 ns |  0.486 ns |  0.406 ns |  1.82 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                               |       |              |           |           |       |         |        |       |       |           |
|                            **ValueLinq_Standard** |  **1000** |  **7,434.48 ns** | **21.979 ns** | **19.484 ns** |  **2.27** |    **0.02** | **1.9760** |     **-** |     **-** |    **4144 B** |
|                               ValueLinq_Stack |  1000 |  7,218.70 ns | 18.692 ns | 15.609 ns |  2.21 |    0.02 | 1.9760 |     - |     - |    4144 B |
|                     ValueLinq_SharedPool_Push |  1000 |  5,418.93 ns | 16.251 ns | 14.407 ns |  1.66 |    0.01 | 0.9689 |     - |     - |    2040 B |
|                     ValueLinq_SharedPool_Pull |  1000 |  6,929.06 ns | 14.098 ns | 11.007 ns |  2.12 |    0.02 | 0.9689 |     - |     - |    2040 B |
|                ValueLinq_ValueLambda_Standard |  1000 |  7,835.74 ns | 26.549 ns | 23.535 ns |  2.40 |    0.01 | 1.9684 |     - |     - |    4144 B |
|                   ValueLinq_ValueLambda_Stack |  1000 |  7,928.15 ns | 30.872 ns | 27.367 ns |  2.43 |    0.02 | 1.9684 |     - |     - |    4144 B |
|         ValueLinq_ValueLambda_SharedPool_Push |  1000 |  2,930.99 ns | 21.127 ns | 18.729 ns |  0.90 |    0.01 | 0.9727 |     - |     - |    2040 B |
|         ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  7,740.64 ns | 33.332 ns | 31.179 ns |  2.37 |    0.02 | 0.9613 |     - |     - |    2040 B |
|                    ValueLinq_Standard_ByIndex |  1000 |  5,818.38 ns | 17.975 ns | 15.934 ns |  1.78 |    0.01 | 1.9760 |     - |     - |    4144 B |
|                       ValueLinq_Stack_ByIndex |  1000 |  5,865.37 ns | 16.155 ns | 15.112 ns |  1.79 |    0.01 | 1.9760 |     - |     - |    4144 B |
|             ValueLinq_SharedPool_Push_ByIndex |  1000 |  4,933.91 ns | 16.546 ns | 14.668 ns |  1.51 |    0.01 | 0.9689 |     - |     - |    2040 B |
|             ValueLinq_SharedPool_Pull_ByIndex |  1000 |  6,143.23 ns | 35.877 ns | 31.804 ns |  1.88 |    0.02 | 0.9689 |     - |     - |    2040 B |
|        ValueLinq_ValueLambda_Standard_ByIndex |  1000 |  2,552.28 ns |  9.218 ns |  7.197 ns |  0.78 |    0.01 | 1.9798 |     - |     - |    4144 B |
|           ValueLinq_ValueLambda_Stack_ByIndex |  1000 |  2,537.99 ns | 17.577 ns | 16.441 ns |  0.78 |    0.01 | 1.9798 |     - |     - |    4144 B |
| ValueLinq_ValueLambda_SharedPool_Push_ByIndex |  1000 |  2,839.81 ns | 13.785 ns | 12.895 ns |  0.87 |    0.01 | 0.9727 |     - |     - |    2040 B |
| ValueLinq_ValueLambda_SharedPool_Pull_ByIndex |  1000 |  2,493.56 ns |  8.545 ns |  7.575 ns |  0.76 |    0.01 | 0.9727 |     - |     - |    2040 B |
|                                       ForLoop |  1000 |  3,269.24 ns | 23.580 ns | 20.903 ns |  1.00 |    0.00 | 3.0289 |     - |     - |    6344 B |
|                                   ForeachLoop |  1000 |  4,651.41 ns | 16.527 ns | 13.801 ns |  1.42 |    0.01 | 3.0289 |     - |     - |    6344 B |
|                                          Linq |  1000 |  5,339.25 ns | 26.445 ns | 24.737 ns |  1.63 |    0.01 | 2.1896 |     - |     - |    4592 B |
|                                    LinqFaster |  1000 |  5,594.42 ns | 40.108 ns | 33.492 ns |  1.71 |    0.02 | 3.0289 |     - |     - |    6344 B |
|                                        LinqAF |  1000 | 13,138.55 ns | 22.885 ns | 20.287 ns |  4.02 |    0.03 | 3.0060 |     - |     - |    6312 B |
|                                    StructLinq |  1000 |  5,225.32 ns | 14.511 ns | 13.573 ns |  1.60 |    0.01 | 1.0147 |     - |     - |    2136 B |
|                          StructLinq_IFunction |  1000 |  2,885.85 ns | 12.466 ns | 11.050 ns |  0.88 |    0.01 | 0.9727 |     - |     - |    2040 B |
|                                     Hyperlinq |  1000 |  5,190.68 ns | 28.548 ns | 26.704 ns |  1.59 |    0.01 | 0.9689 |     - |     - |    2040 B |
|                           Hyperlinq_IFunction |  1000 |  3,484.09 ns |  6.614 ns |  5.863 ns |  1.07 |    0.01 | 0.9727 |     - |     - |    2040 B |
