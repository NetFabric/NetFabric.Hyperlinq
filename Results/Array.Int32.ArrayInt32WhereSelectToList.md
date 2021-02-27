## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                    **ValueLinq_Standard** |    **10** |   **199.56 ns** |  **0.908 ns** |  **0.758 ns** |  **7.14** |    **0.05** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |    10 |   160.93 ns |  0.994 ns |  0.830 ns |  5.75 |    0.05 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |    10 |   369.37 ns |  2.159 ns |  1.686 ns | 13.20 |    0.12 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |    10 |   275.42 ns |  2.696 ns |  2.390 ns |  9.84 |    0.08 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |    10 |   177.78 ns |  1.095 ns |  0.971 ns |  6.36 |    0.05 | 0.0303 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |    10 |   141.40 ns |  0.760 ns |  0.674 ns |  5.05 |    0.04 | 0.0303 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   297.24 ns |  1.499 ns |  1.329 ns | 10.62 |    0.09 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   279.46 ns |  1.910 ns |  1.786 ns | 10.00 |    0.11 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |    10 |    27.98 ns |  0.231 ns |  0.181 ns |  1.00 |    0.00 | 0.0344 |     - |     - |      72 B |
|                           ForeachLoop |    10 |    26.66 ns |  0.230 ns |  0.204 ns |  0.95 |    0.01 | 0.0344 |     - |     - |      72 B |
|                                  Linq |    10 |    99.24 ns |  0.626 ns |  0.555 ns |  3.55 |    0.03 | 0.0840 |     - |     - |     176 B |
|                            LinqFaster |    10 |    79.70 ns |  0.712 ns |  0.594 ns |  2.85 |    0.02 | 0.0763 |     - |     - |     160 B |
|                                LinqAF |    10 |   107.09 ns |  0.716 ns |  0.597 ns |  3.83 |    0.04 | 0.0343 |     - |     - |      72 B |
|                            StructLinq |    10 |   152.19 ns |  0.923 ns |  0.818 ns |  5.43 |    0.04 | 0.0763 |     - |     - |     160 B |
|                  StructLinq_IFunction |    10 |   104.07 ns |  0.558 ns |  0.466 ns |  3.72 |    0.03 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq |    10 |   119.12 ns |  0.895 ns |  0.793 ns |  4.26 |    0.03 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |    10 |   100.10 ns |  0.489 ns |  0.408 ns |  3.58 |    0.03 | 0.0305 |     - |     - |      64 B |
|                                       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **5,220.36 ns** | **57.259 ns** | **63.644 ns** |  **2.08** |    **0.03** | **2.0523** |     **-** |     **-** |   **4,304 B** |
|                       ValueLinq_Stack |  1000 | 6,632.91 ns | 28.932 ns | 25.648 ns |  2.65 |    0.02 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push |  1000 | 5,774.31 ns | 34.061 ns | 28.442 ns |  2.30 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull |  1000 | 7,240.57 ns | 54.922 ns | 48.687 ns |  2.89 |    0.03 | 0.9842 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 4,278.01 ns | 19.722 ns | 18.448 ns |  1.71 |    0.01 | 2.0523 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 2,922.51 ns | 17.746 ns | 16.600 ns |  1.17 |    0.01 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 4,029.29 ns | 18.590 ns | 16.480 ns |  1.61 |    0.01 | 0.9842 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 2,914.77 ns | 13.695 ns | 11.436 ns |  1.16 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                               ForLoop |  1000 | 2,508.27 ns | 17.685 ns | 16.543 ns |  1.00 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                           ForeachLoop |  1000 | 2,440.52 ns | 18.069 ns | 16.902 ns |  0.97 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|                                  Linq |  1000 | 5,111.96 ns | 34.675 ns | 28.955 ns |  2.04 |    0.02 | 2.1057 |     - |     - |   4,408 B |
|                            LinqFaster |  1000 | 6,441.92 ns | 36.485 ns | 30.467 ns |  2.57 |    0.02 | 3.8834 |     - |     - |   8,136 B |
|                                LinqAF |  1000 | 8,081.79 ns | 47.509 ns | 42.115 ns |  3.22 |    0.03 | 2.0447 |     - |     - |   4,304 B |
|                            StructLinq |  1000 | 6,115.22 ns | 17.967 ns | 15.927 ns |  2.44 |    0.02 | 1.0300 |     - |     - |   2,168 B |
|                  StructLinq_IFunction |  1000 | 3,092.91 ns | 17.041 ns | 15.941 ns |  1.23 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                             Hyperlinq |  1000 | 5,493.32 ns | 20.502 ns | 18.175 ns |  2.19 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|                   Hyperlinq_IFunction |  1000 | 3,445.28 ns | 14.864 ns | 13.177 ns |  1.37 |    0.01 | 0.9880 |     - |     - |   2,072 B |
