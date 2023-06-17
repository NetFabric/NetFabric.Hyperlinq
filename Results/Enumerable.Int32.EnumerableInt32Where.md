## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                   Method |    Job |  Runtime | Count |       Mean |    Error |    StdDev |     Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|---------:|----------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |   839.2 ns | 10.61 ns |   8.28 ns |   837.3 ns | 1.29x faster |   0.02x | 0.0191 |      40 B |  2.40x less |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,972.4 ns | 20.38 ns |  25.03 ns | 1,970.3 ns | 1.82x slower |   0.03x | 4.2534 |    8906 B | 92.77x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,935.6 ns | 53.95 ns | 157.37 ns | 1,846.9 ns | 1.82x slower |   0.17x | 0.2823 |     592 B |  6.17x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   767.5 ns | 15.28 ns |  17.59 ns |   761.0 ns | 1.41x faster |   0.04x | 0.0305 |      64 B |  1.50x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   617.0 ns | 10.31 ns |  25.69 ns |   606.1 ns | 1.74x faster |   0.08x | 0.0191 |      40 B |  2.40x less |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   806.8 ns | 12.81 ns |  13.16 ns |   803.0 ns | 1.34x faster |   0.02x | 0.0191 |      40 B |  2.40x less |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   609.0 ns |  5.43 ns |   4.54 ns |   607.4 ns | 1.78x faster |   0.01x | 0.0191 |      40 B |  2.40x less |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1,083.2 ns |  5.28 ns |   4.68 ns | 1,082.6 ns |     baseline |         | 0.0458 |      96 B |             |
|                          |        |          |       |            |          |           |            |              |         |        |           |             |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   336.8 ns |  6.38 ns |   5.32 ns |   335.3 ns | 1.26x faster |   0.10x | 0.0191 |      40 B |  2.40x less |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,505.6 ns | 21.46 ns |  17.92 ns | 1,497.5 ns | 3.56x slower |   0.25x | 4.2534 |    8905 B | 92.76x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,156.2 ns |  9.45 ns |   7.89 ns | 1,155.7 ns | 2.73x slower |   0.18x | 0.2823 |     592 B |  6.17x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   282.3 ns |  2.98 ns |   2.33 ns |   281.2 ns | 1.51x faster |   0.10x | 0.0305 |      64 B |  1.50x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   315.2 ns |  5.14 ns |   6.11 ns |   313.3 ns | 1.36x faster |   0.09x | 0.0191 |      40 B |  2.40x less |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   280.0 ns |  3.74 ns |   3.12 ns |   278.6 ns | 1.52x faster |   0.12x | 0.0191 |      40 B |  2.40x less |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   218.2 ns |  4.40 ns |  11.03 ns |   212.7 ns | 1.93x faster |   0.13x | 0.0191 |      40 B |  2.40x less |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   420.0 ns |  7.93 ns |  22.12 ns |   407.1 ns |     baseline |         | 0.0458 |      96 B |             |
