## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Duplicates | Count |         Mean |        Error |       StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----------- |------ |-------------:|-------------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |          **4** |    **10** |    **425.49 ns** |     **5.268 ns** |     **4.928 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |          4 |    10 |    474.56 ns |     8.893 ns |     7.426 ns |  1.11 |    0.02 |  0.3204 |     - |     - |     672 B |
|                 Linq | .NET 5 | .NET 5.0 |          4 |    10 |    853.07 ns |    13.803 ns |    12.911 ns |  2.01 |    0.04 |  0.2937 |     - |     - |     616 B |
|           LinqFaster | .NET 5 | .NET 5.0 |          4 |    10 |     62.89 ns |     1.310 ns |     1.346 ns |  0.15 |    0.00 |       - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |          4 |    10 |  1,020.98 ns |    19.035 ns |    18.695 ns |  2.40 |    0.04 |  0.6180 |     - |     - |   1,296 B |
|           StructLinq | .NET 5 | .NET 5.0 |          4 |    10 |    481.71 ns |     8.397 ns |    12.308 ns |  1.14 |    0.04 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |          4 |    10 |    513.61 ns |     7.556 ns |     6.698 ns |  1.21 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |          4 |    10 |    423.88 ns |     2.703 ns |     2.257 ns |  0.99 |    0.01 |       - |     - |     - |         - |
|                      |        |          |            |       |              |              |              |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |          4 |    10 |    444.92 ns |     8.945 ns |    11.313 ns |  1.00 |    0.00 |  0.3171 |     - |     - |     664 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |          4 |    10 |    430.24 ns |     4.121 ns |     3.441 ns |  0.96 |    0.03 |  0.3171 |     - |     - |     664 B |
|                 Linq | .NET 6 | .NET 6.0 |          4 |    10 |    672.17 ns |    12.981 ns |    16.879 ns |  1.51 |    0.06 |  0.3166 |     - |     - |     664 B |
|           LinqFaster | .NET 6 | .NET 6.0 |          4 |    10 |     54.19 ns |     0.741 ns |     0.657 ns |  0.12 |    0.00 |       - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |          4 |    10 |  1,020.05 ns |    18.584 ns |    27.816 ns |  2.30 |    0.09 |  0.6180 |     - |     - |   1,296 B |
|           StructLinq | .NET 6 | .NET 6.0 |          4 |    10 |    476.84 ns |     6.868 ns |     6.425 ns |  1.07 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |          4 |    10 |    473.83 ns |     9.049 ns |     8.021 ns |  1.06 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |          4 |    10 |    436.36 ns |     6.507 ns |     6.086 ns |  0.97 |    0.02 |       - |     - |     - |         - |
|                      |        |          |            |       |              |              |              |       |         |         |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |          **4** |  **1000** | **35,555.48 ns** |   **669.621 ns** |   **744.282 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |          4 |  1000 | 44,468.83 ns |   779.399 ns |   690.917 ns |  1.25 |    0.03 | 27.7710 |     - |     - |  58,672 B |
|                 Linq | .NET 5 | .NET 5.0 |          4 |  1000 | 75,606.37 ns | 1,484.383 ns | 1,877.269 ns |  2.13 |    0.08 | 15.7471 |     - |     - |  33,112 B |
|           LinqFaster | .NET 5 | .NET 5.0 |          4 |  1000 |  8,045.95 ns |   153.189 ns |   157.314 ns |  0.23 |    0.01 |       - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |          4 |  1000 | 92,162.38 ns | 1,559.826 ns | 1,459.062 ns |  2.59 |    0.06 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq | .NET 5 | .NET 5.0 |          4 |  1000 | 32,251.68 ns |   372.192 ns |   329.939 ns |  0.91 |    0.02 |       - |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |          4 |  1000 | 32,104.68 ns |   175.389 ns |   136.933 ns |  0.90 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |          4 |  1000 | 33,020.45 ns |   413.622 ns |   345.393 ns |  0.93 |    0.02 |       - |     - |     - |         - |
|                      |        |          |            |       |              |              |              |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |          4 |  1000 | 36,749.80 ns |   171.660 ns |   160.571 ns |  1.00 |    0.00 | 27.7710 |     - |     - |  58,664 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |          4 |  1000 | 37,004.40 ns |   356.062 ns |   277.990 ns |  1.01 |    0.01 | 27.7710 |     - |     - |  58,664 B |
|                 Linq | .NET 6 | .NET 6.0 |          4 |  1000 | 60,197.69 ns |   262.349 ns |   204.825 ns |  1.64 |    0.01 | 27.7710 |     - |     - |  58,664 B |
|           LinqFaster | .NET 6 | .NET 6.0 |          4 |  1000 |  6,923.04 ns |    18.763 ns |    16.633 ns |  0.19 |    0.00 |       - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |          4 |  1000 | 87,201.97 ns |   649.825 ns |   576.053 ns |  2.37 |    0.02 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq | .NET 6 | .NET 6.0 |          4 |  1000 | 30,841.49 ns |   257.251 ns |   228.046 ns |  0.84 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |          4 |  1000 | 31,878.72 ns |   204.189 ns |   190.998 ns |  0.87 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |          4 |  1000 | 32,883.34 ns |   181.343 ns |   169.628 ns |  0.89 |    0.00 |       - |     - |     - |         - |
