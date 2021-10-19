## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|          Method |           Job | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|---------------- |-------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|         ForLoop |        .NET 6 |     0 |   100 |  93.37 ns | 0.613 ns | 0.544 ns |     baseline |         | 0.2027 |     424 B |
|            Linq |        .NET 6 |     0 |   100 |  98.96 ns | 0.603 ns | 0.534 ns | 1.06x slower |   0.01x | 0.2218 |     464 B |
|      LinqFaster |        .NET 6 |     0 |   100 |  79.76 ns | 0.615 ns | 0.545 ns | 1.17x faster |   0.01x | 0.2027 |     424 B |
| LinqFaster_SIMD |        .NET 6 |     0 |   100 |  43.81 ns | 0.305 ns | 0.285 ns | 2.13x faster |   0.01x | 0.2027 |     424 B |
|          LinqAF |        .NET 6 |     0 |   100 | 223.54 ns | 1.405 ns | 1.314 ns | 2.39x slower |   0.02x | 0.2027 |     424 B |
|      StructLinq |        .NET 6 |     0 |   100 |  91.20 ns | 0.530 ns | 0.470 ns | 1.02x faster |   0.01x | 0.2027 |     424 B |
|       Hyperlinq |        .NET 6 |     0 |   100 |  49.95 ns | 0.373 ns | 0.348 ns | 1.87x faster |   0.02x | 0.2027 |     424 B |
|                 |               |       |       |           |          |          |              |         |        |           |
|         ForLoop |    .NET 6 PGO |     0 |   100 |  94.17 ns | 0.651 ns | 0.577 ns |     baseline |         | 0.2027 |     424 B |
|            Linq |    .NET 6 PGO |     0 |   100 |  97.09 ns | 0.877 ns | 0.821 ns | 1.03x slower |   0.01x | 0.2218 |     464 B |
|      LinqFaster |    .NET 6 PGO |     0 |   100 |  81.63 ns | 0.676 ns | 0.632 ns | 1.15x faster |   0.01x | 0.2027 |     424 B |
| LinqFaster_SIMD |    .NET 6 PGO |     0 |   100 |  45.31 ns | 0.392 ns | 0.347 ns | 2.08x faster |   0.02x | 0.2027 |     424 B |
|          LinqAF |    .NET 6 PGO |     0 |   100 | 228.25 ns | 0.783 ns | 0.732 ns | 2.42x slower |   0.02x | 0.2027 |     424 B |
|      StructLinq |    .NET 6 PGO |     0 |   100 |  93.83 ns | 0.566 ns | 0.529 ns | 1.00x faster |   0.01x | 0.2027 |     424 B |
|       Hyperlinq |    .NET 6 PGO |     0 |   100 |  50.80 ns | 0.288 ns | 0.240 ns | 1.85x faster |   0.02x | 0.2027 |     424 B |
|                 |               |       |       |           |          |          |              |         |        |           |
|         ForLoop | .NET Core 3.1 |     0 |   100 |  88.69 ns | 0.971 ns | 0.908 ns |     baseline |         | 0.2027 |     424 B |
|            Linq | .NET Core 3.1 |     0 |   100 | 112.54 ns | 0.953 ns | 0.845 ns | 1.27x slower |   0.02x | 0.2218 |     464 B |
|      LinqFaster | .NET Core 3.1 |     0 |   100 |  91.46 ns | 0.567 ns | 0.474 ns | 1.03x slower |   0.01x | 0.2027 |     424 B |
| LinqFaster_SIMD | .NET Core 3.1 |     0 |   100 |  42.39 ns | 0.682 ns | 0.638 ns | 2.09x faster |   0.04x | 0.2027 |     424 B |
|          LinqAF | .NET Core 3.1 |     0 |   100 | 264.70 ns | 2.440 ns | 2.163 ns | 2.99x slower |   0.04x | 0.2027 |     424 B |
|      StructLinq | .NET Core 3.1 |     0 |   100 |  91.55 ns | 0.621 ns | 0.581 ns | 1.03x slower |   0.01x | 0.2027 |     424 B |
|       Hyperlinq | .NET Core 3.1 |     0 |   100 |  48.63 ns | 0.964 ns | 0.901 ns | 1.82x faster |   0.04x | 0.2027 |     424 B |
