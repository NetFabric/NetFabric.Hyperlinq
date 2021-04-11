## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method |      Job |  Runtime | Duplicates | Count |         Mean |        Error |       StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |----------- |------ |-------------:|-------------:|-------------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |          **4** |    **10** |    **399.69 ns** |     **2.532 ns** |     **2.368 ns** |    **399.33 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |          4 |    10 |    464.88 ns |     3.153 ns |     2.795 ns |    464.19 ns |  1.16 |    0.01 |  0.3209 |     - |     - |     672 B |
|                 Linq | .NET 5.0 | .NET 5.0 |          4 |    10 |    915.80 ns |    13.728 ns |    11.463 ns |    917.61 ns |  2.29 |    0.04 |  0.2937 |     - |     - |     616 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |          4 |    10 |     67.53 ns |     0.317 ns |     0.281 ns |     67.49 ns |  0.17 |    0.00 |       - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |          4 |    10 |  1,098.29 ns |    20.692 ns |    46.280 ns |  1,080.19 ns |  2.84 |    0.17 |  0.6180 |     - |     - |   1,296 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |          4 |    10 |    512.63 ns |     2.902 ns |     2.572 ns |    512.44 ns |  1.28 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |          4 |    10 |    508.48 ns |     3.823 ns |     3.389 ns |    507.51 ns |  1.27 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |          4 |    10 |    432.79 ns |     1.440 ns |     1.277 ns |    432.99 ns |  1.08 |    0.01 |       - |     - |     - |         - |
|                      |          |          |            |       |              |              |              |              |       |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |          4 |    10 |    410.27 ns |     6.501 ns |     5.428 ns |    408.25 ns |  1.00 |    0.00 |  0.3171 |     - |     - |     664 B |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |          4 |    10 |    374.18 ns |     2.197 ns |     1.948 ns |    374.21 ns |  0.91 |    0.01 |  0.3171 |     - |     - |     664 B |
|                 Linq | .NET 6.0 | .NET 6.0 |          4 |    10 |    623.37 ns |     1.834 ns |     1.626 ns |    623.24 ns |  1.52 |    0.02 |  0.3166 |     - |     - |     664 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |          4 |    10 |     63.98 ns |     0.298 ns |     0.264 ns |     64.06 ns |  0.16 |    0.00 |       - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |          4 |    10 |  1,029.43 ns |     5.460 ns |     5.362 ns |  1,030.01 ns |  2.51 |    0.04 |  0.6180 |     - |     - |   1,296 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |          4 |    10 |    477.55 ns |     1.637 ns |     1.532 ns |    478.04 ns |  1.16 |    0.02 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |          4 |    10 |    486.16 ns |     2.395 ns |     2.123 ns |    485.81 ns |  1.18 |    0.02 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |          4 |    10 |    441.11 ns |     3.171 ns |     2.648 ns |    440.20 ns |  1.08 |    0.02 |       - |     - |     - |         - |
|                      |          |          |            |       |              |              |              |              |       |         |         |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |          **4** |  **1000** | **36,960.52 ns** |   **211.483 ns** |   **197.821 ns** | **36,987.96 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |          4 |  1000 | 40,097.05 ns |   216.783 ns |   192.172 ns | 40,082.39 ns |  1.09 |    0.01 | 27.7710 |     - |     - |  58,672 B |
|                 Linq | .NET 5.0 | .NET 5.0 |          4 |  1000 | 70,425.63 ns |   439.891 ns |   343.438 ns | 70,417.60 ns |  1.91 |    0.02 | 15.7471 |     - |     - |  33,112 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |          4 |  1000 |  8,566.81 ns |    68.675 ns |    60.878 ns |  8,555.14 ns |  0.23 |    0.00 |       - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |          4 |  1000 | 89,200.78 ns |   286.351 ns |   253.842 ns | 89,119.27 ns |  2.41 |    0.02 | 53.9551 |     - |     - | 113,186 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |          4 |  1000 | 32,336.53 ns |   178.889 ns |   167.333 ns | 32,333.70 ns |  0.87 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |          4 |  1000 | 32,077.87 ns |   160.818 ns |   134.290 ns | 32,114.12 ns |  0.87 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |          4 |  1000 | 33,355.71 ns |   141.380 ns |   110.380 ns | 33,370.90 ns |  0.90 |    0.01 |       - |     - |     - |         - |
|                      |          |          |            |       |              |              |              |              |       |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |          4 |  1000 | 35,146.32 ns |   258.990 ns |   229.588 ns | 35,178.02 ns |  1.00 |    0.00 | 27.7710 |     - |     - |  58,664 B |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |          4 |  1000 | 30,651.97 ns |   148.201 ns |   131.377 ns | 30,668.61 ns |  0.87 |    0.01 | 27.7710 |     - |     - |  58,664 B |
|                 Linq | .NET 6.0 | .NET 6.0 |          4 |  1000 | 56,003.93 ns |   338.940 ns |   264.622 ns | 56,067.43 ns |  1.59 |    0.01 | 27.7710 |     - |     - |  58,664 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |          4 |  1000 |  7,884.80 ns |    27.908 ns |    24.740 ns |  7,886.03 ns |  0.22 |    0.00 |       - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |          4 |  1000 | 94,838.87 ns | 1,891.657 ns | 4,112.307 ns | 92,599.88 ns |  2.68 |    0.10 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |          4 |  1000 | 31,080.77 ns |   135.106 ns |   126.378 ns | 31,039.18 ns |  0.88 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |          4 |  1000 | 31,462.59 ns |   295.946 ns |   247.128 ns | 31,408.81 ns |  0.90 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |          4 |  1000 | 34,081.03 ns |   283.999 ns |   251.758 ns | 34,029.50 ns |  0.97 |    0.01 |       - |     - |     - |         - |
