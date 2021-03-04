## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

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
|              **ForLoop** |    **10** |     **7.778 ns** |  **0.0340 ns** |  **0.0318 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     7.422 ns |  0.0360 ns |  0.0319 ns |  0.95 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    61.118 ns |  0.3362 ns |  0.2980 ns |  7.86 |    0.04 | 0.0229 |     - |     - |      48 B |
|           StructLinq |    10 |    60.869 ns |  0.2194 ns |  0.1945 ns |  7.83 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    47.540 ns |  0.2187 ns |  0.1938 ns |  6.11 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    62.769 ns |  0.1849 ns |  0.1639 ns |  8.07 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    48.914 ns |  0.1075 ns |  0.0953 ns |  6.29 |    0.03 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **787.331 ns** | **14.5662 ns** | **13.6252 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   639.736 ns |  8.7621 ns |  8.1961 ns |  0.81 |    0.02 |      - |     - |     - |         - |
|                 Linq |  1000 | 7,347.320 ns | 15.9300 ns | 14.1216 ns |  9.32 |    0.17 | 0.0229 |     - |     - |      48 B |
|           StructLinq |  1000 | 7,386.335 ns | 17.9862 ns | 15.0193 ns |  9.38 |    0.16 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 5,592.282 ns | 31.8131 ns | 29.7580 ns |  7.10 |    0.13 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 8,381.335 ns | 44.2177 ns | 41.3613 ns | 10.65 |    0.18 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 6,282.845 ns | 30.5642 ns | 28.5897 ns |  7.98 |    0.13 |      - |     - |     - |         - |
