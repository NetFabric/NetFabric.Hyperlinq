## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|               Method | Duplicates | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |          **4** |    **10** |    **389.10 ns** |   **2.078 ns** |   **1.842 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |    469.63 ns |   2.074 ns |   1.838 ns |  1.21 |    0.01 |  0.3209 |     - |     - |     672 B |
|                 Linq |          4 |    10 |    847.85 ns |   4.083 ns |   3.409 ns |  2.18 |    0.01 |  0.2937 |     - |     - |     616 B |
|           LinqFaster |          4 |    10 |     67.98 ns |   0.372 ns |   0.329 ns |  0.17 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |    10 |  1,105.98 ns |   3.956 ns |   3.700 ns |  2.84 |    0.02 |  0.6180 |     - |     - |   1,296 B |
|           StructLinq |          4 |    10 |    498.76 ns |   1.555 ns |   1.378 ns |  1.28 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |    496.32 ns |   2.266 ns |   2.009 ns |  1.28 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |    426.14 ns |   1.192 ns |   0.995 ns |  1.09 |    0.01 |       - |     - |     - |         - |
|                      |            |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** | **33,298.53 ns** | **169.486 ns** | **158.537 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop |          4 |  1000 | 37,025.15 ns | 201.412 ns | 188.401 ns |  1.11 |    0.01 | 27.7710 |     - |     - |  58,672 B |
|                 Linq |          4 |  1000 | 71,019.31 ns | 466.370 ns | 436.243 ns |  2.13 |    0.02 | 15.7471 |     - |     - |  33,112 B |
|           LinqFaster |          4 |  1000 |  8,677.56 ns |  48.746 ns |  43.212 ns |  0.26 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |  1000 | 91,646.21 ns | 331.543 ns | 310.125 ns |  2.75 |    0.01 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq |          4 |  1000 | 32,727.57 ns | 136.387 ns | 113.889 ns |  0.98 |    0.00 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 | 31,971.09 ns | 143.293 ns | 134.037 ns |  0.96 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 | 32,777.09 ns | 115.042 ns |  89.817 ns |  0.98 |    0.00 |       - |     - |     - |         - |
