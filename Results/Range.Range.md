## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

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
|         **ForLoop** |     **0** |    **10** |     **3.454 ns** |  **0.0207 ns** |  **0.0173 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |    10 |    71.140 ns |  0.3840 ns |  0.2998 ns | 20.59 |    0.11 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |    10 |    64.726 ns |  0.8301 ns |  0.6932 ns | 18.74 |    0.20 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |    10 |    15.320 ns |  0.1475 ns |  0.1307 ns |  4.44 |    0.05 | 0.0306 |     - |     - |      64 B |
| LinqFaster_SIMD |     0 |    10 |    19.941 ns |  0.1194 ns |  0.0997 ns |  5.77 |    0.04 | 0.0306 |     - |     - |      64 B |
|          LinqAF |     0 |    10 |    31.619 ns |  0.1394 ns |  0.1236 ns |  9.15 |    0.05 |      - |     - |     - |         - |
|      StructLinq |     0 |    10 |     3.934 ns |  0.0271 ns |  0.0240 ns |  1.14 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |    10 |    10.403 ns |  0.0417 ns |  0.0369 ns |  3.01 |    0.01 |      - |     - |     - |         - |
|                 |       |       |              |            |            |       |         |        |       |       |           |
|         **ForLoop** |     **0** |  **1000** |   **276.819 ns** |  **1.5638 ns** |  **1.3058 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |  1000 | 4,851.060 ns | 29.8266 ns | 24.9066 ns | 17.52 |    0.15 | 0.0229 |     - |     - |      56 B |
|            Linq |     0 |  1000 | 4,086.701 ns | 40.3178 ns | 35.7406 ns | 14.76 |    0.17 | 0.0153 |     - |     - |      40 B |
|      LinqFaster |     0 |  1000 | 1,262.223 ns |  6.8994 ns |  6.1162 ns |  4.56 |    0.03 | 1.9226 |     - |     - |   4,024 B |
| LinqFaster_SIMD |     0 |  1000 |   916.979 ns |  8.1031 ns |  7.5796 ns |  3.32 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|          LinqAF |     0 |  1000 | 2,160.134 ns | 15.5369 ns | 13.7730 ns |  7.80 |    0.07 |      - |     - |     - |         - |
|      StructLinq |     0 |  1000 |   278.132 ns |  1.2193 ns |  1.0182 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |  1000 |   546.345 ns |  3.8961 ns |  3.4538 ns |  1.97 |    0.02 |      - |     - |     - |         - |
