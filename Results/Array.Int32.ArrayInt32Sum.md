## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|               Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **5.311 ns** |  **0.0236 ns** |  **0.0185 ns** |     **5.314 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     5.133 ns |  0.0193 ns |  0.0161 ns |     5.134 ns |  0.97 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    57.043 ns |  1.1540 ns |  1.9906 ns |    55.938 ns | 11.23 |    0.24 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     4.580 ns |  0.0783 ns |  0.0654 ns |     4.579 ns |  0.86 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |    10 |     7.096 ns |  0.0874 ns |  0.0817 ns |     7.070 ns |  1.34 |    0.02 |      - |     - |     - |         - |
|               LinqAF |    10 |    30.891 ns |  0.1702 ns |  0.1508 ns |    30.948 ns |  5.81 |    0.04 |      - |     - |     - |         - |
|           StructLinq |    10 |    19.134 ns |  0.3889 ns |  0.4322 ns |    19.221 ns |  3.59 |    0.11 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     5.046 ns |  0.0272 ns |  0.0241 ns |     5.045 ns |  0.95 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    17.332 ns |  0.1373 ns |  0.1217 ns |    17.331 ns |  3.26 |    0.03 |      - |     - |     - |         - |
|                      |       |              |            |            |              |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **544.943 ns** |  **5.2189 ns** |  **4.6264 ns** |   **545.542 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   541.486 ns |  3.3117 ns |  2.7654 ns |   541.470 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 4,038.266 ns | 25.5642 ns | 22.6620 ns | 4,029.720 ns |  7.41 |    0.08 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |   457.431 ns |  1.9684 ns |  1.7450 ns |   457.138 ns |  0.84 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD |  1000 |    76.236 ns |  0.4873 ns |  0.4558 ns |    76.194 ns |  0.14 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 1,993.949 ns | 12.7170 ns | 11.8955 ns | 1,993.707 ns |  3.66 |    0.02 |      - |     - |     - |         - |
|           StructLinq |  1000 |   695.315 ns |  3.3337 ns |  2.9553 ns |   694.180 ns |  1.28 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   614.524 ns |  3.1297 ns |  2.7744 ns |   614.000 ns |  1.13 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    89.605 ns |  0.3267 ns |  0.3056 ns |    89.668 ns |  0.16 |    0.00 |      - |     - |     - |         - |
