## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **232.0 ns** |   **0.67 ns** |   **0.56 ns** |  **1.00** |    **0.00** |  **0.3405** |     **-** |     **-** |     **712 B** |
|                 Linq |    10 |    323.7 ns |   1.10 ns |   1.02 ns |  1.39 |    0.00 |  0.2942 |     - |     - |     616 B |
|               LinqAF |    10 |    432.9 ns |   1.65 ns |   1.46 ns |  1.87 |    0.01 |  0.2942 |     - |     - |     616 B |
|           StructLinq |    10 |    347.5 ns |   1.71 ns |   1.43 ns |  1.50 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    347.8 ns |   1.32 ns |   1.03 ns |  1.50 |    0.00 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    266.2 ns |   1.35 ns |   1.13 ns |  1.15 |    0.00 |  0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |         |         |       |       |           |
|          **ForeachLoop** |  **1000** | **15,958.6 ns** | **167.93 ns** | **140.23 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,712 B** |
|                 Linq |  1000 | 24,510.1 ns |  83.51 ns |  74.03 ns |  1.54 |    0.01 | 15.7776 |     - |     - |  33,112 B |
|               LinqAF |  1000 | 29,850.9 ns | 124.54 ns | 110.40 ns |  1.87 |    0.02 | 19.5923 |     - |     - |  41,224 B |
|           StructLinq |  1000 | 17,827.9 ns |  37.81 ns |  33.52 ns |  1.12 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 18,199.1 ns |  43.22 ns |  38.31 ns |  1.14 |    0.01 |       - |     - |     - |      40 B |
|            Hyperlinq |  1000 | 16,464.5 ns |  69.08 ns |  61.24 ns |  1.03 |    0.01 |       - |     - |     - |      40 B |
