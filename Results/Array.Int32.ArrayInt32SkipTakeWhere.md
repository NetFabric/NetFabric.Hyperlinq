## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |      **9.251 ns** |  **0.0288 ns** |  **0.0255 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  2,181.122 ns |  8.0188 ns |  7.5008 ns | 235.71 |    0.78 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    220.709 ns |  0.7339 ns |  0.6864 ns |  23.86 |    0.10 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |     68.787 ns |  0.1860 ns |  0.1740 ns |   7.44 |    0.02 | 0.1147 |     - |     - |     240 B |
|               LinqAF | 1000 |    10 |  2,047.693 ns |  9.5607 ns |  7.9836 ns | 221.31 |    1.00 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     77.781 ns |  0.5365 ns |  0.4756 ns |   8.41 |    0.06 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     39.933 ns |  0.1425 ns |  0.1263 ns |   4.32 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     62.226 ns |  0.5672 ns |  0.5305 ns |   6.72 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     57.054 ns |  0.1403 ns |  0.1313 ns |   6.17 |    0.02 |      - |     - |     - |         - |
|                      |      |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |    **968.438 ns** | **10.8846 ns** | **10.1814 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  5,089.656 ns | 20.3535 ns | 18.0428 ns |   5.26 |    0.07 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 16,302.861 ns | 73.9839 ns | 61.7799 ns |  16.85 |    0.17 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 |  4,306.109 ns | 27.4992 ns | 24.3773 ns |   4.45 |    0.05 | 6.7215 |     - |     - |  14,064 B |
|               LinqAF | 1000 |  1000 | 15,459.861 ns | 38.1706 ns | 35.7048 ns |  15.97 |    0.18 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  5,513.011 ns | 24.8971 ns | 22.0706 ns |   5.70 |    0.07 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  1,619.448 ns | 21.4442 ns | 20.0589 ns |   1.67 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  5,047.870 ns | 22.2886 ns | 19.7583 ns |   5.22 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  2,046.722 ns | 38.6591 ns | 36.1618 ns |   2.11 |    0.05 |      - |     - |     - |         - |
