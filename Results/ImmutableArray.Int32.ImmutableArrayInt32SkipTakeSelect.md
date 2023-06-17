## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

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
|                   Method |    Job |  Runtime | Skip | Count |         Mean |      Error |     StdDev |       Median |          Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |----- |------ |-------------:|-----------:|-----------:|-------------:|---------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 | 1000 |   100 |     86.98 ns |   1.757 ns |   4.175 ns |     84.84 ns |       baseline |         |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 | 1000 |   100 |  1,195.82 ns |  23.833 ns |  52.812 ns |  1,175.55 ns |  13.76x slower |   0.66x | 0.0839 |     176 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 | 1000 |   100 |    937.73 ns |   7.942 ns |   7.040 ns |    937.73 ns |  10.75x slower |   0.58x | 2.5444 |    5328 B |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |   100 |  6,396.52 ns | 170.943 ns | 490.467 ns |  6,111.45 ns |  73.74x slower |   6.01x | 4.2496 |    8898 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 | 1000 |   100 | 10,515.71 ns | 164.556 ns | 137.412 ns | 10,476.06 ns | 120.15x slower |   5.70x | 0.4425 |     936 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 | 1000 |   100 |    238.34 ns |   1.964 ns |   1.533 ns |    237.87 ns |   2.72x slower |   0.15x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |    179.89 ns |   1.648 ns |   1.287 ns |    179.71 ns |   2.05x slower |   0.11x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 | 1000 |   100 |    251.64 ns |   2.847 ns |   2.222 ns |    251.28 ns |   2.87x slower |   0.16x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |    202.42 ns |   3.979 ns |   5.579 ns |    199.00 ns |   2.31x slower |   0.10x |      - |         - |          NA |
|                          |        |          |      |       |              |            |            |              |                |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 | 1000 |   100 |     59.02 ns |   1.120 ns |   2.103 ns |     58.07 ns |       baseline |         |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 | 1000 |   100 |    348.74 ns |   6.906 ns |   7.676 ns |    345.88 ns |   5.90x slower |   0.24x | 0.0839 |     176 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 | 1000 |   100 |    631.57 ns |  11.755 ns |  24.794 ns |    622.12 ns |  10.76x slower |   0.58x | 2.5444 |    5328 B |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 | 1000 |   100 |  5,976.82 ns |  98.118 ns | 127.581 ns |  5,935.85 ns | 101.43x slower |   3.80x | 4.2419 |    8897 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 | 1000 |   100 |  6,900.77 ns | 166.320 ns | 479.872 ns |  6,624.13 ns | 117.92x slower |   9.88x | 0.4425 |     936 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 | 1000 |   100 |    204.76 ns |   4.139 ns |   6.067 ns |    201.40 ns |   3.45x slower |   0.18x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |    152.33 ns |   1.569 ns |   1.311 ns |    151.76 ns |   2.56x slower |   0.11x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 | 1000 |   100 |    173.93 ns |   1.270 ns |   0.991 ns |    173.56 ns |   2.91x slower |   0.12x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |    153.35 ns |   3.082 ns |   2.732 ns |    152.52 ns |   2.58x slower |   0.13x |      - |         - |          NA |
