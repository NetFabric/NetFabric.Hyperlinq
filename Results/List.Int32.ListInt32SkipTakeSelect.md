## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-preview.5.23303.2
  [Host] : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 6 : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 8 : .NET 8.0.0 (8.0.23.28008), X64 RyuJIT AVX2


```
|                   Method |    Job |  Runtime | Skip | Count |        Mean |      Error |     StdDev |      Median |          Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |----- |------ |------------:|-----------:|-----------:|------------:|---------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 | 1000 |   100 |    70.76 ns |   0.422 ns |   0.330 ns |    70.72 ns |       baseline |         |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 | 1000 |   100 |   907.91 ns |   6.472 ns |   5.053 ns |   907.34 ns |  12.83x slower |   0.08x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 | 1000 |   100 |   842.17 ns |  19.627 ns |  56.315 ns |   810.77 ns |  12.10x slower |   0.97x | 0.6533 |    1368 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 | 1000 |   100 |   949.39 ns |  18.673 ns |  17.467 ns |   942.90 ns |  13.46x slower |   0.26x | 2.5311 |    5304 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 | 1000 |   100 | 3,828.64 ns |  86.175 ns | 248.635 ns | 3,672.97 ns |  54.55x slower |   3.45x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |   100 | 9,068.42 ns | 156.797 ns | 334.146 ns | 8,943.66 ns | 127.74x slower |   3.78x | 4.2419 |    8906 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 | 1000 |   100 | 7,596.75 ns |  43.047 ns |  35.946 ns | 7,594.22 ns | 107.41x slower |   0.54x | 0.4425 |     936 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 | 1000 |   100 |   264.43 ns |   2.340 ns |   1.827 ns |   263.97 ns |   3.74x slower |   0.03x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |   168.98 ns |   3.327 ns |   2.949 ns |   167.74 ns |   2.38x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 | 1000 |   100 |   228.09 ns |   4.549 ns |   3.552 ns |   226.45 ns |   3.22x slower |   0.06x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |   202.19 ns |   3.189 ns |   2.827 ns |   201.14 ns |   2.86x slower |   0.05x |      - |         - |          NA |
|                          |        |          |      |       |             |            |            |             |                |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 | 1000 |   100 |    70.61 ns |   0.442 ns |   0.369 ns |    70.48 ns |       baseline |         |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 | 1000 |   100 |   419.47 ns |  10.246 ns |  29.067 ns |   401.42 ns |   5.91x slower |   0.41x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 | 1000 |   100 |   764.66 ns |  14.828 ns |  20.296 ns |   754.56 ns |  10.87x slower |   0.36x | 0.6533 |    1368 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 | 1000 |   100 |   683.86 ns |  13.993 ns |  39.469 ns |   667.97 ns |   9.81x slower |   0.65x | 2.5311 |    5304 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 | 1000 |   100 | 2,647.54 ns |  13.038 ns |  10.887 ns | 2,648.37 ns |  37.49x slower |   0.22x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 | 1000 |   100 | 8,992.42 ns | 101.398 ns |  79.165 ns | 8,974.85 ns | 127.29x slower |   1.26x | 4.2419 |    8905 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 | 1000 |   100 | 5,674.26 ns | 128.133 ns | 375.792 ns | 5,453.53 ns |  82.67x slower |   5.97x | 0.4425 |     936 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 | 1000 |   100 |   222.21 ns |   1.090 ns |   0.911 ns |   222.09 ns |   3.15x slower |   0.02x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |   148.69 ns |   0.731 ns |   0.648 ns |   148.50 ns |   2.11x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 | 1000 |   100 |   183.19 ns |   3.673 ns |   9.611 ns |   178.24 ns |   2.62x slower |   0.17x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |   154.89 ns |   2.444 ns |   3.262 ns |   153.49 ns |   2.20x slower |   0.05x |      - |         - |          NA |
