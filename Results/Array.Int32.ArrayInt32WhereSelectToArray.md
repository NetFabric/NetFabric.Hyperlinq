## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **32.57 ns** |   **0.225 ns** |   **0.210 ns** |     **1.00** |    **0.00** |  **0.0497** |     **-** |     **-** |     **104 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |     33.33 ns |   0.484 ns |   0.404 ns |     1.02 |    0.02 |  0.0497 |     - |     - |     104 B |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    108.29 ns |   0.265 ns |   0.248 ns |     3.32 |    0.02 |  0.0842 |     - |     - |     176 B |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |     39.91 ns |   0.272 ns |   0.254 ns |     1.23 |    0.01 |  0.0458 |     - |     - |      96 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    101.57 ns |   0.433 ns |   0.384 ns |     3.12 |    0.02 |  0.0343 |     - |     - |      72 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 46,980.77 ns | 138.513 ns | 122.788 ns | 1,442.36 |    9.47 | 14.5874 |     - |     - |  30,578 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    273.68 ns |   1.995 ns |   1.866 ns |     8.40 |    0.08 |  0.2937 |     - |     - |     616 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    127.64 ns |   1.569 ns |   1.390 ns |     3.92 |    0.06 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     87.98 ns |   0.235 ns |   0.209 ns |     2.70 |    0.02 |  0.0153 |     - |     - |      32 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    105.90 ns |   0.269 ns |   0.239 ns |     3.25 |    0.02 |  0.0153 |     - |     - |      32 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     77.83 ns |   0.418 ns |   0.371 ns |     2.39 |    0.02 |  0.0153 |     - |     - |      32 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |     31.91 ns |   0.239 ns |   0.223 ns |     1.00 |    0.00 |  0.0497 |     - |     - |     104 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     31.97 ns |   0.223 ns |   0.197 ns |     1.00 |    0.01 |  0.0497 |     - |     - |     104 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     99.25 ns |   0.588 ns |   0.550 ns |     3.11 |    0.02 |  0.0842 |     - |     - |     176 B |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |     41.28 ns |   0.305 ns |   0.285 ns |     1.29 |    0.01 |  0.0459 |     - |     - |      96 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    105.32 ns |   1.307 ns |   1.021 ns |     3.30 |    0.04 |  0.0343 |     - |     - |      72 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 44,539.35 ns | 160.289 ns | 142.092 ns | 1,396.40 |    8.70 | 14.4653 |     - |     - |  30,320 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    268.49 ns |   2.764 ns |   2.450 ns |     8.42 |    0.09 |  0.2937 |     - |     - |     616 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    130.35 ns |   0.428 ns |   0.357 ns |     4.09 |    0.04 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     87.81 ns |   0.432 ns |   0.404 ns |     2.75 |    0.02 |  0.0153 |     - |     - |      32 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     99.05 ns |   0.895 ns |   0.837 ns |     3.10 |    0.04 |  0.0153 |     - |     - |      32 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     76.74 ns |   0.528 ns |   0.412 ns |     2.40 |    0.03 |  0.0153 |     - |     - |      32 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **2,837.98 ns** |  **17.698 ns** |  **16.554 ns** |     **1.00** |    **0.00** |  **3.0289** |     **-** |     **-** |   **6,344 B** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  2,760.39 ns |  20.638 ns |  19.304 ns |     0.97 |    0.01 |  3.0289 |     - |     - |   6,344 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  5,104.51 ns |  19.636 ns |  18.368 ns |     1.80 |    0.01 |  2.1667 |     - |     - |   4,544 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  4,230.95 ns |  23.556 ns |  22.034 ns |     1.49 |    0.01 |  2.8915 |     - |     - |   6,064 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  7,582.72 ns |  27.974 ns |  23.359 ns |     2.67 |    0.02 |  3.0136 |     - |     - |   6,312 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 49,019.84 ns | 250.862 ns | 195.857 ns |    17.28 |    0.11 | 15.5640 |     - |     - |  32,587 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  9,609.36 ns |  36.600 ns |  34.236 ns |     3.39 |    0.02 |  3.2654 |     - |     - |   6,856 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5,612.39 ns |  26.276 ns |  24.579 ns |     1.98 |    0.01 |  1.0147 |     - |     - |   2,136 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4,185.78 ns |   9.692 ns |   8.093 ns |     1.48 |    0.01 |  0.9689 |     - |     - |   2,040 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5,097.55 ns |  24.500 ns |  21.718 ns |     1.80 |    0.01 |  0.9689 |     - |     - |   2,040 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  3,963.23 ns |  18.387 ns |  17.199 ns |     1.40 |    0.01 |  0.9689 |     - |     - |   2,040 B |
|                      |        |          |       |              |            |            |          |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  1,441.40 ns |  18.467 ns |  17.274 ns |     1.00 |    0.00 |  3.0308 |     - |     - |   6,344 B |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1,427.78 ns |  23.849 ns |  18.620 ns |     0.99 |    0.02 |  3.0308 |     - |     - |   6,344 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5,186.07 ns |  24.473 ns |  21.695 ns |     3.60 |    0.05 |  2.1667 |     - |     - |   4,544 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  4,725.32 ns |  24.673 ns |  23.079 ns |     3.28 |    0.03 |  2.8915 |     - |     - |   6,064 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  7,531.91 ns |  81.846 ns |  63.900 ns |     5.22 |    0.10 |  3.0136 |     - |     - |   6,312 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 46,840.76 ns | 164.534 ns | 153.905 ns |    32.50 |    0.37 | 15.4419 |     - |     - |  32,329 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  8,470.91 ns |  38.913 ns |  30.381 ns |     5.87 |    0.08 |  3.2654 |     - |     - |   6,856 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5,979.96 ns |  17.688 ns |  14.770 ns |     4.14 |    0.05 |  1.0147 |     - |     - |   2,136 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  4,350.07 ns |  24.264 ns |  21.509 ns |     3.02 |    0.03 |  0.9689 |     - |     - |   2,040 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  5,260.90 ns |  40.314 ns |  31.475 ns |     3.64 |    0.06 |  0.9689 |     - |     - |   2,040 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1,317.27 ns |  14.014 ns |  13.109 ns |     0.91 |    0.02 |  0.9747 |     - |     - |   2,040 B |
