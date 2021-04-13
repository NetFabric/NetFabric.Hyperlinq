## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|          Method |    Job |  Runtime | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------- |--------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|         **ForLoop** | **.NET 5** | **.NET 5.0** |     **0** |    **10** |     **3.315 ns** |  **0.0138 ns** |  **0.0122 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop | .NET 5 | .NET 5.0 |     0 |    10 |    65.156 ns |  0.4493 ns |  0.3752 ns | 19.65 |    0.15 | 0.0267 |     - |     - |      56 B |
|            Linq | .NET 5 | .NET 5.0 |     0 |    10 |    66.033 ns |  0.2469 ns |  0.2189 ns | 19.92 |    0.12 | 0.0191 |     - |     - |      40 B |
|      LinqFaster | .NET 5 | .NET 5.0 |     0 |    10 |    12.706 ns |  0.1145 ns |  0.1071 ns |  3.83 |    0.03 | 0.0306 |     - |     - |      64 B |
| LinqFaster_SIMD | .NET 5 | .NET 5.0 |     0 |    10 |    18.924 ns |  0.3680 ns |  0.3073 ns |  5.71 |    0.09 | 0.0306 |     - |     - |      64 B |
|          LinqAF | .NET 5 | .NET 5.0 |     0 |    10 |    32.713 ns |  0.0851 ns |  0.0754 ns |  9.87 |    0.04 |      - |     - |     - |         - |
|      StructLinq | .NET 5 | .NET 5.0 |     0 |    10 |     4.073 ns |  0.0203 ns |  0.0170 ns |  1.23 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq | .NET 5 | .NET 5.0 |     0 |    10 |     9.914 ns |  0.0460 ns |  0.0384 ns |  2.99 |    0.01 |      - |     - |     - |         - |
|                 |        |          |       |       |              |            |            |       |         |        |       |       |           |
|         ForLoop | .NET 6 | .NET 6.0 |     0 |    10 |     3.107 ns |  0.0223 ns |  0.0197 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop | .NET 6 | .NET 6.0 |     0 |    10 |    43.629 ns |  0.3038 ns |  0.2693 ns | 14.04 |    0.13 | 0.0268 |     - |     - |      56 B |
|            Linq | .NET 6 | .NET 6.0 |     0 |    10 |    37.838 ns |  0.2597 ns |  0.2168 ns | 12.19 |    0.08 | 0.0191 |     - |     - |      40 B |
|      LinqFaster | .NET 6 | .NET 6.0 |     0 |    10 |    15.034 ns |  0.1687 ns |  0.1578 ns |  4.84 |    0.06 | 0.0306 |     - |     - |      64 B |
| LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |    10 |    21.359 ns |  0.2542 ns |  0.2378 ns |  6.87 |    0.08 | 0.0306 |     - |     - |      64 B |
|          LinqAF | .NET 6 | .NET 6.0 |     0 |    10 |    31.824 ns |  0.0733 ns |  0.0650 ns | 10.24 |    0.06 |      - |     - |     - |         - |
|      StructLinq | .NET 6 | .NET 6.0 |     0 |    10 |     3.408 ns |  0.0303 ns |  0.0269 ns |  1.10 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq | .NET 6 | .NET 6.0 |     0 |    10 |    10.038 ns |  0.0261 ns |  0.0245 ns |  3.23 |    0.02 |      - |     - |     - |         - |
|                 |        |          |       |       |              |            |            |       |         |        |       |       |           |
|         **ForLoop** | **.NET 5** | **.NET 5.0** |     **0** |  **1000** |   **271.923 ns** |  **1.1490 ns** |  **1.0748 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop | .NET 5 | .NET 5.0 |     0 |  1000 | 4,529.223 ns | 26.9320 ns | 25.1922 ns | 16.66 |    0.13 | 0.0229 |     - |     - |      56 B |
|            Linq | .NET 5 | .NET 5.0 |     0 |  1000 | 3,987.755 ns | 35.4055 ns | 33.1183 ns | 14.67 |    0.12 | 0.0153 |     - |     - |      40 B |
|      LinqFaster | .NET 5 | .NET 5.0 |     0 |  1000 | 1,175.509 ns | 21.9893 ns | 20.5688 ns |  4.32 |    0.08 | 1.9226 |     - |     - |   4,024 B |
| LinqFaster_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   817.601 ns |  8.0597 ns |  7.5391 ns |  3.01 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|          LinqAF | .NET 5 | .NET 5.0 |     0 |  1000 | 1,536.933 ns |  8.2878 ns |  6.9207 ns |  5.65 |    0.04 |      - |     - |     - |         - |
|      StructLinq | .NET 5 | .NET 5.0 |     0 |  1000 |   273.045 ns |  1.4362 ns |  1.1993 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq | .NET 5 | .NET 5.0 |     0 |  1000 |   280.560 ns |  1.9075 ns |  1.7842 ns |  1.03 |    0.01 |      - |     - |     - |         - |
|                 |        |          |       |       |              |            |            |       |         |        |       |       |           |
|         ForLoop | .NET 6 | .NET 6.0 |     0 |  1000 |   273.238 ns |  1.5436 ns |  1.3684 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop | .NET 6 | .NET 6.0 |     0 |  1000 | 2,910.931 ns | 23.5338 ns | 20.8621 ns | 10.65 |    0.10 | 0.0267 |     - |     - |      56 B |
|            Linq | .NET 6 | .NET 6.0 |     0 |  1000 | 2,388.303 ns | 13.8904 ns | 12.3135 ns |  8.74 |    0.08 | 0.0191 |     - |     - |      40 B |
|      LinqFaster | .NET 6 | .NET 6.0 |     0 |  1000 | 1,179.215 ns | 15.8576 ns | 14.8332 ns |  4.31 |    0.06 | 1.9226 |     - |     - |   4,024 B |
| LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 |   788.289 ns | 11.6651 ns | 10.3408 ns |  2.89 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|          LinqAF | .NET 6 | .NET 6.0 |     0 |  1000 | 1,420.592 ns |  2.5135 ns |  2.2282 ns |  5.20 |    0.03 |      - |     - |     - |         - |
|      StructLinq | .NET 6 | .NET 6.0 |     0 |  1000 |   275.551 ns |  2.7590 ns |  2.4457 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq | .NET 6 | .NET 6.0 |     0 |  1000 |   281.171 ns |  2.1699 ns |  1.8120 ns |  1.03 |    0.01 |      - |     - |     - |         - |
