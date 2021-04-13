## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Start | Count |         Mean |      Error |      StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |------ |-------------:|-----------:|------------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5** | **.NET 5.0** |     **0** |    **10** |     **2.956 ns** |  **0.0316 ns** |   **0.0296 ns** |     **2.949 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |     0 |    10 |    74.957 ns |  0.4362 ns |   0.3866 ns |    74.854 ns | 25.37 |    0.31 | 0.0267 |     - |     - |      56 B |
|                 Linq | .NET 5 | .NET 5.0 |     0 |    10 |   105.013 ns |  0.5039 ns |   0.4467 ns |   104.977 ns | 35.54 |    0.45 | 0.0421 |     - |     - |      88 B |
|           LinqFaster | .NET 5 | .NET 5.0 |     0 |    10 |    39.944 ns |  0.8617 ns |   2.2397 ns |    39.076 ns | 14.83 |    0.60 | 0.0612 |     - |     - |     128 B |
|      LinqFaster_SIMD | .NET 5 | .NET 5.0 |     0 |    10 |    35.155 ns |  0.6360 ns |   1.0627 ns |    34.574 ns | 12.05 |    0.48 | 0.0612 |     - |     - |     128 B |
|               LinqAF | .NET 5 | .NET 5.0 |     0 |    10 |    79.206 ns |  0.3846 ns |   0.3597 ns |    79.066 ns | 26.80 |    0.32 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |     0 |    10 |    36.129 ns |  0.1333 ns |   0.1114 ns |    36.094 ns | 12.25 |    0.12 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |     0 |    10 |    26.256 ns |  0.0542 ns |   0.0480 ns |    26.252 ns |  8.89 |    0.10 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |     0 |    10 |    38.068 ns |  0.0942 ns |   0.0787 ns |    38.046 ns | 12.90 |    0.12 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |     0 |    10 |    32.867 ns |  0.1634 ns |   0.1529 ns |    32.805 ns | 11.12 |    0.12 |      - |     - |     - |         - |
|                      |        |          |       |       |              |            |             |              |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |     0 |    10 |     1.814 ns |  0.0317 ns |   0.0265 ns |     1.809 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |     0 |    10 |    43.918 ns |  0.1957 ns |   0.1830 ns |    43.928 ns | 24.21 |    0.39 | 0.0268 |     - |     - |      56 B |
|                 Linq | .NET 6 | .NET 6.0 |     0 |    10 |    80.093 ns |  0.4080 ns |   0.3407 ns |    80.046 ns | 44.16 |    0.67 | 0.0421 |     - |     - |      88 B |
|           LinqFaster | .NET 6 | .NET 6.0 |     0 |    10 |    42.246 ns |  0.3479 ns |   0.2905 ns |    42.223 ns | 23.29 |    0.42 | 0.0612 |     - |     - |     128 B |
|      LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |    10 |    54.830 ns |  1.1564 ns |   1.3317 ns |    55.322 ns | 30.48 |    0.92 | 0.0612 |     - |     - |     128 B |
|               LinqAF | .NET 6 | .NET 6.0 |     0 |    10 |    79.204 ns |  0.2166 ns |   0.1691 ns |    79.229 ns | 43.73 |    0.63 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |     0 |    10 |    34.889 ns |  0.1198 ns |   0.1000 ns |    34.921 ns | 19.24 |    0.30 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |     0 |    10 |    26.152 ns |  0.4287 ns |   0.3800 ns |    26.250 ns | 14.47 |    0.21 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |     0 |    10 |    37.491 ns |  0.1270 ns |   0.1126 ns |    37.479 ns | 20.67 |    0.33 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |     0 |    10 |    31.600 ns |  0.0675 ns |   0.0631 ns |    31.584 ns | 17.42 |    0.26 |      - |     - |     - |         - |
|                      |        |          |       |       |              |            |             |              |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5** | **.NET 5.0** |     **0** |  **1000** |   **346.467 ns** |  **1.5359 ns** |   **1.2825 ns** |   **346.970 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5 | .NET 5.0 |     0 |  1000 | 4,750.623 ns | 17.3401 ns |  16.2200 ns | 4,754.072 ns | 13.71 |    0.08 | 0.0229 |     - |     - |      56 B |
|                 Linq | .NET 5 | .NET 5.0 |     0 |  1000 | 6,319.831 ns | 23.3432 ns |  20.6931 ns | 6,321.104 ns | 18.25 |    0.09 | 0.0381 |     - |     - |      88 B |
|           LinqFaster | .NET 5 | .NET 5.0 |     0 |  1000 | 3,055.583 ns | 60.6252 ns | 150.9778 ns | 2,980.062 ns |  8.95 |    0.46 | 3.8452 |     - |     - |   8,048 B |
|      LinqFaster_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 | 1,383.718 ns | 27.6686 ns |  78.9401 ns | 1,343.954 ns |  4.21 |    0.26 | 3.8452 |     - |     - |   8,048 B |
|               LinqAF | .NET 5 | .NET 5.0 |     0 |  1000 | 4,898.222 ns | 24.8843 ns |  20.7795 ns | 4,893.707 ns | 14.14 |    0.07 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |     0 |  1000 | 1,854.365 ns | 11.4798 ns |  10.1765 ns | 1,851.888 ns |  5.36 |    0.03 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |     0 |  1000 | 1,445.358 ns |  3.3722 ns |   3.1543 ns | 1,444.889 ns |  4.17 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |     0 |  1000 | 1,589.384 ns |  3.2723 ns |   2.7325 ns | 1,589.568 ns |  4.59 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |     0 |  1000 | 1,453.451 ns |  2.7153 ns |   2.5399 ns | 1,452.317 ns |  4.19 |    0.01 |      - |     - |     - |         - |
|                      |        |          |       |       |              |            |             |              |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |     0 |  1000 |   355.316 ns |  1.2904 ns |   1.1439 ns |   355.393 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |     0 |  1000 | 2,897.965 ns | 10.5132 ns |   9.3197 ns | 2,896.139 ns |  8.16 |    0.04 | 0.0267 |     - |     - |      56 B |
|                 Linq | .NET 6 | .NET 6.0 |     0 |  1000 | 3,754.934 ns | 26.9258 ns |  22.4843 ns | 3,749.439 ns | 10.57 |    0.08 | 0.0420 |     - |     - |      88 B |
|           LinqFaster | .NET 6 | .NET 6.0 |     0 |  1000 | 3,504.276 ns | 69.3789 ns |  79.8968 ns | 3,478.027 ns |  9.92 |    0.26 | 3.8452 |     - |     - |   8,048 B |
|      LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 | 2,969.359 ns | 40.1890 ns |  37.5928 ns | 2,950.558 ns |  8.36 |    0.11 | 3.8452 |     - |     - |   8,048 B |
|               LinqAF | .NET 6 | .NET 6.0 |     0 |  1000 | 4,194.222 ns |  8.8044 ns |   7.3520 ns | 4,193.235 ns | 11.80 |    0.05 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |     0 |  1000 | 1,602.453 ns |  6.9107 ns |   5.7707 ns | 1,601.778 ns |  4.51 |    0.02 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |     0 |  1000 | 1,445.628 ns |  3.1016 ns |   2.5900 ns | 1,446.074 ns |  4.07 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |     0 |  1000 | 2,340.303 ns | 46.7189 ns | 122.2553 ns | 2,323.683 ns |  6.71 |    0.26 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |     0 |  1000 | 1,478.350 ns |  9.3237 ns |   8.2652 ns | 1,479.153 ns |  4.16 |    0.02 |      - |     - |     - |         - |
