## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method | Duplicates | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |          **4** |    **10** |    **434.63 ns** |   **8.437 ns** |   **9.027 ns** |    **436.03 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |    478.78 ns |   2.833 ns |   2.650 ns |    478.44 ns |  1.10 |    0.03 |  0.3204 |     - |     - |     672 B |
|                 Linq |          4 |    10 |    891.67 ns |  17.699 ns |  35.346 ns |    870.77 ns |  2.06 |    0.07 |  0.2937 |     - |     - |     616 B |
|           LinqFaster |          4 |    10 |     69.30 ns |   0.611 ns |   0.542 ns |     69.39 ns |  0.16 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |    10 |  1,131.12 ns |  17.370 ns |  14.505 ns |  1,130.09 ns |  2.61 |    0.07 |  0.6180 |     - |     - |   1,296 B |
|           StructLinq |          4 |    10 |    502.94 ns |   2.110 ns |   1.974 ns |    503.15 ns |  1.16 |    0.03 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |    494.39 ns |   2.058 ns |   1.825 ns |    493.65 ns |  1.14 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |    449.51 ns |   2.965 ns |   2.773 ns |    450.10 ns |  1.04 |    0.02 |       - |     - |     - |         - |
|                      |            |       |              |            |            |              |       |         |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** | **34,143.33 ns** | **199.494 ns** | **186.607 ns** | **34,153.77 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop |          4 |  1000 | 41,114.72 ns | 194.001 ns | 162.000 ns | 41,117.80 ns |  1.20 |    0.01 | 27.7710 |     - |     - |  58,672 B |
|                 Linq |          4 |  1000 | 76,615.76 ns | 574.632 ns | 509.396 ns | 76,481.40 ns |  2.24 |    0.02 | 15.7471 |     - |     - |  33,112 B |
|           LinqFaster |          4 |  1000 |  8,866.58 ns |  32.927 ns |  30.800 ns |  8,864.88 ns |  0.26 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |  1000 | 90,437.61 ns | 444.920 ns | 394.410 ns | 90,393.61 ns |  2.65 |    0.02 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq |          4 |  1000 | 32,992.44 ns | 203.908 ns | 190.736 ns | 33,051.43 ns |  0.97 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 | 33,777.33 ns | 189.668 ns | 168.136 ns | 33,772.10 ns |  0.99 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 | 33,896.83 ns | 193.307 ns | 161.420 ns | 33,858.56 ns |  0.99 |    0.01 |       - |     - |     - |         - |
