## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3516/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-rc.1.23463.5
  [Host]     : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  Job-VLSRZF : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  Job-CRYVOQ : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2


```
|                   Method |  Runtime | Skip | Count |     Mean |     Error |    StdDev |   Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |---------:|----------:|----------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|                     Linq | .NET 6.0 | 1000 |   100 | 3.649 μs | 0.0196 μs | 0.0164 μs | 3.651 μs |     baseline |         | 0.0916 |     200 B |             |
|                   LinqAF | .NET 6.0 | 1000 |   100 | 4.239 μs | 0.0256 μs | 0.0214 μs | 4.234 μs | 1.16x slower |   0.01x | 0.0153 |      32 B |  6.25x less |
|               StructLinq | .NET 6.0 | 1000 |   100 | 3.411 μs | 0.0680 μs | 0.1804 μs | 3.330 μs | 1.07x faster |   0.05x | 0.0572 |     120 B |  1.67x less |
| StructLinq_ValueDelegate | .NET 6.0 | 1000 |   100 | 3.059 μs | 0.0233 μs | 0.0194 μs | 3.062 μs | 1.19x faster |   0.01x | 0.0153 |      32 B |  6.25x less |
|                Hyperlinq | .NET 6.0 | 1000 |   100 | 3.028 μs | 0.0409 μs | 0.0319 μs | 3.023 μs | 1.21x faster |   0.01x | 0.0153 |      32 B |  6.25x less |
|  Hyperlinq_ValueDelegate | .NET 6.0 | 1000 |   100 | 2.878 μs | 0.0314 μs | 0.0245 μs | 2.873 μs | 1.27x faster |   0.01x | 0.0153 |      32 B |  6.25x less |
|                          |          |      |       |          |           |           |          |              |         |        |           |             |
|                     Linq | .NET 8.0 | 1000 |   100 | 1.960 μs | 0.0392 μs | 0.0536 μs | 1.936 μs |     baseline |         | 0.0954 |     200 B |             |
|                   LinqAF | .NET 8.0 | 1000 |   100 | 1.667 μs | 0.0321 μs | 0.0369 μs | 1.651 μs | 1.18x faster |   0.03x | 0.0153 |      32 B |  6.25x less |
|               StructLinq | .NET 8.0 | 1000 |   100 | 1.712 μs | 0.0113 μs | 0.0125 μs | 1.717 μs | 1.15x faster |   0.04x | 0.0572 |     120 B |  1.67x less |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 |   100 | 1.565 μs | 0.0122 μs | 0.0120 μs | 1.563 μs | 1.26x faster |   0.04x | 0.0153 |      32 B |  6.25x less |
|                Hyperlinq | .NET 8.0 | 1000 |   100 | 1.595 μs | 0.0290 μs | 0.0226 μs | 1.587 μs | 1.22x faster |   0.04x | 0.0153 |      32 B |  6.25x less |
|  Hyperlinq_ValueDelegate | .NET 8.0 | 1000 |   100 | 1.838 μs | 0.0105 μs | 0.0093 μs | 1.838 μs | 1.07x faster |   0.03x | 0.0153 |      32 B |  6.25x less |
