## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|               Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **5.151 ns** | **0.0383 ns** | **0.0339 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     5.206 ns | 0.0321 ns | 0.0285 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    15.383 ns | 0.1765 ns | 0.1474 ns |  2.99 |    0.02 |      - |     - |     - |         - |
|           LinqFaster |    10 |     9.322 ns | 0.0307 ns | 0.0273 ns |  1.81 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |    10 |     5.000 ns | 0.0490 ns | 0.0459 ns |  0.97 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |    11.119 ns | 0.0947 ns | 0.0840 ns |  2.16 |    0.02 |      - |     - |     - |         - |
|           StructLinq |    10 |    17.774 ns | 0.1602 ns | 0.1498 ns |  3.45 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    11.859 ns | 0.0679 ns | 0.0635 ns |  2.30 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    16.139 ns | 0.1432 ns | 0.1270 ns |  3.13 |    0.03 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |    20.117 ns | 0.0572 ns | 0.0535 ns |  3.90 |    0.03 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **534.876 ns** | **6.2381 ns** | **5.2091 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   540.704 ns | 2.2868 ns | 2.0272 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 |   254.431 ns | 3.6833 ns | 3.4453 ns |  0.48 |    0.01 |      - |     - |     - |         - |
|           LinqFaster |  1000 |   244.463 ns | 0.9886 ns | 0.7718 ns |  0.46 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD |  1000 |    88.752 ns | 0.9411 ns | 0.8803 ns |  0.17 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 |   239.348 ns | 0.9353 ns | 0.7811 ns |  0.45 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 |   578.153 ns | 4.4444 ns | 4.1573 ns |  1.08 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,058.936 ns | 4.9232 ns | 4.3643 ns |  1.98 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   239.523 ns | 1.4518 ns | 1.2123 ns |  0.45 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   116.842 ns | 0.5991 ns | 0.5311 ns |  0.22 |    0.00 |      - |     - |     - |         - |
