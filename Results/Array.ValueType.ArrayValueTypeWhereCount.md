## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|               Method | Count |          Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |      **8.409 ns** |  **0.0479 ns** |  **0.0424 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     15.167 ns |  0.0806 ns |  0.0715 ns |  1.80 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |     73.965 ns |  0.3800 ns |  0.3554 ns |  8.80 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     27.364 ns |  0.1308 ns |  0.1159 ns |  3.25 |    0.03 |      - |     - |     - |         - |
|               LinqAF |    10 |     88.290 ns |  1.7350 ns |  2.5431 ns | 10.36 |    0.36 |      - |     - |     - |         - |
|           StructLinq |    10 |     52.655 ns |  0.1521 ns |  0.1423 ns |  6.26 |    0.03 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     40.756 ns |  0.1261 ns |  0.1179 ns |  4.85 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     66.556 ns |  0.2238 ns |  0.1984 ns |  7.91 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     50.592 ns |  0.1454 ns |  0.1214 ns |  6.01 |    0.03 |      - |     - |     - |         - |
|                      |       |               |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |    **855.114 ns** | **11.5026 ns** | **10.7596 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  4,323.335 ns | 18.0590 ns | 14.0992 ns |  5.06 |    0.08 |      - |     - |     - |         - |
|                 Linq |  1000 | 12,200.242 ns | 52.2313 ns | 48.8572 ns | 14.27 |    0.17 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |  3,894.358 ns | 26.8526 ns | 25.1179 ns |  4.56 |    0.07 |      - |     - |     - |         - |
|               LinqAF |  1000 | 11,489.253 ns | 68.1896 ns | 63.7846 ns | 13.44 |    0.17 |      - |     - |     - |         - |
|           StructLinq |  1000 |  5,122.865 ns | 32.2392 ns | 30.1565 ns |  5.99 |    0.08 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  1,761.381 ns | 19.0541 ns | 15.9110 ns |  2.06 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  5,203.075 ns | 15.6787 ns | 13.8988 ns |  6.09 |    0.09 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  3,489.997 ns |  7.3334 ns |  6.5008 ns |  4.08 |    0.06 |      - |     - |     - |         - |
