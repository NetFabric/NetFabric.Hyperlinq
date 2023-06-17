## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |    67.84 ns |  0.608 ns |  0.475 ns |    67.77 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |    67.22 ns |  0.540 ns |  0.600 ns |    67.15 ns |  1.01x faster |   0.01x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   666.28 ns |  3.903 ns |  3.259 ns |   666.15 ns |  9.82x slower |   0.07x | 0.0496 |     104 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |   342.33 ns |  5.690 ns |  6.988 ns |   341.83 ns |  5.05x slower |   0.14x | 0.3171 |     664 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |   887.78 ns | 12.605 ns |  9.841 ns |   886.13 ns | 13.09x slower |   0.18x | 0.4120 |     864 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |   486.89 ns |  9.609 ns | 17.810 ns |   481.51 ns |  7.25x slower |   0.32x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,305.65 ns | 23.746 ns | 19.829 ns | 1,313.76 ns | 19.26x slower |   0.36x | 4.1485 |    8682 B |          NA |
|                 SpanLinq | .NET 6 | .NET 6.0 |   100 |   436.58 ns |  8.682 ns | 19.239 ns |   426.16 ns |  6.50x slower |   0.32x |      - |         - |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,589.82 ns | 10.832 ns | 13.303 ns | 1,588.15 ns | 23.46x slower |   0.20x | 0.3510 |     736 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   337.63 ns |  5.620 ns |  6.902 ns |   335.30 ns |  4.96x slower |   0.10x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   193.20 ns |  1.278 ns |  1.420 ns |   192.96 ns |  2.85x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   310.91 ns |  3.040 ns |  2.374 ns |   310.21 ns |  4.58x slower |   0.04x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   218.17 ns |  4.390 ns |  4.312 ns |   216.17 ns |  3.23x slower |   0.08x |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 |   391.83 ns |  7.862 ns | 18.532 ns |   382.36 ns |  5.92x slower |   0.34x | 0.2027 |     424 B |          NA |
|                          |        |          |       |             |           |           |             |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |    68.76 ns |  0.939 ns |  0.879 ns |    68.54 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |    68.00 ns |  0.529 ns |  0.469 ns |    67.97 ns |  1.01x faster |   0.01x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   236.98 ns |  1.686 ns |  1.494 ns |   236.55 ns |  3.45x slower |   0.05x | 0.0496 |     104 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |   184.27 ns |  1.822 ns |  1.615 ns |   183.70 ns |  2.68x slower |   0.04x | 0.3171 |     664 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |   571.87 ns | 11.263 ns | 20.020 ns |   561.37 ns |  8.33x slower |   0.20x | 0.4129 |     864 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   275.24 ns |  3.925 ns |  3.065 ns |   274.39 ns |  3.99x slower |   0.07x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 |   989.94 ns | 17.311 ns | 24.267 ns |   985.91 ns | 14.47x slower |   0.54x | 4.1485 |    8681 B |          NA |
|                 SpanLinq | .NET 8 | .NET 8.0 |   100 |   295.09 ns |  3.302 ns |  2.927 ns |   295.22 ns |  4.29x slower |   0.06x |      - |         - |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,231.21 ns | 16.423 ns | 19.550 ns | 1,225.17 ns | 17.96x slower |   0.43x | 0.3510 |     736 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   259.79 ns |  1.649 ns |  1.377 ns |   259.77 ns |  3.77x slower |   0.05x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   175.71 ns |  3.096 ns |  2.417 ns |   174.93 ns |  2.55x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   199.81 ns |  3.809 ns |  3.741 ns |   198.33 ns |  2.91x slower |   0.08x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   177.02 ns |  2.049 ns |  1.711 ns |   176.18 ns |  2.57x slower |   0.04x |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |   204.85 ns |  4.013 ns | 10.501 ns |   198.75 ns |  2.98x slower |   0.15x | 0.2027 |     424 B |          NA |
