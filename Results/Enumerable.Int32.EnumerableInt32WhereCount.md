## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|                   Method |    Job |  Runtime | Count |     Mean |    Error |   StdDev |   Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |---------:|---------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 443.1 ns |  4.10 ns |  3.42 ns | 441.7 ns |     baseline |         | 0.0191 |      40 B |             |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 595.3 ns |  3.15 ns |  2.46 ns | 595.0 ns | 1.34x slower |   0.01x | 0.0191 |      40 B |  1.00x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 692.5 ns | 14.98 ns | 42.75 ns | 670.5 ns | 1.59x slower |   0.13x | 0.0191 |      40 B |  1.00x more |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 850.9 ns | 20.01 ns | 57.40 ns | 818.1 ns | 1.86x slower |   0.05x | 0.0305 |      64 B |  1.60x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 965.5 ns |  9.95 ns | 11.06 ns | 963.7 ns | 2.19x slower |   0.03x | 0.1907 |     400 B | 10.00x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 652.8 ns |  4.34 ns |  3.39 ns | 652.2 ns | 1.47x slower |   0.01x | 0.0458 |      96 B |  2.40x more |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 495.1 ns |  2.70 ns |  2.39 ns | 495.2 ns | 1.12x slower |   0.01x | 0.0191 |      40 B |  1.00x more |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 548.3 ns |  2.89 ns |  2.56 ns | 548.0 ns | 1.24x slower |   0.01x | 0.0191 |      40 B |  1.00x more |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 520.2 ns |  4.11 ns |  3.64 ns | 519.5 ns | 1.17x slower |   0.01x | 0.0191 |      40 B |  1.00x more |
|                          |        |          |       |          |          |          |          |              |         |        |           |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 | 224.0 ns |  1.71 ns |  1.52 ns | 223.2 ns |     baseline |         | 0.0191 |      40 B |             |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 251.8 ns |  1.85 ns |  1.54 ns | 251.4 ns | 1.12x slower |   0.01x | 0.0191 |      40 B |  1.00x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 338.0 ns |  2.96 ns |  2.31 ns | 336.9 ns | 1.51x slower |   0.01x | 0.0191 |      40 B |  1.00x more |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 656.9 ns | 13.06 ns | 29.21 ns | 642.9 ns | 2.98x slower |   0.15x | 0.0305 |      64 B |  1.60x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 701.2 ns | 13.60 ns | 13.97 ns | 697.8 ns | 3.14x slower |   0.07x | 0.1907 |     400 B | 10.00x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 330.9 ns |  1.98 ns |  1.65 ns | 330.0 ns | 1.48x slower |   0.01x | 0.0458 |      96 B |  2.40x more |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 205.2 ns |  4.16 ns |  9.55 ns | 199.5 ns | 1.09x faster |   0.05x | 0.0191 |      40 B |  1.00x more |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 | 211.0 ns |  3.02 ns |  3.59 ns | 210.1 ns | 1.06x faster |   0.02x | 0.0191 |      40 B |  1.00x more |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 254.1 ns |  3.24 ns |  2.87 ns | 253.8 ns | 1.13x slower |   0.01x | 0.0191 |      40 B |  1.00x more |
