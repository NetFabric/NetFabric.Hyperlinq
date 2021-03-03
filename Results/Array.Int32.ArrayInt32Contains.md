## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |     Error |    StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **5.178 ns** | **0.0216 ns** | **0.0202 ns** |     **5.175 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     3.075 ns | 0.0644 ns | 0.0902 ns |     3.059 ns |  0.60 |    0.02 |      - |     - |     - |         - |
|                 Linq |    10 |    16.412 ns | 0.2417 ns | 0.1887 ns |    16.353 ns |  3.17 |    0.04 |      - |     - |     - |         - |
|           LinqFaster |    10 |     9.333 ns | 0.0240 ns | 0.0224 ns |     9.332 ns |  1.80 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |    10 |     3.477 ns | 0.0178 ns | 0.0166 ns |     3.471 ns |  0.67 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    10.032 ns | 0.0250 ns | 0.0222 ns |    10.031 ns |  1.94 |    0.01 |      - |     - |     - |         - |
|           StructLinq |    10 |    15.173 ns | 0.0910 ns | 0.0851 ns |    15.167 ns |  2.93 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    11.638 ns | 0.0320 ns | 0.0300 ns |    11.624 ns |  2.25 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    13.843 ns | 0.2265 ns | 0.4085 ns |    13.639 ns |  2.71 |    0.10 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |    17.065 ns | 0.0527 ns | 0.0493 ns |    17.068 ns |  3.30 |    0.01 |      - |     - |     - |         - |
|                      |       |              |           |           |              |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **349.855 ns** | **1.7080 ns** | **1.3335 ns** |   **349.666 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   524.396 ns | 3.7039 ns | 3.2834 ns |   522.992 ns |  1.50 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 |   245.004 ns | 0.6725 ns | 0.6291 ns |   245.463 ns |  0.70 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |  1000 |   227.545 ns | 0.3929 ns | 0.3281 ns |   227.582 ns |  0.65 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD |  1000 |    81.447 ns | 0.8170 ns | 0.6822 ns |    81.106 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 |   233.147 ns | 1.2451 ns | 1.1647 ns |   232.713 ns |  0.67 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 |   541.656 ns | 2.7684 ns | 2.4541 ns |   540.814 ns |  1.55 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,036.815 ns | 7.1914 ns | 6.0051 ns | 1,035.109 ns |  2.97 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   231.223 ns | 0.3273 ns | 0.2902 ns |   231.246 ns |  0.66 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   107.536 ns | 0.2290 ns | 0.2030 ns |   107.477 ns |  0.31 |    0.00 |      - |     - |     - |         - |
