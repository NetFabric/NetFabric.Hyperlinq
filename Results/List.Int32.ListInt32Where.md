## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **14.33 ns** |  **0.071 ns** |  **0.063 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     29.23 ns |  0.130 ns |  0.108 ns |  2.04 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |     90.64 ns |  0.286 ns |  0.254 ns |  6.32 |    0.04 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |    10 |     41.70 ns |  0.260 ns |  0.217 ns |  2.91 |    0.02 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |     94.56 ns |  0.262 ns |  0.232 ns |  6.60 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |     39.10 ns |  0.155 ns |  0.137 ns |  2.73 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     36.80 ns |  0.092 ns |  0.086 ns |  2.57 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     41.33 ns |  0.110 ns |  0.103 ns |  2.88 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     37.93 ns |  0.087 ns |  0.072 ns |  2.65 |    0.01 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **1,476.72 ns** |  **2.060 ns** |  **1.720 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  3,608.05 ns | 22.908 ns | 21.428 ns |  2.45 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 10,210.23 ns | 22.651 ns | 21.188 ns |  6.91 |    0.02 | 0.0305 |     - |     - |      72 B |
|           LinqFaster |  1000 |  4,711.40 ns | 16.568 ns | 14.687 ns |  3.19 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF |  1000 | 11,847.52 ns | 19.489 ns | 16.274 ns |  8.02 |    0.01 |      - |     - |     - |         - |
|           StructLinq |  1000 |  6,281.16 ns | 11.040 ns |  9.787 ns |  4.25 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  1,487.73 ns |  4.414 ns |  4.129 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,400.63 ns | 14.419 ns | 12.782 ns |  3.66 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  1,906.24 ns |  7.646 ns |  7.152 ns |  1.29 |    0.01 |      - |     - |     - |         - |
