## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **61.38 ns** |  **0.175 ns** |  **0.155 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |   183.31 ns |  1.248 ns |  1.106 ns |  2.99 |    0.02 | 0.0763 |     - |     - |     160 B |
|               LinqAF |    10 |   150.89 ns |  0.633 ns |  0.529 ns |  2.46 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   128.26 ns |  1.143 ns |  1.014 ns |  2.09 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |    85.78 ns |  0.478 ns |  0.447 ns |  1.40 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |   114.72 ns |  0.319 ns |  0.266 ns |  1.87 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    80.15 ns |  0.306 ns |  0.287 ns |  1.31 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,343.43 ns** | **14.647 ns** | **12.984 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 9,748.59 ns | 44.918 ns | 39.818 ns |  2.24 |    0.01 | 0.0763 |     - |     - |     160 B |
|               LinqAF |  1000 | 9,160.27 ns | 24.211 ns | 20.218 ns |  2.11 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 7,392.36 ns | 28.664 ns | 25.410 ns |  1.70 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 | 5,643.01 ns | 25.646 ns | 23.990 ns |  1.30 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 7,860.43 ns | 15.537 ns | 12.130 ns |  1.81 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 5,007.60 ns | 28.363 ns | 26.530 ns |  1.15 |    0.01 | 0.0153 |     - |     - |      40 B |
