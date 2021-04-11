## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                      Method |      Job |  Runtime | Skip | Count |        Mean |     Error |      StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |--------- |--------- |----- |------ |------------:|----------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |    **10** |    **165.9 ns** |   **0.37 ns** |     **0.31 ns** |    **165.8 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2,552.0 ns |  11.84 ns |     9.89 ns |  2,549.9 ns | 15.38 |    0.07 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    365.2 ns |   6.91 ns |    11.16 ns |    359.1 ns |  2.26 |    0.07 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |    10 |    355.1 ns |   7.13 ns |    19.39 ns |    345.7 ns |  2.17 |    0.11 |  0.9522 |     - |     - |   1,992 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 | 1000 |    10 |  5,043.2 ns |  98.80 ns |   147.89 ns |  5,036.9 ns | 29.91 |    0.69 |       - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    246.2 ns |   0.80 ns |     0.71 ns |    246.0 ns |  1.48 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |    207.0 ns |   0.37 ns |     0.31 ns |    207.1 ns |  1.25 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 | 1000 |    10 |    244.7 ns |   0.57 ns |     0.53 ns |    244.8 ns |  1.47 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |    216.7 ns |   0.62 ns |     0.55 ns |    216.6 ns |  1.31 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 | 1000 |    10 |    232.2 ns |   0.48 ns |     0.43 ns |    232.2 ns |  1.40 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |    208.6 ns |   0.43 ns |     0.38 ns |    208.5 ns |  1.26 |    0.00 |       - |     - |     - |         - |
|                             |          |          |      |       |             |           |             |             |       |         |         |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |    168.5 ns |   0.34 ns |     0.32 ns |    168.6 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2,313.1 ns |  21.20 ns |    18.80 ns |  2,308.1 ns | 13.72 |    0.12 |  0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    348.9 ns |   6.98 ns |    12.76 ns |    340.9 ns |  2.16 |    0.06 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |    10 |    343.0 ns |   3.11 ns |     2.76 ns |    343.2 ns |  2.03 |    0.02 |  0.9522 |     - |     - |   1,992 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 | 1000 |    10 |  5,149.4 ns |  98.97 ns |   121.54 ns |  5,166.1 ns | 30.45 |    0.76 |       - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    262.0 ns |   1.30 ns |     1.22 ns |    261.8 ns |  1.55 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |    208.4 ns |   0.56 ns |     0.50 ns |    208.3 ns |  1.24 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 | 1000 |    10 |    243.4 ns |   0.62 ns |     0.58 ns |    243.4 ns |  1.44 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |    216.9 ns |   0.52 ns |     0.44 ns |    216.9 ns |  1.29 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 | 1000 |    10 |    233.7 ns |   1.18 ns |     1.10 ns |    233.1 ns |  1.39 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |    208.7 ns |   0.38 ns |     0.32 ns |    208.7 ns |  1.24 |    0.00 |       - |     - |     - |         - |
|                             |          |          |      |       |             |           |             |             |       |         |         |       |       |           |
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |  **1000** | **16,801.0 ns** |  **48.14 ns** |    **37.58 ns** | **16,797.1 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 21,144.9 ns |  49.13 ns |    43.55 ns | 21,160.6 ns |  1.26 |    0.00 |       - |     - |     - |      32 B |
|                        Linq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 26,411.5 ns |  76.65 ns |    71.70 ns | 26,427.6 ns |  1.57 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 34,965.3 ns | 695.79 ns | 1,962.48 ns | 33,930.9 ns |  2.02 |    0.09 | 90.8813 |     - |     - | 192,072 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 41,058.9 ns | 483.17 ns |   451.96 ns | 41,098.1 ns |  2.44 |    0.02 |       - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 18,735.9 ns |  71.11 ns |    66.52 ns | 18,706.4 ns |  1.11 |    0.00 |  0.0305 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 18,000.3 ns |  53.84 ns |    50.36 ns | 18,010.1 ns |  1.07 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 19,676.6 ns |  73.33 ns |    61.23 ns | 19,654.8 ns |  1.17 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 17,466.5 ns |  60.46 ns |    53.59 ns | 17,461.9 ns |  1.04 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 19,941.9 ns |  66.89 ns |    59.29 ns | 19,935.6 ns |  1.19 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 17,298.6 ns |  55.16 ns |    51.60 ns | 17,284.3 ns |  1.03 |    0.00 |       - |     - |     - |         - |
|                             |          |          |      |       |             |           |             |             |       |         |         |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 16,625.7 ns |  61.60 ns |    54.61 ns | 16,609.0 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 21,065.8 ns |  46.66 ns |    41.36 ns | 21,064.0 ns |  1.27 |    0.01 |       - |     - |     - |      32 B |
|                        Linq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 26,406.3 ns | 144.21 ns |   127.84 ns | 26,412.2 ns |  1.59 |    0.01 |  0.1526 |     - |     - |     320 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 33,155.0 ns | 304.64 ns |   579.60 ns | 33,176.1 ns |  2.01 |    0.03 | 90.8813 |     - |     - | 192,072 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 40,848.3 ns | 277.55 ns |   259.62 ns | 40,870.0 ns |  2.46 |    0.02 |       - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 18,556.1 ns |  64.72 ns |    54.05 ns | 18,580.7 ns |  1.12 |    0.00 |  0.0305 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 19,370.7 ns | 315.61 ns |   387.59 ns | 19,487.3 ns |  1.16 |    0.03 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 21,367.0 ns | 418.96 ns |   529.85 ns | 21,247.1 ns |  1.29 |    0.03 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 19,156.2 ns | 360.89 ns |   337.58 ns | 19,256.7 ns |  1.15 |    0.02 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 22,374.1 ns | 443.10 ns |   905.13 ns | 22,728.7 ns |  1.28 |    0.05 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 20,016.9 ns | 296.48 ns |   277.33 ns | 20,000.7 ns |  1.20 |    0.02 |       - |     - |     - |         - |
