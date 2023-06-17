## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                   Method |    Job |  Runtime | Count |     Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |    Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |---------:|----------:|----------:|----------:|-------------:|--------:|--------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 | 1.870 μs | 0.0371 μs | 0.0837 μs | 1.8364 μs |     baseline |         |  3.8605 |    7.9 KB |             |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 1.380 μs | 0.0200 μs | 0.0156 μs | 1.3775 μs | 1.39x faster |   0.08x |  3.8605 |    7.9 KB |  1.00x more |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1.616 μs | 0.0153 μs | 0.0119 μs | 1.6149 μs | 1.18x faster |   0.07x |  4.0436 |   8.27 KB |  1.05x more |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 | 1.879 μs | 0.0129 μs | 0.0114 μs | 1.8779 μs | 1.01x faster |   0.05x |  5.5389 |  11.33 KB |  1.43x more |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 2.076 μs | 0.0197 μs | 0.0185 μs | 2.0774 μs | 1.10x slower |   0.06x |  8.0643 |   16.5 KB |  2.09x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 2.963 μs | 0.0419 μs | 0.0371 μs | 2.9704 μs | 1.56x slower |   0.09x |  3.8605 |    7.9 KB |  1.00x more |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 7.946 μs | 0.1525 μs | 0.1756 μs | 7.9195 μs | 4.23x slower |   0.26x | 64.5142 | 135.16 KB | 17.11x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 7.100 μs | 0.0531 μs | 0.0497 μs | 7.0858 μs | 3.75x slower |   0.19x |  4.1199 |   8.43 KB |  1.07x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 1.396 μs | 0.0073 μs | 0.0081 μs | 1.3940 μs | 1.35x faster |   0.07x |  1.7262 |   3.53 KB |  2.24x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 1.117 μs | 0.0101 μs | 0.0079 μs | 1.1154 μs | 1.71x faster |   0.10x |  1.6766 |   3.43 KB |  2.30x less |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 1.595 μs | 0.0169 μs | 0.0166 μs | 1.5895 μs | 1.19x faster |   0.06x |  1.6766 |   3.43 KB |  2.30x less |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 1.412 μs | 0.0282 μs | 0.0732 μs | 1.3759 μs | 1.33x faster |   0.09x |  1.6766 |   3.43 KB |  2.30x less |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 1.580 μs | 0.0316 μs | 0.0881 μs | 1.5499 μs | 1.19x faster |   0.09x |  3.8605 |    7.9 KB |  1.00x more |
|                          |        |          |       |          |           |           |           |              |         |         |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 | 1.111 μs | 0.0174 μs | 0.0145 μs | 1.1124 μs |     baseline |         |  3.8605 |    7.9 KB |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 | 1.193 μs | 0.0201 μs | 0.0178 μs | 1.1842 μs | 1.07x slower |   0.02x |  3.8605 |    7.9 KB |  1.00x more |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 1.166 μs | 0.0216 μs | 0.0303 μs | 1.1547 μs | 1.05x slower |   0.04x |  4.0436 |   8.27 KB |  1.05x more |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 | 1.423 μs | 0.0272 μs | 0.0212 μs | 1.4213 μs | 1.28x slower |   0.02x |  5.5389 |  11.33 KB |  1.43x more |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 1.832 μs | 0.0438 μs | 0.1250 μs | 1.7760 μs | 1.60x slower |   0.06x |  8.0643 |   16.5 KB |  2.09x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 1.636 μs | 0.0389 μs | 0.1122 μs | 1.5862 μs | 1.45x slower |   0.08x |  3.8605 |    7.9 KB |  1.00x more |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 7.995 μs | 0.1404 μs | 0.2495 μs | 7.9033 μs | 7.31x slower |   0.37x | 64.5142 | 135.14 KB | 17.11x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 6.821 μs | 0.1144 μs | 0.1014 μs | 6.7829 μs | 6.12x slower |   0.09x |  4.1199 |   8.43 KB |  1.07x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 1.103 μs | 0.0105 μs | 0.0088 μs | 1.1006 μs | 1.01x faster |   0.02x |  1.7262 |   3.53 KB |  2.24x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 1.002 μs | 0.0124 μs | 0.0104 μs | 0.9993 μs | 1.11x faster |   0.02x |  1.6766 |   3.43 KB |  2.30x less |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 | 1.036 μs | 0.0094 μs | 0.0088 μs | 1.0341 μs | 1.07x faster |   0.02x |  1.6766 |   3.43 KB |  2.30x less |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 1.012 μs | 0.0114 μs | 0.0101 μs | 1.0090 μs | 1.10x faster |   0.02x |  1.6766 |   3.43 KB |  2.30x less |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 | 1.113 μs | 0.0114 μs | 0.0107 μs | 1.1098 μs | 1.00x slower |   0.02x |  3.8605 |    7.9 KB |  1.00x more |
