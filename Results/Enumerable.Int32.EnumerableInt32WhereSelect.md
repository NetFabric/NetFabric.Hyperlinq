## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|               Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **62.02 ns** |   **0.319 ns** |   **0.299 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |   204.98 ns |   1.532 ns |   1.433 ns |  3.31 |    0.03 | 0.0763 |     - |     - |     160 B |
|               LinqAF |    10 |   151.15 ns |   0.951 ns |   0.843 ns |  2.44 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   133.77 ns |   2.495 ns |   2.212 ns |  2.16 |    0.04 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |    88.90 ns |   1.787 ns |   2.886 ns |  1.45 |    0.04 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |   118.19 ns |   0.689 ns |   0.575 ns |  1.90 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    80.13 ns |   0.327 ns |   0.290 ns |  1.29 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |             |            |            |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,688.17 ns** |  **23.003 ns** |  **21.517 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 9,444.37 ns | 130.623 ns | 122.185 ns |  2.01 |    0.03 | 0.0763 |     - |     - |     160 B |
|               LinqAF |  1000 | 8,804.62 ns |  59.641 ns |  46.564 ns |  1.88 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 8,315.35 ns |  72.170 ns |  63.977 ns |  1.77 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 | 5,722.20 ns |  53.902 ns |  47.783 ns |  1.22 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 8,495.50 ns |  31.403 ns |  26.223 ns |  1.81 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 5,557.96 ns |  26.114 ns |  23.150 ns |  1.19 |    0.01 | 0.0153 |     - |     - |      40 B |
