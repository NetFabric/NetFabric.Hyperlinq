## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** |    **10** |    **64.96 ns** |  **0.480 ns** |  **0.375 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    70.06 ns |  1.060 ns |  0.828 ns |  1.08 |    0.01 | 0.1032 |     - |     - |     216 B |
|                     Linq |    10 |    66.95 ns |  0.381 ns |  0.338 ns |  1.03 |    0.01 | 0.0688 |     - |     - |     144 B |
|               LinqFaster |    10 |    57.60 ns |  0.281 ns |  0.234 ns |  0.89 |    0.01 | 0.0763 |     - |     - |     160 B |
|          LinqFaster_SIMD |    10 |    45.63 ns |  0.234 ns |  0.208 ns |  0.70 |    0.00 | 0.0764 |     - |     - |     160 B |
|                   LinqAF |    10 |   168.28 ns |  1.401 ns |  1.242 ns |  2.59 |    0.01 | 0.1032 |     - |     - |     216 B |
|               StructLinq |    10 |    59.51 ns |  0.254 ns |  0.212 ns |  0.92 |    0.01 | 0.0763 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    42.88 ns |  0.168 ns |  0.149 ns |  0.66 |    0.00 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    47.95 ns |  0.177 ns |  0.166 ns |  0.74 |    0.00 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    35.85 ns |  0.236 ns |  0.197 ns |  0.55 |    0.00 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    61.31 ns |  0.249 ns |  0.233 ns |  0.94 |    0.01 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    41.17 ns |  0.165 ns |  0.138 ns |  0.63 |    0.00 | 0.0458 |     - |     - |      96 B |
|                          |       |             |           |           |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,541.03 ns** | **11.976 ns** | **10.617 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop |  1000 | 2,318.49 ns | 10.039 ns |  9.391 ns |  0.91 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|                     Linq |  1000 | 2,423.84 ns | 17.486 ns | 16.357 ns |  0.95 |    0.01 | 1.9608 |     - |     - |   4,104 B |
|               LinqFaster |  1000 | 2,384.30 ns | 19.381 ns | 18.129 ns |  0.94 |    0.01 | 3.8605 |     - |     - |   8,080 B |
|          LinqFaster_SIMD |  1000 |   787.52 ns |  3.775 ns |  3.152 ns |  0.31 |    0.00 | 3.8605 |     - |     - |   8,080 B |
|                   LinqAF |  1000 | 7,362.70 ns | 52.038 ns | 48.677 ns |  2.90 |    0.02 | 4.0207 |     - |     - |   8,424 B |
|               StructLinq |  1000 | 2,123.13 ns |  8.082 ns |  7.165 ns |  0.84 |    0.01 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction |  1000 |   979.39 ns |  6.857 ns |  5.726 ns |  0.39 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq |  1000 | 2,128.98 ns |  9.376 ns |  7.829 ns |  0.84 |    0.01 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction |  1000 |   786.41 ns |  3.373 ns |  3.155 ns |  0.31 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD |  1000 |   578.62 ns |  4.439 ns |  3.935 ns |  0.23 |    0.00 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   340.08 ns |  1.821 ns |  1.614 ns |  0.13 |    0.00 | 1.9341 |     - |     - |   4,056 B |
