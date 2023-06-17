## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                   Method |    Job |  Runtime | Count |       Mean |    Error |    StdDev |     Median |         Ratio | RatioSD |   Gen0 | Allocated |  Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|---------:|----------:|-----------:|--------------:|--------:|-------:|----------:|-------------:|
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   443.6 ns |  3.17 ns |   2.47 ns |   443.5 ns |      baseline |         | 0.0191 |      40 B |              |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 1,020.9 ns | 12.82 ns |  13.16 ns | 1,014.9 ns |  2.31x slower |   0.04x | 0.0458 |      96 B |   2.40x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |   604.0 ns |  2.26 ns |   1.76 ns |   604.0 ns |  1.36x slower |   0.01x | 0.0191 |      40 B |   1.00x more |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,978.1 ns | 37.65 ns |  53.99 ns | 1,967.9 ns |  4.47x slower |   0.09x | 4.2534 |    8906 B | 222.65x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,808.9 ns | 17.78 ns |  15.76 ns | 1,803.4 ns |  4.08x slower |   0.04x | 0.2823 |     592 B |  14.80x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   671.8 ns |  5.71 ns |   4.46 ns |   670.4 ns |  1.51x slower |   0.01x | 0.0305 |      64 B |   1.60x more |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   474.9 ns | 11.47 ns |  33.83 ns |   451.7 ns |  1.09x slower |   0.07x | 0.0191 |      40 B |   1.00x more |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   622.5 ns |  3.26 ns |   2.72 ns |   622.0 ns |  1.40x slower |   0.01x | 0.0191 |      40 B |   1.00x more |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   494.0 ns |  2.91 ns |   2.58 ns |   493.5 ns |  1.11x slower |   0.01x | 0.0191 |      40 B |   1.00x more |
|                          |        |          |       |            |          |           |            |               |         |        |           |              |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   154.8 ns |  2.66 ns |   4.44 ns |   152.1 ns |      baseline |         | 0.0191 |      40 B |              |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   362.6 ns |  6.78 ns |  13.23 ns |   355.9 ns |  2.36x slower |   0.13x | 0.0458 |      96 B |   2.40x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   307.2 ns |  3.67 ns |   4.08 ns |   306.3 ns |  1.98x slower |   0.05x | 0.0191 |      40 B |   1.00x more |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,635.7 ns | 36.17 ns | 101.41 ns | 1,585.6 ns | 10.62x slower |   0.75x | 4.2553 |    8905 B | 222.62x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,177.6 ns | 19.93 ns |  27.28 ns | 1,166.6 ns |  7.61x slower |   0.24x | 0.2823 |     592 B |  14.80x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   256.5 ns |  1.56 ns |   1.30 ns |   256.3 ns |  1.64x slower |   0.05x | 0.0305 |      64 B |   1.60x more |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   279.7 ns |  1.71 ns |   1.52 ns |   279.2 ns |  1.79x slower |   0.06x | 0.0191 |      40 B |   1.00x more |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   187.1 ns |  3.79 ns |  10.99 ns |   180.7 ns |  1.21x slower |   0.07x | 0.0191 |      40 B |   1.00x more |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   190.7 ns |  3.79 ns |   8.07 ns |   186.3 ns |  1.23x slower |   0.07x | 0.0191 |      40 B |   1.00x more |
