## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|                   Method |  Runtime | Count |     Mean |     Error |    StdDev |   Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|----------:|----------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|              ForeachLoop | .NET 6.0 |   100 | 1.323 μs | 0.0162 μs | 0.0135 μs | 1.318 μs |     baseline |         | 1.3485 |    2824 B |             |
|                     Linq | .NET 6.0 |   100 | 1.718 μs | 0.0079 μs | 0.0062 μs | 1.719 μs | 1.30x slower |   0.01x | 1.3275 |    2784 B |  1.01x less |
|                   LinqAF | .NET 6.0 |   100 | 3.956 μs | 0.0518 μs | 0.0432 μs | 3.937 μs | 2.99x slower |   0.03x | 1.6327 |    3424 B |  1.21x more |
|               StructLinq | .NET 6.0 |   100 | 1.696 μs | 0.0338 μs | 0.0891 μs | 1.653 μs | 1.28x slower |   0.06x | 0.0267 |      56 B | 50.43x less |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 1.607 μs | 0.0126 μs | 0.0141 μs | 1.603 μs | 1.22x slower |   0.02x | 0.0153 |      32 B | 88.25x less |
|                Hyperlinq | .NET 6.0 |   100 | 1.857 μs | 0.0106 μs | 0.0104 μs | 1.855 μs | 1.41x slower |   0.01x | 0.0153 |      32 B | 88.25x less |
|                          |          |       |          |           |           |          |              |         |        |           |             |
|              ForeachLoop | .NET 8.0 |   100 | 1.110 μs | 0.0073 μs | 0.0065 μs | 1.108 μs |     baseline |         | 1.3485 |    2824 B |             |
|                     Linq | .NET 8.0 |   100 | 1.228 μs | 0.0129 μs | 0.0114 μs | 1.223 μs | 1.11x slower |   0.01x | 1.3294 |    2784 B |  1.01x less |
|                   LinqAF | .NET 8.0 |   100 | 3.030 μs | 0.0920 μs | 0.2550 μs | 2.999 μs | 2.67x slower |   0.23x | 1.6365 |    3424 B |  1.21x more |
|               StructLinq | .NET 8.0 |   100 | 1.196 μs | 0.0236 μs | 0.0271 μs | 1.190 μs | 1.08x slower |   0.03x | 0.0267 |      56 B | 50.43x less |
| StructLinq_ValueDelegate | .NET 8.0 |   100 | 1.150 μs | 0.0092 μs | 0.0072 μs | 1.151 μs | 1.04x slower |   0.01x | 0.0153 |      32 B | 88.25x less |
|                Hyperlinq | .NET 8.0 |   100 | 1.319 μs | 0.0211 μs | 0.0176 μs | 1.312 μs | 1.19x slower |   0.02x | 0.0153 |      32 B | 88.25x less |
