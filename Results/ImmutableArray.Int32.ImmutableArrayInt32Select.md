## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                   Method |  Runtime | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |  55.05 ns |  1.104 ns |  0.979 ns |  54.74 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |  55.88 ns |  1.132 ns |  1.473 ns |  55.11 ns |  1.02x slower |   0.04x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 615.47 ns |  3.949 ns |  3.297 ns | 615.27 ns | 11.17x slower |   0.22x | 0.0229 |      48 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 658.12 ns | 13.149 ns | 34.868 ns | 643.26 ns | 11.75x slower |   0.66x | 0.4320 |     904 B |          NA |
|               StructLinq | .NET 6.0 |   100 | 208.76 ns |  3.548 ns |  2.963 ns | 207.83 ns |  3.79x slower |   0.10x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 161.82 ns |  0.754 ns |  0.588 ns | 161.85 ns |  2.94x slower |   0.06x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 207.16 ns |  1.098 ns |  0.973 ns | 206.94 ns |  3.76x slower |   0.07x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 177.97 ns |  0.668 ns |  0.558 ns | 177.94 ns |  3.23x slower |   0.06x |      - |         - |          NA |
|                          |          |       |           |           |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  45.25 ns |  0.248 ns |  0.220 ns |  45.20 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  48.79 ns |  0.440 ns |  0.432 ns |  48.76 ns |  1.08x slower |   0.01x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 | 181.13 ns |  0.887 ns |  0.741 ns | 180.89 ns |  4.00x slower |   0.01x | 0.0229 |      48 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 404.62 ns |  8.786 ns | 25.350 ns | 407.63 ns |  9.11x slower |   0.57x | 0.4320 |     904 B |          NA |
|               StructLinq | .NET 8.0 |   100 | 118.04 ns |  2.254 ns |  2.109 ns | 117.18 ns |  2.61x slower |   0.05x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  82.72 ns |  0.798 ns |  0.623 ns |  82.51 ns |  1.83x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |  67.17 ns |  0.269 ns |  0.210 ns |  67.14 ns |  1.48x slower |   0.01x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |  47.64 ns |  0.850 ns |  0.795 ns |  47.45 ns |  1.05x slower |   0.02x |      - |         - |          NA |
