## RangeSelectDistinctToArrayBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|         Method | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|           **Linq** |     **0** |    **73.24 ns** | **0.556 ns** | **0.493 ns** |  **1.00** |    **0.00** | **0.1452** |     **-** |     **-** |     **304 B** |
|      Hyperlinq |     0 |    57.02 ns | 0.419 ns | 0.392 ns |  0.78 |    0.01 | 0.0112 |     - |     - |      24 B |
| Hyperlinq_Pool |     0 |          NA |       NA |       NA |     ? |       ? |      - |     - |     - |         - |
|                |       |             |          |          |       |         |        |       |       |           |
|           **Linq** |     **1** |   **115.98 ns** | **1.242 ns** | **1.162 ns** |  **1.00** |    **0.00** | **0.1907** |     **-** |     **-** |     **400 B** |
|      Hyperlinq |     1 |   140.66 ns | 0.595 ns | 0.557 ns |  1.21 |    0.01 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Pool |     1 |   201.72 ns | 0.818 ns | 0.725 ns |  1.74 |    0.02 | 0.0267 |     - |     - |      56 B |
|                |       |             |          |          |       |         |        |       |       |           |
|           **Linq** |    **10** |   **340.24 ns** | **1.784 ns** | **1.581 ns** |  **1.00** |    **0.00** | **0.3481** |     **-** |     **-** |     **728 B** |
|      Hyperlinq |    10 |   265.85 ns | 1.653 ns | 1.466 ns |  0.78 |    0.01 | 0.0305 |     - |     - |      64 B |
| Hyperlinq_Pool |    10 |   345.19 ns | 1.526 ns | 1.352 ns |  1.01 |    0.01 | 0.0267 |     - |     - |      56 B |
|                |       |             |          |          |       |         |        |       |       |           |
|           **Linq** |   **100** | **1,696.17 ns** | **6.998 ns** | **6.204 ns** |  **1.00** |    **0.00** | **0.3471** |     **-** |     **-** |     **728 B** |
|      Hyperlinq |   100 | 1,124.04 ns | 9.601 ns | 8.981 ns |  0.66 |    0.01 | 0.0305 |     - |     - |      64 B |
| Hyperlinq_Pool |   100 | 1,183.79 ns | 8.121 ns | 7.199 ns |  0.70 |    0.00 | 0.0267 |     - |     - |      56 B |

Benchmarks with issues:
  RangeSelectDistinctToArrayBenchmarks.Hyperlinq_Pool: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=0]
