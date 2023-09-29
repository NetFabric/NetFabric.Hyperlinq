## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|                   Method |  Runtime | Count |     Mean |   Error |   StdDev |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|--------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|              ForeachLoop | .NET 6.0 |   100 | 425.7 ns | 8.47 ns | 20.46 ns |     baseline |         | 0.0153 |      32 B |             |
|                     Linq | .NET 6.0 |   100 | 847.4 ns | 9.74 ns |  8.13 ns | 1.95x slower |   0.07x | 0.0153 |      32 B |  1.00x more |
|                   LinqAF | .NET 6.0 |   100 | 835.9 ns | 6.18 ns |  4.82 ns | 1.92x slower |   0.07x | 0.0153 |      32 B |  1.00x more |
|               StructLinq | .NET 6.0 |   100 | 611.5 ns | 7.23 ns |  5.65 ns | 1.41x slower |   0.05x | 0.0420 |      88 B |  2.75x more |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 439.4 ns | 8.23 ns |  9.15 ns | 1.02x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
|                Hyperlinq | .NET 6.0 |   100 | 511.5 ns | 4.58 ns |  3.82 ns | 1.18x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 454.4 ns | 4.81 ns |  3.75 ns | 1.05x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
|                          |          |       |          |         |          |              |         |        |           |             |
|              ForeachLoop | .NET 8.0 |   100 | 151.6 ns | 2.29 ns |  2.36 ns |     baseline |         | 0.0153 |      32 B |             |
|                     Linq | .NET 8.0 |   100 | 180.7 ns | 2.16 ns |  1.80 ns | 1.19x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
|                   LinqAF | .NET 8.0 |   100 | 210.3 ns | 1.38 ns |  1.23 ns | 1.39x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
|               StructLinq | .NET 8.0 |   100 | 249.5 ns | 4.22 ns |  3.53 ns | 1.64x slower |   0.04x | 0.0420 |      88 B |  2.75x more |
| StructLinq_ValueDelegate | .NET 8.0 |   100 | 187.7 ns | 3.73 ns |  5.35 ns | 1.25x slower |   0.05x | 0.0153 |      32 B |  1.00x more |
|                Hyperlinq | .NET 8.0 |   100 | 300.2 ns | 2.78 ns |  2.46 ns | 1.98x slower |   0.04x | 0.0153 |      32 B |  1.00x more |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 | 222.4 ns | 3.58 ns |  3.18 ns | 1.47x slower |   0.02x | 0.0153 |      32 B |  1.00x more |
