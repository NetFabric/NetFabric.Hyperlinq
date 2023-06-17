## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|                   Method |    Job |  Runtime | Duplicates | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |    Gen0 | Allocated |     Alloc Ratio |
|------------------------- |------- |--------- |----------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|--------:|----------:|----------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |          4 |   100 | 14.164 μs | 0.3346 μs | 0.9707 μs | 13.666 μs |     baseline |         | 12.8174 |   26976 B |                 |
|              ForeachLoop | .NET 6 | .NET 6.0 |          4 |   100 | 14.219 μs | 0.2810 μs | 0.7353 μs | 13.882 μs | 1.01x slower |   0.07x | 12.8174 |   26976 B |     1.000x more |
|                     Linq | .NET 6 | .NET 6.0 |          4 |   100 | 16.482 μs | 0.2573 μs | 0.2643 μs | 16.420 μs | 1.17x slower |   0.05x | 12.8174 |   26912 B |     1.002x less |
|               LinqFaster | .NET 6 | .NET 6.0 |          4 |   100 |  2.788 μs | 0.0539 μs | 0.0529 μs |  2.774 μs | 5.08x faster |   0.27x |  0.0076 |      24 B | 1,124.000x less |
|             LinqFasterer | .NET 6 | .NET 6.0 |          4 |   100 | 16.468 μs | 0.1213 μs | 0.0947 μs | 16.441 μs | 1.18x slower |   0.05x | 34.8816 |   73168 B |     2.712x more |
|                   LinqAF | .NET 6 | .NET 6.0 |          4 |   100 | 80.292 μs | 0.5680 μs | 0.4743 μs | 80.283 μs | 5.76x slower |   0.21x | 19.8975 |   41936 B |     1.555x more |
|               StructLinq | .NET 6 | .NET 6.0 |          4 |   100 | 14.388 μs | 0.2849 μs | 0.2379 μs | 14.326 μs | 1.03x slower |   0.05x |  0.0305 |      64 B |   421.500x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |          4 |   100 |  4.738 μs | 0.0222 μs | 0.0173 μs |  4.732 μs | 2.94x faster |   0.12x |       - |         - |              NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |          4 |   100 | 13.078 μs | 0.2580 μs | 0.5876 μs | 12.765 μs | 1.08x faster |   0.10x |       - |         - |              NA |
|                          |        |          |            |       |           |           |           |           |              |         |         |           |                 |
|                  ForLoop | .NET 8 | .NET 8.0 |          4 |   100 | 12.636 μs | 0.2518 μs | 0.7144 μs | 12.316 μs |     baseline |         | 12.8937 |   26976 B |                 |
|              ForeachLoop | .NET 8 | .NET 8.0 |          4 |   100 | 13.366 μs | 0.2665 μs | 0.7021 μs | 13.070 μs | 1.06x slower |   0.09x | 12.8937 |   26976 B |     1.000x more |
|                     Linq | .NET 8 | .NET 8.0 |          4 |   100 | 14.516 μs | 0.3601 μs | 1.0449 μs | 13.966 μs | 1.15x slower |   0.08x | 12.8174 |   26912 B |     1.002x less |
|               LinqFaster | .NET 8 | .NET 8.0 |          4 |   100 |  1.923 μs | 0.0366 μs | 0.0501 μs |  1.905 μs | 6.60x faster |   0.39x |  0.0114 |      24 B | 1,124.000x less |
|             LinqFasterer | .NET 8 | .NET 8.0 |          4 |   100 | 20.179 μs | 0.7830 μs | 2.2341 μs | 20.915 μs | 1.60x slower |   0.20x | 34.8816 |   73168 B |     2.712x more |
|                   LinqAF | .NET 8 | .NET 8.0 |          4 |   100 | 64.375 μs | 2.7716 μs | 8.1722 μs | 62.255 μs | 5.15x slower |   0.68x | 20.2637 |   42464 B |     1.574x more |
|               StructLinq | .NET 8 | .NET 8.0 |          4 |   100 | 12.136 μs | 0.2415 μs | 0.5970 μs | 11.865 μs | 1.05x faster |   0.08x |  0.0305 |      64 B |   421.500x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |          4 |   100 |  3.819 μs | 0.0764 μs | 0.1958 μs |  3.725 μs | 3.31x faster |   0.20x |       - |         - |              NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |          4 |   100 | 11.874 μs | 0.1083 μs | 0.0904 μs | 11.855 μs | 1.05x faster |   0.04x |       - |         - |              NA |
