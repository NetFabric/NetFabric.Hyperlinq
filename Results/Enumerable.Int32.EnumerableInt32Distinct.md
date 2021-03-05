## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |   StdDev | Ratio |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|---------:|------:|--------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **232.7 ns** |   **0.55 ns** |  **0.46 ns** |  **1.00** |  **0.3405** |     **-** |     **-** |     **712 B** |
|                 Linq |    10 |    326.5 ns |   0.83 ns |  0.74 ns |  1.40 |  0.2942 |     - |     - |     616 B |
|               LinqAF |    10 |    437.0 ns |   1.38 ns |  1.22 ns |  1.88 |  0.2942 |     - |     - |     616 B |
|           StructLinq |    10 |    347.7 ns |   0.77 ns |  0.72 ns |  1.49 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    341.1 ns |   0.98 ns |  0.87 ns |  1.47 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    272.9 ns |   0.69 ns |  0.65 ns |  1.17 |  0.0191 |     - |     - |      40 B |
|                      |       |             |           |          |       |         |       |       |           |
|          **ForeachLoop** |  **1000** | **15,874.7 ns** |  **61.74 ns** | **57.75 ns** |  **1.00** | **27.7710** |     **-** |     **-** |  **58,712 B** |
|                 Linq |  1000 | 23,341.0 ns |  72.08 ns | 60.19 ns |  1.47 | 15.7776 |     - |     - |  33,112 B |
|               LinqAF |  1000 | 30,731.8 ns | 110.35 ns | 92.14 ns |  1.94 | 19.5923 |     - |     - |  41,224 B |
|           StructLinq |  1000 | 18,149.6 ns |  62.47 ns | 55.38 ns |  1.14 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 18,050.5 ns |  44.64 ns | 41.75 ns |  1.14 |       - |     - |     - |      40 B |
|            Hyperlinq |  1000 | 15,555.8 ns |  46.85 ns | 43.82 ns |  0.98 |       - |     - |     - |      40 B |
