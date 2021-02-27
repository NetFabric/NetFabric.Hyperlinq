## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|               Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **12.96 ns** |  **0.078 ns** |  **0.065 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     33.36 ns |  0.178 ns |  0.166 ns |  2.57 |    0.02 |      - |     - |     - |         - |
|                 Linq |    10 |    134.13 ns |  0.761 ns |  0.675 ns | 10.34 |    0.07 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |    10 |     52.55 ns |  0.509 ns |  0.451 ns |  4.06 |    0.03 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |    118.82 ns |  0.773 ns |  0.685 ns |  9.18 |    0.07 |      - |     - |     - |         - |
|           StructLinq |    10 |     62.16 ns |  0.561 ns |  0.469 ns |  4.80 |    0.04 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     53.07 ns |  0.238 ns |  0.222 ns |  4.10 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     52.94 ns |  0.336 ns |  0.298 ns |  4.08 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     48.23 ns |  0.277 ns |  0.259 ns |  3.72 |    0.03 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **1,399.39 ns** | **12.822 ns** | **11.993 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  4,021.34 ns | 36.159 ns | 32.054 ns |  2.87 |    0.04 |      - |     - |     - |         - |
|                 Linq |  1000 | 11,969.81 ns | 97.034 ns | 86.018 ns |  8.55 |    0.09 | 0.0610 |     - |     - |     152 B |
|           LinqFaster |  1000 |  6,488.20 ns | 19.200 ns | 16.033 ns |  4.63 |    0.04 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF |  1000 | 12,351.39 ns | 35.832 ns | 29.921 ns |  8.82 |    0.07 |      - |     - |     - |         - |
|           StructLinq |  1000 |  5,393.34 ns | 23.857 ns | 19.921 ns |  3.85 |    0.04 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  1,565.14 ns |  9.332 ns |  7.793 ns |  1.12 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,866.52 ns | 29.200 ns | 25.885 ns |  4.19 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  2,004.97 ns | 19.329 ns | 17.134 ns |  1.43 |    0.01 |      - |     - |     - |         - |
