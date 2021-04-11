## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Count |         Mean |     Error |    StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|----------:|----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **5.098 ns** | **0.0533 ns** | **0.0473 ns** |     **5.080 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     6.104 ns | 0.0404 ns | 0.0358 ns |     6.102 ns |  1.20 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |     8.708 ns | 0.0372 ns | 0.0330 ns |     8.697 ns |  1.71 |    0.02 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    31.546 ns | 0.6530 ns | 1.0358 ns |    32.086 ns |  6.01 |    0.21 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    20.007 ns | 0.0750 ns | 0.0702 ns |    20.038 ns |  3.93 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    13.133 ns | 0.0567 ns | 0.0530 ns |    13.116 ns |  2.58 |    0.03 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |    10 |    19.972 ns | 0.0841 ns | 0.0787 ns |    19.963 ns |  3.92 |    0.04 |      - |     - |     - |         - |
|                      |          |          |       |              |           |           |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     3.189 ns | 0.0279 ns | 0.0233 ns |     3.197 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     5.783 ns | 0.0270 ns | 0.0239 ns |     5.785 ns |  1.81 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    11.136 ns | 0.0312 ns | 0.0261 ns |    11.136 ns |  3.49 |    0.03 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    17.347 ns | 0.1195 ns | 0.1118 ns |    17.343 ns |  5.44 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     6.694 ns | 0.1020 ns | 0.2324 ns |     6.630 ns |  2.13 |    0.13 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    13.160 ns | 0.0254 ns | 0.0238 ns |    13.170 ns |  4.13 |    0.03 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |    10 |    18.181 ns | 0.0980 ns | 0.0917 ns |    18.173 ns |  5.70 |    0.06 |      - |     - |     - |         - |
|                      |          |          |       |              |           |           |              |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |   **530.897 ns** | **2.3621 ns** | **2.2095 ns** |   **530.726 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |   526.015 ns | 1.6581 ns | 1.3846 ns |   526.174 ns |  0.99 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 |   241.673 ns | 0.8672 ns | 0.7687 ns |   241.805 ns |  0.46 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 1,898.444 ns | 8.5728 ns | 7.5995 ns | 1,897.993 ns |  3.58 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 1,840.874 ns | 5.9151 ns | 5.2436 ns | 1,841.623 ns |  3.47 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 |   237.236 ns | 1.1056 ns | 0.9800 ns |   237.099 ns |  0.45 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5.0 | .NET 5.0 |  1000 |   117.137 ns | 0.4946 ns | 0.4385 ns |   117.227 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|                      |          |          |       |              |           |           |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |   354.871 ns | 1.9483 ns | 1.7271 ns |   354.363 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |   531.716 ns | 3.1982 ns | 2.9916 ns |   530.780 ns |  1.50 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 |   275.179 ns | 1.1044 ns | 0.9790 ns |   275.439 ns |  0.78 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 |   806.101 ns | 3.2251 ns | 3.0168 ns |   805.581 ns |  2.27 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |   527.900 ns | 2.4995 ns | 2.2158 ns |   527.204 ns |  1.49 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 |   274.081 ns | 0.5995 ns | 0.5314 ns |   273.897 ns |  0.77 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6.0 | .NET 6.0 |  1000 |   111.014 ns | 0.5103 ns | 0.4524 ns |   110.899 ns |  0.31 |    0.00 |      - |     - |     - |         - |
