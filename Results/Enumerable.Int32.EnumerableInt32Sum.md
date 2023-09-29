## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|              ForeachLoop | .NET 6.0 |   100 | 385.0 ns |  7.18 ns |  6.37 ns | 382.8 ns |     baseline |         | 0.0153 |      32 B |             |
|                     Linq | .NET 6.0 |   100 | 415.4 ns |  4.29 ns |  4.59 ns | 414.7 ns | 1.08x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
|                   LinqAF | .NET 6.0 |   100 | 465.9 ns |  8.96 ns | 23.44 ns | 455.3 ns | 1.20x slower |   0.05x | 0.0153 |      32 B |  1.00x more |
|               StructLinq | .NET 6.0 |   100 | 431.8 ns |  8.94 ns | 25.64 ns | 420.3 ns | 1.11x slower |   0.06x | 0.0267 |      56 B |  1.75x more |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 407.8 ns |  5.92 ns |  4.62 ns | 406.8 ns | 1.06x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
|                Hyperlinq | .NET 6.0 |   100 | 434.0 ns | 12.43 ns | 36.26 ns | 415.3 ns | 1.11x slower |   0.08x | 0.0153 |      32 B |  1.00x more |
|                          |          |       |          |          |          |          |              |         |        |           |             |
|              ForeachLoop | .NET 8.0 |   100 | 160.8 ns |  0.90 ns |  0.70 ns | 160.9 ns |     baseline |         | 0.0153 |      32 B |             |
|                     Linq | .NET 8.0 |   100 | 172.9 ns |  3.15 ns |  3.75 ns | 171.4 ns | 1.08x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
|                   LinqAF | .NET 8.0 |   100 | 239.7 ns |  2.31 ns |  1.93 ns | 240.1 ns | 1.49x slower |   0.01x | 0.0153 |      32 B |  1.00x more |
|               StructLinq | .NET 8.0 |   100 | 204.5 ns |  4.12 ns |  5.77 ns | 201.4 ns | 1.29x slower |   0.04x | 0.0267 |      56 B |  1.75x more |
| StructLinq_ValueDelegate | .NET 8.0 |   100 | 193.1 ns |  2.59 ns |  2.02 ns | 192.2 ns | 1.20x slower |   0.01x | 0.0153 |      32 B |  1.00x more |
|                Hyperlinq | .NET 8.0 |   100 | 199.5 ns |  3.94 ns |  3.87 ns | 198.0 ns | 1.25x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
