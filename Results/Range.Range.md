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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|          Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|         **ForLoop** |     **0** |    **10** |     **3.128 ns** |  **0.0152 ns** |  **0.0134 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |    10 |    67.255 ns |  0.2076 ns |  0.1942 ns | 21.50 |    0.11 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |    10 |    67.973 ns |  0.3360 ns |  0.2979 ns | 21.73 |    0.14 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |    10 |    13.346 ns |  0.0442 ns |  0.0345 ns |  4.27 |    0.01 | 0.0306 |     - |     - |      64 B |
| LinqFaster_SIMD |     0 |    10 |    18.503 ns |  0.0549 ns |  0.0459 ns |  5.91 |    0.02 | 0.0306 |     - |     - |      64 B |
|          LinqAF |     0 |    10 |    30.674 ns |  0.0828 ns |  0.0734 ns |  9.81 |    0.04 |      - |     - |     - |         - |
|      StructLinq |     0 |    10 |     3.795 ns |  0.0173 ns |  0.0144 ns |  1.21 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |    10 |    10.098 ns |  0.0279 ns |  0.0261 ns |  3.23 |    0.02 |      - |     - |     - |         - |
|                 |       |       |              |            |            |       |         |        |       |       |           |
|         **ForLoop** |     **0** |  **1000** |   **267.465 ns** |  **0.6029 ns** |  **0.5639 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |  1000 | 4,699.512 ns | 16.2084 ns | 15.1614 ns | 17.57 |    0.08 | 0.0229 |     - |     - |      56 B |
|            Linq |     0 |  1000 | 3,954.313 ns |  9.2884 ns |  8.6884 ns | 14.78 |    0.04 | 0.0153 |     - |     - |      40 B |
|      LinqFaster |     0 |  1000 | 1,127.657 ns |  4.0818 ns |  3.6184 ns |  4.22 |    0.02 | 1.9226 |     - |     - |   4,024 B |
| LinqFaster_SIMD |     0 |  1000 |   786.253 ns |  5.1074 ns |  4.5276 ns |  2.94 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|          LinqAF |     0 |  1000 | 2,090.420 ns |  5.7701 ns |  5.3973 ns |  7.82 |    0.02 |      - |     - |     - |         - |
|      StructLinq |     0 |  1000 |   268.654 ns |  1.4542 ns |  1.2891 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |  1000 |   279.741 ns |  1.0963 ns |  1.0255 ns |  1.05 |    0.00 |      - |     - |     - |         - |
