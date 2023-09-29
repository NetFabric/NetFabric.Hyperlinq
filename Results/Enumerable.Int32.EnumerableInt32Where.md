## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                   Method |  Runtime | Count |     Mean |    Error |   StdDev |   Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|---------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|                   LinqAF | .NET 6.0 |   100 | 952.7 ns |  3.92 ns |  3.27 ns | 953.5 ns | 1.02x faster |   0.01x | 0.0153 |      32 B |  2.75x less |
|               StructLinq | .NET 6.0 |   100 | 681.0 ns |  7.38 ns |  5.76 ns | 679.3 ns | 1.43x faster |   0.02x | 0.0267 |      56 B |  1.57x less |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 536.1 ns | 10.57 ns | 15.16 ns | 532.2 ns | 1.80x faster |   0.07x | 0.0153 |      32 B |  2.75x less |
|                Hyperlinq | .NET 6.0 |   100 | 707.4 ns |  8.51 ns |  6.65 ns | 705.9 ns | 1.37x faster |   0.03x | 0.0153 |      32 B |  2.75x less |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 539.7 ns |  3.11 ns |  3.82 ns | 539.4 ns | 1.79x faster |   0.03x | 0.0153 |      32 B |  2.75x less |
|                     Linq | .NET 6.0 |   100 | 970.0 ns | 16.29 ns | 14.44 ns | 964.0 ns |     baseline |         | 0.0420 |      88 B |             |
|                          |          |       |          |          |          |          |              |         |        |           |             |
|                   LinqAF | .NET 8.0 |   100 | 231.7 ns |  3.69 ns |  3.08 ns | 231.1 ns | 1.46x faster |   0.02x | 0.0153 |      32 B |  2.75x less |
|               StructLinq | .NET 8.0 |   100 | 246.5 ns |  3.66 ns |  2.86 ns | 246.0 ns | 1.37x faster |   0.02x | 0.0267 |      56 B |  1.57x less |
| StructLinq_ValueDelegate | .NET 8.0 |   100 | 204.3 ns |  1.29 ns |  1.01 ns | 204.2 ns | 1.65x faster |   0.02x | 0.0153 |      32 B |  2.75x less |
|                Hyperlinq | .NET 8.0 |   100 | 210.4 ns |  2.22 ns |  1.73 ns | 210.1 ns | 1.61x faster |   0.02x | 0.0153 |      32 B |  2.75x less |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 | 208.6 ns |  4.18 ns | 10.02 ns | 204.7 ns | 1.60x faster |   0.08x | 0.0153 |      32 B |  2.75x less |
|                     Linq | .NET 8.0 |   100 | 337.7 ns |  3.76 ns |  2.93 ns | 337.3 ns |     baseline |         | 0.0420 |      88 B |             |
