## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta38](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta38)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                                Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                    **ValueLinq_Standard** |     **0** |    **182.38 ns** |   **2.042 ns** |   **1.910 ns** |  **8.34** |    **0.11** | **0.0191** |     **-** |     **-** |      **40 B** |
|                       ValueLinq_Stack |     0 |    174.79 ns |   3.499 ns |   3.890 ns |  8.01 |    0.21 | 0.0191 |     - |     - |      40 B |
|             ValueLinq_SharedPool_Push |     0 |    367.91 ns |   2.359 ns |   1.970 ns | 16.83 |    0.11 | 0.0191 |     - |     - |      40 B |
|             ValueLinq_SharedPool_Pull |     0 |    275.98 ns |   2.590 ns |   2.296 ns | 12.63 |    0.12 | 0.0191 |     - |     - |      40 B |
|        ValueLinq_ValueLambda_Standard |     0 |    177.74 ns |   1.253 ns |   1.046 ns |  8.13 |    0.06 | 0.0191 |     - |     - |      40 B |
|           ValueLinq_ValueLambda_Stack |     0 |    141.63 ns |   2.906 ns |   3.231 ns |  6.49 |    0.11 | 0.0191 |     - |     - |      40 B |
| ValueLinq_ValueLambda_SharedPool_Push |     0 |    288.82 ns |   3.574 ns |   3.343 ns | 13.23 |    0.19 | 0.0191 |     - |     - |      40 B |
| ValueLinq_ValueLambda_SharedPool_Pull |     0 |    285.54 ns |   5.350 ns |   5.004 ns | 13.07 |    0.24 | 0.0191 |     - |     - |      40 B |
|                           ForeachLoop |     0 |     21.85 ns |   0.108 ns |   0.090 ns |  1.00 |    0.00 | 0.0344 |     - |     - |      72 B |
|                                  Linq |     0 |     97.03 ns |   1.074 ns |   1.005 ns |  4.45 |    0.05 | 0.0764 |     - |     - |     160 B |
|                                LinqAF |     0 |    103.30 ns |   0.745 ns |   0.661 ns |  4.72 |    0.04 | 0.0497 |     - |     - |     104 B |
|                            StructLinq |     0 |    100.49 ns |   0.817 ns |   0.725 ns |  4.60 |    0.05 | 0.0726 |     - |     - |     152 B |
|                  StructLinq_IFunction |     0 |     70.50 ns |   0.459 ns |   0.429 ns |  3.23 |    0.03 | 0.0305 |     - |     - |      64 B |
|                             Hyperlinq |     0 |     61.60 ns |   0.701 ns |   0.655 ns |  2.82 |    0.03 | 0.0304 |     - |     - |      64 B |
|                   Hyperlinq_IFunction |     0 |     63.26 ns |   0.664 ns |   0.589 ns |  2.90 |    0.03 | 0.0304 |     - |     - |      64 B |
|                                       |       |              |            |            |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |    **10** |    **327.70 ns** |   **6.243 ns** |   **6.411 ns** |  **2.49** |    **0.06** | **0.0415** |     **-** |     **-** |      **88 B** |
|                       ValueLinq_Stack |    10 |    304.30 ns |   6.034 ns |   5.039 ns |  2.31 |    0.04 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Push |    10 |    535.47 ns |   7.276 ns |   6.806 ns |  4.07 |    0.07 | 0.0420 |     - |     - |      88 B |
|             ValueLinq_SharedPool_Pull |    10 |    410.07 ns |   7.850 ns |   7.343 ns |  3.12 |    0.06 | 0.0420 |     - |     - |      88 B |
|        ValueLinq_ValueLambda_Standard |    10 |    251.22 ns |   3.876 ns |   3.436 ns |  1.91 |    0.03 | 0.0415 |     - |     - |      88 B |
|           ValueLinq_ValueLambda_Stack |    10 |    208.15 ns |   4.014 ns |   3.754 ns |  1.58 |    0.03 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Push |    10 |    397.29 ns |   4.955 ns |   4.393 ns |  3.02 |    0.03 | 0.0420 |     - |     - |      88 B |
| ValueLinq_ValueLambda_SharedPool_Pull |    10 |    351.06 ns |   3.108 ns |   2.907 ns |  2.67 |    0.03 | 0.0420 |     - |     - |      88 B |
|                           ForeachLoop |    10 |    131.60 ns |   1.140 ns |   0.952 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|                                  Linq |    10 |    250.77 ns |   2.898 ns |   2.569 ns |  1.90 |    0.02 | 0.1450 |     - |     - |     304 B |
|                                LinqAF |    10 |    250.15 ns |   4.457 ns |   3.951 ns |  1.90 |    0.04 | 0.0873 |     - |     - |     184 B |
|                            StructLinq |    10 |    246.28 ns |   4.231 ns |   3.958 ns |  1.88 |    0.03 | 0.0839 |     - |     - |     176 B |
|                  StructLinq_IFunction |    10 |    168.05 ns |   2.369 ns |   2.216 ns |  1.28 |    0.02 | 0.0420 |     - |     - |      88 B |
|                             Hyperlinq |    10 |    224.91 ns |   4.058 ns |   3.796 ns |  1.71 |    0.03 | 0.0420 |     - |     - |      88 B |
|                   Hyperlinq_IFunction |    10 |    161.56 ns |   2.063 ns |   1.930 ns |  1.23 |    0.02 | 0.0420 |     - |     - |      88 B |
|                                       |       |              |            |            |       |         |        |       |       |           |
|                    **ValueLinq_Standard** |  **1000** | **11,925.08 ns** | **229.204 ns** | **298.030 ns** |  **1.94** |    **0.04** | **1.9836** |     **-** |     **-** |    **4168 B** |
|                       ValueLinq_Stack |  1000 | 12,113.17 ns | 235.206 ns | 321.953 ns |  1.97 |    0.06 | 1.9836 |     - |     - |    4168 B |
|             ValueLinq_SharedPool_Push |  1000 | 13,137.80 ns | 256.063 ns | 323.838 ns |  2.13 |    0.05 | 0.9766 |     - |     - |    2064 B |
|             ValueLinq_SharedPool_Pull |  1000 | 12,519.13 ns | 244.765 ns | 447.567 ns |  2.02 |    0.08 | 0.9766 |     - |     - |    2064 B |
|        ValueLinq_ValueLambda_Standard |  1000 |  7,266.12 ns | 137.579 ns | 141.284 ns |  1.17 |    0.03 | 1.9913 |     - |     - |    4168 B |
|           ValueLinq_ValueLambda_Stack |  1000 |  6,836.35 ns |  61.508 ns |  54.525 ns |  1.11 |    0.01 | 1.9913 |     - |     - |    4168 B |
| ValueLinq_ValueLambda_SharedPool_Push |  1000 |  8,213.32 ns | 141.482 ns | 173.752 ns |  1.33 |    0.04 | 0.9766 |     - |     - |    2064 B |
| ValueLinq_ValueLambda_SharedPool_Pull |  1000 |  7,650.22 ns | 134.092 ns | 125.430 ns |  1.24 |    0.02 | 0.9842 |     - |     - |    2064 B |
|                           ForeachLoop |  1000 |  6,175.80 ns |  51.514 ns |  48.186 ns |  1.00 |    0.00 | 3.0441 |     - |     - |    6368 B |
|                                  Linq |  1000 | 11,112.68 ns | 208.514 ns | 204.788 ns |  1.80 |    0.04 | 2.1820 |     - |     - |    4584 B |
|                                LinqAF |  1000 | 12,581.14 ns | 249.559 ns | 287.393 ns |  2.03 |    0.04 | 3.0212 |     - |     - |    6336 B |
|                            StructLinq |  1000 | 12,446.23 ns | 245.677 ns | 443.007 ns |  2.01 |    0.08 | 1.0223 |     - |     - |    2152 B |
|                  StructLinq_IFunction |  1000 |  9,300.01 ns | 183.983 ns | 204.497 ns |  1.51 |    0.04 | 0.9766 |     - |     - |    2064 B |
|                             Hyperlinq |  1000 | 13,478.19 ns | 268.254 ns | 497.226 ns |  2.20 |    0.09 | 0.9766 |     - |     - |    2064 B |
|                   Hyperlinq_IFunction |  1000 |  7,729.88 ns | 153.827 ns | 210.561 ns |  1.25 |    0.03 | 0.9766 |     - |     - |    2064 B |
