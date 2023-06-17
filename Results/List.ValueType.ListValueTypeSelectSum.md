## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|                   Method |    Job |  Runtime | Count |        Mean |     Error |    StdDev |      Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |------------:|----------:|----------:|------------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |   213.72 ns |  1.608 ns |  1.343 ns |   213.46 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   348.53 ns |  5.685 ns |  4.439 ns |   347.43 ns | 1.63x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1,386.88 ns | 26.942 ns | 21.035 ns | 1,379.61 ns | 6.49x slower |   0.12x | 0.0458 |      96 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |   423.09 ns |  7.997 ns | 17.887 ns |   412.63 ns | 1.99x slower |   0.09x |      - |         - |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |   646.99 ns | 18.355 ns | 52.070 ns |   618.91 ns | 3.02x slower |   0.27x | 3.0670 |    6424 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |   994.64 ns | 19.736 ns | 35.081 ns |   988.19 ns | 4.70x slower |   0.13x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,105.75 ns | 20.823 ns | 16.257 ns | 1,099.35 ns | 5.18x slower |   0.09x | 0.0572 |     120 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 |   688.72 ns | 10.903 ns |  9.104 ns |   685.02 ns | 3.22x slower |   0.04x | 0.1717 |     360 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   203.86 ns |  1.186 ns |  1.109 ns |   203.30 ns | 1.05x faster |   0.01x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |    87.27 ns |  1.644 ns |  1.373 ns |    86.71 ns | 2.45x faster |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   455.40 ns |  9.068 ns | 21.197 ns |   444.07 ns | 2.13x slower |   0.09x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   739.25 ns | 14.247 ns | 15.244 ns |   730.90 ns | 3.48x slower |   0.07x |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 1,248.61 ns | 19.377 ns | 16.181 ns | 1,248.17 ns | 5.84x slower |   0.08x | 0.5836 |    1224 B |          NA |
|                          |        |          |       |             |           |           |             |              |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |   107.67 ns |  1.703 ns |  2.028 ns |   106.70 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   329.87 ns |  3.429 ns |  2.864 ns |   328.66 ns | 3.05x slower |   0.08x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   460.01 ns |  8.985 ns | 19.910 ns |   451.24 ns | 4.25x slower |   0.22x | 0.0458 |      96 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |   142.70 ns |  1.481 ns |  1.312 ns |   142.59 ns | 1.32x slower |   0.03x |      - |         - |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |   561.92 ns |  5.496 ns |  4.872 ns |   560.56 ns | 5.20x slower |   0.12x | 3.0670 |    6424 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   592.25 ns |  1.695 ns |  1.416 ns |   592.56 ns | 5.48x slower |   0.12x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,045.30 ns |  5.424 ns |  4.808 ns | 1,043.44 ns | 9.67x slower |   0.22x | 0.0572 |     120 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 |   564.10 ns |  6.403 ns |  8.098 ns |   562.90 ns | 5.25x slower |   0.10x | 0.1717 |     360 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   180.89 ns |  2.693 ns |  3.101 ns |   180.00 ns | 1.68x slower |   0.05x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |    60.35 ns |  0.471 ns |  0.393 ns |    60.25 ns | 1.79x faster |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   104.31 ns |  2.204 ns |  6.288 ns |   100.84 ns | 1.03x faster |   0.06x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |    96.08 ns |  1.958 ns |  1.736 ns |    95.27 ns | 1.13x faster |   0.03x |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |   411.92 ns |  8.896 ns | 25.091 ns |   397.69 ns | 3.89x slower |   0.32x | 0.5660 |    1184 B |          NA |
