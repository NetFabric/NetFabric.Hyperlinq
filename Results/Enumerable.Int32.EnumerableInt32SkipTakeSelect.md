## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|                   Method |    Job |  Runtime | Skip | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |----- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                     Linq | .NET 6 | .NET 6.0 | 1000 |   100 |  4.183 μs | 0.0462 μs | 0.0386 μs |  4.166 μs |     baseline |         | 0.0992 |     208 B |             |
|                   LinqAF | .NET 6 | .NET 6.0 | 1000 |   100 |  4.393 μs | 0.0197 μs | 0.0153 μs |  4.398 μs | 1.05x slower |   0.01x | 0.0153 |      40 B |  5.20x less |
|            LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |   100 |  6.269 μs | 0.0383 μs | 0.0359 μs |  6.275 μs | 1.50x slower |   0.02x | 4.2419 |    8906 B | 42.82x more |
|                  Streams | .NET 6 | .NET 6.0 | 1000 |   100 | 10.745 μs | 0.1872 μs | 0.2080 μs | 10.667 μs | 2.57x slower |   0.05x | 0.4272 |     920 B |  4.42x more |
|               StructLinq | .NET 6 | .NET 6.0 | 1000 |   100 |  3.901 μs | 0.0737 μs | 0.0905 μs |  3.866 μs | 1.06x faster |   0.03x | 0.0610 |     128 B |  1.62x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |  3.663 μs | 0.0428 μs | 0.0334 μs |  3.655 μs | 1.14x faster |   0.01x | 0.0153 |      40 B |  5.20x less |
|                Hyperlinq | .NET 6 | .NET 6.0 | 1000 |   100 |  3.298 μs | 0.0606 μs | 0.0622 μs |  3.274 μs | 1.27x faster |   0.03x | 0.0191 |      40 B |  5.20x less |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |  3.244 μs | 0.0635 μs | 0.1726 μs |  3.152 μs | 1.31x faster |   0.05x | 0.0191 |      40 B |  5.20x less |
|                          |        |          |      |       |           |           |           |           |              |         |        |           |             |
|                     Linq | .NET 8 | .NET 8.0 | 1000 |   100 |  2.890 μs | 0.0223 μs | 0.0186 μs |  2.883 μs |     baseline |         | 0.0992 |     208 B |             |
|                   LinqAF | .NET 8 | .NET 8.0 | 1000 |   100 |  3.198 μs | 0.0636 μs | 0.1314 μs |  3.130 μs | 1.13x slower |   0.05x | 0.0191 |      40 B |  5.20x less |
|            LinqOptimizer | .NET 8 | .NET 8.0 | 1000 |   100 |  6.264 μs | 0.1700 μs | 0.4932 μs |  5.990 μs | 2.16x slower |   0.15x | 4.2496 |    8905 B | 42.81x more |
|                  Streams | .NET 8 | .NET 8.0 | 1000 |   100 |  6.279 μs | 0.1487 μs | 0.4242 μs |  6.071 μs | 2.20x slower |   0.16x | 0.4349 |     920 B |  4.42x more |
|               StructLinq | .NET 8 | .NET 8.0 | 1000 |   100 |  2.351 μs | 0.0180 μs | 0.0150 μs |  2.348 μs | 1.23x faster |   0.01x | 0.0610 |     128 B |  1.62x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |  2.494 μs | 0.0143 μs | 0.0119 μs |  2.492 μs | 1.16x faster |   0.01x | 0.0191 |      40 B |  5.20x less |
|                Hyperlinq | .NET 8 | .NET 8.0 | 1000 |   100 |  1.871 μs | 0.0160 μs | 0.0142 μs |  1.868 μs | 1.54x faster |   0.01x | 0.0191 |      40 B |  5.20x less |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |  1.888 μs | 0.0312 μs | 0.0260 μs |  1.880 μs | 1.53x faster |   0.02x | 0.0191 |      40 B |  5.20x less |
