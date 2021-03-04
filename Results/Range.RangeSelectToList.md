## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Start | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **10** |   **107.68 ns** |  **0.423 ns** |  **0.375 ns** |  **1.63** |    **0.01** | **0.0459** |     **-** |     **-** |      **96 B** |
|                       ValueLinq_Stack |     0 |    10 |   120.85 ns |  0.295 ns |  0.246 ns |  1.83 |    0.01 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   337.84 ns |  1.419 ns |  1.185 ns |  5.11 |    0.03 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   230.00 ns |  1.376 ns |  1.287 ns |  3.48 |    0.03 | 0.0458 |     - |     - |      96 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |   103.57 ns |  0.411 ns |  0.364 ns |  1.57 |    0.01 | 0.0459 |     - |     - |      96 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |   107.60 ns |  0.620 ns |  0.549 ns |  1.63 |    0.01 | 0.0459 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   243.54 ns |  0.801 ns |  0.749 ns |  3.68 |    0.02 | 0.0458 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   224.12 ns |  0.829 ns |  0.693 ns |  3.39 |    0.02 | 0.0458 |     - |     - |      96 B |
|                               ForLoop |     0 |    10 |    66.11 ns |  0.233 ns |  0.207 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                           ForeachLoop |     0 |    10 |   131.38 ns |  0.425 ns |  0.398 ns |  1.99 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                  Linq |     0 |    10 |    76.48 ns |  0.471 ns |  0.440 ns |  1.16 |    0.01 | 0.0879 |     - |     - |     184 B |
|                            LinqFaster |     0 |    10 |    66.29 ns |  0.317 ns |  0.297 ns |  1.00 |    0.01 | 0.1070 |     - |     - |     224 B |
|                                LinqAF |     0 |    10 |   160.89 ns |  0.819 ns |  0.684 ns |  2.43 |    0.02 | 0.1032 |     - |     - |     216 B |
|                            StructLinq |     0 |    10 |    61.53 ns |  0.382 ns |  0.357 ns |  0.93 |    0.01 | 0.0725 |     - |     - |     152 B |
|                  StructLinq_IFunction |     0 |    10 |    36.97 ns |  0.109 ns |  0.091 ns |  0.56 |    0.00 | 0.0459 |     - |     - |      96 B |
|                             Hyperlinq |     0 |    10 |    59.29 ns |  0.314 ns |  0.278 ns |  0.90 |    0.00 | 0.0459 |     - |     - |      96 B |
|                   Hyperlinq_IFunction |     0 |    10 |    46.76 ns |  0.193 ns |  0.161 ns |  0.71 |    0.00 | 0.0458 |     - |     - |      96 B |
|                        Hyperlinq_SIMD |     0 |    10 |    51.90 ns |  0.298 ns |  0.506 ns |  0.78 |    0.01 | 0.0459 |     - |     - |      96 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    35.46 ns |  0.157 ns |  0.139 ns |  0.54 |    0.00 | 0.0458 |     - |     - |      96 B |
|                                       |       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **3,030.96 ns** | **10.434 ns** |  **9.249 ns** |  **1.37** |    **0.01** | **1.9379** |     **-** |     **-** |   **4,056 B** |
|                       ValueLinq_Stack |     0 |  1000 | 4,232.82 ns | 17.685 ns | 16.542 ns |  1.91 |    0.02 | 3.9291 |     - |     - |   8,232 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,366.03 ns | 19.619 ns | 18.352 ns |  1.52 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 3,856.79 ns | 11.105 ns | 10.388 ns |  1.74 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 2,254.62 ns | 10.910 ns | 10.205 ns |  1.02 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,693.92 ns | 17.177 ns | 14.343 ns |  1.22 |    0.01 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,520.41 ns | 14.774 ns | 13.097 ns |  1.14 |    0.01 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,470.79 ns |  8.676 ns |  7.691 ns |  1.12 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                               ForLoop |     0 |  1000 | 2,213.22 ns | 17.496 ns | 15.509 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|                           ForeachLoop |     0 |  1000 | 6,684.77 ns | 23.511 ns | 21.992 ns |  3.02 |    0.03 | 4.0436 |     - |     - |   8,480 B |
|                                  Linq |     0 |  1000 | 3,116.46 ns | 13.157 ns | 12.307 ns |  1.41 |    0.01 | 1.9798 |     - |     - |   4,144 B |
|                            LinqFaster |     0 |  1000 | 2,980.59 ns | 26.546 ns | 24.831 ns |  1.35 |    0.02 | 5.7793 |     - |     - |  12,104 B |
|                                LinqAF |     0 |  1000 | 6,286.68 ns | 31.631 ns | 29.587 ns |  2.84 |    0.02 | 4.0207 |     - |     - |   8,424 B |
|                            StructLinq |     0 |  1000 | 2,125.83 ns | 14.246 ns | 13.326 ns |  0.96 |    0.01 | 1.9646 |     - |     - |   4,112 B |
|                  StructLinq_IFunction |     0 |  1000 |   764.29 ns |  5.585 ns |  5.225 ns |  0.35 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                             Hyperlinq |     0 |  1000 | 2,144.14 ns | 12.447 ns | 10.394 ns |  0.97 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                   Hyperlinq_IFunction |     0 |  1000 | 1,307.24 ns |  7.972 ns |  7.457 ns |  0.59 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   598.67 ns |  3.522 ns |  2.941 ns |  0.27 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   328.85 ns |  1.249 ns |  1.043 ns |  0.15 |    0.00 | 1.9341 |     - |     - |   4,056 B |
