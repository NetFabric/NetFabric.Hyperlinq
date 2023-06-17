## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |   269.5 ns |  4.08 ns |   6.10 ns |   267.6 ns |     baseline |         | 0.4244 |     888 B |             |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   266.9 ns |  1.88 ns |   1.57 ns |   266.5 ns | 1.01x faster |   0.02x | 0.4244 |     888 B |  1.00x more |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   512.3 ns |  4.05 ns |   3.38 ns |   510.8 ns | 1.90x slower |   0.05x | 0.3786 |     792 B |  1.12x less |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |   415.2 ns |  8.36 ns |   7.41 ns |   413.7 ns | 1.54x slower |   0.05x | 0.3171 |     664 B |  1.34x less |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |   506.9 ns |  6.32 ns |   7.02 ns |   506.6 ns | 1.87x slower |   0.05x | 0.3977 |     832 B |  1.07x less |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |   700.9 ns | 12.73 ns |  10.63 ns |   701.7 ns | 2.60x slower |   0.08x | 0.4082 |     856 B |  1.04x less |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,135.6 ns | 56.81 ns | 162.99 ns | 1,035.1 ns | 4.01x slower |   0.42x | 4.1313 |    8650 B |  9.74x more |
|                 SpanLinq | .NET 6 | .NET 6.0 |   100 |   557.7 ns |  9.43 ns |  10.86 ns |   554.0 ns | 2.06x slower |   0.07x | 0.4244 |     888 B |  1.00x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 |   913.6 ns | 11.50 ns |   9.60 ns |   910.5 ns | 3.39x slower |   0.10x | 0.6695 |    1400 B |  1.58x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   516.4 ns |  9.63 ns |  17.12 ns |   508.3 ns | 1.93x slower |   0.09x | 0.1602 |     336 B |  2.64x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   289.9 ns |  2.04 ns |   1.71 ns |   289.9 ns | 1.08x slower |   0.03x | 0.1144 |     240 B |  3.70x less |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   607.3 ns | 11.54 ns |  30.61 ns |   592.1 ns | 2.26x slower |   0.13x | 0.1144 |     240 B |  3.70x less |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   353.0 ns |  6.95 ns |   8.28 ns |   349.9 ns | 1.30x slower |   0.04x | 0.1144 |     240 B |  3.70x less |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 |   329.5 ns |  3.67 ns |   3.07 ns |   328.4 ns | 1.22x slower |   0.03x | 0.2027 |     424 B |  2.09x less |
|                          |        |          |       |            |          |           |            |              |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |   237.8 ns |  2.53 ns |   2.24 ns |   237.0 ns |     baseline |         | 0.4244 |     888 B |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   244.8 ns |  3.03 ns |   2.83 ns |   243.9 ns | 1.03x slower |   0.01x | 0.4244 |     888 B |  1.00x more |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   290.8 ns |  2.97 ns |   2.48 ns |   289.7 ns | 1.22x slower |   0.01x | 0.3786 |     792 B |  1.12x less |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |   192.2 ns |  1.54 ns |   1.45 ns |   191.5 ns | 1.24x faster |   0.02x | 0.3171 |     664 B |  1.34x less |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |   250.9 ns |  1.97 ns |   1.74 ns |   250.6 ns | 1.06x slower |   0.01x | 0.3977 |     832 B |  1.07x less |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   392.2 ns |  8.12 ns |  22.91 ns |   380.5 ns | 1.65x slower |   0.07x | 0.4091 |     856 B |  1.04x less |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 |   902.7 ns |  7.62 ns |   7.13 ns |   900.6 ns | 3.80x slower |   0.04x | 4.1313 |    8649 B |  9.74x more |
|                 SpanLinq | .NET 8 | .NET 8.0 |   100 |   360.3 ns |  6.55 ns |  15.93 ns |   352.7 ns | 1.53x slower |   0.09x | 0.4244 |     888 B |  1.00x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 |   925.4 ns | 16.26 ns |  14.42 ns |   919.3 ns | 3.89x slower |   0.06x | 0.6695 |    1400 B |  1.58x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   398.0 ns |  9.91 ns |  28.58 ns |   382.1 ns | 1.71x slower |   0.15x | 0.1602 |     336 B |  2.64x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   304.4 ns |  5.79 ns |  14.94 ns |   298.2 ns | 1.30x slower |   0.08x | 0.1144 |     240 B |  3.70x less |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   398.5 ns |  5.95 ns |   5.56 ns |   398.2 ns | 1.68x slower |   0.03x | 0.1144 |     240 B |  3.70x less |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   306.8 ns |  1.47 ns |   1.15 ns |   306.7 ns | 1.29x slower |   0.01x | 0.1144 |     240 B |  3.70x less |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |   179.9 ns |  3.51 ns |   5.76 ns |   178.4 ns | 1.31x faster |   0.06x | 0.2027 |     424 B |  2.09x less |
