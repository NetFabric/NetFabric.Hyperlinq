## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|---------:|--------:|--------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **57.40 ns** |   **0.323 ns** |   **0.303 ns** |     **1.00** |    **0.00** |  **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    167.38 ns |   0.617 ns |   0.577 ns |     2.92 |    0.02 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    129.28 ns |   0.343 ns |   0.321 ns |     2.25 |    0.01 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 38,395.47 ns | 210.720 ns | 197.108 ns |   668.94 |    3.85 | 13.5498 |     - |     - |  28,375 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    363.16 ns |   1.812 ns |   1.695 ns |     6.33 |    0.05 |  0.2828 |     - |     - |     592 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |     76.80 ns |   0.336 ns |   0.314 ns |     1.34 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     68.30 ns |   0.332 ns |   0.295 ns |     1.19 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     74.46 ns |   0.313 ns |   0.293 ns |     1.30 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     64.53 ns |   0.350 ns |   0.328 ns |     1.12 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     34.86 ns |   0.227 ns |   0.189 ns |     1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     91.18 ns |   0.326 ns |   0.305 ns |     2.62 |    0.02 |  0.0459 |     - |     - |      96 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    105.08 ns |   0.456 ns |   0.427 ns |     3.01 |    0.02 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 36,751.78 ns | 211.502 ns | 165.127 ns | 1,054.53 |    7.82 | 13.3057 |     - |     - |  27,935 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    298.69 ns |   1.316 ns |   1.231 ns |     8.57 |    0.06 |  0.2828 |     - |     - |     592 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     56.83 ns |   0.309 ns |   0.274 ns |     1.63 |    0.01 |  0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     48.50 ns |   0.665 ns |   0.589 ns |     1.39 |    0.02 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     54.82 ns |   0.795 ns |   0.744 ns |     1.58 |    0.02 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     47.56 ns |   0.463 ns |   0.386 ns |     1.36 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **4,416.46 ns** |  **19.808 ns** |  **18.528 ns** |     **1.00** |    **0.00** |  **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  9,375.22 ns |  48.685 ns |  45.540 ns |     2.12 |    0.01 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  7,596.31 ns |  31.962 ns |  26.690 ns |     1.72 |    0.01 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 49,381.38 ns | 241.209 ns | 213.825 ns |    11.18 |    0.07 | 15.4419 |     - |     - |  32,337 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 17,236.12 ns |  72.576 ns |  67.888 ns |     3.90 |    0.02 |  0.2747 |     - |     - |     592 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  4,958.74 ns |  31.441 ns |  29.410 ns |     1.12 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4,445.10 ns |  21.204 ns |  19.834 ns |     1.01 |    0.01 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5,466.02 ns |  18.673 ns |  17.466 ns |     1.24 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4,197.79 ns |  20.980 ns |  18.599 ns |     0.95 |    0.01 |  0.0153 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  3,121.59 ns |  17.783 ns |  16.634 ns |     1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5,488.85 ns |  23.367 ns |  21.858 ns |     1.76 |    0.01 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  5,282.75 ns |  31.726 ns |  29.677 ns |     1.69 |    0.01 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 44,994.14 ns | 335.881 ns | 262.233 ns |    14.42 |    0.11 | 15.1978 |     - |     - |  31,897 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 13,506.43 ns |  45.660 ns |  42.711 ns |     4.33 |    0.03 |  0.2747 |     - |     - |     592 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  3,887.47 ns |  12.168 ns |  10.787 ns |     1.25 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,879.48 ns |  25.926 ns |  21.650 ns |     0.92 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  3,898.92 ns |   9.751 ns |   8.644 ns |     1.25 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,629.63 ns |   9.906 ns |   9.266 ns |     0.84 |    0.01 |  0.0191 |     - |     - |      40 B |
