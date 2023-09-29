## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|              ForeachLoop | .NET 6.0 |   100 | 426.8 ns | 10.83 ns | 31.42 ns | 411.2 ns |     baseline |         | 0.0153 |      32 B |             |
|                     Linq | .NET 6.0 |   100 | 984.5 ns | 16.18 ns | 14.35 ns | 980.3 ns | 2.33x slower |   0.13x | 0.0420 |      88 B |  2.75x more |
|                   LinqAF | .NET 6.0 |   100 | 546.0 ns |  5.58 ns |  5.22 ns | 545.1 ns | 1.29x slower |   0.07x | 0.0153 |      32 B |  1.00x more |
|               StructLinq | .NET 6.0 |   100 | 605.7 ns |  7.65 ns |  9.10 ns | 603.2 ns | 1.43x slower |   0.09x | 0.0267 |      56 B |  1.75x more |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 412.2 ns |  4.24 ns |  3.31 ns | 411.1 ns | 1.04x faster |   0.07x | 0.0153 |      32 B |  1.00x more |
|                Hyperlinq | .NET 6.0 |   100 | 548.3 ns |  4.15 ns |  5.53 ns | 548.2 ns | 1.28x slower |   0.09x | 0.0153 |      32 B |  1.00x more |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 412.6 ns |  4.19 ns |  3.71 ns | 411.3 ns | 1.03x faster |   0.05x | 0.0153 |      32 B |  1.00x more |
|                          |          |       |          |          |          |          |              |         |        |           |             |
|              ForeachLoop | .NET 8.0 |   100 | 169.6 ns |  0.70 ns |  0.55 ns | 169.6 ns |     baseline |         | 0.0153 |      32 B |             |
|                     Linq | .NET 8.0 |   100 | 288.3 ns |  5.80 ns | 10.76 ns | 287.5 ns | 1.70x slower |   0.03x | 0.0420 |      88 B |  2.75x more |
|                   LinqAF | .NET 8.0 |   100 | 221.1 ns |  4.26 ns |  4.56 ns | 219.4 ns | 1.30x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
|               StructLinq | .NET 8.0 |   100 | 238.0 ns |  4.57 ns |  4.69 ns | 237.5 ns | 1.40x slower |   0.03x | 0.0267 |      56 B |  1.75x more |
| StructLinq_ValueDelegate | .NET 8.0 |   100 | 164.4 ns |  0.91 ns |  0.71 ns | 164.6 ns | 1.03x faster |   0.01x | 0.0153 |      32 B |  1.00x more |
|                Hyperlinq | .NET 8.0 |   100 | 207.5 ns |  2.56 ns |  2.84 ns | 206.5 ns | 1.22x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 | 173.9 ns |  2.92 ns |  3.58 ns | 174.3 ns | 1.02x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
