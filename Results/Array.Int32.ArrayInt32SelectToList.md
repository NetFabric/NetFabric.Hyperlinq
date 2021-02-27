## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
|                  **ForLoop** |    **10** |    **78.13 ns** |  **0.856 ns** |  **0.800 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    80.07 ns |  1.101 ns |  0.976 ns |  1.03 |    0.01 | 0.1032 |     - |     - |     216 B |
|                     Linq |    10 |    73.32 ns |  0.493 ns |  0.412 ns |  0.94 |    0.01 | 0.0688 |     - |     - |     144 B |
|               LinqFaster |    10 |    60.01 ns |  0.417 ns |  0.370 ns |  0.77 |    0.01 | 0.0763 |     - |     - |     160 B |
|          LinqFaster_SIMD |    10 |    50.05 ns |  0.531 ns |  0.470 ns |  0.64 |    0.01 | 0.0764 |     - |     - |     160 B |
|                   LinqAF |    10 |   176.76 ns |  1.937 ns |  4.127 ns |  2.25 |    0.05 | 0.1032 |     - |     - |     216 B |
|               StructLinq |    10 |    69.32 ns |  0.458 ns |  0.383 ns |  0.89 |    0.01 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    47.55 ns |  0.338 ns |  0.316 ns |  0.61 |    0.01 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    51.96 ns |  0.389 ns |  0.345 ns |  0.67 |    0.01 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    38.98 ns |  0.235 ns |  0.196 ns |  0.50 |    0.01 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    68.24 ns |  0.251 ns |  0.234 ns |  0.87 |    0.01 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    49.60 ns |  0.156 ns |  0.131 ns |  0.64 |    0.01 | 0.0459 |     - |     - |      96 B |
|                          |       |             |           |           |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,544.57 ns** | **28.420 ns** | **25.194 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop |  1000 | 2,511.98 ns | 12.540 ns | 11.116 ns |  0.99 |    0.01 | 4.0207 |     - |     - |   8,424 B |
|                     Linq |  1000 | 2,568.32 ns | 15.027 ns | 13.321 ns |  1.01 |    0.01 | 1.9608 |     - |     - |   4,104 B |
|               LinqFaster |  1000 | 2,596.11 ns | 15.590 ns | 13.820 ns |  1.02 |    0.01 | 3.8605 |     - |     - |   8,080 B |
|          LinqFaster_SIMD |  1000 |   979.27 ns |  7.528 ns |  6.287 ns |  0.38 |    0.00 | 3.8605 |     - |     - |   8,080 B |
|                   LinqAF |  1000 | 7,350.95 ns | 35.745 ns | 27.907 ns |  2.89 |    0.03 | 4.0207 |     - |     - |   8,424 B |
|               StructLinq |  1000 | 2,263.60 ns | 11.461 ns | 10.721 ns |  0.89 |    0.01 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction |  1000 | 1,087.18 ns | 15.923 ns | 14.894 ns |  0.43 |    0.01 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq |  1000 | 2,239.87 ns | 11.791 ns | 10.452 ns |  0.88 |    0.01 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction |  1000 |   914.64 ns |  8.434 ns |  7.043 ns |  0.36 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD |  1000 |   694.25 ns |  3.980 ns |  3.324 ns |  0.27 |    0.00 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   450.78 ns |  5.176 ns |  4.841 ns |  0.18 |    0.00 | 1.9341 |     - |     - |   4,056 B |
