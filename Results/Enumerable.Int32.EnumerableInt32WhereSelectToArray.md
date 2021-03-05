## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                                Method | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **249.0 ns** |  **0.59 ns** |  **0.53 ns** |  **2.29** | **0.0415** |     **-** |     **-** |      **88 B** |
|                       ValueLinq_Stack |    10 |   207.9 ns |  0.36 ns |  0.31 ns |  1.91 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Push |    10 |   463.0 ns |  1.38 ns |  1.22 ns |  4.26 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Pull |    10 |   334.1 ns |  1.85 ns |  1.64 ns |  3.07 | 0.0420 |     - |     - |      88 B |
|        ValueLinq_ValueLambda_Standard |    10 |   217.3 ns |  0.69 ns |  0.58 ns |  2.00 | 0.0420 |     - |     - |      88 B |
|           ValueLinq_ValueLambda_Stack |    10 |   172.0 ns |  0.51 ns |  0.48 ns |  1.58 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   361.3 ns |  1.07 ns |  0.90 ns |  3.33 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   321.6 ns |  1.04 ns |  0.92 ns |  2.96 | 0.0420 |     - |     - |      88 B |
|                           ForeachLoop |    10 |   108.6 ns |  0.26 ns |  0.22 ns |  1.00 | 0.1031 |     - |     - |     216 B |
|                                  Linq |    10 |   197.6 ns |  0.67 ns |  0.63 ns |  1.82 | 0.1452 |     - |     - |     304 B |
|                                LinqAF |    10 |   208.7 ns |  0.36 ns |  0.30 ns |  1.92 | 0.0877 |     - |     - |     184 B |
|                            StructLinq |    10 |   206.5 ns |  0.34 ns |  0.28 ns |  1.90 | 0.0842 |     - |     - |     176 B |
|                  StructLinq_IFunction |    10 |   150.2 ns |  0.65 ns |  0.54 ns |  1.38 | 0.0420 |     - |     - |      88 B |
|                             Hyperlinq |    10 |   166.4 ns |  0.55 ns |  0.49 ns |  1.53 | 0.0420 |     - |     - |      88 B |
|                   Hyperlinq_IFunction |    10 |   135.1 ns |  0.39 ns |  0.35 ns |  1.24 | 0.0420 |     - |     - |      88 B |
|                                       |       |            |          |          |       |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **7,705.6 ns** | **27.54 ns** | **22.99 ns** |  **1.40** | **1.9836** |     **-** |     **-** |   **4,168 B** |
|                       ValueLinq_Stack |  1000 | 7,732.0 ns | 17.65 ns | 15.65 ns |  1.41 | 1.9836 |     - |     - |   4,168 B |
|             ValueLinq_SharedPool_Push |  1000 | 8,130.9 ns | 18.33 ns | 16.25 ns |  1.48 | 0.9766 |     - |     - |   2,064 B |
|             ValueLinq_SharedPool_Pull |  1000 | 7,680.1 ns | 33.58 ns | 29.77 ns |  1.40 | 0.9766 |     - |     - |   2,064 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 6,148.8 ns | 21.18 ns | 18.78 ns |  1.12 | 1.9913 |     - |     - |   4,168 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 6,101.6 ns | 14.80 ns | 13.12 ns |  1.11 | 1.9913 |     - |     - |   4,168 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 6,025.4 ns | 15.46 ns | 12.07 ns |  1.09 | 0.9842 |     - |     - |   2,064 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 6,022.1 ns | 29.28 ns | 25.95 ns |  1.09 | 0.9842 |     - |     - |   2,064 B |
|                           ForeachLoop |  1000 | 5,500.5 ns | 23.88 ns | 21.17 ns |  1.00 | 3.0441 |     - |     - |   6,368 B |
|                                  Linq |  1000 | 7,731.8 ns | 22.13 ns | 19.62 ns |  1.41 | 2.1820 |     - |     - |   4,584 B |
|                                LinqAF |  1000 | 9,578.0 ns | 33.03 ns | 29.28 ns |  1.74 | 3.0212 |     - |     - |   6,336 B |
|                            StructLinq |  1000 | 7,810.5 ns | 58.90 ns | 49.18 ns |  1.42 | 1.0223 |     - |     - |   2,152 B |
|                  StructLinq_IFunction |  1000 | 6,170.7 ns | 22.04 ns | 19.53 ns |  1.12 | 0.9842 |     - |     - |   2,064 B |
|                             Hyperlinq |  1000 | 7,634.9 ns | 29.60 ns | 26.24 ns |  1.39 | 0.9766 |     - |     - |   2,064 B |
|                   Hyperlinq_IFunction |  1000 | 5,808.9 ns | 11.96 ns | 10.60 ns |  1.06 | 0.9842 |     - |     - |   2,064 B |
