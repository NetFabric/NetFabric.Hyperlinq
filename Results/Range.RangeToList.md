## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                    Method | Start | Count |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |------------:|----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |    **10** |    **84.86 ns** |  **1.748 ns** |   **2.013 ns** |    **85.33 ns** |  **1.21** |    **0.09** | **0.0459** |     **-** |     **-** |      **96 B** |
|           ValueLinq_Stack |     0 |    10 |    74.47 ns |  0.390 ns |   0.326 ns |    74.53 ns |  1.06 |    0.07 | 0.0459 |     - |     - |      96 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   183.30 ns |  0.814 ns |   0.680 ns |   183.36 ns |  2.61 |    0.15 | 0.0458 |     - |     - |      96 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   197.02 ns |  0.720 ns |   0.674 ns |   196.77 ns |  2.82 |    0.16 | 0.0458 |     - |     - |      96 B |
|                   ForLoop |     0 |    10 |    69.23 ns |  1.437 ns |   3.062 ns |    68.36 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|               ForeachLoop |     0 |    10 |   138.05 ns |  2.835 ns |   7.467 ns |   133.12 ns |  2.04 |    0.14 | 0.1299 |     - |     - |     272 B |
|                      Linq |     0 |    10 |    45.85 ns |  0.992 ns |   2.134 ns |    44.85 ns |  0.66 |    0.03 | 0.0650 |     - |     - |     136 B |
|                LinqFaster |     0 |    10 |    41.46 ns |  0.891 ns |   0.744 ns |    41.35 ns |  0.59 |    0.04 | 0.0765 |     - |     - |     160 B |
|                    LinqAF |     0 |    10 |    69.72 ns |  0.673 ns |   0.629 ns |    69.75 ns |  1.00 |    0.06 | 0.0458 |     - |     - |      96 B |
|                StructLinq |     0 |    10 |    20.53 ns |  0.154 ns |   0.137 ns |    20.53 ns |  0.29 |    0.02 | 0.0459 |     - |     - |      96 B |
|                 Hyperlinq |     0 |    10 |    25.11 ns |  0.261 ns |   0.391 ns |    25.01 ns |  0.36 |    0.01 | 0.0459 |     - |     - |      96 B |
|                           |       |       |             |           |            |             |       |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **2,222.02 ns** | **23.185 ns** |  **18.102 ns** | **2,220.57 ns** |  **0.87** |    **0.04** | **1.9379** |     **-** |     **-** |   **4,056 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,750.69 ns | 11.970 ns |  11.756 ns | 2,754.87 ns |  1.07 |    0.04 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,572.47 ns | 20.739 ns |  19.399 ns | 2,567.70 ns |  1.00 |    0.04 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,528.93 ns | 12.852 ns |  12.022 ns | 2,528.00 ns |  0.99 |    0.04 | 1.9379 |     - |     - |   4,056 B |
|                   ForLoop |     0 |  1000 | 2,463.14 ns | 55.225 ns | 161.965 ns | 2,394.68 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|               ForeachLoop |     0 |  1000 | 6,297.29 ns | 75.698 ns |  67.104 ns | 6,273.86 ns |  2.46 |    0.11 | 4.0436 |     - |     - |   8,480 B |
|                      Linq |     0 |  1000 | 1,855.35 ns |  7.619 ns |   6.362 ns | 1,855.59 ns |  0.73 |    0.03 | 1.9569 |     - |     - |   4,096 B |
|                LinqFaster |     0 |  1000 |   963.39 ns | 19.233 ns |  19.751 ns |   962.32 ns |  0.38 |    0.02 | 3.8605 |     - |     - |   8,080 B |
|                    LinqAF |     0 |  1000 | 3,267.24 ns |  9.522 ns |  16.170 ns | 3,265.97 ns |  1.28 |    0.07 | 1.9379 |     - |     - |   4,056 B |
|                StructLinq |     0 |  1000 |   767.27 ns | 12.968 ns |  12.131 ns |   771.00 ns |  0.30 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                 Hyperlinq |     0 |  1000 |   358.64 ns |  2.646 ns |   2.475 ns |   358.17 ns |  0.14 |    0.01 | 1.9379 |     - |     - |   4,056 B |
