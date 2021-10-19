## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                       Method |           Job | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |-------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |        .NET 6 |     0 |   100 | 103.30 ns | 0.771 ns | 0.683 ns |     baseline |         | 0.2027 |     424 B |
|                         Linq |        .NET 6 |     0 |   100 | 274.37 ns | 2.937 ns | 2.747 ns | 2.65x slower |   0.03x | 0.2446 |     512 B |
|                   LinqFaster |        .NET 6 |     0 |   100 | 290.55 ns | 0.844 ns | 0.659 ns | 2.81x slower |   0.02x | 0.4053 |     848 B |
|              LinqFaster_SIMD |        .NET 6 |     0 |   100 | 123.65 ns | 1.110 ns | 1.038 ns | 1.20x slower |   0.02x | 0.4053 |     848 B |
|                       LinqAF |        .NET 6 |     0 |   100 | 604.04 ns | 4.651 ns | 4.351 ns | 5.85x slower |   0.05x | 0.7534 |   1,576 B |
|                   StructLinq |        .NET 6 |     0 |   100 | 234.21 ns | 1.334 ns | 1.114 ns | 2.27x slower |   0.02x | 0.2294 |     480 B |
|     StructLinq_ValueDelegate |        .NET 6 |     0 |   100 | 103.36 ns | 0.514 ns | 0.429 ns | 1.00x slower |   0.01x | 0.2027 |     424 B |
|                    Hyperlinq |        .NET 6 |     0 |   100 | 290.46 ns | 3.150 ns | 2.946 ns | 2.81x slower |   0.04x | 0.2027 |     424 B |
|      Hyperlinq_ValueDelegate |        .NET 6 |     0 |   100 | 131.55 ns | 1.321 ns | 1.171 ns | 1.27x slower |   0.01x | 0.2027 |     424 B |
|               Hyperlinq_SIMD |        .NET 6 |     0 |   100 |  94.14 ns | 0.598 ns | 0.530 ns | 1.10x faster |   0.01x | 0.2027 |     424 B |
| Hyperlinq_ValueDelegate_SIMD |        .NET 6 |     0 |   100 |  63.78 ns | 0.624 ns | 0.583 ns | 1.62x faster |   0.02x | 0.2027 |     424 B |
|                              |               |       |       |           |          |          |              |         |        |           |
|                      ForLoop |    .NET 6 PGO |     0 |   100 | 102.59 ns | 0.785 ns | 0.696 ns |     baseline |         | 0.2027 |     424 B |
|                         Linq |    .NET 6 PGO |     0 |   100 | 301.52 ns | 2.310 ns | 2.161 ns | 2.94x slower |   0.03x | 0.2446 |     512 B |
|                   LinqFaster |    .NET 6 PGO |     0 |   100 | 293.81 ns | 2.205 ns | 1.954 ns | 2.86x slower |   0.02x | 0.4053 |     848 B |
|              LinqFaster_SIMD |    .NET 6 PGO |     0 |   100 | 130.64 ns | 1.320 ns | 1.234 ns | 1.27x slower |   0.01x | 0.4053 |     848 B |
|                       LinqAF |    .NET 6 PGO |     0 |   100 | 572.04 ns | 6.645 ns | 5.891 ns | 5.58x slower |   0.07x | 0.7534 |   1,576 B |
|                   StructLinq |    .NET 6 PGO |     0 |   100 | 230.79 ns | 1.791 ns | 1.675 ns | 2.25x slower |   0.01x | 0.2294 |     480 B |
|     StructLinq_ValueDelegate |    .NET 6 PGO |     0 |   100 | 107.72 ns | 0.579 ns | 0.541 ns | 1.05x slower |   0.01x | 0.2027 |     424 B |
|                    Hyperlinq |    .NET 6 PGO |     0 |   100 | 281.71 ns | 2.092 ns | 1.957 ns | 2.74x slower |   0.03x | 0.2027 |     424 B |
|      Hyperlinq_ValueDelegate |    .NET 6 PGO |     0 |   100 | 133.88 ns | 1.074 ns | 1.005 ns | 1.31x slower |   0.01x | 0.2027 |     424 B |
|               Hyperlinq_SIMD |    .NET 6 PGO |     0 |   100 |  94.89 ns | 1.015 ns | 0.950 ns | 1.08x faster |   0.01x | 0.2027 |     424 B |
| Hyperlinq_ValueDelegate_SIMD |    .NET 6 PGO |     0 |   100 |  64.72 ns | 0.620 ns | 0.580 ns | 1.59x faster |   0.02x | 0.2027 |     424 B |
|                              |               |       |       |           |          |          |              |         |        |           |
|                      ForLoop | .NET Core 3.1 |     0 |   100 |  99.98 ns | 0.962 ns | 0.900 ns |     baseline |         | 0.2027 |     424 B |
|                         Linq | .NET Core 3.1 |     0 |   100 | 280.76 ns | 1.425 ns | 1.113 ns | 2.81x slower |   0.03x | 0.2446 |     512 B |
|                   LinqFaster | .NET Core 3.1 |     0 |   100 | 325.21 ns | 1.905 ns | 1.689 ns | 3.25x slower |   0.04x | 0.4053 |     848 B |
|              LinqFaster_SIMD | .NET Core 3.1 |     0 |   100 | 126.41 ns | 1.519 ns | 1.421 ns | 1.26x slower |   0.02x | 0.4053 |     848 B |
|                       LinqAF | .NET Core 3.1 |     0 |   100 | 930.33 ns | 5.918 ns | 5.246 ns | 9.30x slower |   0.12x | 0.7534 |   1,576 B |
|                   StructLinq | .NET Core 3.1 |     0 |   100 | 343.48 ns | 4.269 ns | 3.993 ns | 3.44x slower |   0.05x | 0.2294 |     480 B |
|     StructLinq_ValueDelegate | .NET Core 3.1 |     0 |   100 | 118.60 ns | 0.941 ns | 0.786 ns | 1.19x slower |   0.01x | 0.2027 |     424 B |
|                    Hyperlinq | .NET Core 3.1 |     0 |   100 | 321.64 ns | 1.761 ns | 1.648 ns | 3.22x slower |   0.04x | 0.2027 |     424 B |
|      Hyperlinq_ValueDelegate | .NET Core 3.1 |     0 |   100 | 243.21 ns | 0.486 ns | 0.406 ns | 2.43x slower |   0.02x | 0.2027 |     424 B |
|               Hyperlinq_SIMD | .NET Core 3.1 |     0 |   100 | 222.79 ns | 1.306 ns | 1.091 ns | 2.23x slower |   0.02x | 0.2027 |     424 B |
| Hyperlinq_ValueDelegate_SIMD | .NET Core 3.1 |     0 |   100 | 196.74 ns | 1.340 ns | 1.188 ns | 1.97x slower |   0.02x | 0.2027 |     424 B |
