## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |    **10** |     **60.03 ns** |   **0.222 ns** |   **0.197 ns** |   **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 |    10 |     73.89 ns |   0.452 ns |   0.401 ns |   1.23 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |     89.12 ns |   0.383 ns |   0.339 ns |   1.48 |    0.01 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |    10 | 37,944.24 ns | 185.951 ns | 164.841 ns | 632.11 |    3.50 | 9.8267 |     - |     - |  20,582 B |
|              Streams | .NET 5 | .NET 5.0 |    10 |    295.66 ns |   1.231 ns |   1.091 ns |   4.93 |    0.02 | 0.1912 |     - |     - |     400 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    109.27 ns |   0.276 ns |   0.258 ns |   1.82 |    0.01 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |     73.22 ns |   0.340 ns |   0.318 ns |   1.22 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |     76.15 ns |   0.210 ns |   0.196 ns |   1.27 |    0.00 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |    10 |     61.98 ns |   0.293 ns |   0.260 ns |   1.03 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |        |         |        |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |     39.27 ns |   0.438 ns |   0.409 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |     47.12 ns |   0.245 ns |   0.229 ns |   1.20 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |     63.17 ns |   0.317 ns |   0.281 ns |   1.61 |    0.02 | 0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |    10 | 36,512.03 ns | 213.105 ns | 199.339 ns | 929.78 |   12.52 | 9.7046 |     - |     - |  20,333 B |
|              Streams | .NET 6 | .NET 6.0 |    10 |    251.81 ns |   1.176 ns |   1.100 ns |   6.41 |    0.07 | 0.1912 |     - |     - |     400 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |     83.20 ns |   0.407 ns |   0.340 ns |   2.12 |    0.02 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |     45.75 ns |   0.318 ns |   0.298 ns |   1.17 |    0.02 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |     52.23 ns |   0.197 ns |   0.174 ns |   1.33 |    0.02 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |    10 |     37.88 ns |   0.152 ns |   0.119 ns |   0.97 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |        |         |        |       |       |           |
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |  **1000** |  **4,548.15 ns** |  **17.076 ns** |  **14.259 ns** |   **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  9,909.83 ns |  37.071 ns |  34.676 ns |   2.18 |    0.01 | 0.0153 |     - |     - |      40 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  6,122.09 ns |  56.874 ns |  44.403 ns |   1.35 |    0.01 | 0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 48,473.63 ns | 275.227 ns | 257.448 ns |  10.66 |    0.06 | 9.8267 |     - |     - |  20,582 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  8,047.29 ns |  33.238 ns |  27.755 ns |   1.77 |    0.01 | 0.1831 |     - |     - |     400 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5,732.38 ns |  19.957 ns |  18.668 ns |   1.26 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4,958.08 ns |  22.009 ns |  18.379 ns |   1.09 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5,449.00 ns |  11.878 ns |  10.530 ns |   1.20 |    0.00 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4,557.75 ns |  26.902 ns |  22.464 ns |   1.00 |    0.01 | 0.0153 |     - |     - |      40 B |
|                      |        |          |       |              |            |            |        |         |        |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  2,980.35 ns |  20.511 ns |  17.128 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  3,591.39 ns |  21.186 ns |  19.818 ns |   1.21 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  4,170.37 ns |  19.650 ns |  18.381 ns |   1.40 |    0.01 | 0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 47,151.12 ns | 368.210 ns | 344.424 ns |  15.83 |    0.18 | 9.5825 |     - |     - |  20,333 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  5,844.09 ns |  18.397 ns |  17.209 ns |   1.96 |    0.01 | 0.1907 |     - |     - |     400 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  3,671.84 ns |  12.962 ns |  12.125 ns |   1.23 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,869.46 ns |  12.320 ns |  10.921 ns |   0.96 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  3,903.51 ns |  14.110 ns |  12.508 ns |   1.31 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2,868.25 ns |   8.223 ns |   7.289 ns |   0.96 |    0.01 | 0.0191 |     - |     - |      40 B |
