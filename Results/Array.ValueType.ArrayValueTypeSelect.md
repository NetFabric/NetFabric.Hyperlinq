## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                   Method |           Job | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |   100 |  1.574 μs | 0.0043 μs | 0.0040 μs |  1.572 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop |        .NET 6 |   100 |  1.685 μs | 0.0030 μs | 0.0028 μs |  1.684 μs |  1.07x slower |   0.00x |       - |       - |         - |
|                     Linq |        .NET 6 |   100 |  2.499 μs | 0.0039 μs | 0.0033 μs |  2.498 μs |  1.59x slower |   0.00x |  0.0496 |       - |     104 B |
|               LinqFaster |        .NET 6 |   100 |  2.447 μs | 0.0126 μs | 0.0105 μs |  2.444 μs |  1.56x slower |   0.01x |  3.0670 |       - |   6,424 B |
|             LinqFasterer |        .NET 6 |   100 |  2.840 μs | 0.0089 μs | 0.0083 μs |  2.837 μs |  1.80x slower |   0.01x |  3.0861 |       - |   6,456 B |
|                   LinqAF |        .NET 6 |   100 |  2.746 μs | 0.0111 μs | 0.0098 μs |  2.741 μs |  1.74x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 11.009 μs | 0.0681 μs | 0.0604 μs | 10.999 μs |  7.00x slower |   0.04x | 50.0031 | 16.6626 | 137,767 B |
|                 SpanLinq |        .NET 6 |   100 |  2.280 μs | 0.0081 μs | 0.0076 μs |  2.276 μs |  1.45x slower |   0.01x |       - |       - |         - |
|                  Streams |        .NET 6 |   100 |  3.834 μs | 0.0142 μs | 0.0133 μs |  3.826 μs |  2.44x slower |   0.01x |  0.3891 |       - |     824 B |
|               StructLinq |        .NET 6 |   100 |  1.920 μs | 0.0065 μs | 0.0054 μs |  1.919 μs |  1.22x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |  1.883 μs | 0.0037 μs | 0.0034 μs |  1.882 μs |  1.20x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 |   100 |  1.939 μs | 0.0016 μs | 0.0013 μs |  1.939 μs |  1.23x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |  1.772 μs | 0.0049 μs | 0.0046 μs |  1.771 μs |  1.13x slower |   0.00x |       - |       - |         - |
|                          |               |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO |   100 |  1.516 μs | 0.0033 μs | 0.0031 μs |  1.515 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |  1.626 μs | 0.0025 μs | 0.0022 μs |  1.625 μs |  1.07x slower |   0.00x |       - |       - |         - |
|                     Linq |    .NET 6 PGO |   100 |  2.262 μs | 0.0083 μs | 0.0074 μs |  2.260 μs |  1.49x slower |   0.01x |  0.0496 |       - |     104 B |
|               LinqFaster |    .NET 6 PGO |   100 |  2.423 μs | 0.0126 μs | 0.0118 μs |  2.422 μs |  1.60x slower |   0.01x |  3.0670 |       - |   6,424 B |
|             LinqFasterer |    .NET 6 PGO |   100 |  2.711 μs | 0.0056 μs | 0.0044 μs |  2.711 μs |  1.79x slower |   0.01x |  3.0861 |       - |   6,456 B |
|                   LinqAF |    .NET 6 PGO |   100 |  2.711 μs | 0.0075 μs | 0.0070 μs |  2.709 μs |  1.79x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 10.886 μs | 0.1416 μs | 0.1255 μs | 10.906 μs |  7.18x slower |   0.09x | 50.0031 | 16.6626 | 137,767 B |
|                 SpanLinq |    .NET 6 PGO |   100 |  2.220 μs | 0.0017 μs | 0.0013 μs |  2.220 μs |  1.46x slower |   0.00x |       - |       - |         - |
|                  Streams |    .NET 6 PGO |   100 |  3.356 μs | 0.0165 μs | 0.0154 μs |  3.350 μs |  2.21x slower |   0.01x |  0.3929 |       - |     824 B |
|               StructLinq |    .NET 6 PGO |   100 |  1.882 μs | 0.0042 μs | 0.0039 μs |  1.881 μs |  1.24x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |  1.710 μs | 0.0026 μs | 0.0023 μs |  1.709 μs |  1.13x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |  1.913 μs | 0.0068 μs | 0.0060 μs |  1.909 μs |  1.26x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |  1.798 μs | 0.0047 μs | 0.0044 μs |  1.797 μs |  1.19x slower |   0.00x |       - |       - |         - |
|                          |               |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 |   100 |  1.775 μs | 0.0039 μs | 0.0034 μs |  1.774 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |  1.915 μs | 0.0010 μs | 0.0008 μs |  1.915 μs |  1.08x slower |   0.00x |       - |       - |         - |
|                     Linq | .NET Core 3.1 |   100 |  2.642 μs | 0.0076 μs | 0.0071 μs |  2.640 μs |  1.49x slower |   0.00x |  0.0496 |       - |     104 B |
|               LinqFaster | .NET Core 3.1 |   100 |  2.571 μs | 0.0112 μs | 0.0105 μs |  2.566 μs |  1.45x slower |   0.01x |  3.0670 |       - |   6,424 B |
|             LinqFasterer | .NET Core 3.1 |   100 |  2.912 μs | 0.0146 μs | 0.0130 μs |  2.907 μs |  1.64x slower |   0.01x |  3.0861 |       - |   6,456 B |
|                   LinqAF | .NET Core 3.1 |   100 |  3.670 μs | 0.0092 μs | 0.0086 μs |  3.667 μs |  2.07x slower |   0.00x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 26.676 μs | 1.3746 μs | 3.9659 μs | 28.022 μs | 13.93x slower |   3.18x | 49.9878 | 16.6626 | 137,799 B |
|                 SpanLinq | .NET Core 3.1 |   100 |  2.545 μs | 0.0089 μs | 0.0083 μs |  2.541 μs |  1.43x slower |   0.01x |       - |       - |         - |
|                  Streams | .NET Core 3.1 |   100 |  4.022 μs | 0.0203 μs | 0.0190 μs |  4.013 μs |  2.27x slower |   0.01x |  0.3891 |       - |     824 B |
|               StructLinq | .NET Core 3.1 |   100 |  2.079 μs | 0.0011 μs | 0.0009 μs |  2.079 μs |  1.17x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |  2.042 μs | 0.0026 μs | 0.0021 μs |  2.041 μs |  1.15x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |  2.258 μs | 0.0071 μs | 0.0066 μs |  2.257 μs |  1.27x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |  1.971 μs | 0.0027 μs | 0.0021 μs |  1.970 μs |  1.11x slower |   0.00x |       - |       - |         - |
