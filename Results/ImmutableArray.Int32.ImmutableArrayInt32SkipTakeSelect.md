## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|                      Method |      Job |  Runtime | Skip | Count |          Mean |      Error |     StdDev |        Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |--------- |--------- |----- |------ |--------------:|-----------:|-----------:|--------------:|-------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |    **10** |      **5.677 ns** |  **0.0374 ns** |  **0.0312 ns** |      **5.681 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |    10 |  2,147.996 ns | 10.3883 ns |  9.2089 ns |  2,147.220 ns | 378.24 |    2.73 | 0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    243.613 ns |  2.1531 ns |  1.7980 ns |    243.094 ns |  42.91 |    0.35 | 0.0839 |     - |     - |     176 B |
|                  StructLinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |     88.247 ns |  1.7666 ns |  3.1402 ns |     86.408 ns |  16.20 |    0.49 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |     44.913 ns |  0.1260 ns |  0.1179 ns |     44.906 ns |   7.91 |    0.05 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 | 1000 |    10 |     59.589 ns |  0.2066 ns |  0.1725 ns |     59.588 ns |  10.50 |    0.05 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |     60.519 ns |  0.1966 ns |  0.1839 ns |     60.512 ns |  10.65 |    0.06 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 | 1000 |    10 |     48.108 ns |  0.1352 ns |  0.1199 ns |     48.076 ns |   8.47 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |     44.537 ns |  0.1302 ns |  0.1154 ns |     44.543 ns |   7.84 |    0.06 |      - |     - |     - |         - |
|                             |          |          |      |       |               |            |            |               |        |         |        |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |      7.679 ns |  0.0284 ns |  0.0266 ns |      7.668 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |  2,419.445 ns |  9.9207 ns |  9.2798 ns |  2,417.720 ns | 315.08 |    1.94 | 0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    190.761 ns |  0.8155 ns |  0.7229 ns |    190.679 ns |  24.84 |    0.15 | 0.0842 |     - |     - |     176 B |
|                  StructLinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |     73.376 ns |  0.3084 ns |  0.2408 ns |     73.385 ns |   9.56 |    0.05 | 0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |     36.268 ns |  0.1632 ns |  0.1362 ns |     36.250 ns |   4.72 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 | 1000 |    10 |     59.914 ns |  0.1984 ns |  0.1856 ns |     59.884 ns |   7.80 |    0.04 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |     59.591 ns |  0.1674 ns |  0.1484 ns |     59.596 ns |   7.76 |    0.03 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 | 1000 |    10 |     48.744 ns |  0.4351 ns |  0.3633 ns |     48.707 ns |   6.35 |    0.05 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |     44.597 ns |  0.3843 ns |  0.3595 ns |     44.614 ns |   5.81 |    0.05 |      - |     - |     - |         - |
|                             |          |          |      |       |               |            |            |               |        |         |        |       |       |           |
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |  **1000** |    **603.798 ns** |  **2.9321 ns** |  **2.4484 ns** |    **603.539 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  4,742.060 ns | 16.9222 ns | 15.0011 ns |  4,742.816 ns |   7.85 |    0.04 | 0.0153 |     - |     - |      32 B |
|                        Linq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 14,341.046 ns | 80.1349 ns | 66.9163 ns | 14,329.784 ns |  23.75 |    0.15 | 0.0763 |     - |     - |     176 B |
|                  StructLinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  2,974.940 ns | 16.9480 ns | 14.1523 ns |  2,970.691 ns |   4.93 |    0.04 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  2,088.421 ns |  8.9859 ns |  7.9657 ns |  2,087.417 ns |   3.46 |    0.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  1,870.809 ns |  6.3931 ns |  4.9913 ns |  1,872.568 ns |   3.10 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  1,753.127 ns | 14.3853 ns | 13.4560 ns |  1,756.219 ns |   2.90 |    0.03 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  2,136.669 ns | 17.5654 ns | 15.5713 ns |  2,136.008 ns |   3.54 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  1,586.807 ns |  4.0876 ns |  3.8235 ns |  1,587.192 ns |   2.63 |    0.01 |      - |     - |     - |         - |
|                             |          |          |      |       |               |            |            |               |        |         |        |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |    786.370 ns |  1.9358 ns |  1.7160 ns |    786.306 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  4,512.703 ns | 17.5014 ns | 16.3708 ns |  4,514.697 ns |   5.74 |    0.03 | 0.0153 |     - |     - |      32 B |
|                        Linq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 11,102.346 ns | 29.9502 ns | 28.0154 ns | 11,097.552 ns |  14.12 |    0.06 | 0.0763 |     - |     - |     176 B |
|                  StructLinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  1,910.333 ns |  5.3264 ns |  4.7217 ns |  1,910.888 ns |   2.43 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  1,538.299 ns |  5.7260 ns |  5.0759 ns |  1,538.730 ns |   1.96 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  2,130.006 ns |  5.9614 ns |  5.2846 ns |  2,129.174 ns |   2.71 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  1,697.480 ns |  4.0347 ns |  3.7741 ns |  1,698.204 ns |   2.16 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  2,134.402 ns | 10.0341 ns |  8.8949 ns |  2,136.461 ns |   2.71 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  1,336.455 ns |  7.9992 ns |  7.0911 ns |  1,334.969 ns |   1.70 |    0.01 |      - |     - |     - |         - |
