## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                   Method |           Job | Skip | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 | 1000 |   100 |  1.600 μs | 0.0044 μs | 0.0039 μs |  1.599 μs |      baseline |         |       - |       - |         - |
|                     Linq |        .NET 6 | 1000 |   100 |  2.901 μs | 0.0071 μs | 0.0066 μs |  2.898 μs |  1.81x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster |        .NET 6 | 1000 |   100 |  3.492 μs | 0.0147 μs | 0.0138 μs |  3.489 μs |  2.18x slower |   0.00x |  9.2010 |       - |  19,272 B |
|             LinqFasterer |        .NET 6 | 1000 |   100 |  3.553 μs | 0.0151 μs | 0.0142 μs |  3.556 μs |  2.22x slower |   0.01x |  6.1531 |       - |  12,880 B |
|                   LinqAF |        .NET 6 | 1000 |   100 |  7.873 μs | 0.0330 μs | 0.0275 μs |  7.869 μs |  4.92x slower |   0.02x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 | 1000 |   100 | 13.141 μs | 0.0844 μs | 0.0790 μs | 13.109 μs |  8.22x slower |   0.06x | 50.0031 | 16.6626 | 137,767 B |
|                 SpanLinq |        .NET 6 | 1000 |   100 |  2.264 μs | 0.0027 μs | 0.0021 μs |  2.264 μs |  1.41x slower |   0.00x |       - |       - |         - |
|                  Streams |        .NET 6 | 1000 |   100 | 12.637 μs | 0.0559 μs | 0.0523 μs | 12.609 μs |  7.89x slower |   0.03x |  0.5493 |       - |   1,152 B |
|               StructLinq |        .NET 6 | 1000 |   100 |  1.947 μs | 0.0025 μs | 0.0019 μs |  1.946 μs |  1.22x slower |   0.00x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate |        .NET 6 | 1000 |   100 |  1.856 μs | 0.0042 μs | 0.0035 μs |  1.855 μs |  1.16x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 | 1000 |   100 |  1.959 μs | 0.0059 μs | 0.0053 μs |  1.958 μs |  1.22x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 | 1000 |   100 |  1.787 μs | 0.0047 μs | 0.0044 μs |  1.787 μs |  1.12x slower |   0.00x |       - |       - |         - |
|                          |               |      |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | 1000 |   100 |  1.543 μs | 0.0039 μs | 0.0035 μs |  1.543 μs |      baseline |         |       - |       - |         - |
|                     Linq |    .NET 6 PGO | 1000 |   100 |  2.558 μs | 0.0061 μs | 0.0057 μs |  2.557 μs |  1.66x slower |   0.00x |  0.1526 |       - |     320 B |
|               LinqFaster |    .NET 6 PGO | 1000 |   100 |  3.481 μs | 0.0206 μs | 0.0193 μs |  3.475 μs |  2.26x slower |   0.01x |  9.2010 |       - |  19,272 B |
|             LinqFasterer |    .NET 6 PGO | 1000 |   100 |  3.512 μs | 0.0524 μs | 0.0464 μs |  3.494 μs |  2.28x slower |   0.03x |  6.1531 |       - |  12,880 B |
|                   LinqAF |    .NET 6 PGO | 1000 |   100 |  7.969 μs | 0.0479 μs | 0.0425 μs |  7.962 μs |  5.16x slower |   0.03x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | 1000 |   100 | 13.260 μs | 0.2393 μs | 0.3112 μs | 13.193 μs |  8.64x slower |   0.23x | 50.0031 | 16.6626 | 137,767 B |
|                 SpanLinq |    .NET 6 PGO | 1000 |   100 |  2.237 μs | 0.0076 μs | 0.0068 μs |  2.234 μs |  1.45x slower |   0.01x |       - |       - |         - |
|                  Streams |    .NET 6 PGO | 1000 |   100 | 10.109 μs | 0.0410 μs | 0.0363 μs | 10.095 μs |  6.55x slower |   0.03x |  0.5493 |       - |   1,152 B |
|               StructLinq |    .NET 6 PGO | 1000 |   100 |  1.911 μs | 0.0026 μs | 0.0021 μs |  1.911 μs |  1.24x slower |   0.00x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |  1.655 μs | 0.0030 μs | 0.0025 μs |  1.654 μs |  1.07x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | 1000 |   100 |  1.928 μs | 0.0043 μs | 0.0036 μs |  1.926 μs |  1.25x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |  1.816 μs | 0.0034 μs | 0.0032 μs |  1.815 μs |  1.18x slower |   0.00x |       - |       - |         - |
|                          |               |      |       |           |           |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 | 1000 |   100 |  1.802 μs | 0.0033 μs | 0.0028 μs |  1.801 μs |      baseline |         |       - |       - |         - |
|                     Linq | .NET Core 3.1 | 1000 |   100 |  3.038 μs | 0.0094 μs | 0.0083 μs |  3.038 μs |  1.69x slower |   0.00x |  0.1526 |       - |     320 B |
|               LinqFaster | .NET Core 3.1 | 1000 |   100 |  3.524 μs | 0.0199 μs | 0.0176 μs |  3.515 μs |  1.96x slower |   0.01x |  9.2010 |       - |  19,272 B |
|             LinqFasterer | .NET Core 3.1 | 1000 |   100 |  3.569 μs | 0.0173 μs | 0.0162 μs |  3.567 μs |  1.98x slower |   0.01x |  6.1531 |       - |  12,880 B |
|                   LinqAF | .NET Core 3.1 | 1000 |   100 |  9.499 μs | 0.0103 μs | 0.0081 μs |  9.499 μs |  5.27x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 | 1000 |   100 | 27.457 μs | 1.3645 μs | 3.7123 μs | 28.755 μs | 13.77x slower |   3.12x | 49.9878 | 16.6626 | 137,799 B |
|                 SpanLinq | .NET Core 3.1 | 1000 |   100 |  2.560 μs | 0.0060 μs | 0.0056 μs |  2.558 μs |  1.42x slower |   0.00x |       - |       - |         - |
|                  Streams | .NET Core 3.1 | 1000 |   100 | 13.976 μs | 0.0995 μs | 0.0831 μs | 13.964 μs |  7.76x slower |   0.04x |  0.5493 |       - |   1,152 B |
|               StructLinq | .NET Core 3.1 | 1000 |   100 |  2.223 μs | 0.0063 μs | 0.0056 μs |  2.220 μs |  1.23x slower |   0.00x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |  1.968 μs | 0.0004 μs | 0.0004 μs |  1.968 μs |  1.09x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 | 1000 |   100 |  2.278 μs | 0.0052 μs | 0.0046 μs |  2.278 μs |  1.26x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |  1.994 μs | 0.0013 μs | 0.0010 μs |  1.994 μs |  1.11x slower |   0.00x |       - |       - |         - |
