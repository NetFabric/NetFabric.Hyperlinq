## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|                     Linq | .NET 6 | .NET 6.0 | 1000 |   100 |  4.177 μs | 0.0179 μs | 0.0149 μs |  4.182 μs |     baseline |         | 0.0992 |     208 B |             |
|                   LinqAF | .NET 6 | .NET 6.0 | 1000 |   100 |  4.587 μs | 0.0210 μs | 0.0175 μs |  4.586 μs | 1.10x slower |   0.00x | 0.0153 |      40 B |  5.20x less |
|            LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |   100 |  6.660 μs | 0.1733 μs | 0.4916 μs |  6.428 μs | 1.64x slower |   0.12x | 4.2496 |    8906 B | 42.82x more |
|                  Streams | .NET 6 | .NET 6.0 | 1000 |   100 | 10.476 μs | 0.2030 μs | 0.2172 μs | 10.427 μs | 2.51x slower |   0.06x | 0.4272 |     920 B |  4.42x more |
|               StructLinq | .NET 6 | .NET 6.0 | 1000 |   100 |  4.081 μs | 0.0401 μs | 0.0394 μs |  4.070 μs | 1.03x faster |   0.01x | 0.0610 |     128 B |  1.62x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |  3.676 μs | 0.0351 μs | 0.0293 μs |  3.674 μs | 1.14x faster |   0.01x | 0.0153 |      40 B |  5.20x less |
|                Hyperlinq | .NET 6 | .NET 6.0 | 1000 |   100 |  3.638 μs | 0.0857 μs | 0.2474 μs |  3.494 μs | 1.14x faster |   0.09x | 0.0191 |      40 B |  5.20x less |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 | 1000 |   100 |  3.831 μs | 0.0520 μs | 0.0406 μs |  3.819 μs | 1.09x faster |   0.01x | 0.0153 |      40 B |  5.20x less |
|                          |        |          |      |       |           |           |           |           |              |         |        |           |             |
|                     Linq | .NET 8 | .NET 8.0 | 1000 |   100 |  3.050 μs | 0.0176 μs | 0.0165 μs |  3.045 μs |     baseline |         | 0.0992 |     208 B |             |
|                   LinqAF | .NET 8 | .NET 8.0 | 1000 |   100 |  2.149 μs | 0.0260 μs | 0.0217 μs |  2.139 μs | 1.42x faster |   0.02x | 0.0191 |      40 B |  5.20x less |
|            LinqOptimizer | .NET 8 | .NET 8.0 | 1000 |   100 |  5.793 μs | 0.0717 μs | 0.0559 μs |  5.800 μs | 1.90x slower |   0.02x | 4.2419 |    8905 B | 42.81x more |
|                  Streams | .NET 8 | .NET 8.0 | 1000 |   100 |  6.133 μs | 0.0423 μs | 0.0330 μs |  6.129 μs | 2.01x slower |   0.01x | 0.4349 |     920 B |  4.42x more |
|               StructLinq | .NET 8 | .NET 8.0 | 1000 |   100 |  2.982 μs | 0.0576 μs | 0.1110 μs |  2.931 μs | 1.02x faster |   0.04x | 0.0610 |     128 B |  1.62x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |  2.709 μs | 0.0529 μs | 0.1080 μs |  2.656 μs | 1.13x faster |   0.04x | 0.0191 |      40 B |  5.20x less |
|                Hyperlinq | .NET 8 | .NET 8.0 | 1000 |   100 |  2.684 μs | 0.0980 μs | 0.2795 μs |  2.516 μs | 1.01x slower |   0.10x | 0.0191 |      40 B |  5.20x less |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 | 1000 |   100 |  1.860 μs | 0.0140 μs | 0.0124 μs |  1.861 μs | 1.64x faster |   0.01x | 0.0191 |      40 B |  5.20x less |
