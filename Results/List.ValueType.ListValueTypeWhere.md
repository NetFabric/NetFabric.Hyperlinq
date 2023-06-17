## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|                   Method |    Job |  Runtime | Count |       Mean |     Error |    StdDev |     Median |         Ratio | RatioSD |    Gen0 |   Gen1 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|----------:|----------:|-----------:|--------------:|--------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |   578.6 ns |   3.08 ns |   2.57 ns |   578.3 ns |      baseline |         |       - |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   678.2 ns |   7.63 ns |   6.37 ns |   676.9 ns |  1.17x slower |   0.01x |       - |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1,385.4 ns |  27.72 ns |  65.33 ns | 1,357.9 ns |  2.39x slower |   0.11x |  0.0877 |      - |     184 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 | 1,517.2 ns |  38.60 ns | 111.99 ns | 1,463.7 ns |  2.62x slower |   0.21x |  3.8605 |      - |    8088 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 1,767.9 ns |  35.32 ns |  47.15 ns | 1,771.0 ns |  3.03x slower |   0.05x |  4.7379 |      - |    9936 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 2,034.9 ns |  46.50 ns | 126.50 ns | 2,061.8 ns |  3.25x slower |   0.23x |       - |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 7,777.2 ns | 118.10 ns | 104.70 ns | 7,757.3 ns | 13.46x slower |   0.17x | 62.4847 | 0.0153 |  134925 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 2,196.5 ns |  42.85 ns |  65.44 ns | 2,173.9 ns |  3.80x slower |   0.13x |  0.4044 |      - |     848 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   619.4 ns |   3.17 ns |   2.48 ns |   619.4 ns |  1.07x slower |   0.01x |  0.0191 |      - |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   531.1 ns |   2.09 ns |   1.63 ns |   530.6 ns |  1.09x faster |   0.01x |       - |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 1,072.8 ns |  10.86 ns |   8.48 ns | 1,071.4 ns |  1.85x slower |   0.02x |       - |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   855.1 ns |   4.67 ns |   4.37 ns |   854.7 ns |  1.48x slower |   0.01x |       - |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 1,721.3 ns |  21.76 ns |  18.17 ns | 1,718.5 ns |  2.97x slower |   0.03x |  3.8605 |      - |    8088 B |          NA |
|                          |        |          |       |            |           |           |            |               |         |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |   498.2 ns |   5.74 ns |   4.49 ns |   497.0 ns |      baseline |         |       - |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   597.6 ns |  10.78 ns |   9.00 ns |   593.5 ns |  1.20x slower |   0.02x |       - |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   799.8 ns |  14.13 ns |  27.90 ns |   786.2 ns |  1.63x slower |   0.06x |  0.0877 |      - |     184 B |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 | 1,295.2 ns |  24.32 ns |  22.75 ns | 1,288.7 ns |  2.61x slower |   0.04x |  3.8605 |      - |    8088 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 1,333.9 ns |  20.60 ns |  22.89 ns | 1,332.8 ns |  2.67x slower |   0.07x |  4.7379 |      - |    9936 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   801.6 ns |  16.00 ns |  38.63 ns |   788.6 ns |  1.62x slower |   0.09x |       - |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 8,054.5 ns | 160.61 ns | 362.52 ns | 8,159.5 ns | 15.49x slower |   0.53x | 62.4695 | 0.0153 |  134906 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,599.3 ns |  21.61 ns |  16.87 ns | 1,596.2 ns |  3.21x slower |   0.03x |  0.4044 |      - |     848 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   530.3 ns |   6.62 ns |   5.16 ns |   528.1 ns |  1.06x slower |   0.01x |  0.0191 |      - |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   509.4 ns |   8.34 ns |   6.96 ns |   507.4 ns |  1.02x slower |   0.02x |       - |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   567.1 ns |   2.54 ns |   1.98 ns |   567.3 ns |  1.14x slower |   0.01x |       - |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   535.5 ns |   3.38 ns |   3.00 ns |   533.8 ns |  1.07x slower |   0.01x |       - |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 | 1,318.3 ns |  11.94 ns |   9.32 ns | 1,315.8 ns |  2.65x slower |   0.03x |  3.8605 |      - |    8088 B |          NA |
