## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|               Method |      Job |  Runtime | Duplicates | Count |        Mean |       Error |      StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |----------- |------ |------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |          **4** |    **10** |    **360.1 ns** |     **3.64 ns** |     **5.67 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |          4 |    10 |    358.4 ns |     4.70 ns |     4.17 ns |  1.00 |    0.02 |  0.3209 |     - |     - |     672 B |
|                 Linq | .NET 5.0 | .NET 5.0 |          4 |    10 |    778.5 ns |    15.58 ns |    21.32 ns |  2.16 |    0.08 |  0.2899 |     - |     - |     608 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |          4 |    10 |    917.7 ns |    16.25 ns |    15.20 ns |  2.55 |    0.06 |  0.6180 |     - |     - |   1,296 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |          4 |    10 |    491.3 ns |     4.78 ns |     4.47 ns |  1.37 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |          4 |    10 |    505.6 ns |     7.80 ns |     7.29 ns |  1.41 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |          4 |    10 |    429.0 ns |     2.14 ns |     1.90 ns |  1.19 |    0.02 |       - |     - |     - |         - |
|                      |          |          |            |       |             |             |             |       |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |          4 |    10 |    354.3 ns |     2.31 ns |     2.05 ns |  1.00 |    0.00 |  0.3171 |     - |     - |     664 B |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |          4 |    10 |    386.4 ns |     7.74 ns |    10.06 ns |  1.08 |    0.03 |  0.3171 |     - |     - |     664 B |
|                 Linq | .NET 6.0 | .NET 6.0 |          4 |    10 |    555.7 ns |     7.39 ns |     6.92 ns |  1.57 |    0.02 |  0.3128 |     - |     - |     656 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |          4 |    10 |    870.3 ns |    15.92 ns |    14.11 ns |  2.46 |    0.04 |  0.6189 |     - |     - |   1,296 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |          4 |    10 |    488.1 ns |     7.48 ns |     7.00 ns |  1.38 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |          4 |    10 |    499.5 ns |     9.33 ns |     8.27 ns |  1.41 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |          4 |    10 |    438.4 ns |     4.35 ns |     3.86 ns |  1.24 |    0.01 |       - |     - |     - |         - |
|                      |          |          |            |       |             |             |             |       |         |         |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |          **4** |  **1000** | **30,192.6 ns** |   **225.97 ns** |   **188.69 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |          4 |  1000 | 30,439.1 ns |   406.38 ns |   339.34 ns |  1.01 |    0.02 | 27.7710 |     - |     - |  58,672 B |
|                 Linq | .NET 5.0 | .NET 5.0 |          4 |  1000 | 68,872.9 ns |   768.24 ns |   681.03 ns |  2.28 |    0.02 | 15.7471 |     - |     - |  33,104 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |          4 |  1000 | 81,876.3 ns | 1,224.44 ns | 1,145.34 ns |  2.71 |    0.04 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |          4 |  1000 | 33,794.4 ns |   276.60 ns |   215.95 ns |  1.12 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |          4 |  1000 | 34,157.6 ns |   233.70 ns |   207.17 ns |  1.13 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |          4 |  1000 | 32,279.3 ns |   196.30 ns |   163.92 ns |  1.07 |    0.01 |       - |     - |     - |         - |
|                      |          |          |            |       |             |             |             |       |         |         |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |          4 |  1000 | 28,518.2 ns |   194.13 ns |   172.09 ns |  1.00 |    0.00 | 27.7710 |     - |     - |  58,664 B |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |          4 |  1000 | 32,215.2 ns |   334.41 ns |   296.44 ns |  1.13 |    0.01 | 27.7710 |     - |     - |  58,664 B |
|                 Linq | .NET 6.0 | .NET 6.0 |          4 |  1000 | 46,366.3 ns |   143.58 ns |   127.28 ns |  1.63 |    0.01 | 27.7710 |     - |     - |  58,656 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |          4 |  1000 | 77,448.0 ns |   610.42 ns |   541.12 ns |  2.72 |    0.02 | 53.9551 |     - |     - | 113,185 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |          4 |  1000 | 31,948.9 ns |   538.19 ns |   477.09 ns |  1.12 |    0.02 |       - |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |          4 |  1000 | 32,217.2 ns |   160.79 ns |   142.53 ns |  1.13 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |          4 |  1000 | 32,744.8 ns |   158.36 ns |   148.13 ns |  1.15 |    0.01 |       - |     - |     - |         - |
