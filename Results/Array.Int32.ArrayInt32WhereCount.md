## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **7.069 ns** |  **0.0532 ns** |  **0.0472 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     7.792 ns |  0.0459 ns |  0.0407 ns |  1.10 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    71.437 ns |  0.2905 ns |  0.2575 ns | 10.11 |    0.08 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    25.094 ns |  0.0690 ns |  0.0645 ns |  3.55 |    0.02 |      - |     - |     - |         - |
|               LinqAF |    10 |    37.527 ns |  0.4137 ns |  0.3454 ns |  5.31 |    0.05 |      - |     - |     - |         - |
|           StructLinq |    10 |    51.864 ns |  0.3361 ns |  0.2979 ns |  7.34 |    0.07 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    22.594 ns |  0.0709 ns |  0.0592 ns |  3.20 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    30.573 ns |  0.0716 ns |  0.0670 ns |  4.32 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    21.537 ns |  0.0493 ns |  0.0461 ns |  3.05 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **759.879 ns** | **10.8824 ns** | **10.1794 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   830.832 ns | 12.8143 ns | 11.3595 ns |  1.09 |    0.02 |      - |     - |     - |         - |
|                 Linq |  1000 | 8,938.050 ns | 22.6886 ns | 21.2229 ns | 11.76 |    0.16 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 3,254.033 ns | 30.0681 ns | 28.1258 ns |  4.28 |    0.08 |      - |     - |     - |         - |
|               LinqAF |  1000 | 3,953.137 ns | 27.9464 ns | 23.3365 ns |  5.20 |    0.06 |      - |     - |     - |         - |
|           StructLinq |  1000 | 3,418.784 ns | 17.5651 ns | 15.5710 ns |  4.50 |    0.06 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |   717.725 ns |  4.5522 ns |  3.8013 ns |  0.94 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,606.241 ns |  5.2758 ns |  4.4055 ns |  2.11 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |   662.440 ns |  1.8387 ns |  1.6299 ns |  0.87 |    0.01 |      - |     - |     - |         - |
