## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|                    Method | Start | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |    **10** |    **79.51 ns** |  **0.847 ns** |  **0.792 ns** |  **0.99** | **0.0459** |     **-** |     **-** |      **96 B** |
|           ValueLinq_Stack |     0 |    10 |    76.66 ns |  0.509 ns |  0.451 ns |  0.96 | 0.0459 |     - |     - |      96 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   197.34 ns |  0.755 ns |  0.669 ns |  2.46 | 0.0458 |     - |     - |      96 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   190.73 ns |  1.247 ns |  1.105 ns |  2.38 | 0.0458 |     - |     - |      96 B |
|                   ForLoop |     0 |    10 |    80.13 ns |  0.483 ns |  0.403 ns |  1.00 | 0.1032 |     - |     - |     216 B |
|               ForeachLoop |     0 |    10 |   138.40 ns |  0.938 ns |  0.832 ns |  1.73 | 0.1299 |     - |     - |     272 B |
|                      Linq |     0 |    10 |    48.40 ns |  0.305 ns |  0.271 ns |  0.60 | 0.0650 |     - |     - |     136 B |
|                LinqFaster |     0 |    10 |    44.10 ns |  0.386 ns |  0.342 ns |  0.55 | 0.0765 |     - |     - |     160 B |
|                    LinqAF |     0 |    10 |    65.03 ns |  0.288 ns |  0.270 ns |  0.81 | 0.0459 |     - |     - |      96 B |
|                StructLinq |     0 |    10 |    22.83 ns |  0.121 ns |  0.107 ns |  0.29 | 0.0459 |     - |     - |      96 B |
|                 Hyperlinq |     0 |    10 |    27.04 ns |  0.224 ns |  0.175 ns |  0.34 | 0.0458 |     - |     - |      96 B |
|                           |       |       |             |           |           |       |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **2,203.10 ns** | **18.537 ns** | **17.340 ns** |  **0.93** | **1.9379** |     **-** |     **-** |   **4,056 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,762.72 ns | 23.800 ns | 21.098 ns |  1.16 | 3.9330 |     - |     - |   8,232 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,758.75 ns | 18.299 ns | 15.281 ns |  1.16 | 1.9379 |     - |     - |   4,056 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,493.42 ns | 22.325 ns | 18.642 ns |  1.05 | 1.9379 |     - |     - |   4,056 B |
|                   ForLoop |     0 |  1000 | 2,374.45 ns | 10.145 ns |  9.489 ns |  1.00 | 4.0207 |     - |     - |   8,424 B |
|               ForeachLoop |     0 |  1000 | 6,897.90 ns | 31.987 ns | 28.356 ns |  2.91 | 4.0436 |     - |     - |   8,480 B |
|                      Linq |     0 |  1000 | 1,954.79 ns | 12.824 ns | 11.368 ns |  0.82 | 1.9569 |     - |     - |   4,096 B |
|                LinqFaster |     0 |  1000 | 1,070.39 ns | 11.988 ns | 10.010 ns |  0.45 | 3.8605 |     - |     - |   8,080 B |
|                    LinqAF |     0 |  1000 | 2,961.88 ns | 23.698 ns | 22.167 ns |  1.25 | 1.9379 |     - |     - |   4,056 B |
|                StructLinq |     0 |  1000 |   844.63 ns |  7.475 ns |  6.242 ns |  0.36 | 1.9379 |     - |     - |   4,056 B |
|                 Hyperlinq |     0 |  1000 |   387.89 ns |  2.161 ns |  1.805 ns |  0.16 | 1.9379 |     - |     - |   4,056 B |
