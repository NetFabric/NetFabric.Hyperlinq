## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|               Method | Duplicates | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |------------:|----------:|----------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |          **4** |    **10** |    **365.4 ns** |   **3.52 ns** |   **2.75 ns** |    **365.0 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |    374.6 ns |   9.14 ns |  25.48 ns |    361.1 ns |  1.13 |    0.07 |  0.3209 |     - |     - |     672 B |
|                 Linq |          4 |    10 |    747.0 ns |   2.87 ns |   2.24 ns |    747.3 ns |  2.04 |    0.02 |  0.2899 |     - |     - |     608 B |
|               LinqAF |          4 |    10 |    932.4 ns |   2.63 ns |   2.46 ns |    932.1 ns |  2.55 |    0.02 |  0.6189 |     - |     - |   1,296 B |
|           StructLinq |          4 |    10 |    492.0 ns |   3.05 ns |   2.54 ns |    491.1 ns |  1.35 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |    512.2 ns |   3.29 ns |   2.92 ns |    511.9 ns |  1.40 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |    441.8 ns |   1.75 ns |   1.55 ns |    441.6 ns |  1.21 |    0.01 |       - |     - |     - |         - |
|                      |            |       |             |           |           |             |       |         |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** | **29,966.6 ns** | **157.86 ns** | **139.93 ns** | **29,988.1 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop |          4 |  1000 | 30,050.0 ns | 199.26 ns | 186.39 ns | 29,999.9 ns |  1.00 |    0.01 | 27.7710 |     - |     - |  58,672 B |
|                 Linq |          4 |  1000 | 65,096.5 ns | 381.32 ns | 356.68 ns | 65,092.8 ns |  2.17 |    0.02 | 15.7471 |     - |     - |  33,104 B |
|               LinqAF |          4 |  1000 | 81,173.7 ns | 364.74 ns | 341.18 ns | 81,244.8 ns |  2.71 |    0.02 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq |          4 |  1000 | 34,092.6 ns | 231.89 ns | 181.05 ns | 34,148.4 ns |  1.14 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 | 33,522.8 ns | 138.20 ns | 129.27 ns | 33,527.8 ns |  1.12 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 | 32,887.7 ns | 312.16 ns | 276.72 ns | 32,843.7 ns |  1.10 |    0.01 |       - |     - |     - |         - |
