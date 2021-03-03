## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                                Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |    **10** |   **189.56 ns** |  **0.333 ns** |  **0.278 ns** |  **7.57** |    **0.05** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |    10 |   147.97 ns |  0.379 ns |  0.336 ns |  5.91 |    0.04 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |    10 |   357.44 ns |  0.888 ns |  0.741 ns | 14.27 |    0.10 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |    10 |   269.01 ns |  1.323 ns |  1.237 ns | 10.74 |    0.11 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |    10 |   167.85 ns |  0.436 ns |  0.364 ns |  6.70 |    0.04 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |    10 |   130.77 ns |  0.373 ns |  0.331 ns |  5.22 |    0.04 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |   279.68 ns |  1.301 ns |  1.217 ns | 11.15 |    0.09 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |   256.72 ns |  0.696 ns |  0.651 ns | 10.25 |    0.07 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |    10 |    25.05 ns |  0.180 ns |  0.150 ns |  1.00 |    0.00 | 0.0344 |     - |     - |      72 B |
|                           ForeachLoop |    10 |    23.77 ns |  0.041 ns |  0.037 ns |  0.95 |    0.01 | 0.0344 |     - |     - |      72 B |
|                                  Linq |    10 |    89.25 ns |  0.298 ns |  0.264 ns |  3.56 |    0.02 | 0.0840 |     - |     - |     176 B |
|                            LinqFaster |    10 |    72.13 ns |  0.232 ns |  0.193 ns |  2.88 |    0.02 | 0.0764 |     - |     - |     160 B |
|                                LinqAF |    10 |   101.83 ns |  0.317 ns |  0.281 ns |  4.06 |    0.03 | 0.0343 |     - |     - |      72 B |
|                            StructLinq |    10 |   138.89 ns |  0.635 ns |  0.594 ns |  5.55 |    0.05 | 0.0763 |     - |     - |     160 B |
|                  StructLinq_IFunction |    10 |   100.76 ns |  0.208 ns |  0.184 ns |  4.02 |    0.02 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq |    10 |   113.72 ns |  0.306 ns |  0.271 ns |  4.54 |    0.03 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |    10 |    93.25 ns |  0.185 ns |  0.164 ns |  3.72 |    0.02 | 0.0305 |     - |     - |      64 B |
|                                       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **4,982.98 ns** | **18.485 ns** | **17.291 ns** |  **2.31** |    **0.02** | **2.0523** |     **-** |     **-** |   **4,304 B** |
|                       ValueLinq_Stack |  1000 | 6,543.19 ns | 12.899 ns | 10.771 ns |  3.03 |    0.02 | 1.9913 |     - |     - |   4,176 B |
|             ValueLinq_SharedPool_Push |  1000 | 5,507.44 ns | 19.677 ns | 17.443 ns |  2.55 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|             ValueLinq_SharedPool_Pull |  1000 | 7,206.65 ns | 17.799 ns | 15.778 ns |  3.34 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|        ValueLinq_ValueLambda_Standard |  1000 | 2,575.45 ns |  8.858 ns | 11.825 ns |  1.19 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|           ValueLinq_ValueLambda_Stack |  1000 | 2,673.54 ns |  9.666 ns |  9.041 ns |  1.24 |    0.01 | 1.9951 |     - |     - |   4,176 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 | 2,978.09 ns | 10.478 ns |  9.289 ns |  1.38 |    0.01 | 0.9880 |     - |     - |   2,072 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 | 2,746.75 ns | 13.441 ns | 11.915 ns |  1.27 |    0.01 | 0.9880 |     - |     - |   2,072 B |
|                               ForLoop |  1000 | 2,160.35 ns | 17.762 ns | 14.832 ns |  1.00 |    0.00 | 2.0561 |     - |     - |   4,304 B |
|                           ForeachLoop |  1000 | 2,357.35 ns | 10.722 ns |  9.505 ns |  1.09 |    0.01 | 2.0561 |     - |     - |   4,304 B |
|                                  Linq |  1000 | 4,832.62 ns | 17.661 ns | 13.789 ns |  2.24 |    0.02 | 2.1057 |     - |     - |   4,408 B |
|                            LinqFaster |  1000 | 4,825.30 ns | 16.621 ns | 14.734 ns |  2.23 |    0.02 | 3.8834 |     - |     - |   8,136 B |
|                                LinqAF |  1000 | 7,537.15 ns | 15.315 ns | 13.577 ns |  3.49 |    0.02 | 2.0523 |     - |     - |   4,304 B |
|                            StructLinq |  1000 | 5,430.15 ns | 39.751 ns | 33.194 ns |  2.51 |    0.02 | 1.0300 |     - |     - |   2,168 B |
|                  StructLinq_IFunction |  1000 | 3,971.12 ns | 20.235 ns | 18.928 ns |  1.84 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|                             Hyperlinq |  1000 | 5,229.86 ns | 28.473 ns | 23.776 ns |  2.42 |    0.02 | 0.9842 |     - |     - |   2,072 B |
|                   Hyperlinq_IFunction |  1000 | 3,195.26 ns | 17.791 ns | 14.856 ns |  1.48 |    0.01 | 0.9880 |     - |     - |   2,072 B |
