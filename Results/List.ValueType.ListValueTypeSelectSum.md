## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **20.51 ns** |   **0.071 ns** |   **0.066 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     51.68 ns |   0.130 ns |   0.122 ns |  2.52 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    128.76 ns |   0.978 ns |   0.867 ns |  6.28 |    0.05 | 0.0458 |     - |     - |      96 B |
|           LinqFaster |    10 |     42.64 ns |   0.121 ns |   0.107 ns |  2.08 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |    146.65 ns |   2.896 ns |   2.844 ns |  7.16 |    0.13 |      - |     - |     - |         - |
|           StructLinq |    10 |     34.58 ns |   0.127 ns |   0.112 ns |  1.69 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |     17.90 ns |   0.039 ns |   0.037 ns |  0.87 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     28.52 ns |   0.079 ns |   0.074 ns |  1.39 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     16.10 ns |   0.044 ns |   0.039 ns |  0.78 |    0.00 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **2,449.10 ns** |   **6.355 ns** |   **5.634 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  4,093.23 ns |  26.459 ns |  24.750 ns |  1.67 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 |  8,943.81 ns |  72.539 ns |  60.573 ns |  3.65 |    0.03 | 0.0458 |     - |     - |      96 B |
|           LinqFaster |  1000 |  4,287.93 ns |   9.102 ns |   8.068 ns |  1.75 |    0.01 |      - |     - |     - |         - |
|               LinqAF |  1000 | 10,296.92 ns | 203.618 ns | 442.649 ns |  4.14 |    0.16 |      - |     - |     - |         - |
|           StructLinq |  1000 |  2,119.78 ns |  20.700 ns |  17.285 ns |  0.87 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |    729.73 ns |   1.267 ns |   1.123 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  1,844.10 ns |   3.369 ns |   2.813 ns |  0.75 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |    604.21 ns |   1.944 ns |   1.819 ns |  0.25 |    0.00 |      - |     - |     - |         - |
