## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|                  ForLoop | .NET 6.0 |   100 |  82.58 ns | 0.371 ns | 0.289 ns |  82.52 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6.0 |   100 | 136.45 ns | 1.901 ns | 2.189 ns | 135.68 ns | 1.65x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 6.0 |   100 | 614.57 ns | 8.229 ns | 6.425 ns | 611.50 ns | 7.44x slower |   0.08x | 0.0191 |      40 B |          NA |
|               LinqFaster | .NET 6.0 |   100 |  82.33 ns | 0.429 ns | 0.335 ns |  82.30 ns | 1.00x faster |   0.00x |      - |         - |          NA |
|             LinqFasterer | .NET 6.0 |   100 |  99.77 ns | 1.862 ns | 3.542 ns |  98.92 ns | 1.19x slower |   0.05x | 0.2027 |     424 B |          NA |
|                   LinqAF | .NET 6.0 |   100 | 255.00 ns | 1.516 ns | 1.418 ns | 254.82 ns | 3.09x slower |   0.02x |      - |         - |          NA |
|               StructLinq | .NET 6.0 |   100 |  71.52 ns | 0.220 ns | 0.172 ns |  71.54 ns | 1.15x faster |   0.00x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6.0 |   100 |  59.84 ns | 0.125 ns | 0.104 ns |  59.81 ns | 1.38x faster |   0.01x |      - |         - |          NA |
|                Hyperlinq | .NET 6.0 |   100 |  21.55 ns | 0.371 ns | 0.329 ns |  21.46 ns | 3.83x faster |   0.07x |      - |         - |          NA |
|                          |          |       |           |          |          |           |              |         |        |           |             |
|                  ForLoop | .NET 8.0 |   100 |  58.82 ns | 1.173 ns | 1.440 ns |  58.22 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8.0 |   100 |  65.40 ns | 0.309 ns | 0.241 ns |  65.38 ns | 1.10x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 8.0 |   100 |  14.39 ns | 0.097 ns | 0.076 ns |  14.38 ns | 4.13x faster |   0.12x |      - |         - |          NA |
|               LinqFaster | .NET 8.0 |   100 |  83.40 ns | 1.659 ns | 2.771 ns |  82.10 ns | 1.43x slower |   0.06x |      - |         - |          NA |
|             LinqFasterer | .NET 8.0 |   100 |  91.55 ns | 0.868 ns | 0.812 ns |  91.46 ns | 1.55x slower |   0.05x | 0.2027 |     424 B |          NA |
|                   LinqAF | .NET 8.0 |   100 | 253.20 ns | 0.925 ns | 0.990 ns | 253.13 ns | 4.29x slower |   0.11x |      - |         - |          NA |
|               StructLinq | .NET 8.0 |   100 |  57.31 ns | 0.342 ns | 0.320 ns |  57.24 ns | 1.03x faster |   0.03x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 |   100 |  46.14 ns | 0.907 ns | 1.329 ns |  45.77 ns | 1.28x faster |   0.06x |      - |         - |          NA |
|                Hyperlinq | .NET 8.0 |   100 |  11.00 ns | 0.246 ns | 0.361 ns |  10.85 ns | 5.32x faster |   0.23x |      - |         - |          NA |
