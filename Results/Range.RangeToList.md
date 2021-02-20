## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|                    Method | Start | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |    **10** |    **73.05 ns** |  **0.264 ns** |  **0.234 ns** |  **1.17** |    **0.01** | **0.0459** |     **-** |     **-** |      **96 B** |
|           ValueLinq_Stack |     0 |    10 |    68.57 ns |  0.168 ns |  0.140 ns |  1.10 |    0.00 | 0.0459 |     - |     - |      96 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   181.29 ns |  0.513 ns |  0.454 ns |  2.91 |    0.02 | 0.0458 |     - |     - |      96 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   183.04 ns |  0.503 ns |  0.446 ns |  2.94 |    0.02 | 0.0458 |     - |     - |      96 B |
|                   ForLoop |     0 |    10 |    62.27 ns |  0.309 ns |  0.258 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|               ForeachLoop |     0 |    10 |   127.78 ns |  0.437 ns |  0.387 ns |  2.05 |    0.01 | 0.1299 |     - |     - |     272 B |
|                      Linq |     0 |    10 |    42.36 ns |  0.124 ns |  0.116 ns |  0.68 |    0.00 | 0.0650 |     - |     - |     136 B |
|                LinqFaster |     0 |    10 |    38.57 ns |  0.271 ns |  0.226 ns |  0.62 |    0.01 | 0.0764 |     - |     - |     160 B |
|                    LinqAF |     0 |    10 |    60.04 ns |  0.254 ns |  0.225 ns |  0.96 |    0.00 | 0.0458 |     - |     - |      96 B |
|                StructLinq |     0 |    10 |    19.80 ns |  0.107 ns |  0.095 ns |  0.32 |    0.00 | 0.0459 |     - |     - |      96 B |
|                 Hyperlinq |     0 |    10 |    24.83 ns |  0.105 ns |  0.088 ns |  0.40 |    0.00 | 0.0459 |     - |     - |      96 B |
|                           |       |       |             |           |           |       |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **2,013.82 ns** |  **7.733 ns** |  **7.234 ns** |  **0.98** |    **0.01** | **1.9379** |     **-** |     **-** |    **4056 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,430.84 ns |  6.664 ns |  5.908 ns |  1.18 |    0.01 | 3.9330 |     - |     - |    8232 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,379.42 ns | 17.289 ns | 15.326 ns |  1.16 |    0.01 | 1.9379 |     - |     - |    4056 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,296.39 ns |  6.992 ns |  6.199 ns |  1.12 |    0.00 | 1.9379 |     - |     - |    4056 B |
|                   ForLoop |     0 |  1000 | 2,053.89 ns |  7.033 ns |  6.235 ns |  1.00 |    0.00 | 4.0207 |     - |     - |    8424 B |
|               ForeachLoop |     0 |  1000 | 6,170.71 ns | 20.736 ns | 18.382 ns |  3.00 |    0.01 | 4.0436 |     - |     - |    8480 B |
|                      Linq |     0 |  1000 | 1,770.21 ns |  7.183 ns |  6.368 ns |  0.86 |    0.00 | 1.9569 |     - |     - |    4096 B |
|                LinqFaster |     0 |  1000 |   946.49 ns |  5.516 ns |  4.890 ns |  0.46 |    0.00 | 3.8605 |     - |     - |    8080 B |
|                    LinqAF |     0 |  1000 | 2,387.36 ns | 19.143 ns | 16.970 ns |  1.16 |    0.01 | 1.9379 |     - |     - |    4056 B |
|                StructLinq |     0 |  1000 |   705.72 ns |  3.731 ns |  2.913 ns |  0.34 |    0.00 | 1.9379 |     - |     - |    4056 B |
|                 Hyperlinq |     0 |  1000 |   292.70 ns |  4.148 ns |  3.880 ns |  0.14 |    0.00 | 1.9379 |     - |     - |    4056 B |
