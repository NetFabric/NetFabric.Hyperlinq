## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **265.9 ns** |   **1.75 ns** |   **1.55 ns** |  **1.00** |    **0.00** |  **0.3405** |     **-** |     **-** |     **712 B** |
|                 Linq |    10 |    357.4 ns |   2.01 ns |   1.78 ns |  1.34 |    0.01 |  0.2942 |     - |     - |     616 B |
|               LinqAF |    10 |    467.7 ns |   2.41 ns |   2.02 ns |  1.76 |    0.01 |  0.2937 |     - |     - |     616 B |
|           StructLinq |    10 |    365.9 ns |   2.72 ns |   2.12 ns |  1.38 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    351.6 ns |   2.12 ns |   1.77 ns |  1.32 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    297.3 ns |   1.91 ns |   1.59 ns |  1.12 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |         |         |       |       |           |
|          **ForeachLoop** |  **1000** | **18,660.2 ns** | **130.07 ns** | **108.61 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,712 B** |
|                 Linq |  1000 | 26,170.6 ns | 127.81 ns | 106.72 ns |  1.40 |    0.01 | 15.7776 |     - |     - |  33,112 B |
|               LinqAF |  1000 | 33,595.6 ns | 214.97 ns | 190.56 ns |  1.80 |    0.02 | 19.5923 |     - |     - |  41,224 B |
|           StructLinq |  1000 | 18,822.3 ns | 110.97 ns |  92.67 ns |  1.01 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 18,608.2 ns |  88.82 ns |  78.74 ns |  1.00 |    0.01 |       - |     - |     - |      40 B |
|            Hyperlinq |  1000 | 17,520.9 ns |  70.74 ns |  62.71 ns |  0.94 |    0.01 |       - |     - |     - |      40 B |
