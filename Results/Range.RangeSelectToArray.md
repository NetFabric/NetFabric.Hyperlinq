## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                                Method | Start | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **10** |   **106.18 ns** |  **0.321 ns** |  **0.284 ns** | **10.60** |    **0.05** | **0.0305** |     **-** |     **-** |      **64 B** |
|                       ValueLinq_Stack |     0 |    10 |    89.48 ns |  0.436 ns |  0.386 ns |  8.94 |    0.07 | 0.0304 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Push |     0 |    10 |   314.41 ns |  2.953 ns |  2.763 ns | 31.42 |    0.36 | 0.0305 |     - |     - |      64 B |
|             ValueLinq_SharedPool_Pull |     0 |    10 |   214.50 ns |  0.596 ns |  0.528 ns | 21.42 |    0.12 | 0.0305 |     - |     - |      64 B |
|        ValueLinq_ValueLambda_Standard |     0 |    10 |    95.47 ns |  0.297 ns |  0.263 ns |  9.53 |    0.05 | 0.0304 |     - |     - |      64 B |
|           ValueLinq_ValueLambda_Stack |     0 |    10 |    79.81 ns |  0.297 ns |  0.248 ns |  7.97 |    0.03 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    10 |   229.33 ns |  1.227 ns |  1.088 ns | 22.90 |    0.17 | 0.0305 |     - |     - |      64 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    10 |   200.15 ns |  1.025 ns |  0.909 ns | 19.99 |    0.11 | 0.0305 |     - |     - |      64 B |
|                               ForLoop |     0 |    10 |    10.01 ns |  0.047 ns |  0.041 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                                  Linq |     0 |    10 |    62.86 ns |  0.370 ns |  0.346 ns |  6.28 |    0.04 | 0.0726 |     - |     - |     152 B |
|                            LinqFaster |     0 |    10 |    37.47 ns |  0.135 ns |  0.120 ns |  3.74 |    0.02 | 0.0612 |     - |     - |     128 B |
|                       LinqFaster_SIMD |     0 |    10 |    31.22 ns |  0.144 ns |  0.113 ns |  3.12 |    0.01 | 0.0612 |     - |     - |     128 B |
|                                LinqAF |     0 |    10 |   156.35 ns |  0.557 ns |  0.521 ns | 15.62 |    0.09 | 0.1185 |     - |     - |     248 B |
|                            StructLinq |     0 |    10 |    49.44 ns |  0.240 ns |  0.213 ns |  4.94 |    0.03 | 0.0573 |     - |     - |     120 B |
|                  StructLinq_IFunction |     0 |    10 |    26.95 ns |  0.195 ns |  0.173 ns |  2.69 |    0.02 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq |     0 |    10 |    48.69 ns |  0.105 ns |  0.093 ns |  4.86 |    0.02 | 0.0305 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |     0 |    10 |    37.43 ns |  0.077 ns |  0.065 ns |  3.74 |    0.02 | 0.0305 |     - |     - |      64 B |
|                        Hyperlinq_SIMD |     0 |    10 |    40.26 ns |  0.242 ns |  0.214 ns |  4.02 |    0.03 | 0.0306 |     - |     - |      64 B |
|              Hyperlinq_IFunction_SIMD |     0 |    10 |    27.46 ns |  0.138 ns |  0.129 ns |  2.74 |    0.02 | 0.0305 |     - |     - |      64 B |
|                                       |       |       |             |           |           |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |     **0** |  **1000** | **1,946.24 ns** |  **7.788 ns** |  **6.904 ns** |  **2.31** |    **0.02** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|                       ValueLinq_Stack |     0 |  1000 | 3,845.30 ns | 13.352 ns | 11.149 ns |  4.56 |    0.04 | 3.9139 |     - |     - |   8,200 B |
|             ValueLinq_SharedPool_Push |     0 |  1000 | 3,342.37 ns | 16.119 ns | 15.078 ns |  3.97 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|             ValueLinq_SharedPool_Pull |     0 |  1000 | 3,993.17 ns | 16.628 ns | 15.554 ns |  4.74 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|        ValueLinq_ValueLambda_Standard |     0 |  1000 | 1,910.27 ns |  7.987 ns |  7.471 ns |  2.27 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|           ValueLinq_ValueLambda_Stack |     0 |  1000 | 2,490.39 ns |  9.560 ns |  8.942 ns |  2.96 |    0.03 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |  1000 | 2,478.19 ns | 10.602 ns |  9.917 ns |  2.94 |    0.03 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |  1000 | 2,380.72 ns |  9.941 ns |  8.812 ns |  2.82 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                               ForLoop |     0 |  1000 |   842.42 ns |  8.153 ns |  7.627 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                                  Linq |     0 |  1000 | 2,141.10 ns | 10.830 ns |  9.043 ns |  2.54 |    0.03 | 1.9646 |     - |     - |   4,112 B |
|                            LinqFaster |     0 |  1000 | 2,712.01 ns | 26.800 ns | 25.069 ns |  3.22 |    0.05 | 3.8452 |     - |     - |   8,048 B |
|                       LinqFaster_SIMD |     0 |  1000 |   800.65 ns | 13.193 ns | 12.341 ns |  0.95 |    0.01 | 3.8452 |     - |     - |   8,048 B |
|                                LinqAF |     0 |  1000 | 6,531.33 ns | 28.927 ns | 25.643 ns |  7.75 |    0.06 | 5.9280 |     - |     - |  12,416 B |
|                            StructLinq |     0 |  1000 | 1,828.59 ns |  9.632 ns |  8.538 ns |  2.17 |    0.02 | 1.9493 |     - |     - |   4,080 B |
|                  StructLinq_IFunction |     0 |  1000 |   746.01 ns |  5.737 ns |  5.367 ns |  0.89 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                             Hyperlinq |     0 |  1000 | 1,944.92 ns |  5.211 ns |  4.352 ns |  2.31 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                   Hyperlinq_IFunction |     0 |  1000 | 1,295.21 ns |  4.557 ns |  4.263 ns |  1.54 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                        Hyperlinq_SIMD |     0 |  1000 |   471.70 ns |  3.154 ns |  2.950 ns |  0.56 |    0.01 | 1.9150 |     - |     - |   4,024 B |
|              Hyperlinq_IFunction_SIMD |     0 |  1000 |   263.30 ns |  2.629 ns |  2.195 ns |  0.31 |    0.00 | 1.9155 |     - |     - |   4,024 B |
