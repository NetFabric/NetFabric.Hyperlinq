## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
|               Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **58.40 ns** |   **0.280 ns** |   **0.248 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    97.23 ns |   1.875 ns |   1.842 ns |  1.66 |    0.03 |      - |     - |     - |         - |
|                 Linq |    10 |    32.41 ns |   0.336 ns |   0.280 ns |  0.55 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |    10 |    29.83 ns |   0.163 ns |   0.136 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    29.36 ns |   0.090 ns |   0.080 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|           StructLinq |    10 |    58.38 ns |   0.373 ns |   0.312 ns |  1.00 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |    61.26 ns |   0.400 ns |   0.355 ns |  1.05 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    30.53 ns |   0.139 ns |   0.116 ns |  0.52 |    0.00 |      - |     - |     - |         - |
|                      |       |             |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **6,293.53 ns** |  **15.656 ns** |  **13.879 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 7,904.14 ns | 157.673 ns | 245.478 ns |  1.25 |    0.04 |      - |     - |     - |         - |
|                 Linq |  1000 | 2,356.47 ns |  20.611 ns |  19.280 ns |  0.37 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |  1000 | 2,342.18 ns |  11.427 ns |   8.922 ns |  0.37 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,439.62 ns |  16.817 ns |  14.908 ns |  0.39 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 | 4,330.44 ns |  18.288 ns |  16.212 ns |  0.69 |    0.00 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 | 4,276.04 ns |  22.072 ns |  19.566 ns |  0.68 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 2,428.13 ns |   9.043 ns |   7.551 ns |  0.39 |    0.00 |      - |     - |     - |         - |
