## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **287.9 ns** |  **1.53 ns** |  **1.36 ns** |  **2.27** |    **0.02** | **0.0415** |     **-** |     **-** |      **88 B** |
|                       ValueLinq_Stack |    10 |   263.8 ns |  5.27 ns |  5.18 ns |  2.08 |    0.05 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Push |    10 |   477.1 ns |  1.47 ns |  1.30 ns |  3.75 |    0.02 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Pull |    10 |   358.5 ns |  0.86 ns |  0.71 ns |  2.82 |    0.01 | 0.0420 |     - |     - |      88 B |
|        ValueLinq_ValueLambda_Standard |    10 |   261.6 ns |  4.84 ns |  4.52 ns |  2.06 |    0.03 | 0.0415 |     - |     - |      88 B |
|           ValueLinq_ValueLambda_Stack |    10 |   221.1 ns |  4.34 ns |  4.82 ns |  1.74 |    0.04 | 0.0417 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   366.0 ns |  1.01 ns |  0.84 ns |  2.88 |    0.01 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   321.6 ns |  0.55 ns |  0.49 ns |  2.53 |    0.01 | 0.0420 |     - |     - |      88 B |
|                           ForeachLoop |    10 |   127.1 ns |  0.63 ns |  0.53 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                                  Linq |    10 |   242.3 ns |  0.77 ns |  0.68 ns |  1.91 |    0.01 | 0.1445 |     - |     - |     304 B |
|                                LinqAF |    10 |   206.9 ns |  0.56 ns |  0.50 ns |  1.63 |    0.01 | 0.0877 |     - |     - |     184 B |
|                            StructLinq |    10 |   225.3 ns |  0.77 ns |  0.72 ns |  1.77 |    0.01 | 0.0842 |     - |     - |     176 B |
|                  StructLinq_IFunction |    10 |   160.6 ns |  0.45 ns |  0.38 ns |  1.26 |    0.01 | 0.0420 |     - |     - |      88 B |
|                             Hyperlinq |    10 |   182.1 ns |  1.03 ns |  0.92 ns |  1.43 |    0.01 | 0.0420 |     - |     - |      88 B |
|                   Hyperlinq_IFunction |    10 |   152.7 ns |  1.14 ns |  1.01 ns |  1.20 |    0.01 | 0.0420 |     - |     - |      88 B |
|                                       |       |            |          |          |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **8,878.7 ns** | **20.04 ns** | **17.77 ns** |  **1.50** |    **0.00** | **1.9836** |     **-** |     **-** |    **4168 B** |
|                       ValueLinq_Stack |  1000 | 9,351.2 ns | 32.74 ns | 29.02 ns |  1.58 |    0.01 | 1.9836 |     - |     - |    4168 B |
|             ValueLinq_SharedPool_Push |  1000 | 9,013.2 ns | 24.90 ns | 22.07 ns |  1.53 |    0.00 | 0.9766 |     - |     - |    2064 B |
|             ValueLinq_SharedPool_Pull |  1000 | 8,436.4 ns | 20.08 ns | 17.80 ns |  1.43 |    0.00 | 0.9766 |     - |     - |    2064 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 6,514.9 ns | 25.09 ns | 22.24 ns |  1.10 |    0.00 | 1.9913 |     - |     - |    4168 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 6,159.5 ns | 17.27 ns | 15.31 ns |  1.04 |    0.00 | 1.9913 |     - |     - |    4168 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 6,571.4 ns | 23.41 ns | 19.55 ns |  1.11 |    0.00 | 0.9842 |     - |     - |    2064 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 6,063.8 ns | 18.57 ns | 15.50 ns |  1.03 |    0.00 | 0.9842 |     - |     - |    2064 B |
|                           ForeachLoop |  1000 | 5,900.7 ns | 10.56 ns |  8.82 ns |  1.00 |    0.00 | 3.0441 |     - |     - |    6368 B |
|                                  Linq |  1000 | 8,791.3 ns | 18.31 ns | 16.23 ns |  1.49 |    0.00 | 2.1820 |     - |     - |    4584 B |
|                                LinqAF |  1000 | 9,401.5 ns | 31.59 ns | 28.00 ns |  1.59 |    0.00 | 3.0212 |     - |     - |    6336 B |
|                            StructLinq |  1000 | 8,914.7 ns | 22.44 ns | 20.99 ns |  1.51 |    0.00 | 1.0223 |     - |     - |    2152 B |
|                  StructLinq_IFunction |  1000 | 5,887.9 ns |  8.74 ns |  7.74 ns |  1.00 |    0.00 | 0.9842 |     - |     - |    2064 B |
|                             Hyperlinq |  1000 | 8,948.0 ns | 24.09 ns | 21.35 ns |  1.52 |    0.00 | 0.9766 |     - |     - |    2064 B |
|                   Hyperlinq_IFunction |  1000 | 6,063.8 ns | 16.16 ns | 12.61 ns |  1.03 |    0.00 | 0.9842 |     - |     - |    2064 B |
