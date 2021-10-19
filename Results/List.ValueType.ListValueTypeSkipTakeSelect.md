## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                   Method |           Job | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |-------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 | 1000 |   100 |  1.708 μs | 0.0042 μs | 0.0039 μs |      baseline |         |       - |       - |         - |
|                     Linq |        .NET 6 | 1000 |   100 |  2.855 μs | 0.0092 μs | 0.0086 μs |  1.67x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster |        .NET 6 | 1000 |   100 |  4.927 μs | 0.0265 μs | 0.0221 μs |  2.89x slower |   0.01x |  9.2545 |       - |  19,368 B |
|             LinqFasterer |        .NET 6 | 1000 |   100 |  8.803 μs | 0.0861 μs | 0.0764 μs |  5.16x slower |   0.04x | 39.2151 |       - |  83,304 B |
|                   LinqAF |        .NET 6 | 1000 |   100 |  9.459 μs | 0.0720 μs | 0.0673 μs |  5.54x slower |   0.04x |       - |       - |         - |
|            LinqOptimizer |        .NET 6 | 1000 |   100 | 20.308 μs | 0.1432 μs | 0.1340 μs | 11.89x slower |   0.09x | 49.9878 | 16.6626 | 137,863 B |
|                  Streams |        .NET 6 | 1000 |   100 | 13.044 μs | 0.0624 μs | 0.0554 μs |  7.64x slower |   0.03x |  0.5493 |       - |   1,176 B |
|               StructLinq |        .NET 6 | 1000 |   100 |  1.950 μs | 0.0082 μs | 0.0073 μs |  1.14x slower |   0.01x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate |        .NET 6 | 1000 |   100 |  1.875 μs | 0.0035 μs | 0.0033 μs |  1.10x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |        .NET 6 | 1000 |   100 |  1.952 μs | 0.0077 μs | 0.0069 μs |  1.14x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 | 1000 |   100 |  1.781 μs | 0.0040 μs | 0.0036 μs |  1.04x slower |   0.00x |       - |       - |         - |
|                          |               |      |       |           |           |           |               |         |         |         |           |
|                  ForLoop |    .NET 6 PGO | 1000 |   100 |  1.652 μs | 0.0051 μs | 0.0045 μs |      baseline |         |       - |       - |         - |
|                     Linq |    .NET 6 PGO | 1000 |   100 |  2.347 μs | 0.0260 μs | 0.0243 μs |  1.42x slower |   0.02x |  0.1526 |       - |     320 B |
|               LinqFaster |    .NET 6 PGO | 1000 |   100 |  4.968 μs | 0.0976 μs | 0.1124 μs |  3.02x slower |   0.08x |  9.2545 |       - |  19,368 B |
|             LinqFasterer |    .NET 6 PGO | 1000 |   100 |  8.644 μs | 0.1459 μs | 0.1365 μs |  5.24x slower |   0.09x | 39.2151 |       - |  83,304 B |
|                   LinqAF |    .NET 6 PGO | 1000 |   100 |  9.520 μs | 0.0486 μs | 0.0454 μs |  5.76x slower |   0.03x |       - |       - |         - |
|            LinqOptimizer |    .NET 6 PGO | 1000 |   100 | 21.359 μs | 0.3138 μs | 0.2935 μs | 12.95x slower |   0.17x | 49.9878 | 16.6626 | 137,863 B |
|                  Streams |    .NET 6 PGO | 1000 |   100 | 11.718 μs | 0.0711 μs | 0.0630 μs |  7.09x slower |   0.04x |  0.5493 |       - |   1,176 B |
|               StructLinq |    .NET 6 PGO | 1000 |   100 |  1.908 μs | 0.0032 μs | 0.0025 μs |  1.15x slower |   0.00x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |  1.618 μs | 0.0028 μs | 0.0025 μs |  1.02x faster |   0.00x |       - |       - |         - |
|                Hyperlinq |    .NET 6 PGO | 1000 |   100 |  1.921 μs | 0.0024 μs | 0.0019 μs |  1.16x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO | 1000 |   100 |  1.726 μs | 0.0040 μs | 0.0038 μs |  1.04x slower |   0.00x |       - |       - |         - |
|                          |               |      |       |           |           |           |               |         |         |         |           |
|                  ForLoop | .NET Core 3.1 | 1000 |   100 |  1.941 μs | 0.0064 μs | 0.0060 μs |      baseline |         |       - |       - |         - |
|                     Linq | .NET Core 3.1 | 1000 |   100 |  2.975 μs | 0.0135 μs | 0.0119 μs |  1.53x slower |   0.01x |  0.1526 |       - |     320 B |
|               LinqFaster | .NET Core 3.1 | 1000 |   100 |  4.996 μs | 0.0393 μs | 0.0368 μs |  2.57x slower |   0.02x |  9.2545 |       - |  19,368 B |
|             LinqFasterer | .NET Core 3.1 | 1000 |   100 |  8.385 μs | 0.1452 μs | 0.1287 μs |  4.32x slower |   0.06x | 38.7573 |       - |  83,304 B |
|                   LinqAF | .NET Core 3.1 | 1000 |   100 | 20.677 μs | 0.0845 μs | 0.0790 μs | 10.65x slower |   0.06x |       - |       - |         - |
|            LinqOptimizer | .NET Core 3.1 | 1000 |   100 | 25.500 μs | 0.4524 μs | 0.4010 μs | 13.14x slower |   0.21x | 60.5469 | 15.1367 | 137,900 B |
|                  Streams | .NET Core 3.1 | 1000 |   100 | 13.949 μs | 0.1422 μs | 0.1330 μs |  7.19x slower |   0.08x |  0.5493 |       - |   1,176 B |
|               StructLinq | .NET Core 3.1 | 1000 |   100 |  2.228 μs | 0.0092 μs | 0.0081 μs |  1.15x slower |   0.01x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |  1.992 μs | 0.0030 μs | 0.0023 μs |  1.03x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | .NET Core 3.1 | 1000 |   100 |  2.272 μs | 0.0052 μs | 0.0046 μs |  1.17x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 | 1000 |   100 |  2.018 μs | 0.0043 μs | 0.0038 μs |  1.04x slower |   0.00x |       - |       - |         - |
