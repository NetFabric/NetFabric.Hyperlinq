## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                   Method | Count |        Mean |     Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** |    **10** |    **64.98 ns** |  **0.227 ns** |   **0.212 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    64.62 ns |  0.268 ns |   0.238 ns |  0.99 |    0.00 | 0.1032 |     - |     - |     216 B |
|                     Linq |    10 |    67.57 ns |  0.254 ns |   0.238 ns |  1.04 |    0.00 | 0.0688 |     - |     - |     144 B |
|               LinqFaster |    10 |    53.46 ns |  0.174 ns |   0.154 ns |  0.82 |    0.00 | 0.0765 |     - |     - |     160 B |
|          LinqFaster_SIMD |    10 |    43.45 ns |  0.170 ns |   0.159 ns |  0.67 |    0.00 | 0.0764 |     - |     - |     160 B |
|                   LinqAF |    10 |   163.22 ns |  1.418 ns |   1.741 ns |  2.52 |    0.03 | 0.1032 |     - |     - |     216 B |
|               StructLinq |    10 |    56.63 ns |  0.211 ns |   0.197 ns |  0.87 |    0.00 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    41.44 ns |  0.137 ns |   0.121 ns |  0.64 |    0.00 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    46.41 ns |  0.092 ns |   0.077 ns |  0.71 |    0.00 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    34.45 ns |  0.099 ns |   0.088 ns |  0.53 |    0.00 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    57.08 ns |  0.284 ns |   0.252 ns |  0.88 |    0.00 | 0.0459 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    40.05 ns |  0.176 ns |   0.156 ns |  0.62 |    0.00 | 0.0459 |     - |     - |      96 B |
|                          |       |             |           |            |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,206.23 ns** | **25.669 ns** |  **22.755 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop |  1000 | 2,448.93 ns | 15.061 ns |  12.577 ns |  1.11 |    0.02 | 4.0207 |     - |     - |   8,424 B |
|                     Linq |  1000 | 2,603.00 ns |  7.201 ns |   6.383 ns |  1.18 |    0.01 | 1.9608 |     - |     - |   4,104 B |
|               LinqFaster |  1000 | 2,298.51 ns | 15.047 ns |  14.075 ns |  1.04 |    0.01 | 3.8605 |     - |     - |   8,080 B |
|          LinqFaster_SIMD |  1000 |   742.01 ns |  2.995 ns |   2.655 ns |  0.34 |    0.00 | 3.8605 |     - |     - |   8,080 B |
|                   LinqAF |  1000 | 7,166.01 ns | 99.576 ns | 106.546 ns |  3.25 |    0.07 | 4.0207 |     - |     - |   8,424 B |
|               StructLinq |  1000 | 2,063.52 ns | 12.870 ns |  11.409 ns |  0.94 |    0.01 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction |  1000 |   939.12 ns |  6.940 ns |   6.491 ns |  0.43 |    0.01 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq |  1000 | 1,783.60 ns |  5.120 ns |   4.275 ns |  0.81 |    0.01 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction |  1000 |   771.84 ns |  2.621 ns |   2.323 ns |  0.35 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD |  1000 |   557.70 ns |  2.863 ns |   2.538 ns |  0.25 |    0.00 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   323.75 ns |  2.064 ns |   1.830 ns |  0.15 |    0.00 | 1.9341 |     - |     - |   4,056 B |
