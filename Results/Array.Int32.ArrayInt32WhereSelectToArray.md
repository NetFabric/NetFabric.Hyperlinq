## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                                Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **165.11 ns** |  **0.477 ns** |  **0.423 ns** |  **4.69** |    **0.01** | **0.0153** |     **-** |     **-** |      **32 B** |
|                       ValueLinq_Stack |    10 |   130.68 ns |  0.508 ns |  0.475 ns |  3.71 |    0.01 | 0.0150 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Push |    10 |   348.07 ns |  0.802 ns |  0.751 ns |  9.88 |    0.04 | 0.0153 |     - |     - |      32 B |
|             ValueLinq_SharedPool_Pull |    10 |   257.25 ns |  0.719 ns |  0.601 ns |  7.30 |    0.02 | 0.0153 |     - |     - |      32 B |
|        ValueLinq_ValueLambda_Standard |    10 |   151.87 ns |  0.487 ns |  0.432 ns |  4.31 |    0.02 | 0.0153 |     - |     - |      32 B |
|           ValueLinq_ValueLambda_Stack |    10 |   109.27 ns |  0.276 ns |  0.215 ns |  3.10 |    0.01 | 0.0151 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   281.95 ns |  0.644 ns |  0.538 ns |  8.00 |    0.03 | 0.0153 |     - |     - |      32 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   254.09 ns |  0.813 ns |  0.721 ns |  7.21 |    0.03 | 0.0153 |     - |     - |      32 B |
|                               ForLoop |    10 |    35.24 ns |  0.124 ns |  0.110 ns |  1.00 |    0.00 | 0.0497 |     - |     - |     104 B |
|                           ForeachLoop |    10 |    35.34 ns |  0.185 ns |  0.173 ns |  1.00 |    0.01 | 0.0497 |     - |     - |     104 B |
|                                  Linq |    10 |   123.03 ns |  0.524 ns |  0.465 ns |  3.49 |    0.02 | 0.0842 |     - |     - |     176 B |
|                            LinqFaster |    10 |    42.81 ns |  0.161 ns |  0.134 ns |  1.22 |    0.00 | 0.0458 |     - |     - |      96 B |
|                                LinqAF |    10 |   102.27 ns |  0.379 ns |  0.336 ns |  2.90 |    0.01 | 0.0342 |     - |     - |      72 B |
|                            StructLinq |    10 |   130.14 ns |  0.508 ns |  0.424 ns |  3.69 |    0.01 | 0.0610 |     - |     - |     128 B |
|                  StructLinq_IFunction |    10 |    91.38 ns |  0.307 ns |  0.272 ns |  2.59 |    0.01 | 0.0153 |     - |     - |      32 B |
|                             Hyperlinq |    10 |   109.97 ns |  0.304 ns |  0.270 ns |  3.12 |    0.01 | 0.0153 |     - |     - |      32 B |
|                   Hyperlinq_IFunction |    10 |    81.69 ns |  0.193 ns |  0.171 ns |  2.32 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **6,397.98 ns** | **14.088 ns** | **12.488 ns** |  **2.41** |    **0.02** | **1.9760** |     **-** |     **-** |   **4,144 B** |
|                       ValueLinq_Stack |  1000 | 6,463.85 ns | 13.931 ns | 13.031 ns |  2.44 |    0.02 | 1.9760 |     - |     - |   4,144 B |
|             ValueLinq_SharedPool_Push |  1000 | 5,460.58 ns | 11.412 ns | 10.675 ns |  2.06 |    0.02 | 0.9689 |     - |     - |   2,040 B |
|             ValueLinq_SharedPool_Pull |  1000 | 7,168.51 ns | 19.262 ns | 17.075 ns |  2.70 |    0.02 | 0.9689 |     - |     - |   2,040 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 2,809.08 ns | 36.158 ns | 30.194 ns |  1.06 |    0.01 | 1.9798 |     - |     - |   4,144 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 2,737.37 ns |  8.647 ns |  7.666 ns |  1.03 |    0.01 | 1.9798 |     - |     - |   4,144 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 2,968.57 ns | 15.340 ns | 14.349 ns |  1.12 |    0.01 | 0.9727 |     - |     - |   2,040 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 2,774.64 ns | 11.993 ns | 10.632 ns |  1.05 |    0.01 | 0.9727 |     - |     - |   2,040 B |
|                               ForLoop |  1000 | 2,650.77 ns | 22.808 ns | 19.046 ns |  1.00 |    0.00 | 3.0289 |     - |     - |   6,344 B |
|                           ForeachLoop |  1000 | 2,688.76 ns | 23.427 ns | 20.768 ns |  1.01 |    0.01 | 3.0289 |     - |     - |   6,344 B |
|                                  Linq |  1000 | 5,320.71 ns | 14.365 ns | 13.437 ns |  2.01 |    0.01 | 2.1667 |     - |     - |   4,544 B |
|                            LinqFaster |  1000 | 4,992.09 ns | 18.154 ns | 16.093 ns |  1.88 |    0.01 | 2.8915 |     - |     - |   6,064 B |
|                                LinqAF |  1000 | 8,436.55 ns | 25.684 ns | 21.447 ns |  3.18 |    0.02 | 3.0060 |     - |     - |   6,312 B |
|                            StructLinq |  1000 | 5,884.87 ns | 16.846 ns | 14.933 ns |  2.22 |    0.02 | 1.0147 |     - |     - |   2,136 B |
|                  StructLinq_IFunction |  1000 | 4,283.98 ns |  9.029 ns |  8.445 ns |  1.62 |    0.01 | 0.9689 |     - |     - |   2,040 B |
|                             Hyperlinq |  1000 | 5,125.87 ns | 11.982 ns | 10.622 ns |  1.93 |    0.02 | 0.9689 |     - |     - |   2,040 B |
|                   Hyperlinq_IFunction |  1000 | 2,395.51 ns | 10.206 ns |  8.522 ns |  0.90 |    0.01 | 0.9727 |     - |     - |   2,040 B |
