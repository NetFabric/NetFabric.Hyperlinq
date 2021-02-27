## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **65.31 ns** |  **0.293 ns** |  **0.260 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |   189.41 ns |  2.910 ns |  2.580 ns |  2.90 |    0.04 | 0.0763 |     - |     - |     160 B |
|               LinqAF |    10 |   152.09 ns |  0.796 ns |  0.705 ns |  2.33 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   133.01 ns |  0.776 ns |  0.688 ns |  2.04 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |    86.25 ns |  0.863 ns |  0.673 ns |  1.32 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |   116.27 ns |  0.685 ns |  0.607 ns |  1.78 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    84.84 ns |  0.341 ns |  0.657 ns |  1.30 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,406.64 ns** | **25.103 ns** | **20.962 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 9,821.90 ns | 33.817 ns | 26.402 ns |  2.23 |    0.01 | 0.0763 |     - |     - |     160 B |
|               LinqAF |  1000 | 8,450.99 ns | 85.239 ns | 66.549 ns |  1.92 |    0.02 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 7,442.74 ns | 37.506 ns | 31.319 ns |  1.69 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 | 5,335.21 ns | 43.876 ns | 38.895 ns |  1.21 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 8,493.10 ns | 35.450 ns | 31.425 ns |  1.93 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 5,333.72 ns | 31.125 ns | 24.300 ns |  1.21 |    0.01 | 0.0153 |     - |     - |      40 B |
