## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|                    Method | Start | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |    **10** |    **79.38 ns** |  **0.213 ns** |  **0.189 ns** |  **1.09** |    **0.00** | **0.0459** |     **-** |     **-** |      **96 B** |
|           ValueLinq_Stack |     0 |    10 |    70.54 ns |  0.153 ns |  0.128 ns |  0.97 |    0.00 | 0.0459 |     - |     - |      96 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   182.03 ns |  0.525 ns |  0.410 ns |  2.51 |    0.01 | 0.0458 |     - |     - |      96 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   185.34 ns |  0.424 ns |  0.376 ns |  2.55 |    0.01 | 0.0458 |     - |     - |      96 B |
|                   ForLoop |     0 |    10 |    72.64 ns |  0.186 ns |  0.174 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|               ForeachLoop |     0 |    10 |   126.97 ns |  0.722 ns |  0.640 ns |  1.75 |    0.01 | 0.1299 |     - |     - |     272 B |
|                      Linq |     0 |    10 |    41.89 ns |  0.098 ns |  0.087 ns |  0.58 |    0.00 | 0.0650 |     - |     - |     136 B |
|                LinqFaster |     0 |    10 |    38.81 ns |  0.223 ns |  0.186 ns |  0.53 |    0.00 | 0.0764 |     - |     - |     160 B |
|                    LinqAF |     0 |    10 |    59.87 ns |  0.249 ns |  0.208 ns |  0.82 |    0.00 | 0.0458 |     - |     - |      96 B |
|                StructLinq |     0 |    10 |    18.99 ns |  0.100 ns |  0.088 ns |  0.26 |    0.00 | 0.0459 |     - |     - |      96 B |
|                 Hyperlinq |     0 |    10 |    23.37 ns |  0.098 ns |  0.081 ns |  0.32 |    0.00 | 0.0459 |     - |     - |      96 B |
|                           |       |       |             |           |           |       |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **2,039.55 ns** |  **6.214 ns** |  **5.813 ns** |  **0.99** |    **0.00** | **1.9379** |     **-** |     **-** |   **4,056 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,472.65 ns |  9.534 ns |  8.918 ns |  1.20 |    0.01 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,391.39 ns | 12.208 ns | 10.822 ns |  1.16 |    0.01 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,263.84 ns |  5.553 ns |  5.195 ns |  1.10 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                   ForLoop |     0 |  1000 | 2,066.51 ns |  9.565 ns |  7.987 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|               ForeachLoop |     0 |  1000 | 6,461.79 ns | 29.736 ns | 26.360 ns |  3.13 |    0.02 | 4.0436 |     - |     - |   8,480 B |
|                      Linq |     0 |  1000 | 1,776.73 ns |  7.221 ns |  6.401 ns |  0.86 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|                LinqFaster |     0 |  1000 |   841.49 ns |  2.975 ns |  2.637 ns |  0.41 |    0.00 | 3.8605 |     - |     - |   8,080 B |
|                    LinqAF |     0 |  1000 | 3,137.33 ns | 11.547 ns | 10.236 ns |  1.52 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                StructLinq |     0 |  1000 |   713.81 ns |  3.920 ns |  3.475 ns |  0.35 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                 Hyperlinq |     0 |  1000 |   275.08 ns |  0.746 ns |  0.661 ns |  0.13 |    0.00 | 1.9379 |     - |     - |   4,056 B |
