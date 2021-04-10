## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|               Method | Count |         Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **4.914 ns** |   **0.0561 ns** |   **0.0497 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    14.386 ns |   0.0795 ns |   0.0705 ns |  2.93 |    0.03 |      - |     - |     - |         - |
|                 Linq |    10 |    89.208 ns |   1.1796 ns |   1.1034 ns | 18.15 |    0.34 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    32.844 ns |   0.1914 ns |   0.1697 ns |  6.68 |    0.07 |      - |     - |     - |         - |
|               LinqAF |    10 |    97.372 ns |   1.8920 ns |   1.8582 ns | 19.76 |    0.41 |      - |     - |     - |         - |
|           StructLinq |    10 |    32.067 ns |   0.1546 ns |   0.1370 ns |  6.53 |    0.08 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     7.079 ns |   0.0736 ns |   0.0615 ns |  1.44 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    65.758 ns |   0.2463 ns |   0.2304 ns | 13.38 |    0.17 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    50.662 ns |   0.1987 ns |   0.1761 ns | 10.31 |    0.12 |      - |     - |     - |         - |
|                      |       |              |             |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **704.272 ns** |   **4.4334 ns** |   **3.9301 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 1,834.293 ns |   5.6195 ns |   4.9816 ns |  2.60 |    0.02 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,245.034 ns |  21.3249 ns |  18.9040 ns |  8.87 |    0.06 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 3,594.543 ns |  16.5689 ns |  14.6879 ns |  5.10 |    0.04 |      - |     - |     - |         - |
|               LinqAF |  1000 | 7,548.559 ns | 145.8962 ns | 209.2399 ns | 10.63 |    0.30 |      - |     - |     - |         - |
|           StructLinq |  1000 | 2,067.170 ns |  13.6194 ns |  12.7396 ns |  2.93 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   804.574 ns |   3.2324 ns |   2.8655 ns |  1.14 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 4,847.895 ns |  20.1206 ns |  17.8364 ns |  6.88 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 3,467.529 ns |   9.7411 ns |   8.6353 ns |  4.92 |    0.03 |      - |     - |     - |         - |
