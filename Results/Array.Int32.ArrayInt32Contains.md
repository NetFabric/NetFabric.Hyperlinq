## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|                   Method |    Job |  Runtime | Count |      Mean |    Error |    StdDev |    Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |  41.02 ns | 0.530 ns |  0.567 ns |  40.80 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |  40.35 ns | 0.375 ns |  0.293 ns |  40.28 ns | 1.02x faster |   0.02x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 |  33.52 ns | 0.580 ns |  0.712 ns |  33.34 ns | 1.22x faster |   0.03x |      - |         - |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |  33.37 ns | 0.415 ns |  0.324 ns |  33.28 ns | 1.23x faster |   0.03x |      - |         - |          NA |
|          LinqFaster_SIMD | .NET 6 | .NET 6.0 |   100 |  11.62 ns | 0.257 ns |  0.423 ns |  11.39 ns | 3.54x faster |   0.11x |      - |         - |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |  29.13 ns | 0.213 ns |  0.178 ns |  29.11 ns | 1.41x faster |   0.03x |      - |         - |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |  33.28 ns | 0.326 ns |  0.272 ns |  33.18 ns | 1.23x faster |   0.02x |      - |         - |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 | 100.69 ns | 2.025 ns |  4.891 ns |  98.08 ns | 2.44x slower |   0.10x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |  50.37 ns | 0.259 ns |  0.242 ns |  50.25 ns | 1.23x slower |   0.02x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |  35.30 ns | 0.595 ns |  0.731 ns |  35.03 ns | 1.16x faster |   0.03x | 0.0153 |      32 B |          NA |
|           Hyperlinq_SIMD | .NET 6 | .NET 6.0 |   100 |  24.86 ns | 0.486 ns |  0.521 ns |  24.65 ns | 1.65x faster |   0.04x |      - |         - |          NA |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 | 203.15 ns | 4.782 ns | 13.797 ns | 195.02 ns | 5.00x slower |   0.32x | 0.0305 |      64 B |          NA |
|                          |        |          |       |           |          |           |           |              |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |  41.60 ns | 0.821 ns |  2.075 ns |  40.52 ns |     baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |  41.08 ns | 0.805 ns |  1.322 ns |  40.48 ns | 1.02x faster |   0.07x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |  12.16 ns | 0.275 ns |  0.706 ns |  11.80 ns | 3.43x faster |   0.26x |      - |         - |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |  10.66 ns | 0.266 ns |  0.777 ns |  10.19 ns | 3.94x faster |   0.23x |      - |         - |          NA |
|          LinqFaster_SIMD | .NET 8 | .NET 8.0 |   100 |  19.11 ns | 0.394 ns |  1.017 ns |  18.59 ns | 2.18x faster |   0.14x |      - |         - |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |  12.19 ns | 0.093 ns |  0.082 ns |  12.18 ns | 3.50x faster |   0.24x |      - |         - |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |  15.42 ns | 0.272 ns |  0.415 ns |  15.31 ns | 2.73x faster |   0.15x |      - |         - |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |  73.78 ns | 1.476 ns |  1.308 ns |  73.36 ns | 1.73x slower |   0.12x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |  45.67 ns | 0.748 ns |  0.663 ns |  45.45 ns | 1.07x slower |   0.07x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |  17.53 ns | 0.372 ns |  0.382 ns |  17.37 ns | 2.41x faster |   0.14x | 0.0153 |      32 B |          NA |
|           Hyperlinq_SIMD | .NET 8 | .NET 8.0 |   100 |  12.40 ns | 0.276 ns |  0.387 ns |  12.30 ns | 3.40x faster |   0.23x |      - |         - |          NA |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |  79.15 ns | 1.778 ns |  5.131 ns |  76.50 ns | 1.91x slower |   0.14x | 0.0305 |      64 B |          NA |
