## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|                    Method | Start | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |    **10** |    **84.39 ns** |  **0.584 ns** |  **0.517 ns** |  **1.12** |    **0.01** | **0.0459** |     **-** |     **-** |      **96 B** |
|           ValueLinq_Stack |     0 |    10 |    73.09 ns |  0.192 ns |  0.160 ns |  0.97 |    0.00 | 0.0459 |     - |     - |      96 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   186.40 ns |  0.391 ns |  0.326 ns |  2.48 |    0.01 | 0.0458 |     - |     - |      96 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   182.37 ns |  0.522 ns |  0.488 ns |  2.42 |    0.01 | 0.0458 |     - |     - |      96 B |
|                   ForLoop |     0 |    10 |    75.22 ns |  0.315 ns |  0.295 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|               ForeachLoop |     0 |    10 |   133.80 ns |  0.539 ns |  0.504 ns |  1.78 |    0.01 | 0.1299 |     - |     - |     272 B |
|                      Linq |     0 |    10 |    44.11 ns |  0.393 ns |  0.328 ns |  0.59 |    0.01 | 0.0650 |     - |     - |     136 B |
|                LinqFaster |     0 |    10 |    39.99 ns |  0.330 ns |  0.292 ns |  0.53 |    0.00 | 0.0764 |     - |     - |     160 B |
|                    LinqAF |     0 |    10 |    67.18 ns |  0.376 ns |  0.334 ns |  0.89 |    0.01 | 0.0458 |     - |     - |      96 B |
|                StructLinq |     0 |    10 |    20.44 ns |  0.114 ns |  0.107 ns |  0.27 |    0.00 | 0.0459 |     - |     - |      96 B |
|                 Hyperlinq |     0 |    10 |    24.37 ns |  0.044 ns |  0.037 ns |  0.32 |    0.00 | 0.0459 |     - |     - |      96 B |
|                           |       |       |             |           |           |       |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **2,089.67 ns** |  **8.833 ns** |  **7.376 ns** |  **0.98** |    **0.01** | **1.9379** |     **-** |     **-** |   **4,056 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,544.58 ns |  8.137 ns |  7.611 ns |  1.19 |    0.01 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,438.85 ns |  7.160 ns |  5.979 ns |  1.14 |    0.01 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,324.49 ns |  7.970 ns |  6.655 ns |  1.09 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                   ForLoop |     0 |  1000 | 2,132.41 ns | 12.988 ns | 11.514 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|               ForeachLoop |     0 |  1000 | 6,440.35 ns | 51.461 ns | 45.619 ns |  3.02 |    0.03 | 4.0436 |     - |     - |   8,480 B |
|                      Linq |     0 |  1000 | 1,836.25 ns |  8.515 ns |  7.548 ns |  0.86 |    0.01 | 1.9569 |     - |     - |   4,096 B |
|                LinqFaster |     0 |  1000 |   868.18 ns |  7.603 ns |  6.740 ns |  0.41 |    0.00 | 3.8605 |     - |     - |   8,080 B |
|                    LinqAF |     0 |  1000 | 3,236.69 ns | 16.494 ns | 15.428 ns |  1.52 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                StructLinq |     0 |  1000 |   736.68 ns |  2.992 ns |  2.499 ns |  0.35 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                 Hyperlinq |     0 |  1000 |   288.85 ns |  2.362 ns |  2.209 ns |  0.14 |    0.00 | 1.9379 |     - |     - |   4,056 B |
