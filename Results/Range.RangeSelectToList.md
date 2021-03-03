## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Start | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **10** |   **103.42 ns** |  **0.382 ns** |  **0.339 ns** |  **1.65** |    **0.01** | **0.0459** |     **-** |     **-** |      **96 B** |
|                       ValueLinq_Stack |     0 |    10 |   116.14 ns |  0.225 ns |  0.188 ns |  1.85 |    0.01 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   324.29 ns |  0.799 ns |  0.667 ns |  5.17 |    0.02 | 0.0458 |     - |     - |      96 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   220.07 ns |  0.431 ns |  0.360 ns |  3.51 |    0.01 | 0.0458 |     - |     - |      96 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |   100.64 ns |  0.315 ns |  0.294 ns |  1.60 |    0.01 | 0.0459 |     - |     - |      96 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |   102.21 ns |  0.307 ns |  0.272 ns |  1.63 |    0.01 | 0.0459 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   241.96 ns |  0.434 ns |  0.385 ns |  3.86 |    0.01 | 0.0458 |     - |     - |      96 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   220.57 ns |  0.390 ns |  0.346 ns |  3.51 |    0.01 | 0.0458 |     - |     - |      96 B |
|                               ForLoop |     0 |    10 |    62.77 ns |  0.244 ns |  0.204 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                           ForeachLoop |     0 |    10 |   125.94 ns |  0.348 ns |  0.309 ns |  2.01 |    0.01 | 0.1299 |     - |     - |     272 B |
|                                  Linq |     0 |    10 |    76.08 ns |  0.375 ns |  0.314 ns |  1.21 |    0.00 | 0.0880 |     - |     - |     184 B |
|                            LinqFaster |     0 |    10 |    64.07 ns |  0.349 ns |  0.310 ns |  1.02 |    0.01 | 0.1070 |     - |     - |     224 B |
|                                LinqAF |     0 |    10 |   154.19 ns |  0.701 ns |  0.655 ns |  2.46 |    0.01 | 0.1032 |     - |     - |     216 B |
|                            StructLinq |     0 |    10 |    53.85 ns |  0.157 ns |  0.139 ns |  0.86 |    0.00 | 0.0726 |     - |     - |     152 B |
|                  StructLinq_IFunction |     0 |    10 |    36.10 ns |  0.103 ns |  0.091 ns |  0.58 |    0.00 | 0.0459 |     - |     - |      96 B |
|                             Hyperlinq |     0 |    10 |    56.99 ns |  0.214 ns |  0.179 ns |  0.91 |    0.00 | 0.0459 |     - |     - |      96 B |
|                   Hyperlinq_IFunction |     0 |    10 |    45.02 ns |  0.135 ns |  0.120 ns |  0.72 |    0.00 | 0.0458 |     - |     - |      96 B |
|                        Hyperlinq_SIMD |     0 |    10 |    49.64 ns |  0.204 ns |  0.181 ns |  0.79 |    0.00 | 0.0458 |     - |     - |      96 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    34.39 ns |  0.106 ns |  0.094 ns |  0.55 |    0.00 | 0.0458 |     - |     - |      96 B |
|                                       |       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **2,902.97 ns** | **12.114 ns** | **10.116 ns** |  **1.36** |    **0.01** | **1.9379** |     **-** |     **-** |   **4,056 B** |
|                       ValueLinq_Stack |     0 |  1000 | 3,995.46 ns | 15.048 ns | 14.076 ns |  1.87 |    0.01 | 3.9291 |     - |     - |   8,232 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,242.58 ns |  4.945 ns |  4.129 ns |  1.52 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 3,814.49 ns | 16.238 ns | 15.189 ns |  1.79 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 2,181.40 ns |  6.373 ns |  5.650 ns |  1.02 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,601.78 ns |  5.538 ns |  4.909 ns |  1.22 |    0.00 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,425.01 ns |  6.882 ns |  6.101 ns |  1.14 |    0.01 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,428.11 ns | 13.562 ns | 12.686 ns |  1.14 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                               ForLoop |     0 |  1000 | 2,135.04 ns |  8.353 ns |  6.975 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|                           ForeachLoop |     0 |  1000 | 6,407.92 ns | 29.981 ns | 26.577 ns |  3.00 |    0.01 | 4.0436 |     - |     - |   8,480 B |
|                                  Linq |     0 |  1000 | 3,032.02 ns |  7.445 ns |  6.599 ns |  1.42 |    0.01 | 1.9798 |     - |     - |   4,144 B |
|                            LinqFaster |     0 |  1000 | 2,627.54 ns | 13.072 ns | 10.916 ns |  1.23 |    0.01 | 5.7793 |     - |     - |  12,104 B |
|                                LinqAF |     0 |  1000 | 6,036.26 ns | 26.478 ns | 23.472 ns |  2.83 |    0.02 | 4.0207 |     - |     - |   8,424 B |
|                            StructLinq |     0 |  1000 | 1,790.24 ns | 10.446 ns |  9.260 ns |  0.84 |    0.01 | 1.9646 |     - |     - |   4,112 B |
|                  StructLinq_IFunction |     0 |  1000 |   737.41 ns |  3.446 ns |  3.055 ns |  0.35 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                             Hyperlinq |     0 |  1000 | 1,843.46 ns |  9.286 ns |  8.232 ns |  0.86 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                   Hyperlinq_IFunction |     0 |  1000 | 1,267.20 ns |  5.116 ns |  4.535 ns |  0.59 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   542.06 ns |  2.380 ns |  2.226 ns |  0.25 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   314.23 ns |  0.856 ns |  0.759 ns |  0.15 |    0.00 | 1.9341 |     - |     - |   4,056 B |
