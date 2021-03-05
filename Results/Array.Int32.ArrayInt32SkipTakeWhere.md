## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |      **9.056 ns** |  **0.0123 ns** |  **0.0096 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  2,126.638 ns |  3.3601 ns |  3.1430 ns | 234.73 |    0.44 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    212.391 ns |  0.3751 ns |  0.2929 ns |  23.45 |    0.04 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |     69.334 ns |  0.2908 ns |  0.2578 ns |   7.66 |    0.03 | 0.1147 |     - |     - |     240 B |
|               LinqAF | 1000 |    10 |  2,012.597 ns |  3.6064 ns |  3.1970 ns | 222.29 |    0.40 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     80.168 ns |  0.2566 ns |  0.2143 ns |   8.85 |    0.02 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     39.344 ns |  0.0726 ns |  0.0644 ns |   4.35 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     60.559 ns |  0.1297 ns |  0.1083 ns |   6.69 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     55.708 ns |  0.1126 ns |  0.0998 ns |   6.15 |    0.01 |      - |     - |     - |         - |
|                      |      |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |    **925.727 ns** |  **2.9345 ns** |  **2.4504 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  4,552.812 ns | 19.1412 ns | 17.9047 ns |   4.92 |    0.02 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 15,730.883 ns | 42.7257 ns | 39.9657 ns |  16.99 |    0.07 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 |  4,469.097 ns | 18.7742 ns | 16.6429 ns |   4.83 |    0.02 | 6.7215 |     - |     - |  14,064 B |
|               LinqAF | 1000 |  1000 | 15,167.108 ns | 23.1686 ns | 21.6719 ns |  16.38 |    0.05 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  5,652.205 ns | 16.4620 ns | 15.3986 ns |   6.11 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  1,553.307 ns |  7.9185 ns |  7.0195 ns |   1.68 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  4,924.236 ns | 13.2404 ns | 12.3851 ns |   5.32 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  1,966.278 ns | 13.3699 ns | 12.5062 ns |   2.12 |    0.01 |      - |     - |     - |         - |
