## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Duplicates | Count |        Mean |     Error |    StdDev | Ratio |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |------------:|----------:|----------:|------:|--------:|------:|------:|----------:|
|              **ForLoop** |          **4** |    **10** |    **362.6 ns** |   **1.08 ns** |   **0.95 ns** |  **1.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |    362.7 ns |   2.38 ns |   2.11 ns |  1.00 |  0.3209 |     - |     - |     672 B |
|                 Linq |          4 |    10 |    745.7 ns |   3.17 ns |   2.97 ns |  2.06 |  0.2899 |     - |     - |     608 B |
|               LinqAF |          4 |    10 |    904.0 ns |   5.24 ns |   4.90 ns |  2.49 |  0.6189 |     - |     - |   1,296 B |
|           StructLinq |          4 |    10 |    497.0 ns |   3.08 ns |   2.88 ns |  1.37 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |    488.1 ns |   2.50 ns |   2.34 ns |  1.35 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |    413.3 ns |   0.81 ns |   0.72 ns |  1.14 |       - |     - |     - |         - |
|                      |            |       |             |           |           |       |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** | **29,783.7 ns** | **113.49 ns** | **100.60 ns** |  **1.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop |          4 |  1000 | 29,887.7 ns | 111.69 ns | 104.47 ns |  1.00 | 27.7710 |     - |     - |  58,672 B |
|                 Linq |          4 |  1000 | 65,248.5 ns | 316.61 ns | 280.67 ns |  2.19 | 15.7471 |     - |     - |  33,104 B |
|               LinqAF |          4 |  1000 | 75,565.5 ns | 310.68 ns | 290.61 ns |  2.54 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq |          4 |  1000 | 34,148.6 ns | 140.09 ns | 131.04 ns |  1.15 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 | 31,337.1 ns | 310.67 ns | 290.61 ns |  1.05 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 | 30,953.7 ns |  89.18 ns |  83.42 ns |  1.04 |       - |     - |     - |         - |
