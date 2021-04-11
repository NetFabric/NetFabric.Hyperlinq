## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                      Method |      Job |  Runtime | Skip | Count |          Mean |       Error |      StdDev |        Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |--------- |--------- |----- |------ |--------------:|------------:|------------:|--------------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |    **10** |      **8.871 ns** |   **0.5289 ns** |   **1.5593 ns** |      **7.725 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |    10 |  3,519.100 ns |  21.6084 ns |  19.1553 ns |  3,511.255 ns | 345.47 |   28.64 | 0.0191 |     - |     - |      40 B |
|                        Linq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    176.198 ns |   1.1366 ns |   1.0075 ns |    176.209 ns |  17.30 |    1.45 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |    10 |    120.779 ns |   2.4390 ns |   5.3022 ns |    118.103 ns |  12.59 |    1.89 | 0.1377 |     - |     - |     288 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 | 1000 |    10 |  4,604.690 ns |  25.4916 ns |  22.5977 ns |  4,610.699 ns | 452.11 |   38.47 |      - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |     82.830 ns |   1.5917 ns |   1.9548 ns |     83.258 ns |   8.07 |    0.63 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |     39.765 ns |   0.2005 ns |   0.1777 ns |     39.731 ns |   3.90 |    0.32 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 | 1000 |    10 |     59.703 ns |   0.2291 ns |   0.2031 ns |     59.711 ns |   5.86 |    0.50 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |     60.948 ns |   0.1681 ns |   0.1490 ns |     60.993 ns |   5.98 |    0.50 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 | 1000 |    10 |     48.550 ns |   0.1450 ns |   0.1211 ns |     48.583 ns |   4.76 |    0.41 |      - |     - |     - |         - |
|                             |          |          |      |       |               |             |             |               |        |         |        |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |      7.895 ns |   0.0410 ns |   0.0364 ns |      7.888 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |  3,488.572 ns |  15.5023 ns |  13.7424 ns |  3,487.493 ns | 441.88 |    2.86 | 0.0191 |     - |     - |      40 B |
|                        Linq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    164.312 ns |   1.1851 ns |   1.0506 ns |    164.297 ns |  20.81 |    0.19 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |    10 |    115.919 ns |   2.3471 ns |   5.7131 ns |    112.502 ns |  15.37 |    0.51 | 0.1377 |     - |     - |     288 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 | 1000 |    10 |  4,958.181 ns |  27.3003 ns |  22.7970 ns |  4,963.936 ns | 627.69 |    4.02 |      - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |     75.330 ns |   0.6239 ns |   0.5531 ns |     75.158 ns |   9.54 |    0.08 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |     38.515 ns |   0.0847 ns |   0.0708 ns |     38.535 ns |   4.88 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 | 1000 |    10 |     58.328 ns |   0.1931 ns |   0.1806 ns |     58.303 ns |   7.39 |    0.05 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |     59.531 ns |   0.1270 ns |   0.1188 ns |     59.491 ns |   7.54 |    0.04 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 | 1000 |    10 |     48.939 ns |   0.1026 ns |   0.0910 ns |     48.943 ns |   6.20 |    0.03 |      - |     - |     - |         - |
|                             |          |          |      |       |               |             |             |               |        |         |        |       |       |           |
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |  **1000** |    **674.223 ns** |   **3.7719 ns** |   **2.9449 ns** |    **674.531 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  6,327.709 ns |  31.6221 ns |  26.4059 ns |  6,320.230 ns |   9.39 |    0.06 | 0.0153 |     - |     - |      40 B |
|                        Linq | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  8,338.915 ns |  40.8316 ns |  36.1961 ns |  8,333.870 ns |  12.37 |    0.09 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  8,389.069 ns | 162.6819 ns | 222.6809 ns |  8,476.755 ns |  12.31 |    0.45 | 5.8136 |     - |     - |  12,168 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 15,449.153 ns |  51.1546 ns |  45.3472 ns | 15,463.251 ns |  22.91 |    0.14 |      - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  1,949.175 ns |   5.6478 ns |   4.4094 ns |  1,950.266 ns |   2.89 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  1,484.930 ns |   6.9358 ns |   6.1484 ns |  1,483.218 ns |   2.20 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  1,870.628 ns |   7.0253 ns |   6.5714 ns |  1,869.518 ns |   2.78 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  1,658.576 ns |   3.7328 ns |   3.3090 ns |  1,658.051 ns |   2.46 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  2,146.455 ns |  17.7950 ns |  15.7748 ns |  2,142.108 ns |   3.19 |    0.02 |      - |     - |     - |         - |
|                             |          |          |      |       |               |             |             |               |        |         |        |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |    656.880 ns |   1.2120 ns |   1.0744 ns |    657.266 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  6,546.506 ns |  17.8719 ns |  13.9532 ns |  6,546.827 ns |   9.96 |    0.03 | 0.0153 |     - |     - |      40 B |
|                        Linq | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  8,622.123 ns | 156.6121 ns | 316.3642 ns |  8,544.927 ns |  13.44 |    0.82 | 0.0610 |     - |     - |     152 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  7,406.410 ns |  39.3220 ns |  34.8579 ns |  7,402.859 ns |  11.28 |    0.05 | 5.8136 |     - |     - |  12,168 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 16,935.936 ns |  71.4890 ns |  55.8139 ns | 16,919.054 ns |  25.78 |    0.08 |      - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  2,182.665 ns |  15.8600 ns |  14.0595 ns |  2,181.716 ns |   3.32 |    0.02 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  1,472.161 ns |   5.2877 ns |   4.9461 ns |  1,471.336 ns |   2.24 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  2,401.204 ns |   7.8620 ns |   7.3541 ns |  2,399.830 ns |   3.65 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  1,660.187 ns |  10.2007 ns |   9.0427 ns |  1,655.515 ns |   2.53 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  2,386.207 ns |  11.6147 ns |  10.8644 ns |  2,384.216 ns |   3.63 |    0.02 |      - |     - |     - |         - |
