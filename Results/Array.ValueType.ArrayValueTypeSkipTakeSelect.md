## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |    **10** |    **163.6 ns** |   **0.21 ns** |   **0.19 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,589.3 ns |  25.72 ns |  22.80 ns | 15.83 |    0.14 |  0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    354.6 ns |   1.14 ns |   1.01 ns |  2.17 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |    10 |    303.6 ns |   3.46 ns |   2.89 ns |  1.86 |    0.02 |  0.9522 |     - |     - |   1,992 B |
|                      LinqAF | 1000 |    10 |  4,930.9 ns |  97.88 ns | 166.20 ns | 30.16 |    0.85 |       - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |    236.2 ns |   0.82 ns |   0.72 ns |  1.44 |    0.00 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |    196.5 ns |   0.28 ns |   0.25 ns |  1.20 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |    229.1 ns |   0.39 ns |   0.33 ns |  1.40 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |    201.6 ns |   0.34 ns |   0.32 ns |  1.23 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |    218.2 ns |   0.39 ns |   0.36 ns |  1.33 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |    195.1 ns |   0.81 ns |   0.72 ns |  1.19 |    0.00 |       - |     - |     - |         - |
|                             |      |       |             |           |           |       |         |         |       |       |           |
|                     **ForLoop** | **1000** |  **1000** | **15,470.2 ns** |  **48.43 ns** |  **40.44 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 20,046.8 ns |  34.43 ns |  28.75 ns |  1.30 |    0.00 |       - |     - |     - |      32 B |
|                        Linq | 1000 |  1000 | 25,284.6 ns |  38.57 ns |  34.19 ns |  1.63 |    0.00 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | 1000 |  1000 | 30,051.4 ns | 127.42 ns | 112.95 ns |  1.94 |    0.01 | 90.8813 |     - |     - | 192,072 B |
|                      LinqAF | 1000 |  1000 | 39,542.0 ns | 551.26 ns | 515.65 ns |  2.56 |    0.04 |       - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 | 17,621.6 ns |  35.02 ns |  31.05 ns |  1.14 |    0.00 |  0.0305 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 | 17,059.5 ns |  34.24 ns |  30.35 ns |  1.10 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 | 25,279.6 ns |  49.23 ns |  46.05 ns |  1.63 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 | 16,406.6 ns |  79.06 ns |  61.73 ns |  1.06 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 | 18,892.4 ns |  64.36 ns |  53.74 ns |  1.22 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 | 16,371.5 ns |  50.12 ns |  41.86 ns |  1.06 |    0.00 |       - |     - |     - |         - |
