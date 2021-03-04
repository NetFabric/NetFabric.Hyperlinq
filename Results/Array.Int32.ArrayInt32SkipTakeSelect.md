## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |      **6.424 ns** |  **0.0284 ns** |  **0.0221 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,190.103 ns | 10.8899 ns |  9.6536 ns | 341.26 |    1.57 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    202.563 ns |  0.7598 ns |  0.6735 ns |  31.53 |    0.15 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |     57.084 ns |  0.2872 ns |  0.2546 ns |   8.89 |    0.06 | 0.0918 |     - |     - |     192 B |
|                      LinqAF | 1000 |    10 |  2,061.329 ns |  6.0652 ns |  4.7353 ns | 320.91 |    1.32 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     82.016 ns |  0.4151 ns |  0.3680 ns |  12.77 |    0.08 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     38.112 ns |  0.1452 ns |  0.1358 ns |   5.94 |    0.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     59.515 ns |  0.2814 ns |  0.2494 ns |   9.26 |    0.05 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     58.691 ns |  0.2571 ns |  0.2405 ns |   9.14 |    0.05 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     50.249 ns |  0.1792 ns |  0.1497 ns |   7.82 |    0.04 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |     38.131 ns |  0.1119 ns |  0.1047 ns |   5.94 |    0.02 |      - |     - |     - |         - |
|                             |      |       |               |            |            |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **543.300 ns** |  **4.1196 ns** |  **3.6519 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  4,840.624 ns | 20.6889 ns | 16.1526 ns |   8.91 |    0.08 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |  1000 | 10,244.481 ns | 32.3995 ns | 28.7213 ns |  18.86 |    0.12 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  3,137.351 ns | 13.8915 ns | 12.3144 ns |   5.77 |    0.04 | 5.7678 |     - |     - |  12,072 B |
|                      LinqAF | 1000 |  1000 | 10,905.712 ns | 32.6266 ns | 27.2447 ns |  20.07 |    0.11 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  1,984.521 ns | 14.3138 ns | 13.3891 ns |   3.65 |    0.04 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,422.582 ns |  2.8331 ns |  2.3658 ns |   2.62 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  2,196.159 ns | 34.5602 ns | 69.8132 ns |   4.12 |    0.23 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,501.377 ns |  3.8977 ns |  3.6459 ns |   2.76 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  2,412.968 ns |  9.8116 ns |  9.1778 ns |   4.44 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 |  1,602.712 ns |  5.4101 ns |  5.0606 ns |   2.95 |    0.02 |      - |     - |     - |         - |
