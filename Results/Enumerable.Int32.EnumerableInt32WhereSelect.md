## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|                   Method |  Runtime | Count |       Mean |    Error |   StdDev |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |-----------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|              ForeachLoop | .NET 6.0 |   100 |   407.0 ns |  8.07 ns |  7.55 ns |     baseline |         | 0.0153 |      32 B |             |
|                     Linq | .NET 6.0 |   100 | 1,119.1 ns | 21.04 ns | 32.13 ns | 2.76x slower |   0.12x | 0.0725 |     152 B |  4.75x more |
|                   LinqAF | .NET 6.0 |   100 | 1,079.5 ns | 19.49 ns | 22.45 ns | 2.66x slower |   0.06x | 0.0153 |      32 B |  1.00x more |
|               StructLinq | .NET 6.0 |   100 |   872.3 ns | 17.25 ns | 19.17 ns | 2.15x slower |   0.07x | 0.0420 |      88 B |  2.75x more |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |   541.4 ns |  7.74 ns |  6.86 ns | 1.33x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
|                Hyperlinq | .NET 6.0 |   100 |   843.9 ns | 16.16 ns | 19.84 ns | 2.08x slower |   0.06x | 0.0153 |      32 B |  1.00x more |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 |   539.4 ns |  4.85 ns |  4.05 ns | 1.33x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
|                          |          |       |            |          |          |              |         |        |           |             |
|              ForeachLoop | .NET 8.0 |   100 |   149.7 ns |  1.46 ns |  1.22 ns |     baseline |         | 0.0153 |      32 B |             |
|                     Linq | .NET 8.0 |   100 |   335.8 ns |  6.65 ns |  6.83 ns | 2.25x slower |   0.05x | 0.0725 |     152 B |  4.75x more |
|                   LinqAF | .NET 8.0 |   100 |   236.9 ns |  4.64 ns |  5.87 ns | 1.59x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
|               StructLinq | .NET 8.0 |   100 |   322.2 ns |  5.23 ns |  4.64 ns | 2.15x slower |   0.04x | 0.0420 |      88 B |  2.75x more |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |   295.1 ns |  5.69 ns |  6.99 ns | 1.97x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
|                Hyperlinq | .NET 8.0 |   100 |   261.9 ns |  3.68 ns |  4.38 ns | 1.76x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |   228.8 ns |  1.23 ns |  1.09 ns | 1.53x slower |   0.01x | 0.0153 |      32 B |  1.00x more |
