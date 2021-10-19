## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                   Method |           Job | Count |       Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |-----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |   100 |   587.2 ns |  2.22 ns |  2.08 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |        .NET 6 |   100 | 1,209.5 ns |  5.24 ns |  4.90 ns | 2.06x slower |   0.01x | 0.0458 |      96 B |
|                   LinqAF |        .NET 6 |   100 |   744.1 ns |  2.75 ns |  2.44 ns | 1.27x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |        .NET 6 |   100 | 2,644.4 ns | 22.17 ns | 18.52 ns | 4.51x slower |   0.03x | 4.2534 |   8,906 B |
|                  Streams |        .NET 6 |   100 | 2,259.3 ns | 32.58 ns | 30.47 ns | 3.85x slower |   0.06x | 0.2823 |     592 B |
|               StructLinq |        .NET 6 |   100 |   628.9 ns |  7.34 ns |  5.73 ns | 1.07x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   537.4 ns |  7.18 ns |  6.37 ns | 1.09x faster |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |        .NET 6 |   100 |   675.1 ns |  2.20 ns |  2.06 ns | 1.15x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |        .NET 6 |   100 |   506.4 ns |  1.67 ns |  1.48 ns | 1.16x faster |   0.01x | 0.0191 |      40 B |
|                          |               |       |            |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO |   100 |   275.3 ns |  1.57 ns |  1.46 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq |    .NET 6 PGO |   100 |   449.6 ns |  1.50 ns |  1.41 ns | 1.63x slower |   0.01x | 0.0458 |      96 B |
|                   LinqAF |    .NET 6 PGO |   100 |   396.4 ns |  1.47 ns |  1.30 ns | 1.44x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer |    .NET 6 PGO |   100 | 2,305.0 ns | 15.95 ns | 14.14 ns | 8.37x slower |   0.07x | 4.2534 |   8,906 B |
|                  Streams |    .NET 6 PGO |   100 | 1,515.0 ns |  7.97 ns |  7.06 ns | 5.50x slower |   0.03x | 0.2823 |     592 B |
|               StructLinq |    .NET 6 PGO |   100 |   338.3 ns |  2.55 ns |  2.26 ns | 1.23x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   312.8 ns |  1.10 ns |  1.03 ns | 1.14x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq |    .NET 6 PGO |   100 |   361.4 ns |  1.48 ns |  1.31 ns | 1.31x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |    .NET 6 PGO |   100 |   313.0 ns |  1.55 ns |  1.37 ns | 1.14x slower |   0.01x | 0.0191 |      40 B |
|                          |               |       |            |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |   100 |   508.5 ns |  2.91 ns |  2.58 ns |     baseline |         | 0.0191 |      40 B |
|                     Linq | .NET Core 3.1 |   100 | 1,153.9 ns |  5.33 ns |  4.72 ns | 2.27x slower |   0.01x | 0.0458 |      96 B |
|                   LinqAF | .NET Core 3.1 |   100 |   902.5 ns |  2.91 ns |  2.58 ns | 1.77x slower |   0.01x | 0.0191 |      40 B |
|            LinqOptimizer | .NET Core 3.1 |   100 | 2,614.3 ns | 23.66 ns | 22.13 ns | 5.14x slower |   0.04x | 4.2725 |   8,936 B |
|                  Streams | .NET Core 3.1 |   100 | 2,353.6 ns | 11.54 ns | 10.23 ns | 4.63x slower |   0.03x | 0.2823 |     592 B |
|               StructLinq | .NET Core 3.1 |   100 |   767.0 ns |  2.49 ns |  2.33 ns | 1.51x slower |   0.01x | 0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   613.6 ns |  3.78 ns |  3.53 ns | 1.21x slower |   0.01x | 0.0191 |      40 B |
|                Hyperlinq | .NET Core 3.1 |   100 |   680.7 ns |  2.31 ns |  2.16 ns | 1.34x slower |   0.01x | 0.0191 |      40 B |
|  Hyperlinq_ValueDelegate | .NET Core 3.1 |   100 |   661.8 ns |  2.04 ns |  1.71 ns | 1.30x slower |   0.01x | 0.0191 |      40 B |
