## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|                                Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |   **129.70 ns** |  **0.377 ns** |  **0.334 ns** |  **6.11** |    **0.03** | **0.0343** |     **-** |     **-** |      **72 B** |
|                       ValueLinq_Stack |     0 |   136.76 ns |  0.474 ns |  0.443 ns |  6.45 |    0.03 | 0.0343 |     - |     - |      72 B |
|             ValueLinq_SharedPool_Push |     0 |   437.98 ns |  1.750 ns |  1.551 ns | 20.65 |    0.10 | 0.0339 |     - |     - |      72 B |
|             ValueLinq_SharedPool_Pull |     0 |   253.17 ns |  1.196 ns |  0.998 ns | 11.94 |    0.07 | 0.0343 |     - |     - |      72 B |
|        ValueLinq_ValueLambda_Standard |     0 |   132.21 ns |  0.616 ns |  0.514 ns |  6.23 |    0.03 | 0.0341 |     - |     - |      72 B |
|           ValueLinq_ValueLambda_Stack |     0 |   131.05 ns |  0.835 ns |  0.741 ns |  6.18 |    0.04 | 0.0341 |     - |     - |      72 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |   375.85 ns |  1.630 ns |  1.445 ns | 17.72 |    0.09 | 0.0339 |     - |     - |      72 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |   270.00 ns |  0.916 ns |  0.812 ns | 12.73 |    0.05 | 0.0343 |     - |     - |      72 B |
|                           ForeachLoop |     0 |    21.21 ns |  0.075 ns |  0.067 ns |  1.00 |    0.00 | 0.0344 |     - |     - |      72 B |
|                                  Linq |     0 |    72.37 ns |  0.287 ns |  0.255 ns |  3.41 |    0.02 | 0.0917 |     - |     - |     192 B |
|                                LinqAF |     0 |    81.48 ns |  0.989 ns |  0.971 ns |  3.86 |    0.03 | 0.0343 |     - |     - |      72 B |
|                            StructLinq |     0 |    98.37 ns |  0.444 ns |  0.371 ns |  4.64 |    0.03 | 0.0879 |     - |     - |     184 B |
|                  StructLinq_IFunction |     0 |    74.81 ns |  0.183 ns |  0.162 ns |  3.53 |    0.01 | 0.0459 |     - |     - |      96 B |
|                             Hyperlinq |     0 |    61.80 ns |  0.286 ns |  0.239 ns |  2.91 |    0.02 | 0.0459 |     - |     - |      96 B |
|                   Hyperlinq_IFunction |     0 |    67.86 ns |  0.191 ns |  0.179 ns |  3.20 |    0.01 | 0.0459 |     - |     - |      96 B |
|                                       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |    **10** |   **225.94 ns** |  **0.905 ns** |  **0.803 ns** |  **2.28** |    **0.01** | **0.0801** |     **-** |     **-** |     **168 B** |
|                       ValueLinq_Stack |    10 |   231.38 ns |  0.863 ns |  0.807 ns |  2.33 |    0.01 | 0.0572 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Push |    10 |   467.78 ns |  1.314 ns |  1.165 ns |  4.72 |    0.02 | 0.0572 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Pull |    10 |   364.50 ns |  1.433 ns |  1.340 ns |  3.67 |    0.02 | 0.0572 |     - |     - |     120 B |
|        ValueLinq_ValueLambda_Standard |    10 |   217.25 ns |  0.590 ns |  0.523 ns |  2.19 |    0.01 | 0.0801 |     - |     - |     168 B |
|           ValueLinq_ValueLambda_Stack |    10 |   193.38 ns |  0.901 ns |  0.799 ns |  1.95 |    0.01 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   369.90 ns |  1.233 ns |  1.093 ns |  3.73 |    0.02 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   322.69 ns |  1.367 ns |  1.141 ns |  3.25 |    0.01 | 0.0572 |     - |     - |     120 B |
|                           ForeachLoop |    10 |    99.19 ns |  0.354 ns |  0.331 ns |  1.00 |    0.00 | 0.0802 |     - |     - |     168 B |
|                                  Linq |    10 |   182.19 ns |  0.589 ns |  0.522 ns |  1.84 |    0.01 | 0.1373 |     - |     - |     288 B |
|                                LinqAF |    10 |   203.63 ns |  0.924 ns |  0.820 ns |  2.05 |    0.01 | 0.0801 |     - |     - |     168 B |
|                            StructLinq |    10 |   216.21 ns |  0.731 ns |  0.648 ns |  2.18 |    0.01 | 0.0994 |     - |     - |     208 B |
|                  StructLinq_IFunction |    10 |   160.02 ns |  0.670 ns |  0.594 ns |  1.61 |    0.01 | 0.0572 |     - |     - |     120 B |
|                             Hyperlinq |    10 |   181.40 ns |  1.132 ns |  0.946 ns |  1.83 |    0.01 | 0.0572 |     - |     - |     120 B |
|                   Hyperlinq_IFunction |    10 |   152.07 ns |  0.974 ns |  0.863 ns |  1.53 |    0.01 | 0.0572 |     - |     - |     120 B |
|                                       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **8,106.74 ns** | **31.697 ns** | **26.469 ns** |  **1.46** |    **0.01** | **2.0752** |     **-** |     **-** |    **4344 B** |
|                       ValueLinq_Stack |  1000 | 8,679.42 ns | 57.258 ns | 47.813 ns |  1.56 |    0.01 | 1.9989 |     - |     - |    4200 B |
|             ValueLinq_SharedPool_Push |  1000 | 8,603.21 ns | 41.578 ns | 36.858 ns |  1.55 |    0.01 | 0.9918 |     - |     - |    2096 B |
|             ValueLinq_SharedPool_Pull |  1000 | 7,912.23 ns | 28.590 ns | 23.874 ns |  1.43 |    0.01 | 0.9918 |     - |     - |    2096 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 5,722.92 ns | 19.379 ns | 17.179 ns |  1.03 |    0.00 | 2.0752 |     - |     - |    4344 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 6,261.46 ns | 25.595 ns | 22.689 ns |  1.13 |    0.01 | 2.0065 |     - |     - |    4200 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 5,689.22 ns | 22.493 ns | 18.782 ns |  1.03 |    0.00 | 0.9995 |     - |     - |    2096 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 6,112.78 ns | 24.275 ns | 21.519 ns |  1.10 |    0.00 | 0.9995 |     - |     - |    2096 B |
|                           ForeachLoop |  1000 | 5,547.26 ns | 19.030 ns | 15.891 ns |  1.00 |    0.00 | 2.0752 |     - |     - |    4344 B |
|                                  Linq |  1000 | 7,650.50 ns | 23.570 ns | 20.895 ns |  1.38 |    0.01 | 2.1210 |     - |     - |    4464 B |
|                                LinqAF |  1000 | 8,822.31 ns | 54.330 ns | 48.162 ns |  1.59 |    0.01 | 2.0752 |     - |     - |    4344 B |
|                            StructLinq |  1000 | 8,236.74 ns | 34.232 ns | 30.346 ns |  1.49 |    0.01 | 1.0376 |     - |     - |    2184 B |
|                  StructLinq_IFunction |  1000 | 5,653.62 ns | 16.350 ns | 14.493 ns |  1.02 |    0.00 | 0.9995 |     - |     - |    2096 B |
|                             Hyperlinq |  1000 | 8,276.70 ns | 44.047 ns | 39.047 ns |  1.49 |    0.01 | 0.9918 |     - |     - |    2096 B |
|                   Hyperlinq_IFunction |  1000 | 5,700.70 ns | 14.935 ns | 13.970 ns |  1.03 |    0.00 | 0.9995 |     - |     - |    2096 B |
