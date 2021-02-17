## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|                    Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |     **0** |    **39.307 ns** |  **0.1596 ns** |  **0.1493 ns** |  **7.25** |    **0.07** | **0.0152** |     **-** |     **-** |      **32 B** |
|           ValueLinq_Stack |     0 |     0 |    40.595 ns |  0.1464 ns |  0.1222 ns |  7.48 |    0.07 | 0.0153 |     - |     - |      32 B |
| ValueLinq_SharedPool_Push |     0 |     0 |   112.819 ns |  0.3439 ns |  0.2872 ns | 20.79 |    0.22 | 0.0153 |     - |     - |      32 B |
| ValueLinq_SharedPool_Pull |     0 |     0 |   145.119 ns |  0.5007 ns |  0.4438 ns | 26.76 |    0.28 | 0.0153 |     - |     - |      32 B |
|                   ForLoop |     0 |     0 |     5.423 ns |  0.0544 ns |  0.0482 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|               ForeachLoop |     0 |     0 |    30.304 ns |  0.3532 ns |  0.3131 ns |  5.59 |    0.08 | 0.0421 |     - |     - |      88 B |
|                      Linq |     0 |     0 |     9.778 ns |  0.0747 ns |  0.0624 ns |  1.80 |    0.02 | 0.0153 |     - |     - |      32 B |
|                LinqFaster |     0 |     0 |    19.288 ns |  0.0821 ns |  0.0728 ns |  3.56 |    0.03 | 0.0268 |     - |     - |      56 B |
|                    LinqAF |     0 |     0 |    32.686 ns |  0.1798 ns |  0.1681 ns |  6.03 |    0.06 | 0.0152 |     - |     - |      32 B |
|                StructLinq |     0 |     0 |    12.878 ns |  0.1595 ns |  0.1332 ns |  2.37 |    0.03 | 0.0267 |     - |     - |      56 B |
|                 Hyperlinq |     0 |     0 |    11.037 ns |  0.0711 ns |  0.0594 ns |  2.03 |    0.02 | 0.0153 |     - |     - |      32 B |
|                           |       |       |              |            |            |       |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |    **10** |    **73.269 ns** |  **0.4413 ns** |  **0.3685 ns** |  **0.99** |    **0.01** | **0.0459** |     **-** |     **-** |      **96 B** |
|           ValueLinq_Stack |     0 |    10 |    69.973 ns |  0.4081 ns |  0.3817 ns |  0.95 |    0.01 | 0.0459 |     - |     - |      96 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   179.594 ns |  0.6776 ns |  0.6338 ns |  2.43 |    0.01 | 0.0458 |     - |     - |      96 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   184.705 ns |  0.6370 ns |  0.5959 ns |  2.50 |    0.01 | 0.0458 |     - |     - |      96 B |
|                   ForLoop |     0 |    10 |    73.844 ns |  0.3967 ns |  0.3517 ns |  1.00 |    0.00 | 0.1032 |     - |     - |     216 B |
|               ForeachLoop |     0 |    10 |   125.463 ns |  0.6617 ns |  0.5866 ns |  1.70 |    0.01 | 0.1299 |     - |     - |     272 B |
|                      Linq |     0 |    10 |    41.834 ns |  0.5406 ns |  0.4514 ns |  0.57 |    0.01 | 0.0650 |     - |     - |     136 B |
|                LinqFaster |     0 |    10 |    38.499 ns |  0.2478 ns |  0.2197 ns |  0.52 |    0.00 | 0.0764 |     - |     - |     160 B |
|                    LinqAF |     0 |    10 |    61.335 ns |  1.1467 ns |  1.0727 ns |  0.83 |    0.02 | 0.0459 |     - |     - |      96 B |
|                StructLinq |     0 |    10 |    19.677 ns |  0.1446 ns |  0.1129 ns |  0.27 |    0.00 | 0.0459 |     - |     - |      96 B |
|                 Hyperlinq |     0 |    10 |    29.255 ns |  0.1909 ns |  0.1786 ns |  0.40 |    0.00 | 0.0459 |     - |     - |      96 B |
|                           |       |       |              |            |            |       |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **2,023.559 ns** |  **6.7416 ns** |  **5.2634 ns** |  **0.99** |    **0.01** | **1.9379** |     **-** |     **-** |    **4056 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,432.939 ns | 12.6908 ns | 10.5974 ns |  1.19 |    0.01 | 3.9330 |     - |     - |    8232 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,370.794 ns | 14.0824 ns | 10.9946 ns |  1.16 |    0.01 | 1.9379 |     - |     - |    4056 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,286.654 ns |  7.9038 ns |  7.0065 ns |  1.12 |    0.01 | 1.9379 |     - |     - |    4056 B |
|                   ForLoop |     0 |  1000 | 2,047.259 ns | 13.8773 ns | 12.3019 ns |  1.00 |    0.00 | 4.0207 |     - |     - |    8424 B |
|               ForeachLoop |     0 |  1000 | 6,109.025 ns | 24.0305 ns | 21.3024 ns |  2.98 |    0.02 | 4.0436 |     - |     - |    8480 B |
|                      Linq |     0 |  1000 | 1,769.718 ns | 10.7044 ns | 10.0129 ns |  0.86 |    0.01 | 1.9569 |     - |     - |    4096 B |
|                LinqFaster |     0 |  1000 |   831.806 ns |  3.0920 ns |  2.7410 ns |  0.41 |    0.00 | 3.8605 |     - |     - |    8080 B |
|                    LinqAF |     0 |  1000 | 2,373.108 ns | 14.9660 ns | 13.9992 ns |  1.16 |    0.01 | 1.9379 |     - |     - |    4056 B |
|                StructLinq |     0 |  1000 |   706.494 ns |  4.1641 ns |  3.4772 ns |  0.34 |    0.00 | 1.9379 |     - |     - |    4056 B |
|                 Hyperlinq |     0 |  1000 |   297.821 ns |  2.0490 ns |  1.9166 ns |  0.15 |    0.00 | 1.9379 |     - |     - |    4056 B |
