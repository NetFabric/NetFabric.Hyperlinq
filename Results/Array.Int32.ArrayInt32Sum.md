## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-preview.5.23303.2
  [Host] : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 6 : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 8 : .NET 8.0.0 (8.0.23.28008), X64 RyuJIT AVX2


```
|                   Method |    Job |  Runtime | Count |      Mean |    Error |   StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |  44.66 ns | 0.895 ns | 2.229 ns |  43.40 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |  43.72 ns | 0.423 ns | 0.330 ns |  43.71 ns | 1.05x faster |   0.07x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 411.10 ns | 2.299 ns | 1.919 ns | 410.96 ns | 9.04x slower |   0.50x | 0.0153 |      32 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |  51.46 ns | 1.063 ns | 2.705 ns |  49.90 ns | 1.16x slower |   0.10x |      - |         - |          NA |
|          LinqFaster_SIMD | .NET 6 | .NET 6.0 |   100 |  12.43 ns | 0.116 ns | 0.114 ns |  12.41 ns | 3.63x faster |   0.21x |      - |         - |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |  61.17 ns | 0.399 ns | 0.354 ns |  61.14 ns | 1.35x slower |   0.08x |      - |         - |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 201.79 ns | 1.244 ns | 1.222 ns | 201.46 ns | 4.48x slower |   0.24x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 425.83 ns | 2.631 ns | 2.197 ns | 425.92 ns | 9.37x slower |   0.51x | 0.0114 |      24 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 275.72 ns | 4.435 ns | 3.703 ns | 275.27 ns | 6.07x slower |   0.35x | 0.0992 |     208 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |  72.20 ns | 0.423 ns | 0.354 ns |  72.18 ns | 1.59x slower |   0.09x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |  60.71 ns | 0.236 ns | 0.197 ns |  60.64 ns | 1.34x slower |   0.08x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |  22.97 ns | 0.491 ns | 1.046 ns |  22.37 ns | 1.95x faster |   0.09x |      - |         - |          NA |
|                          |        |          |       |           |          |          |           |              |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |  40.33 ns | 0.818 ns | 0.909 ns |  39.90 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |  40.35 ns | 0.825 ns | 0.731 ns |  39.97 ns | 1.00x slower |   0.03x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |  17.82 ns | 0.339 ns | 0.452 ns |  17.62 ns | 2.25x faster |   0.06x |      - |         - |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |  43.31 ns | 0.291 ns | 0.323 ns |  43.19 ns | 1.07x slower |   0.02x |      - |         - |          NA |
|          LinqFaster_SIMD | .NET 8 | .NET 8.0 |   100 |  13.49 ns | 0.130 ns | 0.109 ns |  13.46 ns | 2.99x faster |   0.08x |      - |         - |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |  88.00 ns | 1.693 ns | 3.753 ns |  85.87 ns | 2.19x slower |   0.12x |      - |         - |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 222.32 ns | 1.096 ns | 0.856 ns | 222.31 ns | 5.51x slower |   0.14x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 267.97 ns | 1.506 ns | 1.258 ns | 267.40 ns | 6.64x slower |   0.16x | 0.0114 |      24 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 245.27 ns | 1.284 ns | 1.003 ns | 245.19 ns | 6.08x slower |   0.17x | 0.0992 |     208 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |  58.06 ns | 0.350 ns | 0.292 ns |  57.99 ns | 1.44x slower |   0.03x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |  84.51 ns | 0.473 ns | 0.369 ns |  84.52 ns | 2.10x slower |   0.05x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |  11.26 ns | 0.244 ns | 0.536 ns |  10.98 ns | 3.54x faster |   0.21x |      - |         - |          NA |
