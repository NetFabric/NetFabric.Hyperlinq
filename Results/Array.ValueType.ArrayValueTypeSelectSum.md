## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|               Method | Count |         Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **4.911 ns** |   **0.0413 ns** |   **0.0386 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    15.614 ns |   0.0616 ns |   0.0514 ns |  3.18 |    0.03 |      - |     - |     - |         - |
|                 Linq |    10 |    87.911 ns |   0.5352 ns |   0.4745 ns | 17.92 |    0.15 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    34.734 ns |   0.1353 ns |   0.1266 ns |  7.07 |    0.07 |      - |     - |     - |         - |
|               LinqAF |    10 |    86.055 ns |   1.6046 ns |   1.7169 ns | 17.48 |    0.38 |      - |     - |     - |         - |
|           StructLinq |    10 |    31.927 ns |   0.1900 ns |   0.1684 ns |  6.51 |    0.06 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     8.106 ns |   0.0712 ns |   0.0631 ns |  1.65 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    68.608 ns |   0.4589 ns |   0.4293 ns | 13.97 |    0.14 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    51.457 ns |   0.1830 ns |   0.1712 ns | 10.48 |    0.07 |      - |     - |     - |         - |
|                      |       |              |             |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **631.439 ns** |   **1.8610 ns** |   **1.4529 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 2,050.765 ns |   7.3061 ns |   6.4766 ns |  3.25 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,325.399 ns |  45.9149 ns |  38.3410 ns | 10.01 |    0.06 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 3,774.659 ns |  12.6604 ns |  11.8425 ns |  5.98 |    0.02 |      - |     - |     - |         - |
|               LinqAF |  1000 | 7,601.768 ns | 131.3504 ns | 122.8653 ns | 11.99 |    0.17 |      - |     - |     - |         - |
|           StructLinq |  1000 | 2,023.372 ns |  13.7501 ns |  12.1891 ns |  3.20 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   739.263 ns |   4.0372 ns |   3.3712 ns |  1.17 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,065.646 ns |  28.7025 ns |  26.8483 ns |  8.02 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 3,793.337 ns |  14.4592 ns |  13.5252 ns |  6.01 |    0.03 |      - |     - |     - |         - |
