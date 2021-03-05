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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Duplicates | Count |         Mean |      Error |       StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|-----------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |          **4** |    **10** |    **376.80 ns** |   **1.089 ns** |     **1.018 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |    421.39 ns |   1.689 ns |     1.497 ns |  1.12 |    0.01 |  0.3209 |     - |     - |     672 B |
|                 Linq |          4 |    10 |    815.33 ns |   2.997 ns |     2.804 ns |  2.16 |    0.01 |  0.2937 |     - |     - |     616 B |
|           LinqFaster |          4 |    10 |     66.31 ns |   0.403 ns |     0.357 ns |  0.18 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |    10 |  1,065.29 ns |   2.095 ns |     1.857 ns |  2.83 |    0.01 |  0.6180 |     - |     - |   1,296 B |
|           StructLinq |          4 |    10 |    502.53 ns |   2.489 ns |     2.206 ns |  1.33 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |    492.86 ns |   3.139 ns |     2.622 ns |  1.31 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |    418.86 ns |   0.786 ns |     0.697 ns |  1.11 |    0.00 |       - |     - |     - |         - |
|                      |            |       |              |            |              |       |         |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** | **32,373.09 ns** | **190.565 ns** |   **168.931 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop |          4 |  1000 | 37,115.58 ns | 142.313 ns |   126.157 ns |  1.15 |    0.01 | 27.7710 |     - |     - |  58,672 B |
|                 Linq |          4 |  1000 | 68,696.73 ns | 247.413 ns |   219.325 ns |  2.12 |    0.01 | 15.7471 |     - |     - |  33,112 B |
|           LinqFaster |          4 |  1000 |  8,626.95 ns |  25.216 ns |    22.353 ns |  0.27 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |  1000 | 91,427.90 ns | 800.982 ns | 1,599.647 ns |  2.86 |    0.07 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq |          4 |  1000 | 30,501.61 ns | 110.641 ns |   103.494 ns |  0.94 |    0.00 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 | 31,659.20 ns |  88.173 ns |    73.628 ns |  0.98 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 | 31,685.48 ns |  81.941 ns |    72.639 ns |  0.98 |    0.01 |       - |     - |     - |         - |
