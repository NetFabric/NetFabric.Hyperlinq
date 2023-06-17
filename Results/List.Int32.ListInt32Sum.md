## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|                   Method |    Job |  Runtime | Count |        Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |------------:|----------:|----------:|----------:|--------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |    84.80 ns |  0.906 ns |  0.969 ns |  84.47 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   138.30 ns |  1.191 ns |  0.995 ns | 137.93 ns |  1.63x slower |   0.02x |      - |         - |          NA |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   657.65 ns | 13.091 ns | 14.007 ns | 649.01 ns |  7.76x slower |   0.18x | 0.0191 |      40 B |          NA |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |    78.36 ns |  0.842 ns |  0.703 ns |  78.12 ns |  1.08x faster |   0.02x |      - |         - |          NA |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |    96.25 ns |  1.288 ns |  1.265 ns |  95.83 ns |  1.13x slower |   0.02x | 0.2027 |     424 B |          NA |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 |   259.37 ns |  4.807 ns |  4.261 ns | 257.79 ns |  3.06x slower |   0.07x |      - |         - |          NA |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,001.37 ns | 16.641 ns | 13.896 ns | 995.71 ns | 11.79x slower |   0.26x | 0.0305 |      64 B |          NA |
|                  Streams | .NET 6 | .NET 6.0 |   100 |   342.93 ns |  3.182 ns |  2.484 ns | 342.00 ns |  4.04x slower |   0.07x | 0.0992 |     208 B |          NA |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |    73.69 ns |  1.448 ns |  1.778 ns |  72.93 ns |  1.15x faster |   0.03x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |    61.70 ns |  1.214 ns |  1.192 ns |  61.34 ns |  1.38x faster |   0.03x |      - |         - |          NA |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |    21.46 ns |  0.104 ns |  0.081 ns |  21.46 ns |  3.96x faster |   0.06x |      - |         - |          NA |
|                          |        |          |       |             |           |           |           |               |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |    59.24 ns |  1.218 ns |  1.747 ns |  58.58 ns |      baseline |         |      - |         - |          NA |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |    67.33 ns |  0.380 ns |  0.317 ns |  67.32 ns |  1.13x slower |   0.04x |      - |         - |          NA |
|                     Linq | .NET 8 | .NET 8.0 |   100 |    16.44 ns |  0.355 ns |  0.277 ns |  16.34 ns |  3.61x faster |   0.11x |      - |         - |          NA |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |    80.78 ns |  1.567 ns |  3.506 ns |  79.03 ns |  1.38x slower |   0.08x |      - |         - |          NA |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |    92.82 ns |  1.249 ns |  1.388 ns |  92.82 ns |  1.56x slower |   0.05x | 0.2027 |     424 B |          NA |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   260.15 ns |  1.244 ns |  0.972 ns | 260.07 ns |  4.38x slower |   0.12x |      - |         - |          NA |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 |   958.74 ns | 12.450 ns | 11.037 ns | 957.19 ns | 16.02x slower |   0.67x | 0.0305 |      64 B |          NA |
|                  Streams | .NET 8 | .NET 8.0 |   100 |   251.53 ns |  4.553 ns |  8.092 ns | 247.99 ns |  4.29x slower |   0.21x | 0.0992 |     208 B |          NA |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |    58.33 ns |  0.400 ns |  0.354 ns |  58.30 ns |  1.03x faster |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |    45.02 ns |  0.523 ns |  0.559 ns |  44.82 ns |  1.33x faster |   0.04x |      - |         - |          NA |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |    11.75 ns |  0.382 ns |  1.125 ns |  11.12 ns |  5.13x faster |   0.50x |      - |         - |          NA |
