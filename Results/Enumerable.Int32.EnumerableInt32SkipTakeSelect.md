## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|                   Method |  Runtime | Skip | Count |     Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |---------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                     Linq | .NET 6.0 | 1000 |   100 | 3.520 μs | 0.0618 μs | 0.0578 μs |     baseline |         | 0.0954 |     200 B |             |
|                   LinqAF | .NET 6.0 | 1000 |   100 | 3.057 μs | 0.0285 μs | 0.0238 μs | 1.15x faster |   0.02x | 0.0153 |      32 B |  6.25x less |
|               StructLinq | .NET 6.0 | 1000 |   100 | 3.298 μs | 0.0645 μs | 0.0663 μs | 1.07x faster |   0.03x | 0.0572 |     120 B |  1.67x less |
| StructLinq_ValueDelegate | .NET 6.0 | 1000 |   100 | 3.074 μs | 0.0178 μs | 0.0175 μs | 1.15x faster |   0.02x | 0.0153 |      32 B |  6.25x less |
|                Hyperlinq | .NET 6.0 | 1000 |   100 | 2.683 μs | 0.0298 μs | 0.0248 μs | 1.31x faster |   0.01x | 0.0153 |      32 B |  6.25x less |
|  Hyperlinq_ValueDelegate | .NET 6.0 | 1000 |   100 | 2.583 μs | 0.0463 μs | 0.0454 μs | 1.36x faster |   0.04x | 0.0153 |      32 B |  6.25x less |
|                          |          |      |       |          |           |           |              |         |        |           |             |
|                     Linq | .NET 8.0 | 1000 |   100 | 1.936 μs | 0.0373 μs | 0.0399 μs |     baseline |         | 0.0954 |     200 B |             |
|                   LinqAF | .NET 8.0 | 1000 |   100 | 1.629 μs | 0.0272 μs | 0.0354 μs | 1.19x faster |   0.04x | 0.0153 |      32 B |  6.25x less |
|               StructLinq | .NET 8.0 | 1000 |   100 | 1.627 μs | 0.0305 μs | 0.0271 μs | 1.19x faster |   0.03x | 0.0572 |     120 B |  1.67x less |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 |   100 | 1.562 μs | 0.0301 μs | 0.0422 μs | 1.23x faster |   0.05x | 0.0153 |      32 B |  6.25x less |
|                Hyperlinq | .NET 8.0 | 1000 |   100 | 1.544 μs | 0.0302 μs | 0.0310 μs | 1.26x faster |   0.04x | 0.0153 |      32 B |  6.25x less |
|  Hyperlinq_ValueDelegate | .NET 8.0 | 1000 |   100 | 1.513 μs | 0.0078 μs | 0.0061 μs | 1.29x faster |   0.03x | 0.0153 |      32 B |  6.25x less |
