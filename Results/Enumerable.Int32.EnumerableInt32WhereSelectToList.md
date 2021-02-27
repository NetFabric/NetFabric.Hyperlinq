## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|                                Method | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **243.6 ns** |   **2.49 ns** |   **2.08 ns** |  **2.26** |    **0.02** | **0.0801** |     **-** |     **-** |     **168 B** |
|                       ValueLinq_Stack |    10 |   246.1 ns |   1.23 ns |   0.96 ns |  2.29 |    0.02 | 0.0567 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Push |    10 |   482.6 ns |   3.60 ns |   3.01 ns |  4.48 |    0.05 | 0.0572 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Pull |    10 |   362.6 ns |   3.87 ns |   3.24 ns |  3.37 |    0.03 | 0.0572 |     - |     - |     120 B |
|        ValueLinq_ValueLambda_Standard |    10 |   225.2 ns |   3.36 ns |   2.98 ns |  2.09 |    0.03 | 0.0801 |     - |     - |     168 B |
|           ValueLinq_ValueLambda_Stack |    10 |   207.9 ns |   0.98 ns |   0.82 ns |  1.93 |    0.02 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   391.9 ns |   1.20 ns |   1.00 ns |  3.64 |    0.03 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   339.5 ns |   2.72 ns |   2.54 ns |  3.15 |    0.04 | 0.0572 |     - |     - |     120 B |
|                           ForeachLoop |    10 |   107.6 ns |   0.86 ns |   0.77 ns |  1.00 |    0.00 | 0.0802 |     - |     - |     168 B |
|                                  Linq |    10 |   192.9 ns |   1.30 ns |   1.15 ns |  1.79 |    0.02 | 0.1373 |     - |     - |     288 B |
|                                LinqAF |    10 |   211.8 ns |   2.16 ns |   1.91 ns |  1.97 |    0.02 | 0.0801 |     - |     - |     168 B |
|                            StructLinq |    10 |   233.0 ns |   1.45 ns |   1.29 ns |  2.16 |    0.02 | 0.0992 |     - |     - |     208 B |
|                  StructLinq_IFunction |    10 |   164.6 ns |   0.62 ns |   0.52 ns |  1.53 |    0.01 | 0.0572 |     - |     - |     120 B |
|                             Hyperlinq |    10 |   185.6 ns |   0.78 ns |   0.69 ns |  1.72 |    0.01 | 0.0572 |     - |     - |     120 B |
|                   Hyperlinq_IFunction |    10 |   153.2 ns |   0.67 ns |   0.60 ns |  1.42 |    0.01 | 0.0572 |     - |     - |     120 B |
|                                       |       |            |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **8,589.9 ns** |  **32.85 ns** |  **29.12 ns** |  **1.43** |    **0.01** | **2.0752** |     **-** |     **-** |   **4,344 B** |
|                       ValueLinq_Stack |  1000 | 8,266.2 ns |  35.07 ns |  31.09 ns |  1.37 |    0.01 | 1.9989 |     - |     - |   4,200 B |
|             ValueLinq_SharedPool_Push |  1000 | 8,690.5 ns |  43.00 ns |  38.12 ns |  1.45 |    0.01 | 0.9918 |     - |     - |   2,096 B |
|             ValueLinq_SharedPool_Pull |  1000 | 8,227.0 ns | 124.75 ns | 104.17 ns |  1.37 |    0.02 | 0.9918 |     - |     - |   2,096 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 5,662.4 ns |  53.01 ns |  46.99 ns |  0.94 |    0.01 | 2.0752 |     - |     - |   4,344 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 6,629.4 ns |  41.87 ns |  37.12 ns |  1.10 |    0.01 | 2.0065 |     - |     - |   4,200 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 6,548.1 ns |  44.33 ns |  37.02 ns |  1.09 |    0.01 | 0.9995 |     - |     - |   2,096 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 6,384.7 ns |  29.38 ns |  24.54 ns |  1.06 |    0.01 | 0.9995 |     - |     - |   2,096 B |
|                           ForeachLoop |  1000 | 6,012.4 ns |  32.73 ns |  29.02 ns |  1.00 |    0.00 | 2.0752 |     - |     - |   4,344 B |
|                                  Linq |  1000 | 8,299.6 ns |  47.98 ns |  37.46 ns |  1.38 |    0.01 | 2.1210 |     - |     - |   4,464 B |
|                                LinqAF |  1000 | 9,339.7 ns |  60.02 ns |  53.21 ns |  1.55 |    0.01 | 2.0752 |     - |     - |   4,344 B |
|                            StructLinq |  1000 | 8,700.3 ns |  37.15 ns |  32.94 ns |  1.45 |    0.01 | 1.0376 |     - |     - |   2,184 B |
|                  StructLinq_IFunction |  1000 | 5,874.9 ns |  33.05 ns |  27.60 ns |  0.98 |    0.01 | 0.9995 |     - |     - |   2,096 B |
|                             Hyperlinq |  1000 | 8,106.3 ns |  37.08 ns |  30.96 ns |  1.35 |    0.01 | 0.9918 |     - |     - |   2,096 B |
|                   Hyperlinq_IFunction |  1000 | 5,859.9 ns |  39.11 ns |  32.65 ns |  0.98 |    0.01 | 0.9995 |     - |     - |   2,096 B |
