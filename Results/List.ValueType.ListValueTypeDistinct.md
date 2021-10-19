## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|                   Method |           Job | Duplicates | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |-------------- |----------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |          4 |   100 | 15.091 μs | 0.1547 μs | 0.1371 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |        .NET 6 |          4 |   100 | 15.941 μs | 0.0935 μs | 0.0730 μs | 1.06x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq |        .NET 6 |          4 |   100 | 17.733 μs | 0.0859 μs | 0.0717 μs | 1.18x slower |   0.01x | 12.8174 |  26,912 B |
|               LinqFaster |        .NET 6 |          4 |   100 |  2.774 μs | 0.0069 μs | 0.0065 μs | 5.44x faster |   0.05x |  0.0114 |      24 B |
|             LinqFasterer |        .NET 6 |          4 |   100 | 18.354 μs | 0.0602 μs | 0.0470 μs | 1.22x slower |   0.01x | 34.8816 |  73,168 B |
|                   LinqAF |        .NET 6 |          4 |   100 | 41.373 μs | 0.2384 μs | 0.2114 μs | 2.74x slower |   0.03x | 21.8506 |  45,736 B |
|               StructLinq |        .NET 6 |          4 |   100 | 16.369 μs | 0.0558 μs | 0.0466 μs | 1.09x slower |   0.01x |  0.0305 |      66 B |
| StructLinq_ValueDelegate |        .NET 6 |          4 |   100 |  5.085 μs | 0.0204 μs | 0.0191 μs | 2.97x faster |   0.03x |       - |         - |
|                Hyperlinq |        .NET 6 |          4 |   100 | 14.714 μs | 0.0994 μs | 0.0881 μs | 1.03x faster |   0.01x |       - |         - |
|                          |               |            |       |           |           |           |              |         |         |           |
|                  ForLoop |    .NET 6 PGO |          4 |   100 | 12.763 μs | 0.0682 μs | 0.0637 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |    .NET 6 PGO |          4 |   100 | 13.810 μs | 0.1025 μs | 0.0958 μs | 1.08x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq |    .NET 6 PGO |          4 |   100 | 14.552 μs | 0.0724 μs | 0.0605 μs | 1.14x slower |   0.01x | 12.8174 |  26,912 B |
|               LinqFaster |    .NET 6 PGO |          4 |   100 |  2.698 μs | 0.0080 μs | 0.0071 μs | 4.73x faster |   0.03x |  0.0114 |      24 B |
|             LinqFasterer |    .NET 6 PGO |          4 |   100 | 17.232 μs | 0.2183 μs | 0.2042 μs | 1.35x slower |   0.02x | 34.8816 |  73,168 B |
|                   LinqAF |    .NET 6 PGO |          4 |   100 | 44.642 μs | 0.4022 μs | 0.3566 μs | 3.50x slower |   0.04x | 20.6299 |  43,177 B |
|               StructLinq |    .NET 6 PGO |          4 |   100 | 12.862 μs | 0.0499 μs | 0.0466 μs | 1.01x slower |   0.01x |  0.0305 |      65 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |          4 |   100 |  5.072 μs | 0.0330 μs | 0.0293 μs | 2.52x faster |   0.02x |       - |         - |
|                Hyperlinq |    .NET 6 PGO |          4 |   100 | 11.610 μs | 0.2034 μs | 0.1903 μs | 1.10x faster |   0.02x |       - |         - |
|                          |               |            |       |           |           |           |              |         |         |           |
|                  ForLoop | .NET Core 3.1 |          4 |   100 | 18.389 μs | 0.0967 μs | 0.0857 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop | .NET Core 3.1 |          4 |   100 | 19.423 μs | 0.1370 μs | 0.1144 μs | 1.06x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq | .NET Core 3.1 |          4 |   100 | 22.278 μs | 0.1076 μs | 0.0954 μs | 1.21x slower |   0.01x |  9.0637 |  18,992 B |
|               LinqFaster | .NET Core 3.1 |          4 |   100 |  3.224 μs | 0.0121 μs | 0.0114 μs | 5.70x faster |   0.04x |  0.0114 |      24 B |
|             LinqFasterer | .NET Core 3.1 |          4 |   100 | 22.510 μs | 0.1957 μs | 0.1830 μs | 1.22x slower |   0.01x | 34.8816 |  73,168 B |
|                   LinqAF | .NET Core 3.1 |          4 |   100 | 51.521 μs | 0.2948 μs | 0.2613 μs | 2.80x slower |   0.02x | 20.9351 |  43,888 B |
|               StructLinq | .NET Core 3.1 |          4 |   100 | 18.051 μs | 0.0619 μs | 0.0549 μs | 1.02x faster |   0.01x |  0.0305 |      66 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |          4 |   100 |  5.322 μs | 0.0693 μs | 0.0615 μs | 3.46x faster |   0.05x |       - |         - |
|                Hyperlinq | .NET Core 3.1 |          4 |   100 | 15.436 μs | 0.0660 μs | 0.0585 μs | 1.19x faster |   0.01x |       - |       1 B |
