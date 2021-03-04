## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                      Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |    **12.20 ns** |  **0.044 ns** |  **0.041 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    28.41 ns |  0.161 ns |  0.151 ns |  2.33 |    0.02 |      - |     - |     - |         - |
|                        Linq |    10 |   127.05 ns |  0.444 ns |  0.415 ns | 10.42 |    0.05 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |    10 |    51.07 ns |  0.314 ns |  0.278 ns |  4.19 |    0.03 | 0.0459 |     - |     - |      96 B |
|                      LinqAF |    10 |   117.30 ns |  0.663 ns |  0.587 ns |  9.62 |    0.05 |      - |     - |     - |         - |
|                  StructLinq |    10 |    40.90 ns |  0.188 ns |  0.157 ns |  3.35 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    38.32 ns |  0.147 ns |  0.138 ns |  3.14 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    43.05 ns |  0.103 ns |  0.086 ns |  3.53 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |    41.07 ns |  0.128 ns |  0.113 ns |  3.37 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |    33.14 ns |  0.092 ns |  0.082 ns |  2.72 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |    22.26 ns |  0.059 ns |  0.053 ns |  1.83 |    0.01 |      - |     - |     - |         - |
|                             |       |             |           |           |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** | **1,327.65 ns** |  **6.552 ns** |  **5.808 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 2,416.81 ns |  8.948 ns |  7.472 ns |  1.82 |    0.01 |      - |     - |     - |         - |
|                        Linq |  1000 | 7,036.34 ns | 37.455 ns | 33.202 ns |  5.30 |    0.03 | 0.0305 |     - |     - |      72 B |
|                  LinqFaster |  1000 | 3,864.13 ns | 12.013 ns | 10.650 ns |  2.91 |    0.01 | 1.9379 |     - |     - |   4,056 B |
|                      LinqAF |  1000 | 7,047.11 ns | 16.514 ns | 14.639 ns |  5.31 |    0.02 |      - |     - |     - |         - |
|                  StructLinq |  1000 | 2,186.88 ns | 13.031 ns | 10.882 ns |  1.65 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 1,422.06 ns |  5.821 ns |  5.445 ns |  1.07 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 2,244.71 ns |  8.527 ns |  7.120 ns |  1.69 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 | 1,483.70 ns |  4.966 ns |  4.645 ns |  1.12 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 2,218.49 ns |  8.543 ns |  7.573 ns |  1.67 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 | 1,326.30 ns |  2.533 ns |  2.246 ns |  1.00 |    0.00 |      - |     - |     - |         - |
