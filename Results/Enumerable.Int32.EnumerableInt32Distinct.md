## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|               Method |    Job |  Runtime | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |    **10** |    **253.9 ns** |   **0.99 ns** |   **0.88 ns** |  **1.00** |    **0.00** |  **0.3405** |     **-** |     **-** |     **712 B** |
|                 Linq | .NET 5 | .NET 5.0 |    10 |    326.4 ns |   3.85 ns |   3.41 ns |  1.29 |    0.01 |  0.2942 |     - |     - |     616 B |
|               LinqAF | .NET 5 | .NET 5.0 |    10 |    417.9 ns |   1.57 ns |   1.47 ns |  1.65 |    0.01 |  0.2942 |     - |     - |     616 B |
|           StructLinq | .NET 5 | .NET 5.0 |    10 |    365.6 ns |   1.31 ns |   1.23 ns |  1.44 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |    10 |    333.4 ns |   1.51 ns |   1.41 ns |  1.31 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |    10 |    281.5 ns |   1.02 ns |   0.90 ns |  1.11 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |        |          |       |             |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |    10 |    235.7 ns |   1.37 ns |   1.28 ns |  1.00 |    0.00 |  0.3366 |     - |     - |     704 B |
|                 Linq | .NET 6 | .NET 6.0 |    10 |    250.3 ns |   1.95 ns |   1.82 ns |  1.06 |    0.01 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 6 | .NET 6.0 |    10 |    390.8 ns |   4.75 ns |   4.45 ns |  1.66 |    0.02 |  0.2942 |     - |     - |     616 B |
|           StructLinq | .NET 6 | .NET 6.0 |    10 |    324.9 ns |   1.62 ns |   1.26 ns |  1.38 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |    10 |    306.3 ns |   1.89 ns |   1.77 ns |  1.30 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |    10 |    235.0 ns |   1.05 ns |   0.99 ns |  1.00 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |        |          |       |             |           |           |       |         |         |       |       |           |
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** |  **1000** | **18,423.0 ns** | **263.38 ns** | **246.37 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,712 B** |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 23,128.9 ns | 131.80 ns | 102.90 ns |  1.26 |    0.02 | 15.7776 |     - |     - |  33,112 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 29,866.2 ns | 262.86 ns | 245.88 ns |  1.62 |    0.02 | 19.5923 |     - |     - |  41,224 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 17,942.8 ns |  89.76 ns |  74.96 ns |  0.98 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 18,902.0 ns | 102.00 ns |  85.17 ns |  1.03 |    0.01 |       - |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 15,991.8 ns | 102.13 ns |  95.53 ns |  0.87 |    0.01 |       - |     - |     - |      40 B |
|                      |        |          |       |             |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 17,054.7 ns |  82.86 ns |  77.50 ns |  1.00 |    0.00 | 27.7710 |     - |     - |  58,704 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 19,412.1 ns | 277.00 ns | 259.10 ns |  1.14 |    0.02 | 27.7710 |     - |     - |  58,664 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 29,074.6 ns | 342.32 ns | 320.21 ns |  1.70 |    0.02 | 19.5923 |     - |     - |  41,224 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 15,690.0 ns |  55.39 ns |  49.10 ns |  0.92 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 16,124.6 ns |  68.17 ns |  56.92 ns |  0.95 |    0.01 |       - |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 13,531.5 ns |  39.26 ns |  32.78 ns |  0.79 |    0.00 |  0.0153 |     - |     - |      40 B |
