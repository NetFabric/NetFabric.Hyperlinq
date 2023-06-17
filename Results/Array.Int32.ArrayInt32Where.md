## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|                   Method |    Job |  Runtime | Count |        Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |    66.33 ns |  0.381 ns |  0.318 ns |    66.39 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |    66.60 ns |  0.639 ns |  0.566 ns |    66.57 ns |  1.00x slower |   0.01x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   502.23 ns |  4.229 ns |  3.748 ns |   500.82 ns |  7.56x slower |   0.06x | 0.0229 |      48 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |   289.76 ns |  3.038 ns |  2.372 ns |   289.64 ns |  4.37x slower |   0.04x | 0.3171 |     664 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |   666.99 ns |  5.878 ns |  5.498 ns |   664.08 ns | 10.06x slower |   0.11x | 0.2136 |     448 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |   393.05 ns |  7.788 ns | 17.258 ns |   384.67 ns |  5.97x slower |   0.27x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,292.42 ns | 18.162 ns | 14.180 ns | 1,295.19 ns | 19.48x slower |   0.26x | 4.1485 |    8682 B |          NA |
|                 SpanLinq | .NET 6 | .NET 6.0 |   100 |   285.69 ns |  5.024 ns |  8.799 ns |   281.84 ns |  4.37x slower |   0.18x |      - |         - |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,415.91 ns | 19.363 ns | 15.117 ns | 1,410.07 ns | 21.34x slower |   0.28x | 0.2785 |     584 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   300.85 ns |  3.717 ns |  3.978 ns |   301.45 ns |  4.54x slower |   0.08x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   167.02 ns |  1.513 ns |  1.181 ns |   166.89 ns |  2.52x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   321.79 ns |  6.282 ns |  5.246 ns |   322.16 ns |  4.85x slower |   0.08x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   207.09 ns |  3.831 ns |  3.199 ns |   205.67 ns |  3.12x slower |   0.04x |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 |   449.94 ns |  8.762 ns | 18.481 ns |   440.66 ns |  6.85x slower |   0.36x | 0.2027 |     424 B |          NA |
|                          |        |          |       |             |           |           |             |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |    66.34 ns |  0.382 ns |  0.338 ns |    66.34 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |    66.30 ns |  0.359 ns |  0.280 ns |    66.33 ns |  1.00x faster |   0.01x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   202.59 ns |  1.181 ns |  1.047 ns |   202.52 ns |  3.05x slower |   0.02x | 0.0229 |      48 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |   180.76 ns |  1.714 ns |  1.905 ns |   180.44 ns |  2.72x slower |   0.04x | 0.3173 |     664 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |   410.75 ns |  8.229 ns | 14.412 ns |   403.41 ns |  6.23x slower |   0.25x | 0.2141 |     448 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   210.40 ns |  4.078 ns |  6.349 ns |   207.91 ns |  3.19x slower |   0.09x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,012.77 ns | 22.679 ns | 62.843 ns |   985.09 ns | 15.15x slower |   0.62x | 4.1485 |    8681 B |          NA |
|                 SpanLinq | .NET 8 | .NET 8.0 |   100 |   235.91 ns |  5.981 ns | 17.634 ns |   226.17 ns |  3.58x slower |   0.29x |      - |         - |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,052.38 ns | 10.262 ns | 10.538 ns | 1,049.35 ns | 15.87x slower |   0.22x | 0.2785 |     584 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   173.59 ns |  1.677 ns |  1.864 ns |   173.35 ns |  2.62x slower |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   159.74 ns |  1.546 ns |  1.207 ns |   159.42 ns |  2.41x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   185.91 ns |  3.573 ns |  5.770 ns |   183.36 ns |  2.83x slower |   0.10x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   175.61 ns |  0.946 ns |  0.739 ns |   175.49 ns |  2.65x slower |   0.02x |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |   237.42 ns |  2.482 ns |  2.073 ns |   236.45 ns |  3.58x slower |   0.04x | 0.2027 |     424 B |          NA |
