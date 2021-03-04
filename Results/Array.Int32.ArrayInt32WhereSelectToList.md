## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                                Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **196.12 ns** |  **0.647 ns** |  **0.573 ns** |  **7.45** |    **0.06** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |    10 |   152.76 ns |  0.485 ns |  0.430 ns |  5.81 |    0.04 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |    10 |   366.15 ns |  1.469 ns |  1.302 ns | 13.92 |    0.11 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |    10 |   268.70 ns |  0.894 ns |  0.793 ns | 10.21 |    0.09 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |    10 |   173.17 ns |  0.857 ns |  0.760 ns |  6.58 |    0.05 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |    10 |   136.69 ns |  1.373 ns |  1.146 ns |  5.20 |    0.06 | 0.0303 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   299.11 ns |  0.977 ns |  0.816 ns | 11.37 |    0.09 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   263.00 ns |  1.239 ns |  1.035 ns | 10.00 |    0.07 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |    10 |    26.31 ns |  0.218 ns |  0.193 ns |  1.00 |    0.00 | 0.0344 |     - |     - |      72 B |
|                           ForeachLoop |    10 |    24.66 ns |  0.145 ns |  0.129 ns |  0.94 |    0.01 | 0.0344 |     - |     - |      72 B |
|                                  Linq |    10 |    92.44 ns |  0.404 ns |  0.337 ns |  3.52 |    0.03 | 0.0842 |     - |     - |     176 B |
|                            LinqFaster |    10 |    75.52 ns |  0.348 ns |  0.308 ns |  2.87 |    0.03 | 0.0763 |     - |     - |     160 B |
|                                LinqAF |    10 |   107.26 ns |  0.411 ns |  0.364 ns |  4.08 |    0.04 | 0.0343 |     - |     - |      72 B |
|                            StructLinq |    10 |   145.79 ns |  0.418 ns |  0.391 ns |  5.54 |    0.05 | 0.0763 |     - |     - |     160 B |
|                  StructLinq_IFunction |    10 |   101.53 ns |  0.366 ns |  0.324 ns |  3.86 |    0.03 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq |    10 |   115.18 ns |  0.393 ns |  0.328 ns |  4.38 |    0.03 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |    10 |    91.36 ns |  0.536 ns |  0.447 ns |  3.47 |    0.02 | 0.0305 |     - |     - |      64 B |
|                                       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **5,326.68 ns** | **24.912 ns** | **20.803 ns** |  **2.29** |    **0.02** | **2.0523** |     **-** |     **-** |   **4,304 B** |
|                       ValueLinq_Stack |  1000 | 6,145.93 ns | 19.920 ns | 15.552 ns |  2.65 |    0.02 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push |  1000 | 5,654.76 ns | 19.308 ns | 16.123 ns |  2.44 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull |  1000 | 6,721.18 ns | 28.557 ns | 23.847 ns |  2.89 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 4,214.92 ns | 25.003 ns | 22.165 ns |  1.81 |    0.02 | 2.0523 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 2,765.99 ns | 21.497 ns | 19.057 ns |  1.19 |    0.01 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 3,121.46 ns | 18.374 ns | 17.187 ns |  1.34 |    0.01 | 0.9880 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 2,815.07 ns | 32.449 ns | 30.352 ns |  1.21 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                               ForLoop |  1000 | 2,324.78 ns | 18.149 ns | 16.089 ns |  1.00 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                           ForeachLoop |  1000 | 2,329.59 ns | 24.845 ns | 23.240 ns |  1.00 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|                                  Linq |  1000 | 5,065.05 ns | 34.007 ns | 30.146 ns |  2.18 |    0.02 | 2.1057 |     - |     - |   4,408 B |
|                            LinqFaster |  1000 | 4,620.20 ns | 28.085 ns | 24.897 ns |  1.99 |    0.01 | 3.8834 |     - |     - |   8,136 B |
|                                LinqAF |  1000 | 7,177.65 ns | 28.339 ns | 25.122 ns |  3.09 |    0.03 | 2.0523 |     - |     - |   4,304 B |
|                            StructLinq |  1000 | 5,922.91 ns | 28.707 ns | 26.853 ns |  2.55 |    0.02 | 1.0300 |     - |     - |   2,168 B |
|                  StructLinq_IFunction |  1000 | 4,054.59 ns | 17.243 ns | 15.285 ns |  1.74 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|                             Hyperlinq |  1000 | 5,139.05 ns | 27.088 ns | 25.338 ns |  2.21 |    0.01 | 0.9842 |     - |     - |   2,072 B |
|                   Hyperlinq_IFunction |  1000 | 3,616.23 ns |  8.574 ns |  8.020 ns |  1.56 |    0.01 | 0.9880 |     - |     - |   2,072 B |
