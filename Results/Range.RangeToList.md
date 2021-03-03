## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|                    Method | Start | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |    **10** |    **75.58 ns** |  **1.264 ns** |  **0.987 ns** |  **1.11** |    **0.02** | **0.0459** |     **-** |     **-** |      **96 B** |
|           ValueLinq_Stack |     0 |    10 |    68.98 ns |  0.385 ns |  0.341 ns |  1.02 |    0.01 | 0.0459 |     - |     - |      96 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   181.21 ns |  0.371 ns |  0.347 ns |  2.67 |    0.01 | 0.0458 |     - |     - |      96 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   184.08 ns |  0.552 ns |  0.489 ns |  2.71 |    0.01 | 0.0458 |     - |     - |      96 B |
|                   ForLoop |     0 |    10 |    67.81 ns |  0.325 ns |  0.288 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|               ForeachLoop |     0 |    10 |   126.76 ns |  0.324 ns |  0.271 ns |  1.87 |    0.01 | 0.1297 |     - |     - |     272 B |
|                      Linq |     0 |    10 |    42.33 ns |  0.218 ns |  0.193 ns |  0.62 |    0.00 | 0.0650 |     - |     - |     136 B |
|                LinqFaster |     0 |    10 |    38.13 ns |  0.216 ns |  0.202 ns |  0.56 |    0.00 | 0.0764 |     - |     - |     160 B |
|                    LinqAF |     0 |    10 |    61.40 ns |  0.282 ns |  0.235 ns |  0.91 |    0.00 | 0.0458 |     - |     - |      96 B |
|                StructLinq |     0 |    10 |    18.94 ns |  0.106 ns |  0.094 ns |  0.28 |    0.00 | 0.0459 |     - |     - |      96 B |
|                 Hyperlinq |     0 |    10 |    24.03 ns |  0.113 ns |  0.095 ns |  0.35 |    0.00 | 0.0459 |     - |     - |      96 B |
|                           |       |       |             |           |           |       |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **2,032.41 ns** |  **6.206 ns** |  **5.182 ns** |  **0.95** |    **0.01** | **1.9379** |     **-** |     **-** |   **4,056 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,447.58 ns | 10.608 ns |  9.404 ns |  1.14 |    0.00 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,344.36 ns | 12.176 ns | 11.389 ns |  1.10 |    0.01 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,283.78 ns |  8.702 ns |  7.714 ns |  1.07 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                   ForLoop |     0 |  1000 | 2,139.27 ns | 11.349 ns | 10.616 ns |  1.00 |    0.00 | 4.0207 |     - |     - |   8,424 B |
|               ForeachLoop |     0 |  1000 | 5,980.46 ns | 20.638 ns | 18.295 ns |  2.79 |    0.01 | 4.0436 |     - |     - |   8,480 B |
|                      Linq |     0 |  1000 | 1,770.81 ns |  5.592 ns |  4.669 ns |  0.83 |    0.00 | 1.9569 |     - |     - |   4,096 B |
|                LinqFaster |     0 |  1000 |   838.08 ns |  4.272 ns |  3.567 ns |  0.39 |    0.00 | 3.8605 |     - |     - |   8,080 B |
|                    LinqAF |     0 |  1000 | 3,094.32 ns |  7.841 ns |  6.951 ns |  1.45 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                StructLinq |     0 |  1000 |   709.28 ns |  3.708 ns |  3.287 ns |  0.33 |    0.00 | 1.9379 |     - |     - |   4,056 B |
|                 Hyperlinq |     0 |  1000 |   275.51 ns |  0.982 ns |  0.820 ns |  0.13 |    0.00 | 1.9379 |     - |     - |   4,056 B |
