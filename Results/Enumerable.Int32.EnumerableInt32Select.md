## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **57.83 ns** |  **0.161 ns** |  **0.142 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |   178.81 ns |  1.596 ns |  1.493 ns |  3.09 |    0.03 | 0.0458 |     - |     - |      96 B |
|               LinqAF |    10 |   130.43 ns |  0.553 ns |  0.490 ns |  2.26 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    92.57 ns |  0.492 ns |  0.436 ns |  1.60 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    67.77 ns |  0.330 ns |  0.293 ns |  1.17 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    95.85 ns |  0.617 ns |  0.547 ns |  1.66 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    64.40 ns |  0.638 ns |  0.565 ns |  1.11 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,311.56 ns** | **39.178 ns** | **32.715 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 9,875.13 ns | 50.938 ns | 47.647 ns |  2.29 |    0.02 | 0.0458 |     - |     - |      96 B |
|               LinqAF |  1000 | 7,520.98 ns | 25.673 ns | 22.758 ns |  1.74 |    0.02 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 5,636.77 ns | 22.097 ns | 19.588 ns |  1.31 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 4,353.62 ns | 40.430 ns | 35.840 ns |  1.01 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 5,995.15 ns | 48.713 ns | 43.183 ns |  1.39 |    0.02 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 4,575.62 ns | 16.085 ns | 14.259 ns |  1.06 |    0.01 | 0.0153 |     - |     - |      40 B |
