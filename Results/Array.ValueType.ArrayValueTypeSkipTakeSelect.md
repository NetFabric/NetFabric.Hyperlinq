## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                   Method |    Job |  Runtime | Skip | Count |        Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |    Gen0 |    Gen1 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |----- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|--------:|--------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 | 1000 |   100 |  1,569.7 ns |  30.44 ns |  31.26 ns |  1,555.5 ns |      baseline |         |       - |       - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 | 1000 |   100 |  2,611.2 ns |  23.62 ns |  19.72 ns |  2,605.6 ns |  1.66x slower |   0.04x |  0.1526 |       - |     320 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 | 1000 |   100 |  3,838.1 ns |  34.70 ns |  32.46 ns |  3,826.1 ns |  2.44x slower |   0.05x |  9.2010 |       - |   19272 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 | 1000 |   100 |  3,172.0 ns |  49.34 ns |  43.74 ns |  3,160.6 ns |  2.02x slower |   0.06x |  6.1493 |       - |   12880 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 | 1000 |   100 |  8,981.3 ns | 176.75 ns | 165.33 ns |  8,919.0 ns |  5.72x slower |   0.19x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |   100 | 12,101.8 ns | 239.90 ns | 531.59 ns | 11,875.4 ns |  7.83x slower |   0.49x | 50.0031 | 16.6626 |  137767 B |          NA |
|                 SpanLinq | .NET 6 | .NET 6.0 | 1000 |   100 |  2,854.2 ns |  55.75 ns | 142.91 ns |  2,768.8 ns |  1.92x slower |   0.11x |       - |       - |         - |          NA |
|                  Streams | .NET 6 | .NET 6.0 | 1000 |   100 | 17,338.5 ns | 276.52 ns | 646.36 ns | 17,043.2 ns | 11.07x slower |   0.53x |  0.5493 |       - |    1152 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 | 1000 |   100 |  1,863.1 ns |  36.46 ns |  58.88 ns |  1,826.0 ns |  1.19x slower |   0.04x |  0.0458 |       - |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |  1,739.3 ns |  10.80 ns |  10.11 ns |  1,737.0 ns |  1.11x slower |   0.03x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 | 1000 |   100 |  2,660.9 ns |  17.91 ns |  13.98 ns |  2,656.9 ns |  1.69x slower |   0.04x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |  1,728.2 ns |  10.70 ns |   8.36 ns |  1,726.1 ns |  1.10x slower |   0.03x |       - |       - |         - |          NA |
|                          |        |          |      |       |             |           |           |             |               |         |         |         |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 | 1000 |   100 |    754.6 ns |   4.64 ns |   3.62 ns |    753.7 ns |      baseline |         |       - |       - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 | 1000 |   100 |  2,093.4 ns |  38.74 ns |  47.57 ns |  2,077.7 ns |  2.77x slower |   0.07x |  0.1526 |       - |     320 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 | 1000 |   100 |  3,205.1 ns |  63.58 ns | 157.15 ns |  3,157.3 ns |  4.05x slower |   0.05x |  9.2010 |       - |   19272 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 | 1000 |   100 |  2,938.7 ns |  29.24 ns |  22.83 ns |  2,941.6 ns |  3.89x slower |   0.03x |  6.1531 |       - |   12880 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 | 1000 |   100 |  4,309.2 ns |  31.20 ns |  24.36 ns |  4,302.6 ns |  5.71x slower |   0.05x |       - |       - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 | 1000 |   100 | 11,054.2 ns | 214.42 ns | 179.05 ns | 11,035.1 ns | 14.65x slower |   0.23x | 64.3311 |  0.1831 |  137755 B |          NA |
|                 SpanLinq | .NET 8 | .NET 8.0 | 1000 |   100 |  1,970.8 ns |  18.43 ns |  14.39 ns |  1,965.6 ns |  2.61x slower |   0.02x |       - |       - |         - |          NA |
|                  Streams | .NET 8 | .NET 8.0 | 1000 |   100 | 14,759.3 ns | 276.95 ns | 709.94 ns | 14,403.4 ns | 19.54x slower |   0.82x |  0.5493 |       - |    1152 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 | 1000 |   100 |  1,730.3 ns |  34.61 ns |  68.32 ns |  1,747.6 ns |  2.39x slower |   0.08x |  0.0458 |       - |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |    803.9 ns |  14.54 ns |  12.89 ns |    797.7 ns |  1.06x slower |   0.01x |       - |       - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 | 1000 |   100 |  1,614.2 ns |  19.51 ns |  16.30 ns |  1,606.5 ns |  2.14x slower |   0.02x |       - |       - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |    834.7 ns |  16.24 ns |  15.95 ns |    826.6 ns |  1.11x slower |   0.02x |       - |       - |         - |          NA |
