## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |         Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **11.45 ns** |  **0.073 ns** |  **0.065 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  4,342.09 ns | 21.969 ns | 18.345 ns | 379.08 |    2.66 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |    10 |    211.58 ns |  1.073 ns |  0.896 ns |  18.47 |    0.14 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |    135.56 ns |  1.161 ns |  0.969 ns |  11.83 |    0.10 | 0.1528 |     - |     - |     320 B |
|               LinqAF | 1000 |    10 |  4,368.58 ns | 15.336 ns | 13.595 ns | 381.45 |    3.06 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     88.63 ns |  0.642 ns |  0.536 ns |   7.74 |    0.06 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     40.97 ns |  0.117 ns |  0.104 ns |   3.58 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     62.88 ns |  0.249 ns |  0.221 ns |   5.49 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     56.39 ns |  0.241 ns |  0.225 ns |   4.92 |    0.03 |      - |     - |     - |         - |
|                      |      |       |              |           |           |        |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **1,249.15 ns** |  **8.988 ns** |  **7.968 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  7,951.53 ns | 42.460 ns | 37.640 ns |   6.37 |    0.05 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |  1000 | 16,294.41 ns | 85.099 ns | 71.062 ns |  13.05 |    0.08 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 |  8,671.22 ns | 72.804 ns | 64.539 ns |   6.94 |    0.07 | 5.9204 |     - |     - |  12,416 B |
|               LinqAF | 1000 |  1000 | 20,517.45 ns | 89.992 ns | 79.775 ns |  16.43 |    0.13 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  6,328.80 ns | 22.670 ns | 17.699 ns |   5.07 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  1,889.23 ns | 30.699 ns | 27.214 ns |   1.51 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  5,397.34 ns | 34.962 ns | 29.195 ns |   4.32 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  2,005.03 ns | 16.702 ns | 14.806 ns |   1.61 |    0.02 |      - |     - |     - |         - |
