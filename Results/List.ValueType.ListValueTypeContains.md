## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
|               Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **58.92 ns** |   **0.144 ns** |   **0.128 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    99.83 ns |   1.836 ns |   1.718 ns |  1.69 |    0.03 |      - |     - |     - |         - |
|                 Linq |    10 |    32.43 ns |   0.134 ns |   0.119 ns |  0.55 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |    10 |    29.55 ns |   0.156 ns |   0.138 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    33.56 ns |   0.109 ns |   0.097 ns |  0.57 |    0.00 |      - |     - |     - |         - |
|           StructLinq |    10 |    57.70 ns |   0.303 ns |   0.269 ns |  0.98 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |    60.34 ns |   0.304 ns |   0.269 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    30.07 ns |   0.075 ns |   0.070 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|                      |       |             |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **6,827.10 ns** |  **23.683 ns** |  **20.994 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 8,305.40 ns | 159.480 ns | 201.691 ns |  1.22 |    0.03 |      - |     - |     - |         - |
|                 Linq |  1000 | 2,319.06 ns |   7.658 ns |   6.395 ns |  0.34 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |  1000 | 2,326.25 ns |   7.927 ns |   7.415 ns |  0.34 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,409.80 ns |   5.762 ns |   5.108 ns |  0.35 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 | 4,323.46 ns |  27.852 ns |  23.257 ns |  0.63 |    0.00 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 | 4,250.74 ns |  20.244 ns |  17.945 ns |  0.62 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 2,329.51 ns |   8.356 ns |   7.408 ns |  0.34 |    0.00 |      - |     - |     - |         - |
