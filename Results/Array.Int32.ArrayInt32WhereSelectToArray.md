## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                                Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **167.39 ns** |  **1.852 ns** |  **1.446 ns** |  **4.15** |    **0.05** | **0.0150** |     **-** |     **-** |      **32 B** |
|                       ValueLinq_Stack |    10 |   136.50 ns |  1.357 ns |  1.203 ns |  3.38 |    0.04 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push |    10 |   380.24 ns |  2.554 ns |  2.389 ns |  9.43 |    0.11 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull |    10 |   267.75 ns |  1.882 ns |  1.571 ns |  6.63 |    0.06 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard |    10 |   149.78 ns |  0.986 ns |  0.823 ns |  3.71 |    0.03 | 0.0150 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack |    10 |   113.89 ns |  0.318 ns |  0.266 ns |  2.82 |    0.02 | 0.0151 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   295.73 ns |  2.879 ns |  2.552 ns |  7.33 |    0.10 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   259.67 ns |  0.908 ns |  0.805 ns |  6.44 |    0.05 | 0.0153 |     - |     - |      32 B |
|                               ForLoop |    10 |    40.35 ns |  0.396 ns |  0.351 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                           ForeachLoop |    10 |    40.40 ns |  0.248 ns |  0.220 ns |  1.00 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                  Linq |    10 |   123.56 ns |  0.655 ns |  0.581 ns |  3.06 |    0.02 | 0.0842 |     - |     - |     176 B |
|                            LinqFaster |    10 |    46.91 ns |  0.277 ns |  0.245 ns |  1.16 |    0.01 | 0.0458 |     - |     - |      96 B |
|                                LinqAF |    10 |   108.07 ns |  0.509 ns |  0.425 ns |  2.68 |    0.03 | 0.0342 |     - |     - |      72 B |
|                            StructLinq |    10 |   142.58 ns |  1.199 ns |  1.001 ns |  3.53 |    0.04 | 0.0610 |     - |     - |     128 B |
|                  StructLinq_IFunction |    10 |    97.09 ns |  0.359 ns |  0.318 ns |  2.41 |    0.02 | 0.0153 |     - |     - |      32 B |
|                             Hyperlinq |    10 |   107.73 ns |  0.525 ns |  0.439 ns |  2.67 |    0.03 | 0.0153 |     - |     - |      32 B |
|                   Hyperlinq_IFunction |    10 |    85.03 ns |  0.450 ns |  0.375 ns |  2.11 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **6,278.18 ns** | **26.677 ns** | **22.277 ns** |  **2.17** |    **0.02** | **1.9760** |     **-** |     **-** |   **4,144 B** |
|                       ValueLinq_Stack |  1000 | 7,281.57 ns | 36.709 ns | 32.542 ns |  2.52 |    0.02 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push |  1000 | 5,699.36 ns | 41.735 ns | 36.997 ns |  1.97 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull |  1000 | 7,374.38 ns | 56.688 ns | 50.253 ns |  2.55 |    0.03 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 2,759.16 ns | 33.957 ns | 30.102 ns |  0.96 |    0.01 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 2,686.43 ns | 17.917 ns | 14.961 ns |  0.93 |    0.01 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 4,256.41 ns | 30.737 ns | 23.997 ns |  1.47 |    0.02 | 0.9689 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 2,836.09 ns | 24.746 ns | 23.148 ns |  0.98 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                               ForLoop |  1000 | 2,884.88 ns | 24.458 ns | 22.878 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                           ForeachLoop |  1000 | 2,955.18 ns | 23.186 ns | 21.688 ns |  1.02 |    0.01 | 3.0289 |     - |     - |   6,344 B |
|                                  Linq |  1000 | 5,575.47 ns | 32.135 ns | 26.834 ns |  1.93 |    0.02 | 2.1667 |     - |     - |   4,544 B |
|                            LinqFaster |  1000 | 6,216.53 ns | 30.183 ns | 26.757 ns |  2.15 |    0.02 | 2.8915 |     - |     - |   6,064 B |
|                                LinqAF |  1000 | 8,633.94 ns | 37.660 ns | 33.385 ns |  2.99 |    0.03 | 3.0060 |     - |     - |   6,312 B |
|                            StructLinq |  1000 | 6,253.99 ns | 57.675 ns | 53.949 ns |  2.17 |    0.03 | 1.0147 |     - |     - |   2,136 B |
|                  StructLinq_IFunction |  1000 | 4,579.49 ns | 20.829 ns | 17.393 ns |  1.59 |    0.02 | 0.9689 |     - |     - |   2,040 B |
|                             Hyperlinq |  1000 | 5,211.68 ns | 35.105 ns | 31.120 ns |  1.81 |    0.02 | 0.9689 |     - |     - |   2,040 B |
|                   Hyperlinq_IFunction |  1000 | 3,721.56 ns |  7.978 ns |  6.229 ns |  1.29 |    0.01 | 0.9727 |     - |     - |   2,040 B |
