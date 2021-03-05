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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Duplicates | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |          **4** |    **10** |    **357.9 ns** |   **2.47 ns** |   **2.06 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |    357.5 ns |   2.48 ns |   2.07 ns |  1.00 |    0.01 |  0.3209 |     - |     - |     672 B |
|                 Linq |          4 |    10 |    730.9 ns |   4.85 ns |   4.53 ns |  2.04 |    0.02 |  0.2899 |     - |     - |     608 B |
|               LinqAF |          4 |    10 |    882.1 ns |   8.22 ns |   7.69 ns |  2.46 |    0.03 |  0.6189 |     - |     - |   1,296 B |
|           StructLinq |          4 |    10 |    489.7 ns |   1.16 ns |   1.03 ns |  1.37 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |    472.3 ns |   1.61 ns |   1.42 ns |  1.32 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |    404.7 ns |   1.16 ns |   0.97 ns |  1.13 |    0.01 |       - |     - |     - |         - |
|                      |            |       |             |           |           |       |         |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** | **29,393.1 ns** |  **74.73 ns** |  **69.91 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,672 B** |
|          ForeachLoop |          4 |  1000 | 29,360.7 ns |  72.19 ns |  60.29 ns |  1.00 |    0.00 | 27.7710 |     - |     - |  58,672 B |
|                 Linq |          4 |  1000 | 63,564.2 ns | 283.19 ns | 221.09 ns |  2.16 |    0.01 | 15.7471 |     - |     - |  33,104 B |
|               LinqAF |          4 |  1000 | 77,212.9 ns | 317.73 ns | 281.66 ns |  2.63 |    0.01 | 53.9551 |     - |     - | 113,184 B |
|           StructLinq |          4 |  1000 | 33,227.6 ns | 122.48 ns | 114.57 ns |  1.13 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 | 30,466.1 ns |  39.88 ns |  31.13 ns |  1.04 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 | 30,088.2 ns |  82.08 ns |  76.78 ns |  1.02 |    0.00 |       - |     - |     - |         - |
