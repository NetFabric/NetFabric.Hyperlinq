## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

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
|                   Method |  Runtime | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |  65.60 ns |  0.783 ns |  0.732 ns |  65.43 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |  66.27 ns |  1.281 ns |  1.136 ns |  65.83 ns | 1.01x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 478.07 ns |  5.314 ns |  4.437 ns | 476.96 ns | 7.29x slower |   0.10x | 0.0229 |      48 B |          NA |
|             LinqFasterer | .NET 6.0 |   100 | 581.63 ns |  3.681 ns |  3.263 ns | 582.19 ns | 8.86x slower |   0.11x | 0.3443 |     720 B |          NA |
|               StructLinq | .NET 6.0 |   100 | 316.05 ns |  3.468 ns |  2.708 ns | 316.64 ns | 4.82x slower |   0.07x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 183.30 ns |  3.042 ns |  4.824 ns | 180.98 ns | 2.81x slower |   0.10x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 | 286.42 ns |  4.781 ns |  4.238 ns | 285.96 ns | 4.36x slower |   0.07x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 205.60 ns |  2.655 ns |  2.217 ns | 204.68 ns | 3.14x slower |   0.04x |      - |         - |          NA |
|                          |          |       |           |           |           |           |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  66.41 ns |  1.358 ns |  1.858 ns |  65.46 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  60.17 ns |  0.495 ns |  0.413 ns |  60.08 ns | 1.12x faster |   0.04x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 | 189.54 ns |  3.331 ns |  3.966 ns | 188.74 ns | 2.85x slower |   0.10x | 0.0229 |      48 B |          NA |
|             LinqFasterer | .NET 8.0 |   100 | 332.22 ns | 16.338 ns | 45.813 ns | 319.26 ns | 5.18x slower |   0.77x | 0.3443 |     720 B |          NA |
|               StructLinq | .NET 8.0 |   100 | 150.36 ns |  1.690 ns |  1.319 ns | 150.37 ns | 2.24x slower |   0.09x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  72.35 ns |  0.745 ns |  0.582 ns |  72.19 ns | 1.08x slower |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 | 134.05 ns |  2.009 ns |  1.568 ns | 133.51 ns | 2.00x slower |   0.07x |      - |         - |          NA |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 |  76.64 ns |  1.411 ns |  1.178 ns |  76.13 ns | 1.14x slower |   0.03x |      - |         - |          NA |
