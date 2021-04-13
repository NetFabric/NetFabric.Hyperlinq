## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|               Method |    Job |  Runtime | Count |       Mean |      Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-----------:|-----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |   **5.326 ns** |  **0.1284 ns** | **0.1201 ns** |   **5.286 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |   5.818 ns |  0.1776 ns | 0.1661 ns |   5.892 ns |  1.09 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |  15.348 ns |  0.3654 ns | 0.8173 ns |  15.181 ns |  3.09 |    0.11 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |   8.096 ns |  0.0786 ns | 0.1675 ns |   8.027 ns |  1.52 |    0.05 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 5 | .NET 5.0 |    10 |   4.121 ns |  0.1149 ns | 0.0897 ns |   4.095 ns |  0.78 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |  12.954 ns |  0.1894 ns | 0.1771 ns |  13.007 ns |  2.43 |    0.06 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |  18.033 ns |  0.3586 ns | 0.8094 ns |  17.829 ns |  3.51 |    0.24 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |   8.471 ns |  0.1896 ns | 0.1583 ns |   8.426 ns |  1.59 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |  16.496 ns |  0.2528 ns | 0.2365 ns |  16.551 ns |  3.10 |    0.08 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5 | .NET 5.0 |    10 |  20.915 ns |  0.2479 ns | 0.2319 ns |  20.890 ns |  3.93 |    0.11 |      - |     - |     - |         - |
|                      |        |          |       |            |            |           |            |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |   2.902 ns |  0.0808 ns | 0.0717 ns |   2.890 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |   2.890 ns |  0.0632 ns | 0.0560 ns |   2.892 ns |  1.00 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |  14.946 ns |  0.2996 ns | 0.2656 ns |  14.898 ns |  5.15 |    0.13 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |  10.473 ns |  0.1069 ns | 0.0947 ns |  10.460 ns |  3.61 |    0.10 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 6 | .NET 6.0 |    10 |   3.858 ns |  0.0621 ns | 0.0551 ns |   3.868 ns |  1.33 |    0.04 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |  12.485 ns |  0.2250 ns | 0.1994 ns |  12.424 ns |  4.30 |    0.11 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |  21.000 ns |  0.3887 ns | 0.3636 ns |  20.841 ns |  7.22 |    0.18 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |   5.948 ns |  0.1751 ns | 0.1462 ns |   5.887 ns |  2.05 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |  15.112 ns |  0.2951 ns | 0.4594 ns |  14.905 ns |  5.36 |    0.13 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6 | .NET 6.0 |    10 |  15.130 ns |  0.1741 ns | 0.3354 ns |  15.058 ns |  5.20 |    0.17 |      - |     - |     - |         - |
|                      |        |          |       |            |            |           |            |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** | **528.692 ns** |  **9.4091 ns** | **8.8012 ns** | **523.893 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 536.888 ns | 10.6330 ns | 9.9461 ns | 535.186 ns |  1.02 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 408.475 ns |  4.0251 ns | 3.3611 ns | 407.874 ns |  0.77 |    0.01 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 396.689 ns |  2.9537 ns | 2.7629 ns | 395.797 ns |  0.75 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 5 | .NET 5.0 |  1000 | 103.290 ns |  0.8525 ns | 0.7975 ns | 103.307 ns |  0.20 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 404.094 ns |  3.0308 ns | 2.5308 ns | 403.690 ns |  0.77 |    0.01 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 570.770 ns | 10.5898 ns | 9.9057 ns | 565.832 ns |  1.08 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 557.800 ns |  4.4594 ns | 3.7238 ns | 556.763 ns |  1.06 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 401.947 ns |  7.9333 ns | 7.7915 ns | 399.927 ns |  0.76 |    0.02 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5 | .NET 5.0 |  1000 | 118.281 ns |  2.2554 ns | 2.1097 ns | 117.687 ns |  0.22 |    0.01 |      - |     - |     - |         - |
|                      |        |          |       |            |            |           |            |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 360.615 ns |  5.9129 ns | 5.5310 ns | 359.848 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 359.750 ns |  6.8945 ns | 6.1118 ns | 357.368 ns |  1.00 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 277.222 ns |  1.6979 ns | 1.5051 ns | 276.814 ns |  0.77 |    0.01 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 266.298 ns |  1.0329 ns | 0.9157 ns | 266.248 ns |  0.74 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 6 | .NET 6.0 |  1000 |  85.714 ns |  0.4525 ns | 0.3778 ns |  85.667 ns |  0.24 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 274.198 ns |  0.7641 ns | 0.7148 ns | 274.199 ns |  0.76 |    0.01 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 531.879 ns |  1.8949 ns | 1.7725 ns | 531.685 ns |  1.48 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 524.272 ns |  1.7082 ns | 1.5978 ns | 524.145 ns |  1.45 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 269.719 ns |  2.4172 ns | 2.1428 ns | 268.822 ns |  0.75 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6 | .NET 6.0 |  1000 | 602.274 ns |  3.5497 ns | 3.3204 ns | 602.431 ns |  1.67 |    0.03 |      - |     - |     - |         - |
