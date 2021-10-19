## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|          Method |           Job | Start | Count |      Mean |    Error |   StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|---------------- |-------------- |------ |------ |----------:|---------:|---------:|--------------:|--------:|-------:|----------:|
|         ForLoop |        .NET 6 |     0 |   100 |  36.50 ns | 0.193 ns | 0.180 ns |      baseline |         |      - |         - |
|            Linq |        .NET 6 |     0 |   100 | 478.87 ns | 4.103 ns | 3.838 ns | 13.12x slower |   0.13x | 0.0191 |      40 B |
|      LinqFaster |        .NET 6 |     0 |   100 | 129.37 ns | 0.965 ns | 0.903 ns |  3.54x slower |   0.02x | 0.2027 |     424 B |
| LinqFaster_SIMD |        .NET 6 |     0 |   100 |  92.25 ns | 0.684 ns | 0.640 ns |  2.53x slower |   0.02x | 0.2027 |     424 B |
|          LinqAF |        .NET 6 |     0 |   100 | 175.20 ns | 0.476 ns | 0.422 ns |  4.80x slower |   0.03x |      - |         - |
|      StructLinq |        .NET 6 |     0 |   100 |  36.82 ns | 0.125 ns | 0.111 ns |  1.01x slower |   0.01x |      - |         - |
|       Hyperlinq |        .NET 6 |     0 |   100 |  45.45 ns | 0.230 ns | 0.215 ns |  1.25x slower |   0.01x |      - |         - |
|                 |               |       |       |           |          |          |               |         |        |           |
|         ForLoop |    .NET 6 PGO |     0 |   100 |  39.91 ns | 0.287 ns | 0.254 ns |      baseline |         |      - |         - |
|            Linq |    .NET 6 PGO |     0 |   100 | 220.54 ns | 0.717 ns | 0.671 ns |  5.53x slower |   0.05x | 0.0191 |      40 B |
|      LinqFaster |    .NET 6 PGO |     0 |   100 | 129.93 ns | 0.361 ns | 0.281 ns |  3.26x slower |   0.02x | 0.2027 |     424 B |
| LinqFaster_SIMD |    .NET 6 PGO |     0 |   100 |  93.43 ns | 0.592 ns | 0.525 ns |  2.34x slower |   0.02x | 0.2027 |     424 B |
|          LinqAF |    .NET 6 PGO |     0 |   100 | 179.55 ns | 0.366 ns | 0.343 ns |  4.50x slower |   0.03x |      - |         - |
|      StructLinq |    .NET 6 PGO |     0 |   100 |  40.28 ns | 0.243 ns | 0.215 ns |  1.01x slower |   0.01x |      - |         - |
|       Hyperlinq |    .NET 6 PGO |     0 |   100 |  47.01 ns | 0.160 ns | 0.134 ns |  1.18x slower |   0.01x |      - |         - |
|                 |               |       |       |           |          |          |               |         |        |           |
|         ForLoop | .NET Core 3.1 |     0 |   100 |  36.76 ns | 0.207 ns | 0.184 ns |      baseline |         |      - |         - |
|            Linq | .NET Core 3.1 |     0 |   100 | 542.45 ns | 2.659 ns | 2.487 ns | 14.76x slower |   0.05x | 0.0191 |      40 B |
|      LinqFaster | .NET Core 3.1 |     0 |   100 | 126.24 ns | 1.113 ns | 1.041 ns |  3.43x slower |   0.03x | 0.2027 |     424 B |
| LinqFaster_SIMD | .NET Core 3.1 |     0 |   100 |  90.15 ns | 0.721 ns | 0.675 ns |  2.45x slower |   0.03x | 0.2027 |     424 B |
|          LinqAF | .NET Core 3.1 |     0 |   100 | 201.08 ns | 0.565 ns | 0.501 ns |  5.47x slower |   0.03x |      - |         - |
|      StructLinq | .NET Core 3.1 |     0 |   100 |  44.63 ns | 0.108 ns | 0.095 ns |  1.21x slower |   0.00x |      - |         - |
|       Hyperlinq | .NET Core 3.1 |     0 |   100 | 187.05 ns | 0.239 ns | 0.224 ns |  5.09x slower |   0.03x |      - |         - |
