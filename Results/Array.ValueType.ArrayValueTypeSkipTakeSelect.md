## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |    **166.4 ns** |   **0.32 ns** |   **0.28 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,566.4 ns |  10.19 ns |   9.54 ns | 15.42 |    0.06 |  0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    407.8 ns |   1.81 ns |   1.51 ns |  2.45 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |    10 |    320.6 ns |   1.48 ns |   1.16 ns |  1.93 |    0.01 |  0.9522 |     - |     - |   1,992 B |
|                      LinqAF | 1000 |    10 |  5,133.7 ns | 101.18 ns | 120.45 ns | 30.96 |    0.80 |       - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |    299.6 ns |   0.62 ns |   0.55 ns |  1.80 |    0.00 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |    206.5 ns |   0.46 ns |   0.43 ns |  1.24 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |    231.8 ns |   0.48 ns |   0.43 ns |  1.39 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |    205.6 ns |   0.55 ns |   0.52 ns |  1.24 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |    222.0 ns |   0.36 ns |   0.32 ns |  1.33 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |    196.5 ns |   0.59 ns |   0.55 ns |  1.18 |    0.00 |       - |     - |     - |         - |
|                             |      |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** | **1000** |  **1000** | **15,770.0 ns** |  **43.17 ns** |  **40.38 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 20,983.8 ns |  73.66 ns |  65.30 ns |  1.33 |    0.00 |       - |     - |     - |      32 B |
|                        Linq | 1000 |  1000 | 25,953.0 ns |  64.14 ns |  56.86 ns |  1.65 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |  1000 | 30,907.5 ns | 151.47 ns | 134.27 ns |  1.96 |    0.01 | 90.8813 |     - |     - | 192,072 B |
|                      LinqAF | 1000 |  1000 | 40,841.1 ns | 374.30 ns | 331.80 ns |  2.59 |    0.02 |       - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 | 18,052.0 ns |  82.26 ns |  76.95 ns |  1.14 |    0.00 |  0.0305 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 | 17,450.6 ns |  57.52 ns |  50.99 ns |  1.11 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 | 18,963.3 ns |  78.88 ns |  69.93 ns |  1.20 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 | 16,543.0 ns |  55.04 ns |  48.79 ns |  1.05 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 | 19,031.3 ns |  65.87 ns |  58.39 ns |  1.21 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 | 16,603.3 ns |  47.36 ns |  41.98 ns |  1.05 |    0.00 |       - |     - |     - |         - |
