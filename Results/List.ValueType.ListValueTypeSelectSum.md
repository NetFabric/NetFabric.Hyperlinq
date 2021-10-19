## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|                   Method |           Job | Count |        Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |------------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 |   150.92 ns |  0.387 ns |  0.362 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 |   366.45 ns |  2.372 ns |  2.103 ns | 2.43x slower |   0.02x |      - |         - |
|                     Linq |        .NET 6 |   100 | 1,041.60 ns |  5.457 ns |  4.837 ns | 6.90x slower |   0.03x | 0.0458 |      96 B |
|               LinqFaster |        .NET 6 |   100 |   381.39 ns |  0.616 ns |  0.546 ns | 2.53x slower |   0.01x |      - |         - |
|             LinqFasterer |        .NET 6 |   100 |   689.37 ns |  7.500 ns |  7.015 ns | 4.57x slower |   0.05x | 3.0670 |   6,424 B |
|                   LinqAF |        .NET 6 |   100 | 1,014.28 ns |  7.478 ns |  6.245 ns | 6.72x slower |   0.04x |      - |         - |
|            LinqOptimizer |        .NET 6 |   100 | 1,453.83 ns |  6.826 ns |  6.385 ns | 9.63x slower |   0.05x | 0.0572 |     120 B |
|                  Streams |        .NET 6 |   100 |   839.75 ns |  3.929 ns |  3.675 ns | 5.56x slower |   0.03x | 0.1717 |     360 B |
|               StructLinq |        .NET 6 |   100 |   226.73 ns |  0.981 ns |  0.870 ns | 1.50x slower |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |    92.82 ns |  0.212 ns |  0.198 ns | 1.63x faster |   0.01x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |   527.98 ns |  0.774 ns |  0.724 ns | 3.50x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   285.15 ns |  0.557 ns |  0.466 ns | 1.89x slower |   0.00x |      - |         - |
|                          |               |       |             |           |           |              |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |   165.80 ns |  0.134 ns |  0.104 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 |   423.33 ns |  2.545 ns |  2.125 ns | 2.55x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |   751.08 ns |  2.493 ns |  2.210 ns | 4.53x slower |   0.01x | 0.0458 |      96 B |
|               LinqFaster |    .NET 6 PGO |   100 |   404.68 ns |  0.586 ns |  0.519 ns | 2.44x slower |   0.00x |      - |         - |
|             LinqFasterer |    .NET 6 PGO |   100 |   705.51 ns |  8.363 ns |  7.414 ns | 4.26x slower |   0.05x | 3.0670 |   6,424 B |
|                   LinqAF |    .NET 6 PGO |   100 |   969.37 ns |  4.646 ns |  4.346 ns | 5.85x slower |   0.03x |      - |         - |
|            LinqOptimizer |    .NET 6 PGO |   100 | 1,407.34 ns |  5.992 ns |  5.312 ns | 8.49x slower |   0.03x | 0.0572 |     120 B |
|                  Streams |    .NET 6 PGO |   100 |   883.56 ns |  3.368 ns |  2.986 ns | 5.33x slower |   0.02x | 0.1717 |     360 B |
|               StructLinq |    .NET 6 PGO |   100 |   222.99 ns |  1.157 ns |  1.082 ns | 1.35x slower |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |    95.64 ns |  0.281 ns |  0.263 ns | 1.73x faster |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |   539.51 ns |  1.302 ns |  1.017 ns | 3.25x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   283.01 ns |  0.377 ns |  0.352 ns | 1.71x slower |   0.00x |      - |         - |
|                          |               |       |             |           |           |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |   217.09 ns |  0.627 ns |  0.586 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 |   474.75 ns |  1.721 ns |  1.525 ns | 2.19x slower |   0.01x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 | 1,030.65 ns |  6.813 ns |  5.689 ns | 4.75x slower |   0.02x | 0.0458 |      96 B |
|               LinqFaster | .NET Core 3.1 |   100 |   387.94 ns |  1.222 ns |  1.143 ns | 1.79x slower |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |   100 |   651.42 ns |  5.453 ns |  4.834 ns | 3.00x slower |   0.02x | 3.0670 |   6,424 B |
|                   LinqAF | .NET Core 3.1 |   100 | 1,759.80 ns |  5.992 ns |  5.605 ns | 8.11x slower |   0.03x |      - |         - |
|            LinqOptimizer | .NET Core 3.1 |   100 | 1,518.14 ns | 12.266 ns | 10.243 ns | 6.99x slower |   0.05x | 0.0725 |     152 B |
|                  Streams | .NET Core 3.1 |   100 |   871.41 ns |  3.888 ns |  3.636 ns | 4.01x slower |   0.02x | 0.1717 |     360 B |
|               StructLinq | .NET Core 3.1 |   100 |   224.99 ns |  0.743 ns |  0.695 ns | 1.04x slower |   0.00x | 0.0191 |      40 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |    99.68 ns |  0.316 ns |  0.280 ns | 2.18x faster |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |   607.63 ns |  1.476 ns |  1.309 ns | 2.80x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   311.93 ns |  1.178 ns |  0.983 ns | 1.44x slower |   0.01x |      - |         - |
