## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                                Method | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **193.58 ns** |   **0.622 ns** |   **0.551 ns** |   **193.50 ns** |  **6.77** |    **0.20** | **0.0303** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |    10 |   161.41 ns |   3.178 ns |   3.660 ns |   162.86 ns |  5.68 |    0.24 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |    10 |   368.46 ns |   1.964 ns |   1.837 ns |   367.84 ns | 12.88 |    0.37 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |    10 |   268.32 ns |   1.534 ns |   1.281 ns |   268.67 ns |  9.39 |    0.28 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |    10 |   188.16 ns |   1.331 ns |   1.180 ns |   188.23 ns |  6.58 |    0.18 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |    10 |   141.95 ns |   0.900 ns |   0.798 ns |   141.68 ns |  4.97 |    0.15 | 0.0303 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   293.60 ns |   0.965 ns |   0.855 ns |   293.28 ns | 10.27 |    0.30 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   266.06 ns |   1.511 ns |   1.339 ns |   265.80 ns |  9.31 |    0.28 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |    10 |    27.11 ns |   0.614 ns |   1.573 ns |    26.12 ns |  1.00 |    0.00 | 0.0344 |     - |     - |      72 B |
|                           ForeachLoop |    10 |    27.82 ns |   0.186 ns |   0.174 ns |    27.76 ns |  0.97 |    0.03 | 0.0344 |     - |     - |      72 B |
|                                  Linq |    10 |    95.83 ns |   0.572 ns |   0.478 ns |    95.89 ns |  3.36 |    0.11 | 0.0840 |     - |     - |     176 B |
|                            LinqFaster |    10 |    78.76 ns |   1.050 ns |   0.877 ns |    78.71 ns |  2.76 |    0.10 | 0.0763 |     - |     - |     160 B |
|                                LinqAF |    10 |   106.94 ns |   0.483 ns |   0.428 ns |   107.07 ns |  3.74 |    0.11 | 0.0342 |     - |     - |      72 B |
|                            StructLinq |    10 |   149.84 ns |   0.913 ns |   0.809 ns |   149.79 ns |  5.24 |    0.18 | 0.0763 |     - |     - |     160 B |
|                  StructLinq_IFunction |    10 |   105.42 ns |   2.172 ns |   3.860 ns |   103.15 ns |  3.91 |    0.19 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq |    10 |   123.99 ns |   0.853 ns |   0.798 ns |   124.09 ns |  4.33 |    0.13 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |    10 |    96.31 ns |   0.704 ns |   0.659 ns |    96.08 ns |  3.37 |    0.11 | 0.0305 |     - |     - |      64 B |
|                                       |       |             |            |            |             |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **5,964.61 ns** |  **21.380 ns** |  **19.999 ns** | **5,963.46 ns** |  **1.72** |    **0.06** | **2.0523** |     **-** |     **-** |   **4,304 B** |
|                       ValueLinq_Stack |  1000 | 7,201.16 ns | 142.696 ns | 209.161 ns | 7,317.66 ns |  2.00 |    0.05 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push |  1000 | 6,027.12 ns |  31.832 ns |  26.581 ns | 6,023.19 ns |  1.75 |    0.04 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull |  1000 | 6,760.65 ns |  35.283 ns |  33.004 ns | 6,761.92 ns |  1.94 |    0.07 | 0.9842 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 3,420.00 ns |  15.723 ns |  13.129 ns | 3,423.27 ns |  0.99 |    0.02 | 2.0561 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 3,291.97 ns |  67.319 ns | 197.435 ns | 3,203.28 ns |  0.95 |    0.09 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 3,295.31 ns |  26.190 ns |  25.722 ns | 3,293.22 ns |  0.94 |    0.03 | 0.9880 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 3,678.54 ns |  46.279 ns |  43.290 ns | 3,675.44 ns |  1.06 |    0.04 | 0.9880 |     - |     - |   2,072 B |
|                               ForLoop |  1000 | 3,530.11 ns |  70.108 ns | 152.409 ns | 3,424.71 ns |  1.00 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                           ForeachLoop |  1000 | 2,791.96 ns |  23.684 ns |  22.154 ns | 2,786.93 ns |  0.80 |    0.03 | 2.0561 |     - |     - |   4,304 B |
|                                  Linq |  1000 | 5,142.85 ns |  31.153 ns |  29.140 ns | 5,134.39 ns |  1.48 |    0.05 | 2.1057 |     - |     - |   4,408 B |
|                            LinqFaster |  1000 | 4,744.42 ns |  30.363 ns |  26.916 ns | 4,749.83 ns |  1.37 |    0.04 | 3.8834 |     - |     - |   8,136 B |
|                                LinqAF |  1000 | 8,215.22 ns |  39.078 ns |  36.553 ns | 8,210.40 ns |  2.36 |    0.08 | 2.0447 |     - |     - |   4,304 B |
|                            StructLinq |  1000 | 5,980.21 ns |  31.228 ns |  24.380 ns | 5,982.92 ns |  1.74 |    0.02 | 1.0300 |     - |     - |   2,168 B |
|                  StructLinq_IFunction |  1000 | 4,846.50 ns |  40.236 ns |  35.668 ns | 4,839.81 ns |  1.40 |    0.04 | 0.9842 |     - |     - |   2,072 B |
|                             Hyperlinq |  1000 | 5,522.12 ns |  39.233 ns |  36.699 ns | 5,517.71 ns |  1.59 |    0.05 | 0.9842 |     - |     - |   2,072 B |
|                   Hyperlinq_IFunction |  1000 | 3,700.38 ns |  16.446 ns |  14.579 ns | 3,694.59 ns |  1.07 |    0.03 | 0.9880 |     - |     - |   2,072 B |
