## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **40.09 ns** |   **0.305 ns** |   **0.285 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     51.06 ns |   0.164 ns |   0.137 ns |  1.27 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |    152.02 ns |   1.709 ns |   1.599 ns |  3.79 |    0.06 |  0.1032 |     - |     - |     216 B |
|           LinqFaster |    10 |    129.06 ns |   1.449 ns |   1.355 ns |  3.22 |    0.03 |  0.3901 |     - |     - |     816 B |
|               LinqAF |    10 |    188.44 ns |   2.208 ns |   1.957 ns |  4.70 |    0.06 |       - |     - |     - |         - |
|           StructLinq |    10 |    100.17 ns |   1.983 ns |   3.029 ns |  2.46 |    0.09 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     87.56 ns |   1.704 ns |   1.749 ns |  2.19 |    0.05 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    123.55 ns |   0.419 ns |   0.350 ns |  3.08 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    208.63 ns |   0.817 ns |   0.765 ns |  5.20 |    0.05 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **8,531.83 ns** |  **41.002 ns** |  **34.238 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  9,602.21 ns |  38.096 ns |  31.812 ns |  1.13 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 16,454.02 ns |  58.242 ns |  51.630 ns |  1.93 |    0.01 |  0.0916 |     - |     - |     216 B |
|           LinqFaster |  1000 | 18,542.95 ns |  73.018 ns |  57.008 ns |  2.17 |    0.01 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF |  1000 | 23,042.90 ns | 209.981 ns | 186.143 ns |  2.70 |    0.03 |       - |     - |     - |         - |
|           StructLinq |  1000 | 12,979.79 ns |  70.496 ns |  62.493 ns |  1.52 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  9,750.14 ns |  43.603 ns |  34.042 ns |  1.14 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 16,925.76 ns | 117.185 ns | 109.615 ns |  1.99 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 12,296.24 ns |  58.469 ns |  51.831 ns |  1.44 |    0.01 |       - |     - |     - |         - |
