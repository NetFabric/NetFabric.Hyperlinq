## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|                   Method |  Runtime | Count |     Mean |   Error |   StdDev |   Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|--------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|              ForeachLoop | .NET 6.0 |   100 | 423.2 ns | 8.50 ns | 22.69 ns | 412.1 ns |     baseline |         | 0.0153 |      32 B |             |
|                     Linq | .NET 6.0 |   100 | 445.6 ns | 2.20 ns |  2.16 ns | 445.5 ns | 1.06x slower |   0.05x | 0.0153 |      32 B |  1.00x more |
|                   LinqAF | .NET 6.0 |   100 | 471.3 ns | 3.46 ns |  2.70 ns | 470.5 ns | 1.15x slower |   0.03x | 0.0153 |      32 B |  1.00x more |
|               StructLinq | .NET 6.0 |   100 | 432.8 ns | 7.88 ns | 15.55 ns | 425.9 ns | 1.03x slower |   0.07x | 0.0267 |      56 B |  1.75x more |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 410.0 ns | 3.35 ns |  2.80 ns | 409.6 ns | 1.01x faster |   0.04x | 0.0153 |      32 B |  1.00x more |
|                Hyperlinq | .NET 6.0 |   100 | 495.8 ns | 9.03 ns |  7.54 ns | 492.3 ns | 1.20x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
|                          |          |       |          |         |          |          |              |         |        |           |             |
|              ForeachLoop | .NET 8.0 |   100 | 200.0 ns | 1.45 ns |  1.13 ns | 199.8 ns |     baseline |         | 0.0153 |      32 B |             |
|                     Linq | .NET 8.0 |   100 | 164.0 ns | 3.20 ns |  3.28 ns | 162.6 ns | 1.22x faster |   0.03x | 0.0153 |      32 B |  1.00x more |
|                   LinqAF | .NET 8.0 |   100 | 235.2 ns | 2.92 ns |  2.73 ns | 234.2 ns | 1.18x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
|               StructLinq | .NET 8.0 |   100 | 207.2 ns | 3.09 ns |  2.74 ns | 206.4 ns | 1.04x slower |   0.02x | 0.0267 |      56 B |  1.75x more |
| StructLinq_ValueDelegate | .NET 8.0 |   100 | 190.7 ns | 1.03 ns |  0.80 ns | 190.9 ns | 1.05x faster |   0.01x | 0.0153 |      32 B |  1.00x more |
|                Hyperlinq | .NET 8.0 |   100 | 171.1 ns | 3.36 ns |  4.13 ns | 170.6 ns | 1.18x faster |   0.03x | 0.0153 |      32 B |  1.00x more |
