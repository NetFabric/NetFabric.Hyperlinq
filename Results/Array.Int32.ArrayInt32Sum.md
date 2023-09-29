## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|                   Method |  Runtime | Count |      Mean |    Error |   StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6.0 |   100 |  42.83 ns | 0.384 ns | 0.299 ns |  42.67 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 |  42.65 ns | 0.140 ns | 0.109 ns |  42.61 ns | 1.00x faster |   0.01x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 407.88 ns | 3.421 ns | 2.671 ns | 407.23 ns | 9.52x slower |   0.09x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 6.0 |   100 |  49.29 ns | 0.609 ns | 0.598 ns |  49.08 ns | 1.15x slower |   0.02x |      - |         - |          NA |
|          LinqFaster_SIMD | .NET 6.0 |   100 |  10.58 ns | 0.192 ns | 0.213 ns |  10.53 ns | 4.04x faster |   0.10x |      - |         - |          NA |
|             LinqFasterer | .NET 6.0 |   100 |  60.21 ns | 0.275 ns | 0.257 ns |  60.14 ns | 1.41x slower |   0.01x |      - |         - |          NA |
|                   LinqAF | .NET 6.0 |   100 | 198.41 ns | 1.526 ns | 1.353 ns | 198.20 ns | 4.64x slower |   0.04x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 |  73.14 ns | 1.289 ns | 1.142 ns |  72.65 ns | 1.71x slower |   0.03x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |  61.21 ns | 0.284 ns | 0.237 ns |  61.16 ns | 1.43x slower |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 |  20.42 ns | 0.097 ns | 0.076 ns |  20.40 ns | 2.10x faster |   0.02x |      - |         - |          NA |
|                          |          |       |           |          |          |           |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  39.82 ns | 0.597 ns | 0.664 ns |  39.65 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  39.74 ns | 0.386 ns | 0.459 ns |  39.63 ns | 1.00x faster |   0.02x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 |  16.29 ns | 0.056 ns | 0.047 ns |  16.29 ns | 2.45x faster |   0.04x |      - |         - |          NA |
|               LinqFaster | .NET 8.0 |   100 |  42.49 ns | 0.700 ns | 0.886 ns |  42.18 ns | 1.07x slower |   0.03x |      - |         - |          NA |
|          LinqFaster_SIMD | .NET 8.0 |   100 |  15.31 ns | 0.116 ns | 0.090 ns |  15.32 ns | 2.60x faster |   0.04x |      - |         - |          NA |
|             LinqFasterer | .NET 8.0 |   100 |  84.82 ns | 1.295 ns | 2.234 ns |  83.81 ns | 2.13x slower |   0.05x |      - |         - |          NA |
|                   LinqAF | .NET 8.0 |   100 | 218.00 ns | 4.226 ns | 3.747 ns | 216.18 ns | 5.46x slower |   0.15x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 |  58.55 ns | 0.484 ns | 0.378 ns |  58.46 ns | 1.47x slower |   0.03x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  83.25 ns | 0.356 ns | 0.278 ns |  83.15 ns | 2.09x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |  11.47 ns | 0.260 ns | 0.652 ns |  11.18 ns | 3.43x faster |   0.21x |      - |         - |          NA |
