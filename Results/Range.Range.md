## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|          Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|         **ForLoop** |     **0** |    **10** |     **3.115 ns** |  **0.0126 ns** |  **0.0105 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |    10 |    67.328 ns |  0.2093 ns |  0.1748 ns | 21.61 |    0.09 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |    10 |    61.058 ns |  0.2844 ns |  0.2375 ns | 19.60 |    0.12 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |    10 |    13.190 ns |  0.0317 ns |  0.0247 ns |  4.23 |    0.01 | 0.0306 |     - |     - |      64 B |
| LinqFaster_SIMD |     0 |    10 |    18.501 ns |  0.0803 ns |  0.0751 ns |  5.94 |    0.04 | 0.0306 |     - |     - |      64 B |
|          LinqAF |     0 |    10 |    30.534 ns |  0.0589 ns |  0.0492 ns |  9.80 |    0.04 |      - |     - |     - |         - |
|      StructLinq |     0 |    10 |     3.782 ns |  0.0200 ns |  0.0177 ns |  1.21 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |    10 |    10.108 ns |  0.0334 ns |  0.0297 ns |  3.25 |    0.01 |      - |     - |     - |         - |
|                 |       |       |              |            |            |       |         |        |       |       |           |
|         **ForLoop** |     **0** |  **1000** |   **266.951 ns** |  **0.9930 ns** |  **0.8292 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |  1000 | 4,451.017 ns | 20.1729 ns | 16.8453 ns | 16.67 |    0.09 | 0.0229 |     - |     - |      56 B |
|            Linq |     0 |  1000 | 3,922.246 ns |  9.2125 ns |  8.1667 ns | 14.69 |    0.05 | 0.0153 |     - |     - |      40 B |
|      LinqFaster |     0 |  1000 | 1,123.105 ns |  4.4854 ns |  3.9762 ns |  4.21 |    0.02 | 1.9226 |     - |     - |   4,024 B |
| LinqFaster_SIMD |     0 |  1000 |   784.653 ns |  6.7677 ns |  5.9994 ns |  2.94 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|          LinqAF |     0 |  1000 | 2,081.921 ns |  7.8099 ns |  6.9233 ns |  7.80 |    0.03 |      - |     - |     - |         - |
|      StructLinq |     0 |  1000 |   266.875 ns |  1.2651 ns |  1.1215 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq |     0 |  1000 |   526.555 ns |  1.4132 ns |  1.2528 ns |  1.97 |    0.01 |      - |     - |     - |         - |
