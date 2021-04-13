## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |    **10.055 ns** |  **0.0531 ns** |  **0.0471 ns** |    **10.055 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |    25.301 ns |  0.1313 ns |  0.1025 ns |    25.318 ns |  2.52 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    10.676 ns |  0.0371 ns |  0.0329 ns |    10.674 ns |  1.06 |    0.01 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     6.937 ns |  0.0484 ns |  0.0404 ns |     6.934 ns |  0.69 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |     6.094 ns |  0.0262 ns |  0.0219 ns |     6.092 ns |  0.61 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    17.798 ns |  0.2614 ns |  0.2183 ns |    17.894 ns |  1.77 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    11.549 ns |  0.2935 ns |  0.6381 ns |    11.294 ns |  1.22 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    12.503 ns |  0.3005 ns |  0.3086 ns |    12.387 ns |  1.25 |    0.03 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5 | .NET 5.0 |    10 |    18.059 ns |  0.0690 ns |  0.1171 ns |    18.063 ns |  1.80 |    0.02 |      - |     - |     - |         - |
|                      |        |          |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     9.892 ns |  0.2465 ns |  0.2058 ns |     9.815 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |    16.674 ns |  0.3287 ns |  0.2745 ns |    16.672 ns |  1.69 |    0.04 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     9.316 ns |  0.2459 ns |  0.2526 ns |     9.225 ns |  0.94 |    0.04 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     5.927 ns |  0.1128 ns |  0.2592 ns |     5.816 ns |  0.61 |    0.04 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     5.745 ns |  0.1749 ns |  0.4419 ns |     5.522 ns |  0.66 |    0.05 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    18.890 ns |  0.2298 ns |  0.2150 ns |    19.004 ns |  1.91 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     6.566 ns |  0.0845 ns |  0.0749 ns |     6.546 ns |  0.66 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    13.070 ns |  0.0654 ns |  0.0580 ns |    13.066 ns |  1.32 |    0.03 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6 | .NET 6.0 |    10 |    15.408 ns |  0.0498 ns |  0.0922 ns |    15.395 ns |  1.56 |    0.04 |      - |     - |     - |         - |
|                      |        |          |       |              |            |            |              |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** | **1,035.245 ns** |  **6.1200 ns** |  **5.1105 ns** | **1,033.208 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 2,350.316 ns | 12.4676 ns | 11.6622 ns | 2,346.923 ns |  2.27 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |   397.631 ns |  1.4919 ns |  1.3955 ns |   397.642 ns |  0.38 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |   394.777 ns |  2.9688 ns |  2.4791 ns |   394.355 ns |  0.38 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |   394.625 ns |  1.4674 ns |  1.3726 ns |   394.356 ns |  0.38 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |   533.431 ns |  2.1217 ns |  1.9847 ns |   532.701 ns |  0.52 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 1,037.391 ns |  3.2236 ns |  3.0153 ns | 1,037.088 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |   393.407 ns |  0.8547 ns |  0.7995 ns |   393.094 ns |  0.38 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5 | .NET 5.0 |  1000 |   117.101 ns |  0.5746 ns |  0.5374 ns |   117.195 ns |  0.11 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |              |            |            |              |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 1,035.699 ns |  4.9677 ns |  4.4037 ns | 1,034.832 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 4,342.934 ns | 38.5518 ns | 34.1751 ns | 4,336.390 ns |  4.19 |    0.04 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |   274.946 ns |  5.2842 ns |  4.9429 ns |   274.847 ns |  0.27 |    0.01 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |   270.244 ns |  2.5518 ns |  2.2621 ns |   269.457 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |   177.274 ns |  3.5538 ns |  4.2305 ns |   176.598 ns |  0.17 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |   567.792 ns |  8.8447 ns |  7.8406 ns |   564.754 ns |  0.55 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |   533.022 ns |  8.0803 ns |  6.7474 ns |   532.563 ns |  0.51 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |   184.438 ns |  2.3553 ns |  2.2032 ns |   184.728 ns |  0.18 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6 | .NET 6.0 |  1000 |   635.955 ns | 12.2664 ns | 12.0472 ns |   632.277 ns |  0.61 |    0.01 |      - |     - |     - |         - |
