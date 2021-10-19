## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|     Method |           Job | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------- |-------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|    ForLoop |        .NET 6 |     0 |   100 | 331.22 ns | 1.719 ns | 1.436 ns |     baseline |         | 0.5660 |   1,184 B |
|       Linq |        .NET 6 |     0 |   100 | 202.86 ns | 0.891 ns | 0.834 ns | 1.63x faster |   0.01x | 0.2370 |     496 B |
| LinqFaster |        .NET 6 |     0 |   100 | 144.82 ns | 1.422 ns | 1.260 ns | 2.29x faster |   0.02x | 0.4208 |     880 B |
|     LinqAF |        .NET 6 |     0 |   100 | 335.06 ns | 2.809 ns | 2.490 ns | 1.01x slower |   0.01x | 0.2179 |     456 B |
| StructLinq |        .NET 6 |     0 |   100 | 103.04 ns | 0.729 ns | 0.682 ns | 3.21x faster |   0.03x | 0.2180 |     456 B |
|  Hyperlinq |        .NET 6 |     0 |   100 |  61.54 ns | 0.593 ns | 0.526 ns | 5.39x faster |   0.06x | 0.2180 |     456 B |
|            |               |       |       |           |          |          |              |         |        |           |
|    ForLoop |    .NET 6 PGO |     0 |   100 | 321.91 ns | 3.856 ns | 3.418 ns |     baseline |         | 0.5660 |   1,184 B |
|       Linq |    .NET 6 PGO |     0 |   100 | 211.71 ns | 1.004 ns | 0.939 ns | 1.52x faster |   0.02x | 0.2370 |     496 B |
| LinqFaster |    .NET 6 PGO |     0 |   100 | 147.72 ns | 1.252 ns | 1.171 ns | 2.18x faster |   0.03x | 0.4208 |     880 B |
|     LinqAF |    .NET 6 PGO |     0 |   100 | 287.32 ns | 2.461 ns | 2.182 ns | 1.12x faster |   0.01x | 0.2179 |     456 B |
| StructLinq |    .NET 6 PGO |     0 |   100 | 102.85 ns | 0.534 ns | 0.474 ns | 3.13x faster |   0.03x | 0.2180 |     456 B |
|  Hyperlinq |    .NET 6 PGO |     0 |   100 |  61.42 ns | 0.897 ns | 0.796 ns | 5.24x faster |   0.10x | 0.2180 |     456 B |
|            |               |       |       |           |          |          |              |         |        |           |
|    ForLoop | .NET Core 3.1 |     0 |   100 | 359.26 ns | 2.508 ns | 2.223 ns |     baseline |         | 0.5660 |   1,184 B |
|       Linq | .NET Core 3.1 |     0 |   100 | 204.32 ns | 1.198 ns | 1.121 ns | 1.76x faster |   0.02x | 0.2370 |     496 B |
| LinqFaster | .NET Core 3.1 |     0 |   100 | 154.95 ns | 1.399 ns | 1.309 ns | 2.32x faster |   0.02x | 0.4208 |     880 B |
|     LinqAF | .NET Core 3.1 |     0 |   100 | 384.89 ns | 2.406 ns | 2.133 ns | 1.07x slower |   0.01x | 0.2179 |     456 B |
| StructLinq | .NET Core 3.1 |     0 |   100 | 102.69 ns | 0.623 ns | 0.552 ns | 3.50x faster |   0.03x | 0.2180 |     456 B |
|  Hyperlinq | .NET Core 3.1 |     0 |   100 |  60.11 ns | 0.612 ns | 0.542 ns | 5.98x faster |   0.07x | 0.2180 |     456 B |
