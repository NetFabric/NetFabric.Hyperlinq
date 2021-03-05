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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **5.193 ns** | **0.0464 ns** | **0.0387 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     5.179 ns | 0.0249 ns | 0.0233 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    15.006 ns | 0.2313 ns | 0.2050 ns |  2.88 |    0.05 |      - |     - |     - |         - |
|           LinqFaster |    10 |     8.586 ns | 0.0389 ns | 0.0345 ns |  1.65 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |    10 |     3.560 ns | 0.0808 ns | 0.0755 ns |  0.69 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |     9.050 ns | 0.0312 ns | 0.0292 ns |  1.74 |    0.01 |      - |     - |     - |         - |
|           StructLinq |    10 |    15.435 ns | 0.3147 ns | 0.2628 ns |  2.97 |    0.06 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    11.548 ns | 0.0168 ns | 0.0140 ns |  2.22 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    13.391 ns | 0.0373 ns | 0.0331 ns |  2.58 |    0.02 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |    17.218 ns | 0.1311 ns | 0.1226 ns |  3.31 |    0.04 |      - |     - |     - |         - |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **524.143 ns** | **1.9844 ns** | **1.7592 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   523.975 ns | 3.5258 ns | 2.9442 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 |   245.188 ns | 0.5996 ns | 0.5316 ns |  0.47 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |  1000 |   228.493 ns | 1.4292 ns | 1.1934 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD |  1000 |    80.638 ns | 0.2590 ns | 0.2423 ns |  0.15 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 |   234.210 ns | 2.4898 ns | 2.0791 ns |  0.45 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 |   541.949 ns | 1.4392 ns | 1.2758 ns |  1.03 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,039.132 ns | 7.0571 ns | 6.2559 ns |  1.98 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   231.368 ns | 1.1419 ns | 0.9535 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   106.796 ns | 0.2060 ns | 0.1927 ns |  0.20 |    0.00 |      - |     - |     - |         - |
