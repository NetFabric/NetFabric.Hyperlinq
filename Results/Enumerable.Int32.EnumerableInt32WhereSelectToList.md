## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|                                Method | Count |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **266.6 ns** |  **5.38 ns** |  **12.88 ns** |   **268.2 ns** |  **2.52** |    **0.11** | **0.0796** |     **-** |     **-** |     **168 B** |
|                       ValueLinq_Stack |    10 |   279.2 ns |  5.40 ns |   5.78 ns |   277.5 ns |  2.68 |    0.06 | 0.0567 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Push |    10 |   605.3 ns | 46.19 ns | 136.20 ns |   520.5 ns |  6.78 |    0.90 | 0.0572 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Pull |    10 |   367.5 ns |  1.64 ns |   1.37 ns |   367.0 ns |  3.53 |    0.02 | 0.0572 |     - |     - |     120 B |
|        ValueLinq_ValueLambda_Standard |    10 |   219.4 ns |  1.03 ns |   0.91 ns |   219.4 ns |  2.11 |    0.01 | 0.0801 |     - |     - |     168 B |
|           ValueLinq_ValueLambda_Stack |    10 |   201.7 ns |  0.62 ns |   0.52 ns |   201.6 ns |  1.94 |    0.01 | 0.0570 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   388.6 ns |  1.21 ns |   1.01 ns |   388.7 ns |  3.74 |    0.02 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   337.6 ns |  1.70 ns |   1.51 ns |   337.1 ns |  3.25 |    0.02 | 0.0572 |     - |     - |     120 B |
|                           ForeachLoop |    10 |   104.0 ns |  0.44 ns |   0.39 ns |   104.0 ns |  1.00 |    0.00 | 0.0802 |     - |     - |     168 B |
|                                  Linq |    10 |   182.1 ns |  0.83 ns |   0.78 ns |   181.9 ns |  1.75 |    0.01 | 0.1376 |     - |     - |     288 B |
|                                LinqAF |    10 |   209.5 ns |  0.71 ns |   0.63 ns |   209.2 ns |  2.01 |    0.01 | 0.0801 |     - |     - |     168 B |
|                            StructLinq |    10 |   222.5 ns |  1.02 ns |   0.91 ns |   222.5 ns |  2.14 |    0.01 | 0.0994 |     - |     - |     208 B |
|                  StructLinq_IFunction |    10 |   159.7 ns |  0.33 ns |   0.29 ns |   159.7 ns |  1.54 |    0.01 | 0.0572 |     - |     - |     120 B |
|                             Hyperlinq |    10 |   185.5 ns |  0.78 ns |   0.65 ns |   185.5 ns |  1.78 |    0.01 | 0.0572 |     - |     - |     120 B |
|                   Hyperlinq_IFunction |    10 |   151.2 ns |  0.99 ns |   0.88 ns |   151.1 ns |  1.45 |    0.01 | 0.0572 |     - |     - |     120 B |
|                                       |       |            |          |           |            |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **8,393.5 ns** | **34.47 ns** |  **26.91 ns** | **8,406.1 ns** |  **1.43** |    **0.01** | **2.0752** |     **-** |     **-** |   **4,344 B** |
|                       ValueLinq_Stack |  1000 | 8,141.0 ns | 55.75 ns |  43.53 ns | 8,152.4 ns |  1.38 |    0.01 | 1.9989 |     - |     - |   4,200 B |
|             ValueLinq_SharedPool_Push |  1000 | 8,560.4 ns | 42.54 ns |  37.71 ns | 8,559.1 ns |  1.45 |    0.01 | 0.9918 |     - |     - |   2,096 B |
|             ValueLinq_SharedPool_Pull |  1000 | 8,059.7 ns | 32.01 ns |  28.38 ns | 8,058.3 ns |  1.37 |    0.00 | 0.9918 |     - |     - |   2,096 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 5,515.2 ns | 49.87 ns |  44.21 ns | 5,513.1 ns |  0.94 |    0.01 | 2.0752 |     - |     - |   4,344 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 6,432.7 ns | 18.66 ns |  16.54 ns | 6,429.2 ns |  1.09 |    0.00 | 2.0065 |     - |     - |   4,200 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 6,413.2 ns | 19.67 ns |  17.44 ns | 6,414.5 ns |  1.09 |    0.01 | 0.9995 |     - |     - |   2,096 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 6,246.5 ns | 23.88 ns |  19.94 ns | 6,247.5 ns |  1.06 |    0.00 | 0.9995 |     - |     - |   2,096 B |
|                           ForeachLoop |  1000 | 5,885.9 ns | 19.52 ns |  17.30 ns | 5,880.9 ns |  1.00 |    0.00 | 2.0752 |     - |     - |   4,344 B |
|                                  Linq |  1000 | 8,123.9 ns | 63.93 ns |  56.67 ns | 8,096.8 ns |  1.38 |    0.01 | 2.1210 |     - |     - |   4,464 B |
|                                LinqAF |  1000 | 9,373.6 ns | 37.42 ns |  31.24 ns | 9,371.0 ns |  1.59 |    0.01 | 2.0752 |     - |     - |   4,344 B |
|                            StructLinq |  1000 | 8,580.0 ns | 46.38 ns |  43.39 ns | 8,589.6 ns |  1.46 |    0.01 | 1.0376 |     - |     - |   2,184 B |
|                  StructLinq_IFunction |  1000 | 5,764.9 ns | 18.81 ns |  16.68 ns | 5,769.4 ns |  0.98 |    0.00 | 0.9995 |     - |     - |   2,096 B |
|                             Hyperlinq |  1000 | 8,296.4 ns | 36.79 ns |  32.61 ns | 8,306.0 ns |  1.41 |    0.01 | 0.9918 |     - |     - |   2,096 B |
|                   Hyperlinq_IFunction |  1000 | 6,123.6 ns | 47.22 ns |  36.86 ns | 6,128.9 ns |  1.04 |    0.01 | 0.9995 |     - |     - |   2,096 B |
