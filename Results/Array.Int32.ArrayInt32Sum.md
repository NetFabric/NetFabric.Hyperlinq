## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **3.259 ns** |  **0.0159 ns** |  **0.0149 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     5.167 ns |  0.0233 ns |  0.0182 ns |  1.59 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    52.634 ns |  0.1555 ns |  0.1298 ns | 16.15 |    0.09 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     5.960 ns |  0.0123 ns |  0.0115 ns |  1.83 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |    10 |     6.815 ns |  0.0227 ns |  0.0201 ns |  2.09 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |    29.835 ns |  0.0576 ns |  0.0539 ns |  9.16 |    0.05 |      - |     - |     - |         - |
|           StructLinq |    10 |    16.656 ns |  0.0778 ns |  0.0689 ns |  5.11 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     4.789 ns |  0.0214 ns |  0.0190 ns |  1.47 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    16.154 ns |  0.0466 ns |  0.0413 ns |  4.96 |    0.03 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **525.236 ns** |  **2.8613 ns** |  **2.5365 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   524.463 ns |  1.3337 ns |  1.1137 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 4,167.600 ns | 15.7393 ns | 13.1430 ns |  7.93 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |   524.493 ns |  1.9234 ns |  1.5017 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |  1000 |    52.089 ns |  0.1629 ns |  0.1360 ns |  0.10 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 1,945.075 ns |  3.8995 ns |  3.4568 ns |  3.70 |    0.02 |      - |     - |     - |         - |
|           StructLinq |  1000 |   674.645 ns |  2.0175 ns |  1.7885 ns |  1.28 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   548.587 ns |  1.7447 ns |  1.3621 ns |  1.04 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    84.768 ns |  0.1322 ns |  0.1172 ns |  0.16 |    0.00 |      - |     - |     - |         - |
