## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|                   Method |    Job |  Runtime | Count |       Mean |    Error |    StdDev |     Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |------- |--------- |------ |-----------:|---------:|----------:|-----------:|-------------:|--------:|-------:|----------:|------------:|
|              ForeachLoop | .NET 6 | .NET 6.0 |   100 |   815.3 ns |  8.56 ns |   7.14 ns |   815.9 ns |     baseline |         | 0.0992 |     208 B |             |
|                     Linq | .NET 6 | .NET 6.0 |   100 |   906.5 ns | 11.11 ns |   9.28 ns |   902.1 ns | 1.11x slower |   0.01x | 0.1602 |     336 B |  1.62x more |
|                   LinqAF | .NET 6 | .NET 6.0 |   100 | 1,841.0 ns | 53.17 ns | 155.94 ns | 1,747.1 ns | 2.23x slower |   0.19x | 1.2531 |    2624 B | 12.62x more |
|               StructLinq | .NET 6 | .NET 6.0 |   100 |   974.4 ns | 23.35 ns |  68.13 ns |   936.2 ns | 1.18x slower |   0.06x | 0.0305 |      64 B |  3.25x less |
| StructLinq_ValueDelegate | .NET 6 | .NET 6.0 |   100 |   952.1 ns |  6.84 ns |   6.07 ns |   949.6 ns | 1.17x slower |   0.01x | 0.0191 |      40 B |  5.20x less |
|                Hyperlinq | .NET 6 | .NET 6.0 |   100 |   999.4 ns |  9.86 ns |   7.70 ns |   998.5 ns | 1.22x slower |   0.01x | 0.0191 |      40 B |  5.20x less |
|                          |        |          |       |            |          |           |            |              |         |        |           |             |
|              ForeachLoop | .NET 8 | .NET 8.0 |   100 |   616.1 ns | 12.31 ns |  17.66 ns |   609.4 ns |     baseline |         | 0.0992 |     208 B |             |
|                     Linq | .NET 8 | .NET 8.0 |   100 |   730.7 ns |  6.40 ns |   5.00 ns |   729.4 ns | 1.19x slower |   0.03x | 0.1602 |     336 B |  1.62x more |
|                   LinqAF | .NET 8 | .NET 8.0 |   100 | 1,172.2 ns | 18.89 ns |  29.97 ns | 1,176.3 ns | 1.90x slower |   0.08x | 1.2531 |    2624 B | 12.62x more |
|               StructLinq | .NET 8 | .NET 8.0 |   100 |   685.5 ns | 13.16 ns |  24.07 ns |   674.2 ns | 1.12x slower |   0.06x | 0.0305 |      64 B |  3.25x less |
| StructLinq_ValueDelegate | .NET 8 | .NET 8.0 |   100 |   582.7 ns | 11.60 ns |  31.95 ns |   566.2 ns | 1.05x faster |   0.06x | 0.0191 |      40 B |  5.20x less |
|                Hyperlinq | .NET 8 | .NET 8.0 |   100 |   678.4 ns | 11.90 ns |  16.68 ns |   670.8 ns | 1.10x slower |   0.03x | 0.0191 |      40 B |  5.20x less |
