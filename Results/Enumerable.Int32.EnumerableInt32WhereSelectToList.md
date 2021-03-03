## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|                                Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **228.35 ns** |  **0.922 ns** |  **0.817 ns** |  **2.36** |    **0.01** | **0.0801** |     **-** |     **-** |     **168 B** |
|                       ValueLinq_Stack |    10 |   239.61 ns |  0.729 ns |  0.682 ns |  2.48 |    0.01 | 0.0567 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Push |    10 |   467.02 ns |  0.735 ns |  0.651 ns |  4.84 |    0.02 | 0.0572 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Pull |    10 |   357.77 ns |  0.649 ns |  0.607 ns |  3.70 |    0.02 | 0.0572 |     - |     - |     120 B |
|        ValueLinq_ValueLambda_Standard |    10 |   221.57 ns |  0.641 ns |  0.536 ns |  2.29 |    0.01 | 0.0801 |     - |     - |     168 B |
|           ValueLinq_ValueLambda_Stack |    10 |   199.28 ns |  0.728 ns |  0.681 ns |  2.06 |    0.01 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   374.26 ns |  1.152 ns |  1.021 ns |  3.88 |    0.02 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   333.70 ns |  1.207 ns |  0.943 ns |  3.45 |    0.02 | 0.0572 |     - |     - |     120 B |
|                           ForeachLoop |    10 |    96.57 ns |  0.402 ns |  0.357 ns |  1.00 |    0.00 | 0.0802 |     - |     - |     168 B |
|                                  Linq |    10 |   180.31 ns |  0.306 ns |  0.256 ns |  1.87 |    0.01 | 0.1373 |     - |     - |     288 B |
|                                LinqAF |    10 |   199.39 ns |  0.716 ns |  0.635 ns |  2.06 |    0.01 | 0.0801 |     - |     - |     168 B |
|                            StructLinq |    10 |   211.20 ns |  0.641 ns |  0.568 ns |  2.19 |    0.01 | 0.0994 |     - |     - |     208 B |
|                  StructLinq_IFunction |    10 |   163.50 ns |  0.604 ns |  0.504 ns |  1.69 |    0.01 | 0.0572 |     - |     - |     120 B |
|                             Hyperlinq |    10 |   175.49 ns |  0.419 ns |  0.371 ns |  1.82 |    0.01 | 0.0572 |     - |     - |     120 B |
|                   Hyperlinq_IFunction |    10 |   146.76 ns |  0.441 ns |  0.391 ns |  1.52 |    0.01 | 0.0572 |     - |     - |     120 B |
|                                       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **7,766.84 ns** | **32.601 ns** | **28.900 ns** |  **1.48** |    **0.01** | **2.0752** |     **-** |     **-** |   **4,344 B** |
|                       ValueLinq_Stack |  1000 | 8,328.19 ns | 29.579 ns | 24.699 ns |  1.58 |    0.00 | 1.9989 |     - |     - |   4,200 B |
|             ValueLinq_SharedPool_Push |  1000 | 8,415.25 ns | 92.466 ns | 81.968 ns |  1.60 |    0.02 | 0.9918 |     - |     - |   2,096 B |
|             ValueLinq_SharedPool_Pull |  1000 | 7,540.74 ns | 27.075 ns | 22.609 ns |  1.43 |    0.00 | 0.9995 |     - |     - |   2,096 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 5,821.58 ns | 18.030 ns | 16.865 ns |  1.11 |    0.00 | 2.0752 |     - |     - |   4,344 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 6,114.35 ns | 18.033 ns | 16.868 ns |  1.16 |    0.00 | 2.0065 |     - |     - |   4,200 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 6,358.87 ns | 12.919 ns | 11.453 ns |  1.21 |    0.00 | 0.9995 |     - |     - |   2,096 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 6,456.94 ns | 10.361 ns |  9.692 ns |  1.23 |    0.00 | 0.9995 |     - |     - |   2,096 B |
|                           ForeachLoop |  1000 | 5,263.87 ns | 12.377 ns | 10.335 ns |  1.00 |    0.00 | 2.0752 |     - |     - |   4,344 B |
|                                  Linq |  1000 | 7,612.11 ns | 18.741 ns | 17.531 ns |  1.45 |    0.01 | 2.1210 |     - |     - |   4,464 B |
|                                LinqAF |  1000 | 9,473.58 ns | 36.725 ns | 34.353 ns |  1.80 |    0.01 | 2.0752 |     - |     - |   4,344 B |
|                            StructLinq |  1000 | 7,548.91 ns | 14.679 ns | 13.012 ns |  1.43 |    0.00 | 1.0376 |     - |     - |   2,184 B |
|                  StructLinq_IFunction |  1000 | 6,154.78 ns | 16.901 ns | 14.982 ns |  1.17 |    0.00 | 0.9995 |     - |     - |   2,096 B |
|                             Hyperlinq |  1000 | 7,887.78 ns | 17.388 ns | 14.520 ns |  1.50 |    0.00 | 0.9918 |     - |     - |   2,096 B |
|                   Hyperlinq_IFunction |  1000 | 5,969.53 ns | 10.371 ns |  9.701 ns |  1.13 |    0.00 | 0.9995 |     - |     - |   2,096 B |
