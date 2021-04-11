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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Skip | Count |          Mean |       Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |----- |------ |--------------:|------------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |    **10** |      **9.118 ns** |   **0.0368 ns** |  **0.0326 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2,409.450 ns |  12.8306 ns | 10.7141 ns | 264.28 |    1.54 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    214.994 ns |   1.2196 ns |  1.0184 ns |  23.58 |    0.15 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |    10 |     70.515 ns |   0.6843 ns |  0.5714 ns |   7.73 |    0.07 | 0.1147 |     - |     - |     240 B |
|               LinqAF | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2,020.995 ns |   6.4003 ns |  5.6737 ns | 221.66 |    0.97 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |     87.467 ns |   1.7673 ns |  2.5904 ns |   9.41 |    0.33 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |     39.082 ns |   0.0853 ns |  0.0756 ns |   4.29 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |     63.866 ns |   0.2640 ns |  0.2061 ns |   7.00 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |     58.081 ns |   0.1212 ns |  0.1134 ns |   6.37 |    0.02 |      - |     - |     - |         - |
|                      |          |          |      |       |               |             |            |        |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |      8.990 ns |   0.0430 ns |  0.0381 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2,396.241 ns |  12.3222 ns | 10.9233 ns | 266.55 |    1.80 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    204.628 ns |   4.0103 ns |  3.9387 ns |  22.71 |    0.43 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |    10 |     70.637 ns |   0.3768 ns |  0.3340 ns |   7.86 |    0.05 | 0.1147 |     - |     - |     240 B |
|               LinqAF | .NET 6.0 | .NET 6.0 | 1000 |    10 |  1,955.530 ns |   6.6439 ns |  6.2147 ns | 217.51 |    0.91 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |     77.361 ns |   0.2443 ns |  0.2166 ns |   8.61 |    0.04 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |     39.347 ns |   0.1347 ns |  0.1260 ns |   4.38 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |     61.512 ns |   0.1947 ns |  0.1821 ns |   6.84 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |     58.573 ns |   0.4216 ns |  0.3944 ns |   6.51 |    0.06 |      - |     - |     - |         - |
|                      |          |          |      |       |               |             |            |        |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |  **1000** |    **928.153 ns** |   **4.7268 ns** |  **4.1902 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  5,250.308 ns |  17.6641 ns | 15.6587 ns |   5.66 |    0.03 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 15,425.466 ns | 114.4518 ns | 95.5724 ns |  16.61 |    0.14 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  4,289.958 ns |  31.2246 ns | 26.0740 ns |   4.62 |    0.03 | 6.7215 |     - |     - |  14,064 B |
|               LinqAF | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 15,280.798 ns |  63.7634 ns | 59.6444 ns |  16.47 |    0.11 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  5,474.766 ns |  14.8002 ns | 13.8441 ns |   5.90 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  1,605.708 ns |  11.1339 ns | 10.4147 ns |   1.73 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  5,117.661 ns |  26.3207 ns | 21.9790 ns |   5.51 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  2,127.354 ns |   8.3094 ns |  7.7726 ns |   2.29 |    0.01 |      - |     - |     - |         - |
|                      |          |          |      |       |               |             |            |        |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |    927.810 ns |   5.8553 ns |  5.4770 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  4,862.593 ns |  19.0291 ns | 16.8688 ns |   5.24 |    0.04 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 15,425.789 ns | 105.8965 ns | 99.0556 ns |  16.63 |    0.13 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  4,391.396 ns |  18.2371 ns | 15.2288 ns |   4.74 |    0.04 | 6.7215 |     - |     - |  14,064 B |
|               LinqAF | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 15,402.394 ns |  55.2673 ns | 48.9931 ns |  16.61 |    0.13 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  6,754.578 ns |  15.6595 ns | 14.6479 ns |   7.28 |    0.05 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  1,574.516 ns |  11.7915 ns | 11.0298 ns |   1.70 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  6,668.201 ns |  27.6167 ns | 21.5613 ns |   7.20 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  2,099.298 ns |   5.7984 ns |  5.1401 ns |   2.26 |    0.01 |      - |     - |     - |         - |
