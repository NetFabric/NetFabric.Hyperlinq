## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 442.9 ns |  3.86 ns |  3.23 ns | 442.3 ns |     baseline |         | 0.0191 |      40 B |             |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 449.6 ns |  9.01 ns | 19.97 ns | 439.6 ns | 1.02x slower |   0.05x | 0.0191 |      40 B |  1.00x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 473.6 ns |  3.85 ns |  3.42 ns | 472.2 ns | 1.07x slower |   0.01x | 0.0191 |      40 B |  1.00x more |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 800.9 ns |  8.11 ns |  6.77 ns | 797.1 ns | 1.81x slower |   0.02x | 0.0305 |      64 B |  1.60x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 720.8 ns |  8.97 ns |  7.01 ns | 719.2 ns | 1.63x slower |   0.02x | 0.1183 |     248 B |  6.20x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 453.7 ns |  4.18 ns |  3.49 ns | 452.0 ns | 1.02x slower |   0.01x | 0.0305 |      64 B |  1.60x more |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 465.3 ns | 12.62 ns | 36.61 ns | 443.1 ns | 1.06x slower |   0.08x | 0.0191 |      40 B |  1.00x more |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 455.0 ns | 10.40 ns | 29.67 ns | 438.5 ns | 1.03x slower |   0.07x | 0.0191 |      40 B |  1.00x more |
|                          |        |          |       |          |          |          |          |              |         |        |           |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 | 150.0 ns |  1.37 ns |  1.21 ns | 149.6 ns |     baseline |         | 0.0191 |      40 B |             |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 204.2 ns |  4.06 ns |  6.55 ns | 200.9 ns | 1.36x slower |   0.04x | 0.0191 |      40 B |  1.00x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 245.4 ns |  4.49 ns | 11.43 ns | 238.3 ns | 1.63x slower |   0.09x | 0.0191 |      40 B |  1.00x more |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 640.6 ns |  9.89 ns |  7.72 ns | 638.6 ns | 4.27x slower |   0.06x | 0.0305 |      64 B |  1.60x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 394.8 ns |  4.78 ns |  5.50 ns | 393.2 ns | 2.64x slower |   0.04x | 0.1183 |     248 B |  6.20x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 241.5 ns |  1.68 ns |  1.49 ns | 241.0 ns | 1.61x slower |   0.01x | 0.0305 |      64 B |  1.60x more |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 230.4 ns |  1.58 ns |  1.23 ns | 230.4 ns | 1.53x slower |   0.02x | 0.0191 |      40 B |  1.00x more |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 | 230.3 ns |  4.57 ns |  6.56 ns | 227.0 ns | 1.54x slower |   0.05x | 0.0191 |      40 B |  1.00x more |
