## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|               Method | Count |        Mean |     Error |    StdDev | Ratio |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **242.0 ns** |   **0.80 ns** |   **0.67 ns** |  **1.00** |  **0.3405** |     **-** |     **-** |     **712 B** |
|                 Linq |    10 |    337.8 ns |   1.67 ns |   1.40 ns |  1.40 |  0.2942 |     - |     - |     616 B |
|               LinqAF |    10 |    448.6 ns |   3.55 ns |   3.32 ns |  1.86 |  0.2942 |     - |     - |     616 B |
|           StructLinq |    10 |    354.8 ns |   1.25 ns |   1.10 ns |  1.47 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    348.8 ns |   2.05 ns |   1.81 ns |  1.44 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    276.1 ns |   0.88 ns |   0.82 ns |  1.14 |  0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |         |       |       |           |
|          **ForeachLoop** |  **1000** | **16,914.9 ns** |  **52.36 ns** |  **46.42 ns** |  **1.00** | **27.7710** |     **-** |     **-** |  **58,712 B** |
|                 Linq |  1000 | 25,411.8 ns |  96.04 ns |  85.14 ns |  1.50 | 15.7776 |     - |     - |  33,112 B |
|               LinqAF |  1000 | 31,884.9 ns | 159.19 ns | 124.29 ns |  1.89 | 19.5923 |     - |     - |  41,224 B |
|           StructLinq |  1000 | 18,813.7 ns |  66.85 ns |  62.53 ns |  1.11 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 18,343.8 ns |  53.63 ns |  47.55 ns |  1.08 |       - |     - |     - |      40 B |
|            Hyperlinq |  1000 | 17,173.1 ns |  78.53 ns |  73.46 ns |  1.01 |       - |     - |     - |      40 B |
