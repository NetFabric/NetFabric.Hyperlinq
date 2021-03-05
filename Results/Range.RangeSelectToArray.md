## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                                Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **10** |   **103.511 ns** |  **0.1814 ns** |  **0.1515 ns** | **10.79** |    **0.04** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |     0 |    10 |    85.559 ns |  0.3615 ns |  0.3205 ns |  8.92 |    0.05 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   310.552 ns |  1.2192 ns |  1.0181 ns | 32.36 |    0.12 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   207.613 ns |  0.6238 ns |  0.5835 ns | 21.64 |    0.11 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |    91.984 ns |  0.2622 ns |  0.2324 ns |  9.59 |    0.04 | 0.0305 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |    73.024 ns |  0.2494 ns |  0.2211 ns |  7.61 |    0.03 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   222.373 ns |  0.9701 ns |  0.7574 ns | 23.17 |    0.07 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   196.410 ns |  0.7337 ns |  0.6504 ns | 20.47 |    0.07 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |     0 |    10 |     9.594 ns |  0.0340 ns |  0.0301 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                                  Linq |     0 |    10 |    61.613 ns |  0.1307 ns |  0.1091 ns |  6.42 |    0.02 | 0.0725 |     - |     - |     152 B |
|                            LinqFaster |     0 |    10 |    36.666 ns |  0.1433 ns |  0.1340 ns |  3.82 |    0.02 | 0.0612 |     - |     - |     128 B |
|                       LinqFaster_SIMD |     0 |    10 |    30.027 ns |  0.1306 ns |  0.1222 ns |  3.13 |    0.02 | 0.0612 |     - |     - |     128 B |
|                                LinqAF |     0 |    10 |   151.053 ns |  0.5835 ns |  0.5458 ns | 15.75 |    0.09 | 0.1183 |     - |     - |     248 B |
|                            StructLinq |     0 |    10 |    44.245 ns |  0.1823 ns |  0.1705 ns |  4.61 |    0.02 | 0.0573 |     - |     - |     120 B |
|                  StructLinq_IFunction |     0 |    10 |    26.337 ns |  0.0800 ns |  0.0709 ns |  2.75 |    0.01 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq |     0 |    10 |    47.464 ns |  0.4174 ns |  0.3701 ns |  4.95 |    0.04 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |     0 |    10 |    36.512 ns |  0.1501 ns |  0.1331 ns |  3.81 |    0.01 | 0.0305 |     - |     - |      64 B |
|                        Hyperlinq_SIMD |     0 |    10 |    37.621 ns |  0.0966 ns |  0.0856 ns |  3.92 |    0.02 | 0.0305 |     - |     - |      64 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    26.395 ns |  0.0465 ns |  0.0435 ns |  2.75 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                       |       |       |              |            |            |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **1,887.740 ns** |  **9.6563 ns** |  **9.0326 ns** |  **2.30** |    **0.02** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|                       ValueLinq_Stack |     0 |  1000 | 3,722.855 ns | 12.1298 ns | 10.7527 ns |  4.54 |    0.03 | 3.9177 |     - |     - |   8,200 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,233.449 ns |  8.7043 ns |  7.7161 ns |  3.94 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 3,441.707 ns |  7.6261 ns |  6.3681 ns |  4.20 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 1,849.220 ns |  5.0041 ns |  4.1786 ns |  2.25 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,420.706 ns | 12.4560 ns | 11.0419 ns |  2.95 |    0.02 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,408.326 ns | 17.0770 ns | 15.1383 ns |  2.94 |    0.01 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,190.200 ns |  6.5357 ns |  5.7938 ns |  2.67 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                               ForLoop |     0 |  1000 |   820.201 ns |  5.1928 ns |  4.6033 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                                  Linq |     0 |  1000 | 2,070.689 ns | 13.0817 ns | 12.2366 ns |  2.53 |    0.03 | 1.9646 |     - |     - |   4,112 B |
|                            LinqFaster |     0 |  1000 | 2,622.046 ns | 15.7995 ns | 14.7789 ns |  3.20 |    0.02 | 3.8452 |     - |     - |   8,048 B |
|                       LinqFaster_SIMD |     0 |  1000 |   747.480 ns |  9.8457 ns |  9.2097 ns |  0.91 |    0.01 | 3.8452 |     - |     - |   8,048 B |
|                                LinqAF |     0 |  1000 | 6,322.083 ns | 29.6936 ns | 26.3226 ns |  7.71 |    0.04 | 5.9280 |     - |     - |  12,416 B |
|                            StructLinq |     0 |  1000 | 2,042.271 ns |  7.1149 ns |  6.3072 ns |  2.49 |    0.01 | 1.9493 |     - |     - |   4,080 B |
|                  StructLinq_IFunction |     0 |  1000 |   703.408 ns |  3.7514 ns |  3.3255 ns |  0.86 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                             Hyperlinq |     0 |  1000 | 1,910.266 ns | 12.3972 ns | 10.3522 ns |  2.33 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                   Hyperlinq_IFunction |     0 |  1000 |   907.253 ns |  3.5828 ns |  3.3513 ns |  1.11 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   448.662 ns |  1.6601 ns |  1.5529 ns |  0.55 |    0.00 | 1.9155 |     - |     - |   4,024 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   253.995 ns |  1.6627 ns |  1.2981 ns |  0.31 |    0.00 | 1.9155 |     - |     - |   4,024 B |
