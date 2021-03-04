## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                     **ForLoop** | **1000** |    **10** |      **8.082 ns** |  **0.0725 ns** |  **0.0678 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  4,318.737 ns | 22.5608 ns | 21.1034 ns | 534.37 |    4.29 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |    10 |    182.677 ns |  0.7003 ns |  0.6550 ns |  22.60 |    0.18 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |    10 |    109.752 ns |  0.5894 ns |  0.5224 ns |  13.57 |    0.13 | 0.1377 |     - |     - |     288 B |
|                      LinqAF | 1000 |    10 |  4,233.869 ns | 17.0658 ns | 14.2507 ns | 523.18 |    4.11 |      - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |     76.209 ns |  0.4538 ns |  0.4023 ns |   9.43 |    0.10 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |     38.733 ns |  0.1320 ns |  0.1170 ns |   4.79 |    0.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |     60.497 ns |  0.1373 ns |  0.1146 ns |   7.48 |    0.06 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |     58.349 ns |  0.1567 ns |  0.1466 ns |   7.22 |    0.07 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |     48.998 ns |  0.1284 ns |  0.1138 ns |   6.06 |    0.05 |      - |     - |     - |         - |
|                             |      |       |               |            |            |        |         |        |       |       |           |
|                     **ForLoop** | **1000** |  **1000** |    **803.295 ns** |  **2.4607 ns** |  **2.3017 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 |  7,187.363 ns | 32.7216 ns | 27.3240 ns |   8.95 |    0.04 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |  1000 |  9,360.583 ns | 30.7390 ns | 27.2493 ns |  11.65 |    0.05 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | 1000 |  1000 |  7,569.091 ns | 38.5932 ns | 32.2271 ns |   9.42 |    0.05 | 5.8136 |     - |     - |  12,168 B |
|                      LinqAF | 1000 |  1000 | 15,963.737 ns | 51.2620 ns | 45.4424 ns |  19.87 |    0.10 |      - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 |  1,957.963 ns |  8.8579 ns |  8.2857 ns |   2.44 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 |  1,434.888 ns |  3.6618 ns |  3.4253 ns |   1.79 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 |  2,182.615 ns |  8.0632 ns |  7.5423 ns |   2.72 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  1,510.193 ns |  3.2193 ns |  2.8539 ns |   1.88 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 |  2,165.406 ns |  7.4505 ns |  6.2215 ns |   2.69 |    0.01 |      - |     - |     - |         - |
