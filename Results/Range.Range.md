## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|          Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|         **ForLoop** |     **0** |    **10** |     **3.198 ns** |  **0.0114 ns** |  **0.0106 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |    10 |    67.251 ns |  0.3168 ns |  0.2963 ns | 21.03 |    0.12 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |    10 |    62.737 ns |  0.2138 ns |  0.2000 ns | 19.62 |    0.10 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |    10 |    13.866 ns |  0.0922 ns |  0.0817 ns |  4.34 |    0.02 | 0.0306 |     - |     - |      64 B |
| LinqFaster_SIMD |     0 |    10 |    19.119 ns |  0.0665 ns |  0.0589 ns |  5.98 |    0.03 | 0.0306 |     - |     - |      64 B |
|          LinqAF |     0 |    10 |    31.363 ns |  0.0741 ns |  0.0619 ns |  9.81 |    0.04 |      - |     - |     - |         - |
|      StructLinq |     0 |    10 |     3.893 ns |  0.0171 ns |  0.0151 ns |  1.22 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |    10 |    10.307 ns |  0.0419 ns |  0.0392 ns |  3.22 |    0.02 |      - |     - |     - |         - |
|                 |       |       |              |            |            |       |         |        |       |       |           |
|         **ForLoop** |     **0** |  **1000** |   **274.970 ns** |  **1.5924 ns** |  **1.4116 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |  1000 | 4,801.886 ns |  9.2986 ns |  8.2430 ns | 17.46 |    0.09 | 0.0229 |     - |     - |      56 B |
|            Linq |     0 |  1000 | 4,040.062 ns | 16.4195 ns | 14.5554 ns | 14.69 |    0.09 | 0.0153 |     - |     - |      40 B |
|      LinqFaster |     0 |  1000 | 1,154.738 ns |  6.9981 ns |  6.2036 ns |  4.20 |    0.02 | 1.9226 |     - |     - |   4,024 B |
| LinqFaster_SIMD |     0 |  1000 |   804.716 ns |  3.7220 ns |  3.2995 ns |  2.93 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|          LinqAF |     0 |  1000 | 2,044.331 ns |  8.5357 ns |  7.1277 ns |  7.43 |    0.04 |      - |     - |     - |         - |
|      StructLinq |     0 |  1000 |   275.100 ns |  0.8749 ns |  0.7755 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq |     0 |  1000 |   287.489 ns |  1.5567 ns |  1.2999 ns |  1.05 |    0.01 |      - |     - |     - |         - |
