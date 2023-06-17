## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|                   Method |    Job |  Runtime | Skip | Count |       Mean |     Error |    StdDev |     Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |----- |------ |-----------:|----------:|----------:|-----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 | 1000 |   100 |   117.6 ns |   0.75 ns |   0.73 ns |   117.6 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 | 1000 |   100 | 1,622.0 ns |  65.18 ns | 173.99 ns | 1,540.6 ns | 14.26x slower |   1.38x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 | 1000 |   100 |   861.9 ns |  18.96 ns |  52.54 ns |   841.7 ns |  7.58x slower |   0.62x | 0.7458 |    1560 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 | 1000 |   100 |   865.4 ns |  24.91 ns |  71.47 ns |   827.4 ns |  7.45x slower |   0.69x | 2.4424 |    5112 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 | 1000 |   100 | 6,069.6 ns | 120.13 ns | 285.50 ns | 5,944.3 ns | 52.82x slower |   3.22x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |   100 | 8,255.2 ns | 122.58 ns |  95.70 ns | 8,225.9 ns | 70.19x slower |   0.62x | 4.1656 |    8714 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 | 1000 |   100 | 7,407.2 ns |  38.79 ns |  32.39 ns | 7,410.6 ns | 62.98x slower |   0.50x | 0.4425 |     936 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 | 1000 |   100 |   339.4 ns |   4.79 ns |   3.74 ns |   340.2 ns |  2.89x slower |   0.04x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |   168.8 ns |   2.71 ns |   4.53 ns |   166.5 ns |  1.44x slower |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 | 1000 |   100 |   341.0 ns |   5.97 ns |   7.55 ns |   338.9 ns |  2.91x slower |   0.06x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |   222.2 ns |   2.63 ns |   2.19 ns |   221.4 ns |  1.89x slower |   0.01x |      - |         - |          NA |
|                          |        |          |      |       |            |           |           |            |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 | 1000 |   100 |   118.3 ns |   1.21 ns |   1.01 ns |   117.8 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 | 1000 |   100 |   467.0 ns |   9.33 ns |  22.18 ns |   455.7 ns |  4.02x slower |   0.25x | 0.0725 |     152 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 | 1000 |   100 |   709.1 ns |   9.42 ns |   9.25 ns |   706.3 ns |  6.00x slower |   0.07x | 0.7458 |    1560 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 | 1000 |   100 |   561.4 ns |   5.13 ns |   4.00 ns |   559.7 ns |  4.75x slower |   0.05x | 2.4424 |    5112 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 | 1000 |   100 | 2,597.0 ns |  21.97 ns |  17.16 ns | 2,593.8 ns | 21.95x slower |   0.26x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 | 1000 |   100 | 9,308.3 ns | 180.31 ns | 325.14 ns | 9,154.5 ns | 79.62x slower |   3.96x | 4.1656 |    8713 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 | 1000 |   100 | 5,432.3 ns |  75.82 ns |  59.20 ns | 5,417.5 ns | 45.92x slower |   0.66x | 0.4425 |     936 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 | 1000 |   100 |   196.4 ns |   3.92 ns |   9.47 ns |   191.4 ns |  1.69x slower |   0.08x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |   158.4 ns |   2.62 ns |   3.01 ns |   156.9 ns |  1.35x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 | 1000 |   100 |   197.3 ns |   3.93 ns |   4.03 ns |   195.6 ns |  1.67x slower |   0.04x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |   177.4 ns |   3.52 ns |   3.76 ns |   176.1 ns |  1.49x slower |   0.03x |      - |         - |          NA |
