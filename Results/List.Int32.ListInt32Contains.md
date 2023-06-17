## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|                  ForLoop | .NET 6 | .NET 6.0 |   100 | 112.03 ns | 2.161 ns | 2.885 ns | 110.66 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 | 169.39 ns | 3.403 ns | 7.029 ns | 165.76 ns | 1.53x slower |   0.09x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 |  33.65 ns | 0.301 ns | 0.334 ns |  33.60 ns | 3.34x faster |   0.10x |      - |         - |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |  35.66 ns | 0.637 ns | 0.532 ns |  35.40 ns | 3.12x faster |   0.08x |      - |         - |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |  70.29 ns | 1.010 ns | 0.945 ns |  70.05 ns | 1.59x faster |   0.05x | 0.2027 |     424 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |  32.23 ns | 0.191 ns | 0.169 ns |  32.25 ns | 3.46x faster |   0.08x |      - |         - |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |  76.81 ns | 0.608 ns | 0.475 ns |  76.84 ns | 1.45x faster |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |  64.24 ns | 0.740 ns | 0.577 ns |  64.05 ns | 1.73x faster |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |  37.88 ns | 0.973 ns | 2.679 ns |  36.52 ns | 2.93x faster |   0.23x | 0.0153 |      32 B |          NA |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |   100 |  25.18 ns | 0.498 ns | 0.885 ns |  24.69 ns | 4.46x faster |   0.15x |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 223.22 ns | 3.085 ns | 3.168 ns | 221.88 ns | 1.99x slower |   0.06x | 0.0305 |      64 B |          NA |
|                          |        |          |       |           |          |          |           |              |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |  83.97 ns | 1.451 ns | 1.212 ns |  83.48 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |  73.90 ns | 0.723 ns | 0.564 ns |  73.71 ns | 1.14x faster |   0.02x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |  11.77 ns | 0.130 ns | 0.159 ns |  11.73 ns | 7.14x faster |   0.11x |      - |         - |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |  15.13 ns | 0.300 ns | 0.346 ns |  14.99 ns | 5.52x faster |   0.12x |      - |         - |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |  43.45 ns | 0.452 ns | 0.377 ns |  43.30 ns | 1.93x faster |   0.03x | 0.2027 |     424 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |  12.76 ns | 0.140 ns | 0.117 ns |  12.73 ns | 6.58x faster |   0.12x |      - |         - |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |  56.27 ns | 0.711 ns | 0.665 ns |  56.18 ns | 1.50x faster |   0.02x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |  60.78 ns | 0.428 ns | 0.334 ns |  60.77 ns | 1.38x faster |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |  19.03 ns | 0.298 ns | 0.249 ns |  19.03 ns | 4.41x faster |   0.07x | 0.0153 |      32 B |          NA |
|           Hyperlinq_SIMD | .NET 8 | .NET 8.0 |   100 |  13.28 ns | 0.279 ns | 0.353 ns |  13.12 ns | 6.29x faster |   0.21x |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 | 146.90 ns | 1.883 ns | 1.572 ns | 146.47 ns | 1.75x slower |   0.02x | 0.0305 |      64 B |          NA |
