## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|               Method |      Job |  Runtime | Skip | Count |          Mean |       Error |      StdDev |        Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |----- |------ |--------------:|------------:|------------:|--------------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |    **10** |      **8.117 ns** |   **0.0256 ns** |   **0.0200 ns** |      **8.118 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |    10 |  3,458.587 ns |  10.0121 ns |   8.8754 ns |  3,461.216 ns | 426.18 |    1.32 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 5.0 | .NET 5.0 | 1000 |    10 |    205.354 ns |   4.0301 ns |   6.0320 ns |    207.907 ns |  24.59 |    0.68 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |    10 |    135.805 ns |   0.7949 ns |   0.7047 ns |    135.672 ns |  16.75 |    0.07 | 0.1528 |     - |     - |     320 B |
|               LinqAF | .NET 5.0 | .NET 5.0 | 1000 |    10 |  4,582.015 ns |  27.2890 ns |  24.1910 ns |  4,576.587 ns | 564.96 |    3.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |     79.703 ns |   0.5091 ns |   0.4251 ns |     79.795 ns |   9.82 |    0.07 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |     39.939 ns |   0.1383 ns |   0.1154 ns |     39.946 ns |   4.92 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 | 1000 |    10 |     63.924 ns |   0.4404 ns |   0.3677 ns |     64.078 ns |   7.88 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |    10 |     60.878 ns |   0.1580 ns |   0.1233 ns |     60.925 ns |   7.50 |    0.03 |      - |     - |     - |         - |
|                      |          |          |      |       |               |             |             |               |        |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |     11.833 ns |   0.0822 ns |   0.0686 ns |     11.842 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |    10 |  3,703.837 ns |   8.3381 ns |   6.9627 ns |  3,702.282 ns | 313.03 |    2.07 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 | 1000 |    10 |    178.360 ns |   1.0926 ns |   0.9124 ns |    178.073 ns |  15.07 |    0.11 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |    10 |    131.127 ns |   1.1455 ns |   1.0155 ns |    131.318 ns |  11.09 |    0.12 | 0.1528 |     - |     - |     320 B |
|               LinqAF | .NET 6.0 | .NET 6.0 | 1000 |    10 |  4,986.211 ns |  23.5850 ns |  20.9074 ns |  4,983.686 ns | 421.15 |    2.70 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |     76.130 ns |   0.6221 ns |   0.8089 ns |     75.935 ns |   6.42 |    0.07 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |     39.209 ns |   0.1590 ns |   0.1328 ns |     39.166 ns |   3.31 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 | 1000 |    10 |     63.835 ns |   0.2168 ns |   0.2028 ns |     63.784 ns |   5.40 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |    10 |     56.743 ns |   0.1346 ns |   0.1124 ns |     56.809 ns |   4.80 |    0.03 |      - |     - |     - |         - |
|                      |          |          |      |       |               |             |             |               |        |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** | **1000** |  **1000** |  **1,332.780 ns** |   **9.3281 ns** |   **7.2827 ns** |  **1,331.097 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  6,925.463 ns |  67.8656 ns |  60.1611 ns |  6,908.910 ns |   5.20 |    0.05 | 0.0153 |     - |     - |      40 B |
|                 Linq | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 15,273.601 ns |  89.3357 ns |  69.7475 ns | 15,257.246 ns |  11.46 |    0.08 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 10,716.541 ns | 212.9408 ns | 476.2725 ns | 10,547.484 ns |   7.90 |    0.31 | 5.9204 |     - |     - |  12,416 B |
|               LinqAF | .NET 5.0 | .NET 5.0 | 1000 |  1000 | 20,176.985 ns |  64.7684 ns |  57.4155 ns | 20,181.705 ns |  15.15 |    0.09 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  6,129.100 ns |  19.4512 ns |  16.2426 ns |  6,126.115 ns |   4.60 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  1,775.935 ns |   9.9726 ns |   8.3276 ns |  1,776.904 ns |   1.33 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  5,045.936 ns |  32.3245 ns |  28.6548 ns |  5,045.028 ns |   3.79 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 | 1000 |  1000 |  2,087.638 ns |  10.4043 ns |   8.6881 ns |  2,085.735 ns |   1.57 |    0.01 |      - |     - |     - |         - |
|                      |          |          |      |       |               |             |             |               |        |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  1,202.023 ns |   4.8889 ns |   3.8169 ns |  1,203.491 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  6,697.593 ns |  24.6417 ns |  21.8442 ns |  6,695.732 ns |   5.57 |    0.03 | 0.0153 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 15,399.856 ns |  63.8368 ns |  56.5896 ns | 15,387.712 ns |  12.82 |    0.06 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  8,264.312 ns |  46.9231 ns |  41.5961 ns |  8,258.009 ns |   6.88 |    0.03 | 5.9204 |     - |     - |  12,416 B |
|               LinqAF | .NET 6.0 | .NET 6.0 | 1000 |  1000 | 20,225.546 ns |  48.5644 ns |  43.0511 ns | 20,228.661 ns |  16.82 |    0.08 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  5,273.857 ns |  11.7578 ns |   9.8183 ns |  5,276.473 ns |   4.39 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  1,503.852 ns |   5.9023 ns |   5.2322 ns |  1,504.787 ns |   1.25 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  5,005.236 ns |  12.9619 ns |  10.8238 ns |  5,004.096 ns |   4.16 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 | 1000 |  1000 |  2,064.970 ns |   6.1966 ns |   5.1745 ns |  2,065.678 ns |   1.72 |    0.01 |      - |     - |     - |         - |
