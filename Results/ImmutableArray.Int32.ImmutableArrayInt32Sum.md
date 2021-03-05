## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|              **ForLoop** |    **10** |     **3.275 ns** | **0.0114 ns** | **0.0095 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     5.701 ns | 0.0140 ns | 0.0117 ns |  1.74 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    62.717 ns | 0.2554 ns | 0.1994 ns | 19.15 |    0.08 | 0.0267 |     - |     - |      56 B |
|           StructLinq |    10 |    27.590 ns | 0.0800 ns | 0.0668 ns |  8.43 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    19.700 ns | 0.0643 ns | 0.0570 ns |  6.01 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    16.105 ns | 0.0328 ns | 0.0256 ns |  4.92 |    0.01 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **386.796 ns** | **1.0100 ns** | **0.8434 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   523.452 ns | 1.4212 ns | 1.1867 ns |  1.35 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 3,955.111 ns | 9.8414 ns | 9.2056 ns | 10.23 |    0.04 | 0.0229 |     - |     - |      56 B |
|           StructLinq |  1000 | 1,842.086 ns | 6.2708 ns | 5.5589 ns |  4.76 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,816.740 ns | 3.2917 ns | 2.9180 ns |  4.70 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    84.368 ns | 0.2941 ns | 0.2607 ns |  0.22 |    0.00 |      - |     - |     - |         - |
