## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta38](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta38)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |     **0** |     **14.87 ns** |   **0.169 ns** |   **0.150 ns** |     **14.89 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |     0 |     18.91 ns |   0.236 ns |   0.209 ns |     18.86 ns |  1.27 |    0.02 | 0.0191 |     - |     - |      40 B |
|               LinqAF |     0 |     34.05 ns |   0.584 ns |   0.546 ns |     34.14 ns |  2.29 |    0.05 | 0.0191 |     - |     - |      40 B |
|           StructLinq |     0 |     49.05 ns |   0.251 ns |   0.223 ns |     49.08 ns |  3.30 |    0.04 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction |     0 |     35.01 ns |   1.783 ns |   4.791 ns |     32.36 ns |  2.17 |    0.13 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |     0 |     24.35 ns |   0.114 ns |   0.101 ns |     24.33 ns |  1.64 |    0.02 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |     0 |     18.99 ns |   0.092 ns |   0.077 ns |     19.00 ns |  1.28 |    0.02 | 0.0191 |     - |     - |      40 B |
|                      |       |              |            |            |              |       |         |        |       |       |           |
|          **ForeachLoop** |    **10** |     **70.18 ns** |   **0.978 ns** |   **0.817 ns** |     **70.16 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    129.95 ns |   2.592 ns |   3.371 ns |    128.95 ns |  1.86 |    0.06 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |    144.96 ns |   2.866 ns |   5.095 ns |    144.45 ns |  2.08 |    0.09 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    142.79 ns |   2.322 ns |   2.172 ns |    142.89 ns |  2.03 |    0.04 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |     87.86 ns |   1.766 ns |   2.102 ns |     87.11 ns |  1.25 |    0.04 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    134.34 ns |   2.652 ns |   2.724 ns |    133.98 ns |  1.91 |    0.03 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |     77.17 ns |   1.409 ns |   1.249 ns |     77.19 ns |  1.10 |    0.02 | 0.0191 |     - |     - |      40 B |
|                      |       |              |            |            |              |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** |  **7,587.50 ns** | **151.612 ns** | **351.385 ns** |  **7,542.00 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 14,827.39 ns | 263.619 ns | 233.691 ns | 14,817.52 ns |  1.94 |    0.10 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 12,052.87 ns | 239.340 ns | 701.943 ns | 12,006.51 ns |  1.58 |    0.11 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 11,239.73 ns | 222.995 ns | 617.919 ns | 11,320.62 ns |  1.48 |    0.10 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 |  7,743.21 ns | 154.227 ns | 278.103 ns |  7,731.33 ns |  1.01 |    0.07 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 11,198.33 ns | 222.955 ns | 632.485 ns | 11,230.91 ns |  1.47 |    0.10 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 |  7,055.97 ns | 140.071 ns | 289.270 ns |  7,061.24 ns |  0.93 |    0.05 | 0.0153 |     - |     - |      40 B |
