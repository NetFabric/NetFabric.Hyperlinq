## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                  **ForLoop** |    **10** |    **68.92 ns** |  **0.396 ns** |  **0.351 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    88.57 ns |  0.813 ns |  0.721 ns |  1.29 |    0.01 | 0.1032 |     - |     - |     216 B |
|                     Linq |    10 |    70.17 ns |  0.328 ns |  0.291 ns |  1.02 |    0.01 | 0.0802 |     - |     - |     168 B |
|               LinqFaster |    10 |    63.78 ns |  0.548 ns |  0.457 ns |  0.93 |    0.01 | 0.0917 |     - |     - |     192 B |
|                   LinqAF |    10 |   211.05 ns |  1.606 ns |  1.502 ns |  3.06 |    0.02 | 0.1032 |     - |     - |     216 B |
|               StructLinq |    10 |    60.76 ns |  0.286 ns |  0.254 ns |  0.88 |    0.01 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    42.87 ns |  0.224 ns |  0.199 ns |  0.62 |    0.00 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    47.84 ns |  0.155 ns |  0.130 ns |  0.69 |    0.00 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    36.06 ns |  0.124 ns |  0.110 ns |  0.52 |    0.00 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    61.31 ns |  0.366 ns |  0.324 ns |  0.89 |    0.01 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    41.20 ns |  0.177 ns |  0.157 ns |  0.60 |    0.00 | 0.0459 |     - |     - |      96 B |
|                          |       |             |           |           |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,297.97 ns** | **11.210 ns** | **10.486 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |   **8,424 B** |
|              ForeachLoop |  1000 | 4,058.92 ns | 15.728 ns | 14.712 ns |  1.77 |    0.01 | 4.0207 |     - |     - |   8,424 B |
|                     Linq |  1000 | 2,859.55 ns | 16.536 ns | 15.468 ns |  1.24 |    0.01 | 1.9722 |     - |     - |   4,128 B |
|               LinqFaster |  1000 | 3,058.48 ns | 11.689 ns |  9.761 ns |  1.33 |    0.01 | 3.8757 |     - |     - |   8,112 B |
|                   LinqAF |  1000 | 8,981.71 ns | 50.252 ns | 44.547 ns |  3.91 |    0.02 | 4.0131 |     - |     - |   8,424 B |
|               StructLinq |  1000 | 2,689.67 ns | 51.229 ns | 42.778 ns |  1.17 |    0.02 | 1.9684 |     - |     - |   4,120 B |
|     StructLinq_IFunction |  1000 |   981.56 ns |  7.973 ns |  6.658 ns |  0.43 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|                Hyperlinq |  1000 | 1,850.26 ns |  8.323 ns |  7.378 ns |  0.80 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|      Hyperlinq_IFunction |  1000 |   803.73 ns |  1.701 ns |  1.421 ns |  0.35 |    0.00 | 1.9341 |     - |     - |   4,056 B |
|           Hyperlinq_SIMD |  1000 |   580.56 ns |  2.678 ns |  2.374 ns |  0.25 |    0.00 | 1.9341 |     - |     - |   4,056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   336.15 ns |  2.085 ns |  1.741 ns |  0.15 |    0.00 | 1.9341 |     - |     - |   4,056 B |
