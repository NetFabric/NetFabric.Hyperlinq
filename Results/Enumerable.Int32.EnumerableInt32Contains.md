## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 468.5 ns | 12.95 ns | 38.19 ns | 445.9 ns |     baseline |         | 0.0191 |      40 B |             |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 479.8 ns |  9.19 ns | 17.71 ns | 472.0 ns | 1.03x slower |   0.08x | 0.0191 |      40 B |  1.00x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 542.0 ns |  4.17 ns |  3.48 ns | 540.8 ns | 1.16x slower |   0.08x | 0.0191 |      40 B |  1.00x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 484.6 ns |  8.78 ns | 11.10 ns | 481.0 ns | 1.03x slower |   0.08x | 0.0305 |      64 B |  1.60x more |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 | 462.4 ns |  4.53 ns |  5.39 ns | 461.2 ns | 1.03x faster |   0.08x | 0.0191 |      40 B |  1.00x more |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 | 551.5 ns |  5.74 ns |  5.08 ns | 551.7 ns | 1.19x slower |   0.08x | 0.0191 |      40 B |  1.00x more |
|                          |        |          |       |          |          |          |          |              |         |        |           |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 | 204.7 ns |  4.15 ns | 10.64 ns | 199.5 ns |     baseline |         | 0.0191 |      40 B |             |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 179.8 ns |  1.81 ns |  1.86 ns | 179.5 ns | 1.15x faster |   0.06x | 0.0191 |      40 B |  1.00x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 318.8 ns |  6.32 ns |  9.65 ns | 314.0 ns | 1.56x slower |   0.09x | 0.0191 |      40 B |  1.00x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 264.4 ns |  2.03 ns |  1.59 ns | 263.8 ns | 1.27x slower |   0.08x | 0.0305 |      64 B |  1.60x more |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 | 253.5 ns |  1.64 ns |  1.28 ns | 253.5 ns | 1.22x slower |   0.07x | 0.0191 |      40 B |  1.00x more |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 | 231.6 ns |  1.47 ns |  1.38 ns | 231.4 ns | 1.12x slower |   0.06x | 0.0191 |      40 B |  1.00x more |
