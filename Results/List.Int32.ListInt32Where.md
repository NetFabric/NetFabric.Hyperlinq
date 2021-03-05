## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **14.38 ns** |  **0.059 ns** |  **0.052 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     32.02 ns |  0.208 ns |  0.185 ns |  2.23 |    0.02 |      - |     - |     - |         - |
|                 Linq |    10 |     89.98 ns |  0.311 ns |  0.275 ns |  6.26 |    0.03 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |    10 |     45.24 ns |  0.226 ns |  0.200 ns |  3.15 |    0.02 | 0.0344 |     - |     - |      72 B |
|               LinqAF |    10 |     94.92 ns |  0.162 ns |  0.144 ns |  6.60 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |     39.34 ns |  0.136 ns |  0.121 ns |  2.74 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     37.20 ns |  0.105 ns |  0.093 ns |  2.59 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     40.85 ns |  0.121 ns |  0.114 ns |  2.84 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     37.69 ns |  0.047 ns |  0.039 ns |  2.62 |    0.01 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |  **1,482.95 ns** |  **3.916 ns** |  **3.471 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  3,834.89 ns | 13.059 ns | 11.577 ns |  2.59 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 10,303.21 ns | 28.483 ns | 23.784 ns |  6.95 |    0.03 | 0.0305 |     - |     - |      72 B |
|           LinqFaster |  1000 |  4,709.84 ns | 10.773 ns |  9.550 ns |  3.18 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|               LinqAF |  1000 | 11,603.58 ns | 25.617 ns | 22.709 ns |  7.82 |    0.02 |      - |     - |     - |         - |
|           StructLinq |  1000 |  6,036.20 ns |  5.093 ns |  4.253 ns |  4.07 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  1,493.68 ns |  4.257 ns |  3.982 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,418.03 ns | 17.802 ns | 15.781 ns |  3.65 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  1,916.32 ns | 15.390 ns | 13.643 ns |  1.29 |    0.01 |      - |     - |     - |         - |
