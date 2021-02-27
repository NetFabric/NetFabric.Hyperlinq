## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |      **5.181 ns** |  **0.0261 ns** |  **0.0218 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,478.178 ns | 15.8543 ns | 13.2391 ns | 478.35 |    2.44 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    207.261 ns |  1.0031 ns |  0.8892 ns |  40.02 |    0.25 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |     61.427 ns |  0.9338 ns |  0.8278 ns |  11.87 |    0.14 | 0.0918 |     - |     - |     192 B |
|                      LinqAF | 1000 |    10 |  2,079.255 ns | 11.3707 ns |  9.4950 ns | 401.35 |    2.52 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     80.090 ns |  0.4546 ns |  0.3796 ns |  15.46 |    0.08 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     38.056 ns |  0.1421 ns |  0.1187 ns |   7.35 |    0.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     59.546 ns |  0.2522 ns |  0.2106 ns |  11.49 |    0.08 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     59.209 ns |  0.1433 ns |  0.1196 ns |  11.43 |    0.06 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     50.313 ns |  0.2109 ns |  0.1761 ns |   9.71 |    0.05 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |     38.591 ns |  0.1385 ns |  0.1228 ns |   7.45 |    0.04 |      - |     - |     - |         - |
|                             |      |       |               |            |            |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **542.167 ns** |  **2.0461 ns** |  **1.8138 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  4,890.139 ns | 37.8059 ns | 33.5139 ns |   9.02 |    0.08 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |  1000 |  9,608.594 ns | 56.1094 ns | 46.8539 ns |  17.72 |    0.11 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  3,506.522 ns | 61.6700 ns | 57.6861 ns |   6.47 |    0.10 | 5.7678 |     - |     - |  12,072 B |
|                      LinqAF | 1000 |  1000 | 10,959.847 ns | 38.0028 ns | 31.7340 ns |  20.21 |    0.07 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  1,989.317 ns | 11.3529 ns |  9.4802 ns |   3.67 |    0.02 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,431.055 ns |  4.1983 ns |  3.7217 ns |   2.64 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  2,196.654 ns |  7.3963 ns |  6.1762 ns |   4.05 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,497.214 ns |  6.6123 ns |  5.8616 ns |   2.76 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  2,425.504 ns | 34.3760 ns | 28.7055 ns |   4.47 |    0.05 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 |  1,609.579 ns |  5.6626 ns |  5.0197 ns |   2.97 |    0.01 |      - |     - |     - |         - |
