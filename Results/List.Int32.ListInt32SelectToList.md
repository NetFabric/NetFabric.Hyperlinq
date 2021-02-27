## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** |    **10** |    **75.41 ns** |  **0.470 ns** |  **0.416 ns** |  **1.00** |    **0.00** | **0.1031** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    90.69 ns |  0.359 ns |  0.300 ns |  1.20 |    0.01 | 0.1032 |     - |     - |     216 B |
|                     Linq |    10 |    71.44 ns |  0.612 ns |  0.542 ns |  0.95 |    0.01 | 0.0802 |     - |     - |     168 B |
|               LinqFaster |    10 |    71.06 ns |  0.739 ns |  0.692 ns |  0.94 |    0.01 | 0.0917 |     - |     - |     192 B |
|                   LinqAF |    10 |   213.29 ns |  1.662 ns |  1.473 ns |  2.83 |    0.02 | 0.1032 |     - |     - |     216 B |
|               StructLinq |    10 |    67.88 ns |  0.374 ns |  0.331 ns |  0.90 |    0.01 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    47.71 ns |  0.286 ns |  0.253 ns |  0.63 |    0.01 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    51.41 ns |  1.082 ns |  1.445 ns |  0.69 |    0.02 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    38.44 ns |  0.172 ns |  0.152 ns |  0.51 |    0.00 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    68.17 ns |  0.379 ns |  0.316 ns |  0.90 |    0.01 | 0.0459 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    49.03 ns |  0.452 ns |  0.400 ns |  0.65 |    0.01 | 0.0458 |     - |     - |      96 B |
|                          |       |             |           |           |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,796.93 ns** | **13.016 ns** | **11.538 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop |  1000 | 4,257.85 ns | 20.169 ns | 17.879 ns |  1.52 |    0.01 | 4.0207 |     - |     - |   8,424 B |
|                     Linq |  1000 | 2,752.55 ns | 10.816 ns |  9.032 ns |  0.98 |    0.01 | 1.9722 |     - |     - |   4,128 B |
|               LinqFaster |  1000 | 3,344.26 ns | 11.724 ns |  9.790 ns |  1.20 |    0.01 | 3.8757 |     - |     - |   8,112 B |
|                   LinqAF |  1000 | 9,270.18 ns | 88.258 ns | 73.700 ns |  3.32 |    0.03 | 4.0131 |     - |     - |   8,424 B |
|               StructLinq |  1000 | 2,561.68 ns | 12.066 ns | 10.075 ns |  0.92 |    0.01 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction |  1000 | 1,093.35 ns | 11.306 ns | 10.022 ns |  0.39 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq |  1000 | 2,247.08 ns | 18.430 ns | 16.338 ns |  0.80 |    0.01 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction |  1000 |   964.93 ns |  5.037 ns |  4.466 ns |  0.35 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD |  1000 |   693.35 ns |  3.769 ns |  3.147 ns |  0.25 |    0.00 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   447.98 ns |  5.241 ns |  4.902 ns |  0.16 |    0.00 | 1.9341 |     - |     - |   4,056 B |
