## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **260.0 ns** |  **2.68 ns** |  **2.98 ns** |  **2.38** |    **0.03** | **0.0420** |     **-** |     **-** |      **88 B** |
|                       ValueLinq_Stack |    10 |   211.0 ns |  0.55 ns |  0.46 ns |  1.93 |    0.00 | 0.0417 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Push |    10 |   466.8 ns |  1.65 ns |  1.46 ns |  4.26 |    0.01 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Pull |    10 |   348.9 ns |  0.77 ns |  0.60 ns |  3.19 |    0.01 | 0.0420 |     - |     - |      88 B |
|        ValueLinq_ValueLambda_Standard |    10 |   219.0 ns |  0.48 ns |  0.37 ns |  2.00 |    0.00 | 0.0417 |     - |     - |      88 B |
|           ValueLinq_ValueLambda_Stack |    10 |   172.1 ns |  0.69 ns |  0.65 ns |  1.57 |    0.01 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   360.7 ns |  0.68 ns |  0.57 ns |  3.30 |    0.01 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   317.5 ns |  0.86 ns |  0.77 ns |  2.90 |    0.01 | 0.0420 |     - |     - |      88 B |
|                           ForeachLoop |    10 |   109.4 ns |  0.17 ns |  0.13 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                                  Linq |    10 |   200.4 ns |  0.66 ns |  0.58 ns |  1.83 |    0.01 | 0.1452 |     - |     - |     304 B |
|                                LinqAF |    10 |   201.5 ns |  0.56 ns |  0.52 ns |  1.84 |    0.01 | 0.0880 |     - |     - |     184 B |
|                            StructLinq |    10 |   209.9 ns |  0.47 ns |  0.42 ns |  1.92 |    0.00 | 0.0842 |     - |     - |     176 B |
|                  StructLinq_IFunction |    10 |   148.8 ns |  0.49 ns |  0.41 ns |  1.36 |    0.00 | 0.0420 |     - |     - |      88 B |
|                             Hyperlinq |    10 |   168.3 ns |  0.46 ns |  0.36 ns |  1.54 |    0.00 | 0.0420 |     - |     - |      88 B |
|                   Hyperlinq_IFunction |    10 |   136.7 ns |  0.49 ns |  0.43 ns |  1.25 |    0.00 | 0.0420 |     - |     - |      88 B |
|                                       |       |            |          |          |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **8,259.7 ns** | **23.82 ns** | **18.60 ns** |  **1.37** |    **0.01** | **1.9836** |     **-** |     **-** |   **4,168 B** |
|                       ValueLinq_Stack |  1000 | 7,742.8 ns | 45.55 ns | 40.38 ns |  1.28 |    0.01 | 1.9836 |     - |     - |   4,168 B |
|             ValueLinq_SharedPool_Push |  1000 | 8,493.7 ns | 26.37 ns | 23.37 ns |  1.41 |    0.01 | 0.9766 |     - |     - |   2,064 B |
|             ValueLinq_SharedPool_Pull |  1000 | 7,686.8 ns | 25.59 ns | 23.94 ns |  1.27 |    0.00 | 0.9766 |     - |     - |   2,064 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 6,126.7 ns | 15.83 ns | 14.04 ns |  1.01 |    0.00 | 1.9913 |     - |     - |   4,168 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 6,020.1 ns | 11.44 ns | 10.14 ns |  1.00 |    0.00 | 1.9913 |     - |     - |   4,168 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 6,359.5 ns | 16.32 ns | 15.26 ns |  1.05 |    0.00 | 0.9842 |     - |     - |   2,064 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 5,994.7 ns | 21.48 ns | 20.09 ns |  0.99 |    0.01 | 0.9842 |     - |     - |   2,064 B |
|                           ForeachLoop |  1000 | 6,044.6 ns | 20.27 ns | 17.97 ns |  1.00 |    0.00 | 3.0441 |     - |     - |   6,368 B |
|                                  Linq |  1000 | 7,699.0 ns | 26.29 ns | 21.96 ns |  1.27 |    0.01 | 2.1820 |     - |     - |   4,584 B |
|                                LinqAF |  1000 | 9,957.6 ns | 21.35 ns | 17.83 ns |  1.65 |    0.00 | 3.0212 |     - |     - |   6,336 B |
|                            StructLinq |  1000 | 8,155.0 ns | 20.19 ns | 18.89 ns |  1.35 |    0.01 | 1.0223 |     - |     - |   2,152 B |
|                  StructLinq_IFunction |  1000 | 5,528.9 ns | 16.09 ns | 15.05 ns |  0.91 |    0.00 | 0.9842 |     - |     - |   2,064 B |
|                             Hyperlinq |  1000 | 8,025.9 ns | 28.41 ns | 25.18 ns |  1.33 |    0.01 | 0.9766 |     - |     - |   2,064 B |
|                   Hyperlinq_IFunction |  1000 | 5,561.0 ns | 14.07 ns | 12.48 ns |  0.92 |    0.00 | 0.9842 |     - |     - |   2,064 B |
