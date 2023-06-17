## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|                   Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |  44.68 ns |  0.860 ns |  1.593 ns |  43.88 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |  45.38 ns |  0.923 ns |  1.263 ns |  44.76 ns |  1.01x slower |   0.05x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 | 442.63 ns |  6.545 ns |  5.802 ns | 440.81 ns |  9.99x slower |   0.25x | 0.0267 |      56 B |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 | 109.86 ns |  2.664 ns |  7.687 ns | 105.46 ns |  2.47x slower |   0.20x | 0.2142 |     448 B |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 647.46 ns |  4.707 ns |  5.231 ns | 645.86 ns | 14.43x slower |   0.59x | 0.0267 |      56 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 729.03 ns | 14.251 ns | 18.022 ns | 722.38 ns | 16.27x slower |   0.74x | 0.1259 |     264 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 115.54 ns |  1.501 ns |  1.253 ns | 115.08 ns |  2.60x slower |   0.07x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |  61.00 ns |  1.080 ns |  1.109 ns |  60.54 ns |  1.37x slower |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |  21.59 ns |  0.277 ns |  0.259 ns |  21.49 ns |  2.06x faster |   0.07x |      - |         - |          NA |
|                          |        |          |       |           |           |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |  39.62 ns |  0.213 ns |  0.166 ns |  39.62 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |  40.08 ns |  0.818 ns |  2.154 ns |  39.00 ns |  1.02x slower |   0.05x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 | 180.95 ns |  2.868 ns |  3.188 ns | 179.97 ns |  4.58x slower |   0.10x | 0.0267 |      56 B |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 | 100.16 ns |  0.868 ns |  0.770 ns |  99.82 ns |  2.53x slower |   0.02x | 0.2141 |     448 B |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 530.86 ns |  7.142 ns |  5.576 ns | 529.75 ns | 13.40x slower |   0.15x | 0.0267 |      56 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 473.79 ns |  9.517 ns | 27.761 ns | 455.53 ns | 12.03x slower |   0.78x | 0.1259 |     264 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 | 115.83 ns |  1.743 ns |  1.545 ns | 115.24 ns |  2.92x slower |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |  87.61 ns |  1.774 ns |  4.215 ns |  85.49 ns |  2.26x slower |   0.12x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |  10.62 ns |  0.207 ns |  0.254 ns |  10.54 ns |  3.74x faster |   0.07x |      - |         - |          NA |
