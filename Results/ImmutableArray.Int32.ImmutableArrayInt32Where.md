## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

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
|                   Method |    Job |  Runtime | Count |        Mean |     Error |     StdDev |      Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |------------:|----------:|-----------:|------------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |    66.60 ns |  0.783 ns |   0.611 ns |    66.37 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |    67.29 ns |  1.383 ns |   1.537 ns |    66.83 ns |  1.02x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   472.06 ns |  7.023 ns |   7.212 ns |   469.32 ns |  7.12x slower |   0.13x | 0.0229 |      48 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |   551.81 ns |  5.276 ns |   4.677 ns |   550.15 ns |  8.28x slower |   0.12x | 0.3443 |     720 B |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,717.22 ns | 25.015 ns |  20.889 ns | 1,717.16 ns | 25.79x slower |   0.37x | 4.1656 |    8714 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,905.59 ns | 44.082 ns | 129.977 ns | 1,818.10 ns | 28.91x slower |   2.18x | 0.2899 |     608 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   326.10 ns |  6.487 ns |  13.104 ns |   321.84 ns |  4.92x slower |   0.22x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   184.65 ns |  3.724 ns |   4.433 ns |   182.51 ns |  2.76x slower |   0.07x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   276.70 ns |  4.738 ns |   7.236 ns |   275.08 ns |  4.17x slower |   0.12x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   208.41 ns |  1.989 ns |   1.553 ns |   208.04 ns |  3.13x slower |   0.03x |      - |         - |          NA |
|                          |        |          |       |             |           |            |             |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |    67.72 ns |  1.376 ns |   1.638 ns |    67.08 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |    62.05 ns |  1.236 ns |   1.323 ns |    61.58 ns |  1.10x faster |   0.04x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   184.31 ns |  3.697 ns |   9.740 ns |   178.98 ns |  2.71x slower |   0.12x | 0.0229 |      48 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |   300.82 ns |  4.771 ns |   3.984 ns |   301.15 ns |  4.46x slower |   0.12x | 0.3443 |     720 B |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,360.64 ns | 18.947 ns |  16.796 ns | 1,353.43 ns | 20.10x slower |   0.59x | 4.1656 |    8713 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,149.23 ns | 12.965 ns |  10.827 ns | 1,144.38 ns | 17.04x slower |   0.43x | 0.2899 |     608 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   196.38 ns |  2.342 ns |   1.956 ns |   195.96 ns |  2.91x slower |   0.08x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   177.19 ns |  1.844 ns |   1.540 ns |   176.88 ns |  2.63x slower |   0.06x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   190.04 ns |  3.351 ns |   4.911 ns |   188.51 ns |  2.82x slower |   0.11x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   176.18 ns |  1.501 ns |   1.253 ns |   175.66 ns |  2.61x slower |   0.05x |      - |         - |          NA |
