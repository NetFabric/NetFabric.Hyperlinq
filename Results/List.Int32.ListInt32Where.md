## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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
|               Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **14.79 ns** |  **0.085 ns** |  **0.080 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     33.16 ns |  0.188 ns |  0.176 ns |  2.24 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |     94.09 ns |  0.310 ns |  0.275 ns |  6.36 |    0.04 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |    10 |     43.25 ns |  0.345 ns |  0.306 ns |  2.92 |    0.03 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |     97.89 ns |  0.378 ns |  0.335 ns |  6.62 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |     40.61 ns |  0.204 ns |  0.181 ns |  2.75 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     37.74 ns |  0.095 ns |  0.084 ns |  2.55 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     41.88 ns |  0.165 ns |  0.147 ns |  2.83 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     38.23 ns |  0.134 ns |  0.125 ns |  2.59 |    0.01 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **1,548.44 ns** | **18.077 ns** | **16.909 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  4,044.30 ns | 21.253 ns | 19.880 ns |  2.61 |    0.04 |      - |     - |     - |         - |
|                 Linq |  1000 | 10,488.05 ns | 45.392 ns | 37.904 ns |  6.78 |    0.09 | 0.0305 |     - |     - |      72 B |
|           LinqFaster |  1000 |  4,883.25 ns | 27.256 ns | 24.162 ns |  3.16 |    0.04 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF |  1000 | 12,117.92 ns | 26.959 ns | 22.512 ns |  7.83 |    0.09 |      - |     - |     - |         - |
|           StructLinq |  1000 |  6,423.92 ns |  9.001 ns |  8.420 ns |  4.15 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  1,557.76 ns | 25.689 ns | 24.029 ns |  1.01 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,545.59 ns | 18.415 ns | 16.324 ns |  3.58 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  1,980.84 ns | 28.161 ns | 23.516 ns |  1.28 |    0.02 |      - |     - |     - |         - |
