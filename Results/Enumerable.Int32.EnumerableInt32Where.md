## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                 **Linq** | **.NET 5** | **.NET 5.0** |    **10** |    **143.54 ns** |   **0.664 ns** |   **0.589 ns** |   **1.00** |    **0.00** |  **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    111.43 ns |   0.520 ns |   0.487 ns |   0.78 |    0.00 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 43,349.03 ns | 163.040 ns | 152.508 ns | 301.91 |    1.61 | 13.9160 |     - |     - |  29,164 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    328.49 ns |   1.973 ns |   1.846 ns |   2.29 |    0.02 |  0.2828 |     - |     - |     592 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     87.01 ns |   0.264 ns |   0.220 ns |   0.61 |    0.00 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     74.01 ns |   0.619 ns |   0.549 ns |   0.52 |    0.00 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     84.08 ns |   0.263 ns |   0.233 ns |   0.59 |    0.00 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     74.15 ns |   0.420 ns |   0.392 ns |   0.52 |    0.00 |  0.0191 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |        |         |         |       |       |           |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     82.98 ns |   0.813 ns |   0.761 ns |   1.00 |    0.00 |  0.0459 |     - |     - |      96 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     77.51 ns |   0.134 ns |   0.119 ns |   0.94 |    0.01 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 40,448.95 ns | 734.176 ns | 613.070 ns | 488.60 |    7.94 | 13.6719 |     - |     - |  28,722 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    275.26 ns |   1.730 ns |   1.618 ns |   3.32 |    0.04 |  0.2828 |     - |     - |     592 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     54.63 ns |   0.438 ns |   0.388 ns |   0.66 |    0.00 |  0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     50.02 ns |   0.388 ns |   0.324 ns |   0.60 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     53.66 ns |   0.220 ns |   0.205 ns |   0.65 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     51.73 ns |   0.368 ns |   0.307 ns |   0.62 |    0.00 |  0.0191 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |        |         |         |       |       |           |
|                 **Linq** | **.NET 5** | **.NET 5.0** |  **1000** |  **7,837.90 ns** |  **51.524 ns** |  **48.196 ns** |   **1.00** |    **0.00** |  **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  7,088.44 ns |  69.518 ns |  61.625 ns |   0.90 |    0.01 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 51,750.69 ns | 152.161 ns | 134.887 ns |   6.60 |    0.04 | 14.8315 |     - |     - |  31,142 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 14,011.36 ns |  54.971 ns |  51.420 ns |   1.79 |    0.01 |  0.2747 |     - |     - |     592 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  6,233.47 ns |  17.768 ns |  16.620 ns |   0.80 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5,344.96 ns |  26.561 ns |  20.737 ns |   0.68 |    0.01 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  6,723.06 ns |  19.169 ns |  16.007 ns |   0.86 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4,965.71 ns |  29.196 ns |  25.881 ns |   0.63 |    0.01 |  0.0153 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |        |         |         |       |       |           |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  4,662.52 ns |  15.234 ns |  11.894 ns |   1.00 |    0.00 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  4,446.48 ns |  16.081 ns |  15.042 ns |   0.95 |    0.00 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 46,335.01 ns | 194.301 ns | 172.243 ns |   9.94 |    0.04 | 14.6484 |     - |     - |  30,699 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 10,670.75 ns |  51.209 ns |  47.901 ns |   2.29 |    0.01 |  0.2747 |     - |     - |     592 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  3,781.95 ns |  16.383 ns |  15.325 ns |   0.81 |    0.00 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,245.56 ns |   9.213 ns |   8.167 ns |   0.70 |    0.00 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4,182.15 ns |  56.240 ns |  62.511 ns |   0.90 |    0.02 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,882.01 ns |  11.220 ns |   9.947 ns |   0.62 |    0.00 |  0.0191 |     - |     - |      40 B |
