## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|               Method | Count |          Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |      **8.390 ns** |  **0.0701 ns** |  **0.0621 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     15.250 ns |  0.1018 ns |  0.0952 ns |  1.82 |    0.02 |      - |     - |     - |         - |
|                 Linq |    10 |     75.006 ns |  0.3755 ns |  0.3136 ns |  8.94 |    0.08 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     27.593 ns |  0.1173 ns |  0.1040 ns |  3.29 |    0.03 |      - |     - |     - |         - |
|               LinqAF |    10 |     87.240 ns |  1.6938 ns |  2.0801 ns | 10.35 |    0.31 |      - |     - |     - |         - |
|           StructLinq |    10 |     55.937 ns |  0.4532 ns |  0.4017 ns |  6.67 |    0.08 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     40.743 ns |  0.1034 ns |  0.0864 ns |  4.86 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     66.440 ns |  0.3828 ns |  0.3197 ns |  7.92 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     49.817 ns |  0.1836 ns |  0.1627 ns |  5.94 |    0.05 |      - |     - |     - |         - |
|                      |       |               |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |    **857.019 ns** |  **9.0817 ns** |  **8.4950 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  4,343.453 ns | 16.5416 ns | 13.8130 ns |  5.06 |    0.05 |      - |     - |     - |         - |
|                 Linq |  1000 | 10,375.155 ns | 37.1264 ns | 28.9858 ns | 12.07 |    0.12 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |  3,948.580 ns | 37.7980 ns | 35.3563 ns |  4.61 |    0.06 |      - |     - |     - |         - |
|               LinqAF |  1000 | 12,519.164 ns | 63.8766 ns | 53.3399 ns | 14.58 |    0.16 |      - |     - |     - |         - |
|           StructLinq |  1000 |  5,051.533 ns | 32.8297 ns | 29.1027 ns |  5.89 |    0.08 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  1,718.262 ns | 11.1598 ns |  9.3189 ns |  2.00 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,237.173 ns | 19.2794 ns | 17.0907 ns |  6.10 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  3,793.842 ns | 15.8661 ns | 14.8411 ns |  4.43 |    0.04 |      - |     - |     - |         - |
