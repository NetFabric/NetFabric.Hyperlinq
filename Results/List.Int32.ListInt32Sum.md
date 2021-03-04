## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **12.825 ns** |  **0.0626 ns** |  **0.0586 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    24.649 ns |  0.1050 ns |  0.0930 ns |  1.92 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    97.981 ns |  0.4787 ns |  0.4243 ns |  7.64 |    0.04 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |    10 |     8.758 ns |  0.0353 ns |  0.0330 ns |  0.68 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    71.610 ns |  0.2133 ns |  0.1995 ns |  5.58 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |    19.050 ns |  0.0700 ns |  0.0654 ns |  1.49 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     6.654 ns |  0.0268 ns |  0.0238 ns |  0.52 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    15.859 ns |  0.0450 ns |  0.0421 ns |  1.24 |    0.01 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **1,325.517 ns** |  **3.1330 ns** |  **2.6162 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 2,961.197 ns |  8.5235 ns |  7.5558 ns |  2.23 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,457.244 ns | 23.1840 ns | 21.6863 ns |  4.87 |    0.02 | 0.0153 |     - |     - |      40 B |
|           LinqFaster |  1000 |   800.286 ns |  1.9819 ns |  1.7569 ns |  0.60 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 4,590.309 ns | 21.5873 ns | 19.1365 ns |  3.46 |    0.02 |      - |     - |     - |         - |
|           StructLinq |  1000 |   694.450 ns |  1.8831 ns |  1.5725 ns |  0.52 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   557.858 ns |  1.7401 ns |  1.6277 ns |  0.42 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    89.230 ns |  0.3632 ns |  0.3220 ns |  0.07 |    0.00 |      - |     - |     - |         - |
