## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|                   Method |  Runtime | Start | Count |      Mean |    Error |   StdDev |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |------ |----------:|---------:|---------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |     0 |   100 |  44.58 ns | 0.484 ns | 0.404 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 6.0 |     0 |   100 | 612.91 ns | 5.495 ns | 5.397 ns | 13.76x slower |   0.17x | 0.0420 |      88 B |          NA |
|               LinqFaster | .NET 6.0 |     0 |   100 | 299.78 ns | 5.545 ns | 5.187 ns |  6.73x slower |   0.13x | 0.4053 |     848 B |          NA |
|          LinqFaster_SIMD | .NET 6.0 |     0 |   100 | 315.61 ns | 6.274 ns | 9.196 ns |  7.11x slower |   0.20x | 0.4053 |     848 B |          NA |
|                   LinqAF | .NET 6.0 |     0 |   100 | 209.05 ns | 1.823 ns | 1.522 ns |  4.69x slower |   0.05x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |     0 |   100 | 206.33 ns | 4.124 ns | 5.064 ns |  4.62x slower |   0.09x | 0.0114 |      24 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |     0 |   100 | 162.14 ns | 0.673 ns | 0.562 ns |  3.64x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |     0 |   100 | 181.88 ns | 1.272 ns | 1.063 ns |  4.08x slower |   0.04x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |     0 |   100 | 168.27 ns | 2.370 ns | 2.217 ns |  3.78x slower |   0.06x |      - |         - |          NA |
|                          |          |       |       |           |          |          |               |         |        |           |             |
|                  ForLoop | .NET 8.0 |     0 |   100 |  43.17 ns | 0.252 ns | 0.197 ns |      baseline |         |      - |         - |          NA |
|                     Linq | .NET 8.0 |     0 |   100 | 238.84 ns | 0.799 ns | 0.708 ns |  5.53x slower |   0.03x | 0.0420 |      88 B |          NA |
|               LinqFaster | .NET 8.0 |     0 |   100 | 196.71 ns | 3.229 ns | 3.316 ns |  4.57x slower |   0.10x | 0.4053 |     848 B |          NA |
|          LinqFaster_SIMD | .NET 8.0 |     0 |   100 | 127.16 ns | 0.711 ns | 0.594 ns |  2.95x slower |   0.02x | 0.4053 |     848 B |          NA |
|                   LinqAF | .NET 8.0 |     0 |   100 | 113.24 ns | 1.752 ns | 2.278 ns |  2.63x slower |   0.05x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |     0 |   100 |  86.53 ns | 1.458 ns | 1.138 ns |  2.00x slower |   0.03x | 0.0114 |      24 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |     0 |   100 |  45.43 ns | 0.898 ns | 0.961 ns |  1.06x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |     0 |   100 |  62.67 ns | 0.364 ns | 0.322 ns |  1.45x slower |   0.01x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |     0 |   100 |  46.41 ns | 0.547 ns | 0.427 ns |  1.08x slower |   0.01x |      - |         - |          NA |
