## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|               Method |    Job |  Runtime | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |    **10** |    **60.78 ns** |  **0.372 ns** |  **0.348 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    68.77 ns |  0.819 ns |  0.766 ns |  1.13 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    92.63 ns |  0.455 ns |  0.425 ns |  1.52 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    76.08 ns |  0.938 ns |  0.877 ns |  1.25 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    63.60 ns |  0.267 ns |  0.237 ns |  1.05 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    73.71 ns |  0.690 ns |  0.645 ns |  1.21 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |        |          |       |             |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |    32.59 ns |  0.119 ns |  0.111 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    41.99 ns |  0.206 ns |  0.172 ns |  1.29 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    59.15 ns |  0.106 ns |  0.094 ns |  1.81 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    54.72 ns |  0.378 ns |  0.316 ns |  1.68 |    0.01 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |    42.67 ns |  0.113 ns |  0.095 ns |  1.31 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    41.00 ns |  0.483 ns |  0.452 ns |  1.26 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |        |          |       |             |           |           |       |         |        |       |       |           |
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |  **1000** | **4,729.56 ns** | **87.521 ns** | **85.957 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 4,682.46 ns | 14.462 ns | 13.527 ns |  0.99 |    0.02 | 0.0153 |     - |     - |      40 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 6,016.28 ns | 34.022 ns | 28.410 ns |  1.27 |    0.02 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 4,450.23 ns | 47.680 ns | 39.815 ns |  0.94 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 4,432.34 ns | 27.275 ns | 24.178 ns |  0.94 |    0.02 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 5,447.24 ns | 24.839 ns | 22.020 ns |  1.15 |    0.02 | 0.0153 |     - |     - |      40 B |
|                      |        |          |       |             |           |           |       |         |        |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 2,083.14 ns |  7.609 ns |  7.118 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 2,625.55 ns | 14.942 ns | 13.246 ns |  1.26 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 3,508.76 ns |  9.406 ns |  7.854 ns |  1.68 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 3,144.26 ns | 13.504 ns | 12.632 ns |  1.51 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 3,132.51 ns | 16.029 ns | 14.993 ns |  1.50 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 2,634.77 ns |  9.398 ns |  8.791 ns |  1.26 |    0.01 | 0.0191 |     - |     - |      40 B |
