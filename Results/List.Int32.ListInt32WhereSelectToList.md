## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-preview.5.23303.2
  [Host] : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 6 : .NET 6.0.18 (6.0.1823.26907), X64 RyuJIT AVX2
  .NET 8 : .NET 8.0.0 (8.0.23.28008), X64 RyuJIT AVX2


```
|                   Method |    Job |  Runtime | Count |       Mean |    Error |   StdDev |     Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|---------:|---------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
|                  ForLoop | .NET 6 | .NET 6.0 |   100 |   263.8 ns |  2.14 ns |  1.79 ns |   263.8 ns |     baseline |         | 0.3095 |     648 B |             |
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   288.7 ns |  5.05 ns | 10.55 ns |   284.0 ns | 1.08x slower |   0.03x | 0.3095 |     648 B |  1.00x more |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   514.8 ns |  4.87 ns |  4.56 ns |   514.3 ns | 1.95x slower |   0.02x | 0.3824 |     800 B |  1.23x more |
|               LinqFaster | .NET 6 | .NET 6.0 |   100 |   493.6 ns |  7.07 ns |  6.62 ns |   492.2 ns | 1.87x slower |   0.03x | 0.4396 |     920 B |  1.42x more |
|             LinqFasterer | .NET 6 | .NET 6.0 |   100 |   505.0 ns |  5.24 ns |  4.38 ns |   504.7 ns | 1.91x slower |   0.03x | 0.5617 |    1176 B |  1.81x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 1,112.5 ns | 17.50 ns | 14.61 ns | 1,106.4 ns | 4.22x slower |   0.07x | 0.3090 |     648 B |  1.00x more |
|            LinqOptimizer | .NET 6 | .NET 6.0 |   100 | 1,989.9 ns | 21.43 ns | 16.73 ns | 1,989.4 ns | 7.55x slower |   0.08x | 4.2801 |    8962 B | 13.83x more |
|                  Streams | .NET 6 | .NET 6.0 |   100 | 1,291.4 ns | 15.90 ns | 20.11 ns | 1,286.7 ns | 4.91x slower |   0.09x | 0.5684 |    1192 B |  1.84x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   535.8 ns |  9.83 ns |  8.21 ns |   534.2 ns | 2.03x slower |   0.04x | 0.1755 |     368 B |  1.76x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   309.7 ns |  3.36 ns |  2.81 ns |   309.1 ns | 1.17x slower |   0.01x | 0.1297 |     272 B |  2.38x less |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   614.7 ns |  6.93 ns |  9.49 ns |   611.1 ns | 2.34x slower |   0.04x | 0.1297 |     272 B |  2.38x less |
|  Hyperlinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   385.3 ns |  4.45 ns |  4.37 ns |   384.1 ns | 1.46x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
|                  Faslinq | .NET 6 | .NET 6.0 |   100 |   475.1 ns |  4.64 ns |  4.56 ns |   473.8 ns | 1.80x slower |   0.02x | 0.3090 |     648 B |  1.00x more |
|                          |        |          |       |            |          |          |            |              |         |        |           |             |
|                  ForLoop | .NET 8 | .NET 8.0 |   100 |   241.6 ns |  2.18 ns |  1.82 ns |   241.0 ns |     baseline |         | 0.3095 |     648 B |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   242.4 ns |  3.20 ns |  3.00 ns |   241.1 ns | 1.00x slower |   0.01x | 0.3095 |     648 B |  1.00x more |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   363.4 ns |  7.10 ns |  7.90 ns |   360.4 ns | 1.51x slower |   0.04x | 0.3824 |     800 B |  1.23x more |
|               LinqFaster | .NET 8 | .NET 8.0 |   100 |   297.8 ns |  4.46 ns |  3.72 ns |   296.6 ns | 1.23x slower |   0.02x | 0.4396 |     920 B |  1.42x more |
|             LinqFasterer | .NET 8 | .NET 8.0 |   100 |   272.9 ns |  1.96 ns |  1.74 ns |   272.4 ns | 1.13x slower |   0.01x | 0.5622 |    1176 B |  1.81x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 |   463.3 ns |  4.35 ns |  3.86 ns |   463.3 ns | 1.92x slower |   0.02x | 0.3090 |     648 B |  1.00x more |
|            LinqOptimizer | .NET 8 | .NET 8.0 |   100 | 1,801.9 ns | 19.56 ns | 15.27 ns | 1,799.0 ns | 7.46x slower |   0.09x | 4.2801 |    8961 B | 13.83x more |
|                  Streams | .NET 8 | .NET 8.0 |   100 | 1,216.7 ns | 34.26 ns | 98.31 ns | 1,162.8 ns | 4.97x slower |   0.28x | 0.5684 |    1192 B |  1.84x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   384.2 ns |  7.54 ns |  7.40 ns |   381.3 ns | 1.59x slower |   0.03x | 0.1760 |     368 B |  1.76x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   277.4 ns |  5.63 ns | 15.68 ns |   269.9 ns | 1.19x slower |   0.10x | 0.1297 |     272 B |  2.38x less |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   406.3 ns |  8.12 ns | 20.22 ns |   396.4 ns | 1.72x slower |   0.11x | 0.1297 |     272 B |  2.38x less |
|  Hyperlinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   319.8 ns |  4.08 ns |  3.41 ns |   318.3 ns | 1.32x slower |   0.02x | 0.1297 |     272 B |  2.38x less |
|                  Faslinq | .NET 8 | .NET 8.0 |   100 |   345.9 ns |  6.09 ns | 13.62 ns |   339.9 ns | 1.43x slower |   0.06x | 0.3095 |     648 B |  1.00x more |
