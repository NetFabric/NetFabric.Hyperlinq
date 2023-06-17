## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                   Method |    Job |  Runtime | Count |       Mean |     Error |    StdDev |     Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|----------:|----------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |   280.2 ns |   3.13 ns |   2.77 ns |   279.1 ns |     baseline |         | 0.4244 |     888 B |             |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   326.8 ns |   8.26 ns |  23.30 ns |   316.1 ns | 1.16x slower |   0.09x | 0.4244 |     888 B |  1.00x more |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   530.6 ns |   9.74 ns |  18.06 ns |   525.4 ns | 1.92x slower |   0.10x | 0.4015 |     840 B |  1.06x less |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |   435.2 ns |   2.70 ns |   2.40 ns |   434.8 ns | 1.55x slower |   0.02x | 0.4244 |     888 B |  1.00x more |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |   447.6 ns |   7.79 ns |   6.51 ns |   445.8 ns | 1.60x slower |   0.03x | 0.4320 |     904 B |  1.02x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 1,149.2 ns |  22.83 ns |  19.07 ns | 1,140.1 ns | 4.10x slower |   0.08x | 0.4082 |     856 B |  1.04x less |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 2,068.2 ns | 100.11 ns | 283.99 ns | 1,943.5 ns | 8.36x slower |   0.79x | 4.1466 |    8690 B |  9.79x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 |   961.0 ns |   8.83 ns |   7.83 ns |   961.3 ns | 3.43x slower |   0.05x | 0.6695 |    1400 B |  1.58x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   560.3 ns |   7.63 ns |   6.37 ns |   559.6 ns | 2.00x slower |   0.02x | 0.1602 |     336 B |  2.64x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   292.4 ns |   5.46 ns |  10.64 ns |   287.8 ns | 1.04x slower |   0.04x | 0.1144 |     240 B |  3.70x less |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   612.7 ns |   5.79 ns |   4.84 ns |   611.4 ns | 2.18x slower |   0.02x | 0.1144 |     240 B |  3.70x less |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   369.5 ns |   6.63 ns |  13.69 ns |   364.5 ns | 1.33x slower |   0.06x | 0.1144 |     240 B |  3.70x less |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 |   457.9 ns |   5.90 ns |   4.61 ns |   455.5 ns | 1.63x slower |   0.03x | 0.4244 |     888 B |  1.00x more |
|                          |        |          |       |            |           |           |            |              |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |   308.0 ns |   6.11 ns |   8.96 ns |   304.7 ns |     baseline |         | 0.4244 |     888 B |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   261.8 ns |   3.63 ns |   3.22 ns |   261.7 ns | 1.18x faster |   0.05x | 0.4244 |     888 B |  1.00x more |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   372.8 ns |  10.41 ns |  30.53 ns |   357.3 ns | 1.22x slower |   0.10x | 0.4015 |     840 B |  1.06x less |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |   281.4 ns |   4.07 ns |   4.00 ns |   280.5 ns | 1.10x faster |   0.04x | 0.4244 |     888 B |  1.00x more |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |   271.9 ns |   5.42 ns |  12.66 ns |   267.9 ns | 1.12x faster |   0.04x | 0.4320 |     904 B |  1.02x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   462.0 ns |   2.60 ns |   2.17 ns |   462.0 ns | 1.49x slower |   0.06x | 0.4091 |     856 B |  1.04x less |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,850.4 ns |  33.13 ns |  58.88 ns | 1,832.3 ns | 6.03x slower |   0.22x | 4.1466 |    8689 B |  9.78x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 |   972.0 ns |   5.34 ns |   4.46 ns |   970.9 ns | 3.13x slower |   0.11x | 0.6695 |    1400 B |  1.58x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   373.0 ns |   3.81 ns |   2.97 ns |   373.6 ns | 1.20x slower |   0.04x | 0.1602 |     336 B |  2.64x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   266.6 ns |   3.24 ns |   2.71 ns |   266.1 ns | 1.16x faster |   0.04x | 0.1144 |     240 B |  3.70x less |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   399.4 ns |   5.61 ns |   4.38 ns |   397.4 ns | 1.28x slower |   0.05x | 0.1144 |     240 B |  3.70x less |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   312.0 ns |   3.22 ns |   2.51 ns |   311.5 ns | 1.00x slower |   0.04x | 0.1144 |     240 B |  3.70x less |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |   405.6 ns |   4.41 ns |   4.12 ns |   405.1 ns | 1.31x slower |   0.04x | 0.4244 |     888 B |  1.00x more |
