## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|                   Method |    Job |  Runtime | Duplicates | Count |     Mean |     Error |    StdDev |   Median |        Ratio | RatioSD |   Gen0 | Allocated |   Alloc Ratio |
|------------------------- |------- |--------- |----------- |------ |---------:|----------:|----------:|---------:|-------------:|--------:|-------:|----------:|--------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |          4 |   100 | 3.028 μs | 0.0575 μs | 0.1473 μs | 2.969 μs |     baseline |         | 2.8648 |    6000 B |               |
|              ForeachLoop | .NET 6 | .NET 6.0 |          4 |   100 | 3.019 μs | 0.0593 μs | 0.0974 μs | 2.977 μs | 1.01x faster |   0.06x | 2.8648 |    6000 B |   1.000x more |
|                     Linq | .NET 6 | .NET 6.0 |          4 |   100 | 4.695 μs | 0.0439 μs | 0.0389 μs | 4.688 μs | 1.54x slower |   0.08x | 2.8610 |    5992 B |   1.001x less |
|             LinqFasterer | .NET 6 | .NET 6.0 |          4 |   100 | 4.786 μs | 0.0570 μs | 0.0476 μs | 4.771 μs | 1.59x slower |   0.06x | 4.4174 |    9272 B |   1.545x more |
|                   LinqAF | .NET 6 | .NET 6.0 |          4 |   100 | 7.185 μs | 0.0660 μs | 0.0618 μs | 7.172 μs | 2.36x slower |   0.12x | 5.9204 |   12400 B |   2.067x more |
|               StructLinq | .NET 6 | .NET 6.0 |          4 |   100 | 3.536 μs | 0.0707 μs | 0.1900 μs | 3.430 μs | 1.17x slower |   0.09x | 0.0153 |      32 B | 187.500x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |          4 |   100 | 3.491 μs | 0.0722 μs | 0.2072 μs | 3.374 μs | 1.15x slower |   0.08x |      - |         - |            NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |          4 |   100 | 3.403 μs | 0.0671 μs | 0.1210 μs | 3.334 μs | 1.12x slower |   0.05x |      - |         - |            NA |
|                          |        |          |            |       |          |           |           |          |              |         |        |           |               |
|                  ForLoop | .NET 8 | .NET 8.0 |          4 |   100 | 3.014 μs | 0.0505 μs | 0.0601 μs | 2.993 μs |     baseline |         | 2.8648 |    6000 B |               |
|              ForeachLoop | .NET 8 | .NET 8.0 |          4 |   100 | 3.011 μs | 0.0467 μs | 0.0607 μs | 2.997 μs | 1.00x faster |   0.03x | 2.8648 |    6000 B |   1.000x more |
|                     Linq | .NET 8 | .NET 8.0 |          4 |   100 | 3.700 μs | 0.0297 μs | 0.0278 μs | 3.695 μs | 1.22x slower |   0.03x | 2.8610 |    5992 B |   1.001x less |
|             LinqFasterer | .NET 8 | .NET 8.0 |          4 |   100 | 3.714 μs | 0.0305 μs | 0.0270 μs | 3.709 μs | 1.23x slower |   0.03x | 4.4174 |    9272 B |   1.545x more |
|                   LinqAF | .NET 8 | .NET 8.0 |          4 |   100 | 5.661 μs | 0.1060 μs | 0.1262 μs | 5.612 μs | 1.88x slower |   0.05x | 5.9280 |   12400 B |   2.067x more |
|               StructLinq | .NET 8 | .NET 8.0 |          4 |   100 | 2.642 μs | 0.0527 μs | 0.0493 μs | 2.624 μs | 1.15x faster |   0.04x | 0.0153 |      32 B | 187.500x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |          4 |   100 | 2.696 μs | 0.0536 μs | 0.1450 μs | 2.626 μs | 1.11x faster |   0.07x |      - |         - |            NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |          4 |   100 | 2.492 μs | 0.0497 μs | 0.0441 μs | 2.477 μs | 1.22x faster |   0.04x |      - |         - |            NA |
