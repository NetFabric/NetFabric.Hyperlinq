## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|              **ForLoop** |    **10** |     **14.84 ns** |  **0.127 ns** |  **0.106 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     33.34 ns |  0.337 ns |  0.282 ns |  2.25 |    0.03 |      - |     - |     - |         - |
|                 Linq |    10 |     96.60 ns |  0.363 ns |  0.303 ns |  6.51 |    0.05 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |    10 |     48.73 ns |  0.447 ns |  0.396 ns |  3.28 |    0.04 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |     98.40 ns |  0.494 ns |  0.412 ns |  6.63 |    0.06 |      - |     - |     - |         - |
|           StructLinq |    10 |     41.98 ns |  0.197 ns |  0.174 ns |  2.83 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     38.15 ns |  0.182 ns |  0.162 ns |  2.57 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     43.28 ns |  0.125 ns |  0.105 ns |  2.92 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     38.60 ns |  0.105 ns |  0.094 ns |  2.60 |    0.02 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **1,564.94 ns** | **24.347 ns** | **22.774 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  3,903.71 ns | 39.332 ns | 36.792 ns |  2.49 |    0.03 |      - |     - |     - |         - |
|                 Linq |  1000 | 10,559.92 ns | 29.567 ns | 24.689 ns |  6.75 |    0.09 | 0.0305 |     - |     - |      72 B |
|           LinqFaster |  1000 |  4,949.95 ns | 27.089 ns | 22.621 ns |  3.16 |    0.05 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF |  1000 | 12,234.13 ns | 31.410 ns | 26.229 ns |  7.82 |    0.11 |      - |     - |     - |         - |
|           StructLinq |  1000 |  6,474.84 ns | 35.170 ns | 32.898 ns |  4.14 |    0.07 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  1,569.42 ns | 12.005 ns | 10.025 ns |  1.00 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  6,108.65 ns | 30.785 ns | 28.796 ns |  3.90 |    0.07 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  2,007.10 ns | 27.750 ns | 24.599 ns |  1.28 |    0.03 |      - |     - |     - |         - |
