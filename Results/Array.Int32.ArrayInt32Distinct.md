## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Duplicates | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |          **4** |    **10** |    **385.1 ns** |   **3.45 ns** |   **3.06 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |    382.7 ns |   2.81 ns |   2.49 ns |  0.99 |    0.01 |  0.3209 |     - |     - |     672 B |
|                 Linq |          4 |    10 |    769.5 ns |   5.25 ns |   4.91 ns |  2.00 |    0.02 |  0.2899 |     - |     - |     608 B |
|               LinqAF |          4 |    10 |    937.9 ns |   3.96 ns |   3.51 ns |  2.44 |    0.02 |  0.6189 |     - |     - |   1,296 B |
|           StructLinq |          4 |    10 |    512.0 ns |   5.72 ns |   5.07 ns |  1.33 |    0.02 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |    492.8 ns |   3.96 ns |   3.51 ns |  1.28 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |    511.7 ns |   2.69 ns |   2.24 ns |  1.33 |    0.01 |       - |     - |     - |         - |
|                      |            |       |             |           |           |       |         |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** | **31,787.4 ns** | **191.73 ns** | **169.96 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop |          4 |  1000 | 32,254.1 ns | 127.73 ns |  99.72 ns |  1.01 |    0.01 | 27.7710 |     - |     - |  58,672 B |
|                 Linq |          4 |  1000 | 67,221.2 ns | 447.58 ns | 396.77 ns |  2.11 |    0.02 | 15.7471 |     - |     - |  33,104 B |
|               LinqAF |          4 |  1000 | 85,350.1 ns | 445.24 ns | 394.69 ns |  2.69 |    0.02 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq |          4 |  1000 | 34,382.7 ns | 237.15 ns | 221.83 ns |  1.08 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 | 31,662.9 ns | 205.86 ns | 182.49 ns |  1.00 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 | 39,232.1 ns | 168.28 ns | 157.41 ns |  1.23 |    0.01 |       - |     - |     - |         - |
