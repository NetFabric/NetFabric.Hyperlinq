## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |          **4** |    **10** |    **368.12 ns** |   **1.159 ns** |   **1.084 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |    462.47 ns |   0.892 ns |   0.790 ns |  1.26 |    0.00 |  0.3209 |     - |     - |     672 B |
|                 Linq |          4 |    10 |    813.54 ns |   1.656 ns |   1.468 ns |  2.21 |    0.01 |  0.2937 |     - |     - |     616 B |
|           LinqFaster |          4 |    10 |     65.71 ns |   0.197 ns |   0.184 ns |  0.18 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |    10 |  1,009.32 ns |   2.501 ns |   2.339 ns |  2.74 |    0.01 |  0.6180 |     - |     - |    1296 B |
|           StructLinq |          4 |    10 |    488.24 ns |   1.124 ns |   1.051 ns |  1.33 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |    479.12 ns |   2.654 ns |   2.352 ns |  1.30 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |    482.04 ns |   2.455 ns |   2.177 ns |  1.31 |    0.01 |       - |     - |     - |         - |
|                      |            |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** | **31,106.48 ns** | **193.063 ns** | **180.591 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |   **58672 B** |
|          ForeachLoop |          4 |  1000 | 37,471.38 ns | 230.547 ns | 204.374 ns |  1.20 |    0.01 | 27.7710 |     - |     - |   58672 B |
|                 Linq |          4 |  1000 | 67,601.84 ns | 458.995 ns | 383.281 ns |  2.17 |    0.02 | 15.7471 |     - |     - |   33112 B |
|           LinqFaster |          4 |  1000 |  8,497.13 ns |  21.708 ns |  19.244 ns |  0.27 |    0.00 |       - |     - |     - |         - |
|               LinqAF |          4 |  1000 | 89,521.80 ns | 214.944 ns | 190.543 ns |  2.88 |    0.02 | 53.9551 |     - |     - |  113184 B |
|           StructLinq |          4 |  1000 | 31,414.52 ns |  82.408 ns |  68.814 ns |  1.01 |    0.01 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 | 31,801.84 ns | 133.284 ns | 124.674 ns |  1.02 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 | 33,254.05 ns | 105.552 ns |  93.570 ns |  1.07 |    0.01 |       - |     - |     - |         - |
