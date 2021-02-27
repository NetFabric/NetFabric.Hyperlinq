## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method | Duplicates | Count |          Mean |        Error |       StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |--------------:|-------------:|-------------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |          **4** |    **10** |     **411.87 ns** |     **3.733 ns** |     **3.492 ns** |    **411.63 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |     493.32 ns |     3.522 ns |     3.123 ns |    492.82 ns |  1.20 |    0.01 |  0.3204 |     - |     - |     672 B |
|                 Linq |          4 |    10 |     865.00 ns |     5.747 ns |     4.799 ns |    864.44 ns |  2.10 |    0.02 |  0.2937 |     - |     - |     616 B |
|           LinqFaster |          4 |    10 |      68.45 ns |     0.242 ns |     0.189 ns |     68.40 ns |  0.17 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |    10 |   1,147.63 ns |     7.385 ns |     6.547 ns |  1,147.27 ns |  2.79 |    0.02 |  0.6180 |     - |     - |   1,296 B |
|           StructLinq |          4 |    10 |     501.54 ns |     2.691 ns |     2.385 ns |    501.92 ns |  1.22 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |     496.61 ns |     2.239 ns |     2.094 ns |    496.92 ns |  1.21 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |     498.41 ns |     2.203 ns |     1.953 ns |    498.54 ns |  1.21 |    0.01 |       - |     - |     - |         - |
|                      |            |       |               |              |              |              |       |         |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** |  **34,783.48 ns** |   **299.066 ns** |   **279.746 ns** | **34,724.05 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop |          4 |  1000 |  42,932.45 ns |   177.976 ns |   157.771 ns | 42,911.10 ns |  1.23 |    0.01 | 27.7710 |     - |     - |  58,672 B |
|                 Linq |          4 |  1000 |  72,265.20 ns |   514.572 ns |   456.154 ns | 72,278.41 ns |  2.08 |    0.03 | 15.7471 |     - |     - |  33,112 B |
|           LinqFaster |          4 |  1000 |   8,730.93 ns |    80.295 ns |    67.050 ns |  8,723.71 ns |  0.25 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |  1000 | 101,045.89 ns | 2,013.339 ns | 5,160.956 ns | 99,045.26 ns |  3.13 |    0.22 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq |          4 |  1000 |  31,833.17 ns |   127.552 ns |   106.511 ns | 31,811.61 ns |  0.91 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 |  32,304.52 ns |   216.637 ns |   169.136 ns | 32,303.68 ns |  0.93 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 |  40,906.79 ns |   217.751 ns |   181.832 ns | 40,895.19 ns |  1.17 |    0.01 |       - |     - |     - |         - |
