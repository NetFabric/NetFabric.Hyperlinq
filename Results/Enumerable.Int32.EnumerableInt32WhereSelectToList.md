## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

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
|                                Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **230.19 ns** |  **0.690 ns** |  **0.576 ns** |  **2.32** |    **0.01** | **0.0801** |     **-** |     **-** |     **168 B** |
|                       ValueLinq_Stack |    10 |   233.69 ns |  0.867 ns |  0.768 ns |  2.36 |    0.01 | 0.0572 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Push |    10 |   479.74 ns |  1.625 ns |  1.441 ns |  4.84 |    0.03 | 0.0572 |     - |     - |     120 B |
|             ValueLinq_SharedPool_Pull |    10 |   345.57 ns |  0.878 ns |  0.685 ns |  3.49 |    0.02 | 0.0572 |     - |     - |     120 B |
|        ValueLinq_ValueLambda_Standard |    10 |   216.13 ns |  0.933 ns |  0.729 ns |  2.18 |    0.01 | 0.0801 |     - |     - |     168 B |
|           ValueLinq_ValueLambda_Stack |    10 |   195.95 ns |  0.772 ns |  0.684 ns |  1.98 |    0.01 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   374.81 ns |  1.335 ns |  1.184 ns |  3.79 |    0.02 | 0.0572 |     - |     - |     120 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   330.95 ns |  1.735 ns |  1.538 ns |  3.34 |    0.02 | 0.0572 |     - |     - |     120 B |
|                           ForeachLoop |    10 |    99.01 ns |  0.393 ns |  0.367 ns |  1.00 |    0.00 | 0.0802 |     - |     - |     168 B |
|                                  Linq |    10 |   178.70 ns |  0.553 ns |  0.517 ns |  1.80 |    0.01 | 0.1373 |     - |     - |     288 B |
|                                LinqAF |    10 |   204.50 ns |  1.022 ns |  0.853 ns |  2.06 |    0.01 | 0.0801 |     - |     - |     168 B |
|                            StructLinq |    10 |   222.72 ns |  0.765 ns |  0.678 ns |  2.25 |    0.01 | 0.0994 |     - |     - |     208 B |
|                  StructLinq_IFunction |    10 |   157.85 ns |  0.330 ns |  0.309 ns |  1.59 |    0.01 | 0.0572 |     - |     - |     120 B |
|                             Hyperlinq |    10 |   178.97 ns |  0.592 ns |  0.525 ns |  1.81 |    0.01 | 0.0572 |     - |     - |     120 B |
|                   Hyperlinq_IFunction |    10 |   148.29 ns |  0.597 ns |  0.498 ns |  1.50 |    0.01 | 0.0572 |     - |     - |     120 B |
|                                       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **8,132.97 ns** | **33.350 ns** | **31.196 ns** |  **1.42** |    **0.01** | **2.0752** |     **-** |     **-** |   **4,344 B** |
|                       ValueLinq_Stack |  1000 | 7,872.44 ns | 22.102 ns | 20.674 ns |  1.38 |    0.00 | 1.9989 |     - |     - |   4,200 B |
|             ValueLinq_SharedPool_Push |  1000 | 8,270.38 ns | 17.580 ns | 15.584 ns |  1.45 |    0.01 | 0.9918 |     - |     - |   2,096 B |
|             ValueLinq_SharedPool_Pull |  1000 | 7,849.88 ns | 16.496 ns | 14.623 ns |  1.37 |    0.00 | 0.9918 |     - |     - |   2,096 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 5,781.88 ns | 15.011 ns | 14.041 ns |  1.01 |    0.00 | 2.0752 |     - |     - |   4,344 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 6,286.18 ns | 17.675 ns | 15.669 ns |  1.10 |    0.00 | 2.0065 |     - |     - |   4,200 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 6,391.29 ns | 15.684 ns | 14.670 ns |  1.12 |    0.00 | 0.9995 |     - |     - |   2,096 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 5,956.77 ns | 15.536 ns | 13.772 ns |  1.04 |    0.00 | 0.9995 |     - |     - |   2,096 B |
|                           ForeachLoop |  1000 | 5,714.65 ns | 17.953 ns | 16.793 ns |  1.00 |    0.00 | 2.0752 |     - |     - |   4,344 B |
|                                  Linq |  1000 | 7,430.73 ns |  6.964 ns |  5.437 ns |  1.30 |    0.00 | 2.1210 |     - |     - |   4,464 B |
|                                LinqAF |  1000 | 9,120.12 ns | 96.057 ns | 80.212 ns |  1.60 |    0.01 | 2.0752 |     - |     - |   4,344 B |
|                            StructLinq |  1000 | 8,225.08 ns | 20.392 ns | 19.075 ns |  1.44 |    0.01 | 1.0376 |     - |     - |   2,184 B |
|                  StructLinq_IFunction |  1000 | 5,677.90 ns | 13.438 ns | 11.912 ns |  0.99 |    0.00 | 0.9995 |     - |     - |   2,096 B |
|                             Hyperlinq |  1000 | 8,040.62 ns | 21.010 ns | 19.653 ns |  1.41 |    0.00 | 0.9918 |     - |     - |   2,096 B |
|                   Hyperlinq_IFunction |  1000 | 5,483.54 ns | 11.953 ns |  9.981 ns |  0.96 |    0.00 | 0.9995 |     - |     - |   2,096 B |
