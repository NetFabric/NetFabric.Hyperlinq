## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 |    61.81 ns |  0.106 ns |  0.088 ns |      baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |    61.85 ns |  0.204 ns |  0.191 ns |  1.00x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |   100 |   726.04 ns |  3.063 ns |  2.865 ns | 11.75x slower |   0.05x | 0.0229 |      48 B |
|               LinqFaster |        .NET 6 |   100 |   285.21 ns |  2.525 ns |  2.238 ns |  4.62x slower |   0.04x | 0.2027 |     424 B |
|          LinqFaster_SIMD |        .NET 6 |   100 |   127.20 ns |  1.118 ns |  0.991 ns |  2.06x slower |   0.02x | 0.2027 |     424 B |
|             LinqFasterer |        .NET 6 |   100 |   775.29 ns |  2.814 ns |  2.494 ns | 12.54x slower |   0.05x | 0.2174 |     456 B |
|                   LinqAF |        .NET 6 |   100 |   294.55 ns |  1.048 ns |  0.929 ns |  4.76x slower |   0.02x |      - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 2,234.04 ns | 19.187 ns | 17.947 ns | 36.12x slower |   0.29x | 4.2343 |   8,866 B |
|                 SpanLinq |        .NET 6 |   100 |   232.98 ns |  0.819 ns |  0.766 ns |  3.77x slower |   0.01x |      - |         - |
|                  Streams |        .NET 6 |   100 | 1,722.31 ns | 13.804 ns | 12.912 ns | 27.89x slower |   0.23x | 0.2785 |     584 B |
|               StructLinq |        .NET 6 |   100 |   229.15 ns |  0.910 ns |  0.852 ns |  3.71x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   174.89 ns |  0.319 ns |  0.298 ns |  2.83x slower |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |   225.57 ns |  0.613 ns |  0.543 ns |  3.65x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   195.24 ns |  0.392 ns |  0.366 ns |  3.16x slower |   0.01x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |    60.86 ns |  0.151 ns |  0.141 ns |      baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |    61.30 ns |  0.340 ns |  0.302 ns |  1.01x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |   435.30 ns |  1.342 ns |  1.255 ns |  7.15x slower |   0.03x | 0.0229 |      48 B |
|               LinqFaster |    .NET 6 PGO |   100 |   255.39 ns |  1.107 ns |  1.036 ns |  4.20x slower |   0.02x | 0.2027 |     424 B |
|          LinqFaster_SIMD |    .NET 6 PGO |   100 |   129.25 ns |  0.429 ns |  0.335 ns |  2.12x slower |   0.01x | 0.2027 |     424 B |
|             LinqFasterer |    .NET 6 PGO |   100 |   414.37 ns |  2.958 ns |  2.623 ns |  6.81x slower |   0.05x | 0.2179 |     456 B |
|                   LinqAF |    .NET 6 PGO |   100 |   297.34 ns |  1.593 ns |  1.412 ns |  4.89x slower |   0.03x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 1,834.71 ns | 13.550 ns | 12.011 ns | 30.14x slower |   0.19x | 4.2362 |   8,866 B |
|                 SpanLinq |    .NET 6 PGO |   100 |   278.29 ns |  1.165 ns |  1.033 ns |  4.57x slower |   0.02x |      - |         - |
|                  Streams |    .NET 6 PGO |   100 | 1,490.34 ns |  5.024 ns |  4.700 ns | 24.49x slower |   0.08x | 0.2785 |     584 B |
|               StructLinq |    .NET 6 PGO |   100 |   225.43 ns |  1.321 ns |  1.171 ns |  3.70x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   176.42 ns |  1.166 ns |  1.091 ns |  2.90x slower |   0.02x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |   255.28 ns |  0.296 ns |  0.231 ns |  4.19x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   200.77 ns |  0.574 ns |  0.479 ns |  3.30x slower |   0.01x |      - |         - |
|                          |               |       |             |           |           |               |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |    63.70 ns |  0.573 ns |  0.536 ns |      baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |    62.98 ns |  0.323 ns |  0.286 ns |  1.01x faster |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 |   729.72 ns |  3.691 ns |  2.882 ns | 11.44x slower |   0.13x | 0.0229 |      48 B |
|               LinqFaster | .NET Core 3.1 |   100 |   281.07 ns |  1.008 ns |  0.842 ns |  4.41x slower |   0.04x | 0.2027 |     424 B |
|          LinqFaster_SIMD | .NET Core 3.1 |   100 |   137.75 ns |  0.903 ns |  0.754 ns |  2.16x slower |   0.02x | 0.2027 |     424 B |
|             LinqFasterer | .NET Core 3.1 |   100 |   778.15 ns |  3.897 ns |  3.455 ns | 12.21x slower |   0.12x | 0.2174 |     456 B |
|                   LinqAF | .NET Core 3.1 |   100 |   576.29 ns |  3.245 ns |  2.877 ns |  9.04x slower |   0.07x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 2,207.37 ns | 24.723 ns | 23.126 ns | 34.65x slower |   0.43x | 4.2458 |   8,896 B |
|                 SpanLinq | .NET Core 3.1 |   100 |   429.80 ns |  1.160 ns |  1.085 ns |  6.75x slower |   0.05x |      - |         - |
|                  Streams | .NET Core 3.1 |   100 | 1,998.16 ns | 14.630 ns | 12.969 ns | 31.35x slower |   0.31x | 0.2785 |     584 B |
|               StructLinq | .NET Core 3.1 |   100 |   322.12 ns |  1.079 ns |  0.956 ns |  5.05x slower |   0.05x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   189.24 ns |  0.363 ns |  0.340 ns |  2.97x slower |   0.02x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |   284.09 ns |  1.356 ns |  1.202 ns |  4.46x slower |   0.04x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   206.48 ns |  0.229 ns |  0.215 ns |  3.24x slower |   0.03x |      - |         - |
