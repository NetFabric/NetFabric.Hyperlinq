## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|      Method |    Job |  Runtime | Start | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------- |--------- |------ |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|     **ForLoop** | **.NET 5** | **.NET 5.0** |     **0** |    **10** |    **67.45 ns** |  **1.414 ns** |  **1.322 ns** |    **67.45 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
| ForeachLoop | .NET 5 | .NET 5.0 |     0 |    10 |   120.32 ns |  2.065 ns |  3.450 ns |   119.52 ns |  1.81 |    0.06 | 0.1299 |     - |     - |     272 B |
|        Linq | .NET 5 | .NET 5.0 |     0 |    10 |    44.58 ns |  0.962 ns |  1.145 ns |    44.16 ns |  0.67 |    0.02 | 0.0650 |     - |     - |     136 B |
|  LinqFaster | .NET 5 | .NET 5.0 |     0 |    10 |    40.98 ns |  0.912 ns |  1.758 ns |    41.11 ns |  0.63 |    0.02 | 0.0765 |     - |     - |     160 B |
|      LinqAF | .NET 5 | .NET 5.0 |     0 |    10 |    62.38 ns |  1.053 ns |  1.034 ns |    61.97 ns |  0.93 |    0.02 | 0.0459 |     - |     - |      96 B |
|  StructLinq | .NET 5 | .NET 5.0 |     0 |    10 |    18.31 ns |  0.397 ns |  0.425 ns |    18.23 ns |  0.27 |    0.01 | 0.0459 |     - |     - |      96 B |
|   Hyperlinq | .NET 5 | .NET 5.0 |     0 |    10 |    24.27 ns |  0.220 ns |  0.172 ns |    24.33 ns |  0.36 |    0.01 | 0.0459 |     - |     - |      96 B |
|             |        |          |       |       |             |           |           |             |       |         |        |       |       |           |
|     ForLoop | .NET 6 | .NET 6.0 |     0 |    10 |    66.75 ns |  0.545 ns |  0.483 ns |    66.64 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
| ForeachLoop | .NET 6 | .NET 6.0 |     0 |    10 |   103.73 ns |  0.927 ns |  0.774 ns |   103.59 ns |  1.56 |    0.02 | 0.1301 |     - |     - |     272 B |
|        Linq | .NET 6 | .NET 6.0 |     0 |    10 |    38.89 ns |  0.391 ns |  0.366 ns |    38.93 ns |  0.58 |    0.01 | 0.0650 |     - |     - |     136 B |
|  LinqFaster | .NET 6 | .NET 6.0 |     0 |    10 |    38.12 ns |  0.307 ns |  0.287 ns |    38.21 ns |  0.57 |    0.01 | 0.0765 |     - |     - |     160 B |
|      LinqAF | .NET 6 | .NET 6.0 |     0 |    10 |    60.47 ns |  0.549 ns |  0.487 ns |    60.30 ns |  0.91 |    0.01 | 0.0458 |     - |     - |      96 B |
|  StructLinq | .NET 6 | .NET 6.0 |     0 |    10 |    17.75 ns |  0.177 ns |  0.165 ns |    17.77 ns |  0.27 |    0.00 | 0.0459 |     - |     - |      96 B |
|   Hyperlinq | .NET 6 | .NET 6.0 |     0 |    10 |    23.16 ns |  0.557 ns |  0.946 ns |    23.01 ns |  0.36 |    0.01 | 0.0459 |     - |     - |      96 B |
|             |        |          |       |       |             |           |           |             |       |         |        |       |       |           |
|     **ForLoop** | **.NET 5** | **.NET 5.0** |     **0** |  **1000** | **2,169.39 ns** | **37.609 ns** | **35.179 ns** | **2,161.72 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
| ForeachLoop | .NET 5 | .NET 5.0 |     0 |  1000 | 5,477.92 ns | 42.610 ns | 35.582 ns | 5,480.08 ns |  2.52 |    0.05 | 4.0436 |     - |     - |   8,480 B |
|        Linq | .NET 5 | .NET 5.0 |     0 |  1000 | 1,821.39 ns | 10.714 ns |  8.947 ns | 1,820.59 ns |  0.84 |    0.01 | 1.9569 |     - |     - |   4,096 B |
|  LinqFaster | .NET 5 | .NET 5.0 |     0 |  1000 | 1,188.61 ns |  7.226 ns |  6.406 ns | 1,189.11 ns |  0.55 |    0.01 | 3.8605 |     - |     - |   8,080 B |
|      LinqAF | .NET 5 | .NET 5.0 |     0 |  1000 | 2,921.57 ns | 23.846 ns | 21.139 ns | 2,920.49 ns |  1.35 |    0.02 | 1.9379 |     - |     - |   4,056 B |
|  StructLinq | .NET 5 | .NET 5.0 |     0 |  1000 |   723.63 ns | 12.062 ns | 11.283 ns |   725.01 ns |  0.33 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|   Hyperlinq | .NET 5 | .NET 5.0 |     0 |  1000 |   309.74 ns |  6.435 ns | 18.972 ns |   301.68 ns |  0.14 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|             |        |          |       |       |             |           |           |             |       |         |        |       |       |           |
|     ForLoop | .NET 6 | .NET 6.0 |     0 |  1000 | 2,194.85 ns | 28.890 ns | 24.124 ns | 2,192.20 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
| ForeachLoop | .NET 6 | .NET 6.0 |     0 |  1000 | 4,463.35 ns | 66.385 ns | 62.096 ns | 4,456.14 ns |  2.03 |    0.04 | 4.0436 |     - |     - |   8,480 B |
|        Linq | .NET 6 | .NET 6.0 |     0 |  1000 | 1,548.60 ns | 16.501 ns | 14.628 ns | 1,546.84 ns |  0.71 |    0.01 | 1.9569 |     - |     - |   4,096 B |
|  LinqFaster | .NET 6 | .NET 6.0 |     0 |  1000 |   935.83 ns | 18.008 ns | 17.686 ns |   936.69 ns |  0.43 |    0.01 | 3.8605 |     - |     - |   8,080 B |
|      LinqAF | .NET 6 | .NET 6.0 |     0 |  1000 | 2,323.01 ns | 46.117 ns | 59.965 ns | 2,342.12 ns |  1.05 |    0.03 | 1.9379 |     - |     - |   4,056 B |
|  StructLinq | .NET 6 | .NET 6.0 |     0 |  1000 |   727.55 ns | 13.840 ns | 15.383 ns |   730.39 ns |  0.33 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|   Hyperlinq | .NET 6 | .NET 6.0 |     0 |  1000 |   310.08 ns |  6.224 ns |  7.409 ns |   311.25 ns |  0.14 |    0.00 | 1.9379 |     - |     - |   4,056 B |
