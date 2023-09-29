## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|                   Method |  Runtime | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |  41.29 ns | 0.481 ns | 0.402 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |  41.07 ns | 0.814 ns | 1.030 ns | 1.00x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 |  32.64 ns | 0.404 ns | 0.315 ns | 1.27x faster |   0.02x |      - |         - |          NA |
|               LinqFaster | .NET 6.0 |   100 |  33.61 ns | 0.672 ns | 0.826 ns | 1.23x faster |   0.03x |      - |         - |          NA |
|          LinqFaster_SIMD | .NET 6.0 |   100 |  12.57 ns | 0.262 ns | 0.205 ns | 3.29x faster |   0.06x |      - |         - |          NA |
|             LinqFasterer | .NET 6.0 |   100 |  32.51 ns | 0.677 ns | 0.780 ns | 1.26x faster |   0.04x |      - |         - |          NA |
|                   LinqAF | .NET 6.0 |   100 |  33.11 ns | 0.570 ns | 0.476 ns | 1.25x faster |   0.02x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 |  88.80 ns | 1.439 ns | 1.276 ns | 2.15x slower |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |  50.09 ns | 0.338 ns | 0.282 ns | 1.21x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 |  35.07 ns | 0.365 ns | 0.304 ns | 1.18x faster |   0.02x | 0.0153 |      32 B |          NA |
|           Hyperlinq_SIMD | .NET 6.0 |   100 |  24.36 ns | 0.483 ns | 0.496 ns | 1.69x faster |   0.04x |      - |         - |          NA |
|                  Faslinq | .NET 6.0 |   100 | 197.40 ns | 3.880 ns | 4.152 ns | 4.81x slower |   0.12x | 0.0305 |      64 B |          NA |
|                          |          |       |           |          |          |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  40.09 ns | 0.738 ns | 0.617 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  40.46 ns | 0.803 ns | 0.859 ns | 1.01x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 |  11.41 ns | 0.068 ns | 0.061 ns | 3.51x faster |   0.06x |      - |         - |          NA |
|               LinqFaster | .NET 8.0 |   100 |  10.77 ns | 0.112 ns | 0.105 ns | 3.72x faster |   0.07x |      - |         - |          NA |
|          LinqFaster_SIMD | .NET 8.0 |   100 |  18.63 ns | 0.079 ns | 0.066 ns | 2.15x faster |   0.04x |      - |         - |          NA |
|             LinqFasterer | .NET 8.0 |   100 |  12.07 ns | 0.251 ns | 0.210 ns | 3.32x faster |   0.08x |      - |         - |          NA |
|                   LinqAF | .NET 8.0 |   100 |  14.73 ns | 0.209 ns | 0.163 ns | 2.72x faster |   0.06x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 |  74.59 ns | 1.419 ns | 1.258 ns | 1.86x slower |   0.05x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  44.51 ns | 0.651 ns | 0.723 ns | 1.11x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |  17.33 ns | 0.248 ns | 0.207 ns | 2.31x faster |   0.04x | 0.0153 |      32 B |          NA |
|           Hyperlinq_SIMD | .NET 8.0 |   100 |  11.50 ns | 0.235 ns | 0.208 ns | 3.48x faster |   0.08x |      - |         - |          NA |
|                  Faslinq | .NET 8.0 |   100 |  75.54 ns | 0.853 ns | 0.666 ns | 1.89x slower |   0.03x | 0.0305 |      64 B |          NA |
