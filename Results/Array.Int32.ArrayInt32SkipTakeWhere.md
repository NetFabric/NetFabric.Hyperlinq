## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|                   Method |    Job |  Runtime | Skip | Count |        Mean |      Error |       StdDev |      Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |----- |------ |------------:|-----------:|-------------:|------------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 | 1000 |   100 |    98.09 ns |   1.988 ns |     4.150 ns |    95.75 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 | 1000 |   100 | 1,495.65 ns |   8.722 ns |     6.810 ns | 1,494.51 ns | 14.92x slower |   0.66x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 | 1000 |   100 |   353.04 ns |   6.988 ns |    14.587 ns |   347.73 ns |  3.60x slower |   0.17x | 0.7191 |    1504 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 | 1000 |   100 |   553.85 ns |   3.970 ns |     3.315 ns |   552.61 ns |  5.55x slower |   0.25x | 0.3281 |     688 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 | 1000 |   100 | 2,883.50 ns |  52.133 ns |    60.037 ns | 2,864.86 ns | 29.42x slower |   1.20x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |   100 | 1,948.09 ns |  58.155 ns |   171.472 ns | 1,851.48 ns | 19.60x slower |   1.58x | 4.1389 |    8674 B |          NA |
|                 SpanLinq | .NET 6 | .NET 6.0 | 1000 |   100 |   320.84 ns |   8.073 ns |    22.901 ns |   308.73 ns |  3.28x slower |   0.22x |      - |         - |          NA |
|                  Streams | .NET 6 | .NET 6.0 | 1000 |   100 | 7,570.89 ns | 150.950 ns |   423.280 ns | 7,320.35 ns | 77.72x slower |   5.96x | 0.4349 |     912 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 | 1000 |   100 |   341.93 ns |   6.347 ns |     5.300 ns |   342.37 ns |  3.42x slower |   0.15x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |   167.30 ns |   3.143 ns |     3.494 ns |   165.97 ns |  1.70x slower |   0.07x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 | 1000 |   100 |   455.94 ns |   4.771 ns |     5.303 ns |   453.80 ns |  4.65x slower |   0.21x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |   222.26 ns |   2.678 ns |     2.374 ns |   221.30 ns |  2.23x slower |   0.09x |      - |         - |          NA |
|                          |        |          |      |       |             |            |              |             |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 | 1000 |   100 |    95.84 ns |   1.892 ns |     2.652 ns |    94.41 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 | 1000 |   100 |   768.88 ns |  15.231 ns |    38.489 ns |   747.87 ns |  7.97x slower |   0.36x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 | 1000 |   100 |   237.18 ns |   2.752 ns |     2.298 ns |   236.81 ns |  2.49x slower |   0.06x | 0.7191 |    1504 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 | 1000 |   100 |   250.87 ns |   2.148 ns |     2.109 ns |   250.12 ns |  2.63x slower |   0.06x | 0.3285 |     688 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 | 1000 |   100 | 1,868.72 ns |   9.600 ns |     7.495 ns | 1,868.85 ns | 19.60x slower |   0.53x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 | 1000 |   100 | 1,620.82 ns |  42.653 ns |   122.378 ns | 1,552.69 ns | 17.01x slower |   1.55x | 4.1389 |    8673 B |          NA |
|                 SpanLinq | .NET 8 | .NET 8.0 | 1000 |   100 |   201.43 ns |   3.558 ns |     5.326 ns |   198.61 ns |  2.10x slower |   0.05x |      - |         - |          NA |
|                  Streams | .NET 8 | .NET 8.0 | 1000 |   100 | 6,287.66 ns | 356.669 ns | 1,023.349 ns | 5,659.57 ns | 76.61x slower |  10.80x | 0.4272 |     912 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 | 1000 |   100 |   191.72 ns |   1.019 ns |     0.903 ns |   191.70 ns |  2.01x slower |   0.04x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |   156.91 ns |   0.629 ns |     0.525 ns |   156.88 ns |  1.65x slower |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 | 1000 |   100 |   184.94 ns |   3.084 ns |     4.710 ns |   182.06 ns |  1.94x slower |   0.09x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |   173.64 ns |   1.145 ns |     0.956 ns |   173.35 ns |  1.82x slower |   0.04x |      - |         - |          NA |
