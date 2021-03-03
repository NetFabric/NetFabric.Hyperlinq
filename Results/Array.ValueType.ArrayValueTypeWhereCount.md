## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |      **7.405 ns** |   **0.0231 ns** |   **0.0205 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     14.727 ns |   0.0344 ns |   0.0305 ns |  1.99 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |     75.478 ns |   0.3185 ns |   0.2823 ns | 10.19 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     26.429 ns |   0.0827 ns |   0.0733 ns |  3.57 |    0.02 |      - |     - |     - |         - |
|               LinqAF |    10 |     85.709 ns |   1.7062 ns |   3.0327 ns | 11.35 |    0.31 |      - |     - |     - |         - |
|           StructLinq |    10 |     50.342 ns |   0.1475 ns |   0.1308 ns |  6.80 |    0.03 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     39.801 ns |   0.0669 ns |   0.0593 ns |  5.38 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     64.508 ns |   0.1698 ns |   0.1506 ns |  8.71 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     48.718 ns |   0.0742 ns |   0.0694 ns |  6.58 |    0.02 |      - |     - |     - |         - |
|                      |       |               |             |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |    **821.153 ns** |   **3.8848 ns** |   **3.4437 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  2,033.215 ns |  29.6261 ns |  23.1301 ns |  2.47 |    0.03 |      - |     - |     - |         - |
|                 Linq |  1000 | 10,247.812 ns |  45.8662 ns |  40.6592 ns | 12.48 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |  3,800.754 ns |   8.9759 ns |   7.9569 ns |  4.63 |    0.02 |      - |     - |     - |         - |
|               LinqAF |  1000 | 11,862.243 ns | 137.6326 ns | 122.0077 ns | 14.45 |    0.19 |      - |     - |     - |         - |
|           StructLinq |  1000 |  4,959.362 ns |  27.3648 ns |  24.2582 ns |  6.04 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  1,659.176 ns |   8.4354 ns |   7.4777 ns |  2.02 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,086.194 ns |   7.2481 ns |   6.0525 ns |  6.19 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  3,681.179 ns |  10.8190 ns |   9.5908 ns |  4.48 |    0.02 |      - |     - |     - |         - |
