## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

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
|              **ForLoop** |          **4** |    **10** |    **362.2 ns** |   **1.19 ns** |   **1.05 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |    362.4 ns |   1.35 ns |   1.20 ns |  1.00 |    0.00 |  0.3209 |     - |     - |     672 B |
|                 Linq |          4 |    10 |    728.0 ns |   2.70 ns |   2.40 ns |  2.01 |    0.01 |  0.2899 |     - |     - |     608 B |
|               LinqAF |          4 |    10 |    881.2 ns |   2.68 ns |   2.38 ns |  2.43 |    0.01 |  0.6189 |     - |     - |   1,296 B |
|           StructLinq |          4 |    10 |    484.5 ns |   3.60 ns |   3.00 ns |  1.34 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |    471.0 ns |   1.77 ns |   1.57 ns |  1.30 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |    427.9 ns |   0.73 ns |   0.65 ns |  1.18 |    0.00 |       - |     - |     - |         - |
|                      |            |       |             |           |           |       |         |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** | **30,826.7 ns** | **445.62 ns** | **372.11 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop |          4 |  1000 | 30,714.2 ns | 160.35 ns | 133.90 ns |  1.00 |    0.01 | 27.7710 |     - |     - |  58,672 B |
|                 Linq |          4 |  1000 | 63,846.0 ns | 617.44 ns | 606.41 ns |  2.07 |    0.03 | 15.7471 |     - |     - |  33,104 B |
|               LinqAF |          4 |  1000 | 78,626.2 ns | 266.80 ns | 222.79 ns |  2.55 |    0.03 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq |          4 |  1000 | 33,429.3 ns |  62.64 ns |  55.53 ns |  1.08 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 | 30,595.2 ns |  85.61 ns |  80.08 ns |  0.99 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 | 30,972.6 ns | 121.16 ns | 107.40 ns |  1.01 |    0.01 |       - |     - |     - |         - |
