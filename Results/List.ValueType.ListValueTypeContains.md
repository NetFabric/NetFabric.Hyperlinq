## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
|                   Method |           Job | Count |       Mean |   Error |   StdDev |     Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |------ |-----------:|--------:|---------:|-----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |   100 |   796.2 ns | 1.53 ns |  1.43 ns |   795.7 ns |     baseline |         |      - |         - |
|              ForeachLoop |        .NET 6 |   100 | 1,195.1 ns | 3.29 ns |  3.08 ns | 1,193.9 ns | 1.50x slower |   0.00x |      - |         - |
|                     Linq |        .NET 6 |   100 |   244.5 ns | 4.34 ns |  4.06 ns |   243.2 ns | 3.26x faster |   0.06x |      - |         - |
|               LinqFaster |        .NET 6 |   100 |   255.2 ns | 6.80 ns | 19.71 ns |   244.4 ns | 3.09x faster |   0.21x |      - |         - |
|             LinqFasterer |        .NET 6 |   100 |   691.5 ns | 5.08 ns |  4.76 ns |   689.9 ns | 1.15x faster |   0.01x | 3.0670 |   6,424 B |
|                   LinqAF |        .NET 6 |   100 |   242.6 ns | 1.54 ns |  1.37 ns |   241.7 ns | 3.28x faster |   0.02x |      - |         - |
|               StructLinq |        .NET 6 |   100 |   585.2 ns | 2.75 ns |  2.30 ns |   584.3 ns | 1.36x faster |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |        .NET 6 |   100 |   601.0 ns | 0.99 ns |  0.77 ns |   600.9 ns | 1.32x faster |   0.00x |      - |         - |
|                Hyperlinq |        .NET 6 |   100 |   252.5 ns | 0.75 ns |  0.67 ns |   252.4 ns | 3.15x faster |   0.01x | 0.0153 |      32 B |
|                          |               |       |            |         |          |            |              |         |        |           |
|                  ForLoop |    .NET 6 PGO |   100 |   722.4 ns | 1.63 ns |  1.36 ns |   721.9 ns |     baseline |         |      - |         - |
|              ForeachLoop |    .NET 6 PGO |   100 | 1,171.4 ns | 4.03 ns |  3.58 ns | 1,170.3 ns | 1.62x slower |   0.01x |      - |         - |
|                     Linq |    .NET 6 PGO |   100 |   143.5 ns | 0.58 ns |  0.54 ns |   143.2 ns | 5.04x faster |   0.02x |      - |         - |
|               LinqFaster |    .NET 6 PGO |   100 |   142.6 ns | 0.62 ns |  0.55 ns |   142.3 ns | 5.07x faster |   0.02x |      - |         - |
|             LinqFasterer |    .NET 6 PGO |   100 |   605.9 ns | 7.01 ns |  6.56 ns |   603.0 ns | 1.19x faster |   0.01x | 3.0670 |   6,424 B |
|                   LinqAF |    .NET 6 PGO |   100 |   143.5 ns | 0.20 ns |  0.16 ns |   143.5 ns | 5.03x faster |   0.01x |      - |         - |
|               StructLinq |    .NET 6 PGO |   100 |   518.2 ns | 1.65 ns |  1.38 ns |   517.7 ns | 1.39x faster |   0.00x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |    .NET 6 PGO |   100 |   537.3 ns | 1.93 ns |  1.61 ns |   537.0 ns | 1.34x faster |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO |   100 |   148.2 ns | 0.34 ns |  0.26 ns |   148.2 ns | 4.87x faster |   0.01x | 0.0153 |      32 B |
|                          |               |       |            |         |          |            |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |   100 |   811.2 ns | 1.21 ns |  1.13 ns |   810.8 ns |     baseline |         |      - |         - |
|              ForeachLoop | .NET Core 3.1 |   100 | 1,357.7 ns | 2.08 ns |  1.94 ns | 1,357.1 ns | 1.67x slower |   0.00x |      - |         - |
|                     Linq | .NET Core 3.1 |   100 |   237.6 ns | 0.32 ns |  0.25 ns |   237.5 ns | 3.41x faster |   0.00x |      - |         - |
|               LinqFaster | .NET Core 3.1 |   100 |   239.4 ns | 0.94 ns |  0.84 ns |   239.2 ns | 3.39x faster |   0.01x |      - |         - |
|             LinqFasterer | .NET Core 3.1 |   100 |   670.0 ns | 6.26 ns |  5.55 ns |   669.4 ns | 1.21x faster |   0.01x | 3.0670 |   6,424 B |
|                   LinqAF | .NET Core 3.1 |   100 |   242.7 ns | 1.43 ns |  1.33 ns |   242.1 ns | 3.34x faster |   0.02x |      - |         - |
|               StructLinq | .NET Core 3.1 |   100 |   646.9 ns | 3.41 ns |  3.03 ns |   645.6 ns | 1.25x faster |   0.01x | 0.0191 |      40 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |   100 |   654.5 ns | 4.95 ns |  4.13 ns |   654.3 ns | 1.24x faster |   0.01x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |   100 |   256.7 ns | 1.69 ns |  1.58 ns |   256.0 ns | 3.16x faster |   0.02x | 0.0153 |      32 B |
