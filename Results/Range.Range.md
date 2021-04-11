## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|          Method |      Job |  Runtime | Start | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |--------- |--------- |------ |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|         **ForLoop** | **.NET 5.0** | **.NET 5.0** |     **0** |    **10** |     **3.203 ns** |  **0.0293 ns** |  **0.0244 ns** |     **3.198 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop | .NET 5.0 | .NET 5.0 |     0 |    10 |    63.844 ns |  0.3042 ns |  0.2845 ns |    63.721 ns | 19.95 |    0.17 | 0.0267 |     - |     - |      56 B |
|            Linq | .NET 5.0 | .NET 5.0 |     0 |    10 |    61.346 ns |  0.3945 ns |  0.3497 ns |    61.209 ns | 19.14 |    0.20 | 0.0191 |     - |     - |      40 B |
|      LinqFaster | .NET 5.0 | .NET 5.0 |     0 |    10 |    15.422 ns |  0.3334 ns |  0.4886 ns |    15.562 ns |  4.74 |    0.20 | 0.0306 |     - |     - |      64 B |
| LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |     0 |    10 |    20.873 ns |  0.2302 ns |  0.1922 ns |    20.805 ns |  6.52 |    0.08 | 0.0306 |     - |     - |      64 B |
|          LinqAF | .NET 5.0 | .NET 5.0 |     0 |    10 |    31.044 ns |  0.1719 ns |  0.1435 ns |    31.050 ns |  9.69 |    0.08 |      - |     - |     - |         - |
|      StructLinq | .NET 5.0 | .NET 5.0 |     0 |    10 |     3.570 ns |  0.0370 ns |  0.0328 ns |     3.567 ns |  1.11 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq | .NET 5.0 | .NET 5.0 |     0 |    10 |    11.740 ns |  0.0272 ns |  0.0241 ns |    11.745 ns |  3.66 |    0.03 |      - |     - |     - |         - |
|                 |          |          |       |       |              |            |            |              |       |         |        |       |       |           |
|         ForLoop | .NET 6.0 | .NET 6.0 |     0 |    10 |     3.532 ns |  0.0332 ns |  0.0295 ns |     3.521 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop | .NET 6.0 | .NET 6.0 |     0 |    10 |    60.406 ns |  1.2394 ns |  2.4753 ns |    58.962 ns | 18.12 |    0.43 | 0.0267 |     - |     - |      56 B |
|            Linq | .NET 6.0 | .NET 6.0 |     0 |    10 |    53.098 ns |  0.1589 ns |  0.1486 ns |    53.100 ns | 15.04 |    0.13 | 0.0191 |     - |     - |      40 B |
|      LinqFaster | .NET 6.0 | .NET 6.0 |     0 |    10 |    14.648 ns |  0.3206 ns |  0.8990 ns |    14.369 ns |  3.97 |    0.11 | 0.0306 |     - |     - |      64 B |
| LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |     0 |    10 |    18.311 ns |  0.1333 ns |  0.1041 ns |    18.320 ns |  5.19 |    0.06 | 0.0306 |     - |     - |      64 B |
|          LinqAF | .NET 6.0 | .NET 6.0 |     0 |    10 |    31.898 ns |  0.1268 ns |  0.1186 ns |    31.949 ns |  9.03 |    0.07 |      - |     - |     - |         - |
|      StructLinq | .NET 6.0 | .NET 6.0 |     0 |    10 |     3.714 ns |  0.0341 ns |  0.0285 ns |     3.714 ns |  1.05 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq | .NET 6.0 | .NET 6.0 |     0 |    10 |    11.712 ns |  0.1229 ns |  0.1149 ns |    11.672 ns |  3.31 |    0.03 |      - |     - |     - |         - |
|                 |          |          |       |       |              |            |            |              |       |         |        |       |       |           |
|         **ForLoop** | **.NET 5.0** | **.NET 5.0** |     **0** |  **1000** |   **271.487 ns** |  **1.5552 ns** |  **1.3786 ns** |   **271.446 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop | .NET 5.0 | .NET 5.0 |     0 |  1000 | 4,730.935 ns | 22.9467 ns | 20.3417 ns | 4,723.084 ns | 17.43 |    0.13 | 0.0229 |     - |     - |      56 B |
|            Linq | .NET 5.0 | .NET 5.0 |     0 |  1000 | 4,228.412 ns | 33.6716 ns | 28.1173 ns | 4,217.122 ns | 15.58 |    0.16 | 0.0153 |     - |     - |      40 B |
|      LinqFaster | .NET 5.0 | .NET 5.0 |     0 |  1000 | 1,404.604 ns |  9.5934 ns |  8.5043 ns | 1,404.600 ns |  5.17 |    0.04 | 1.9226 |     - |     - |   4,024 B |
| LinqFaster_SIMD | .NET 5.0 | .NET 5.0 |     0 |  1000 |   867.355 ns |  8.2201 ns |  7.6891 ns |   870.113 ns |  3.20 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|          LinqAF | .NET 5.0 | .NET 5.0 |     0 |  1000 | 1,850.337 ns |  9.3798 ns |  7.8326 ns | 1,850.417 ns |  6.82 |    0.06 |      - |     - |     - |         - |
|      StructLinq | .NET 5.0 | .NET 5.0 |     0 |  1000 |   271.776 ns |  1.7020 ns |  1.5088 ns |   271.590 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq | .NET 5.0 | .NET 5.0 |     0 |  1000 |   534.125 ns |  2.4985 ns |  2.3371 ns |   534.515 ns |  1.97 |    0.01 |      - |     - |     - |         - |
|                 |          |          |       |       |              |            |            |              |       |         |        |       |       |           |
|         ForLoop | .NET 6.0 | .NET 6.0 |     0 |  1000 |   269.654 ns |  1.4006 ns |  1.2416 ns |   269.529 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop | .NET 6.0 | .NET 6.0 |     0 |  1000 | 4,290.848 ns | 23.1421 ns | 20.5149 ns | 4,294.378 ns | 15.91 |    0.09 | 0.0229 |     - |     - |      56 B |
|            Linq | .NET 6.0 | .NET 6.0 |     0 |  1000 | 3,953.154 ns | 12.9303 ns | 11.4623 ns | 3,953.535 ns | 14.66 |    0.07 | 0.0153 |     - |     - |      40 B |
|      LinqFaster | .NET 6.0 | .NET 6.0 |     0 |  1000 | 1,388.564 ns | 26.9545 ns | 35.0485 ns | 1,395.286 ns |  5.12 |    0.15 | 1.9226 |     - |     - |   4,024 B |
| LinqFaster_SIMD | .NET 6.0 | .NET 6.0 |     0 |  1000 |   893.185 ns | 17.2150 ns | 16.1030 ns |   886.449 ns |  3.32 |    0.07 | 1.9226 |     - |     - |   4,024 B |
|          LinqAF | .NET 6.0 | .NET 6.0 |     0 |  1000 | 1,584.376 ns |  5.1726 ns |  4.3194 ns | 1,582.360 ns |  5.87 |    0.04 |      - |     - |     - |         - |
|      StructLinq | .NET 6.0 | .NET 6.0 |     0 |  1000 |   271.360 ns |  1.6126 ns |  1.4295 ns |   271.256 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq | .NET 6.0 | .NET 6.0 |     0 |  1000 |   305.129 ns |  1.8461 ns |  1.6365 ns |   304.920 ns |  1.13 |    0.01 |      - |     - |     - |         - |
