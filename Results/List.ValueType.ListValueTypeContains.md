## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
|               Method |    Job |  Runtime | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |    **10** |    **61.58 ns** |   **0.277 ns** |   **0.231 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |    10 |    87.29 ns |   1.591 ns |   4.218 ns |  1.50 |    0.11 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    26.44 ns |   0.111 ns |   0.103 ns |  0.43 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 | .NET 5.0 |    10 |    25.43 ns |   0.103 ns |   0.091 ns |  0.41 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    26.82 ns |   0.101 ns |   0.089 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    51.94 ns |   0.281 ns |   0.263 ns |  0.84 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    48.17 ns |   0.276 ns |   0.230 ns |  0.78 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    29.31 ns |   0.209 ns |   0.186 ns |  0.48 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |             |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |    10 |    56.66 ns |   0.334 ns |   0.296 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |    85.89 ns |   1.704 ns |   4.083 ns |  1.61 |    0.09 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    25.15 ns |   0.058 ns |   0.049 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | .NET 6.0 |    10 |    34.32 ns |   0.213 ns |   0.189 ns |  0.61 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    27.04 ns |   0.298 ns |   0.278 ns |  0.48 |    0.01 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    54.80 ns |   1.143 ns |   2.385 ns |  1.00 |    0.04 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |    55.50 ns |   0.188 ns |   0.166 ns |  0.98 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    29.15 ns |   0.208 ns |   0.194 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |             |            |            |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |  **1000** | **6,077.47 ns** |  **25.162 ns** |  **23.537 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 8,260.19 ns | 164.323 ns | 300.475 ns |  1.35 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 1,731.03 ns |   5.288 ns |   4.128 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 1,839.51 ns |   4.569 ns |   3.567 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 1,734.06 ns |   6.557 ns |   6.134 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 3,921.97 ns |  32.219 ns |  26.904 ns |  0.65 |    0.01 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 4,187.09 ns |  19.781 ns |  15.444 ns |  0.69 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 1,737.29 ns |   4.554 ns |   3.556 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |             |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 6,470.59 ns |  22.986 ns |  19.195 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 7,548.63 ns | 147.162 ns | 220.265 ns |  1.17 |    0.04 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 1,840.05 ns |   9.716 ns |   7.585 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 1,845.65 ns |   6.936 ns |   6.488 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 1,843.62 ns |   5.894 ns |   4.922 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 5,228.85 ns |  17.619 ns |  14.712 ns |  0.81 |    0.00 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 4,942.56 ns |  23.181 ns |  21.683 ns |  0.76 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 1,853.27 ns |   7.938 ns |   7.037 ns |  0.29 |    0.00 |      - |     - |     - |         - |
